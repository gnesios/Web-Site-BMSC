using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

using BMSC.Services.Simuladores.Contracts;

namespace BmscWebSite2_Simulators.Layouts.BmscWebSite2_Simulators
{
    public partial class DPFResultado : UnsecuredLayoutsPageBase
    {
        protected override bool AllowAnonymousAccess
        {
            get
            {
                //return base.AllowAnonymousAccess;
                return true;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string moneda = Request.QueryString["moneda"];
                string monto = Request.QueryString["monto"];
                string plazo = Request.QueryString["plazo"];

                this.GetSimulatorResult(moneda, monto, plazo);
            }
            catch (Exception ex)
            {
                ltrMessage.Text = ex.Message;
            }
        }

        private void GetSimulatorResult(string moneda, string monto, string plazo)
        {
            SimuladoresServiceClient simServiceClient = new SimuladoresServiceClient();
            SimulacionDPFPeticion simDPFPeticion = new SimulacionDPFPeticion();
            SimulacionDPFRespuesta simDPFRespuesta = new SimulacionDPFRespuesta();

            simDPFPeticion.Usuario = System.Configuration.ConfigurationManager.AppSettings["SimuladoresUsuario"];
            simDPFPeticion.Password = System.Configuration.ConfigurationManager.AppSettings["SimuladoresContrasena"];
            simDPFPeticion.Moneda = Int32.Parse(moneda);
            simDPFPeticion.Monto = Decimal.Parse(monto);
            simDPFPeticion.PlazoEnDias = Int32.Parse(plazo);

            simDPFRespuesta = simServiceClient.SimularDPF(simDPFPeticion);

            decimal interes = simDPFRespuesta.Interes;
            decimal iva = simDPFRespuesta.Iva;
            decimal montoInteresConNit = simDPFRespuesta.MontoInteresConNit;
            decimal montoInteresSinNit = simDPFRespuesta.MontoInteresSinNit;
            decimal montoRetencionIva = simDPFRespuesta.MontoRetencionIva;

            ltrMessage.Text = this.GetFormatedResult(interes, iva, montoInteresConNit, montoInteresSinNit, montoRetencionIva);

            if (simDPFRespuesta.Resultado != 0)
            {
                System.Web.UI.WebControls.Literal resultMessage = new System.Web.UI.WebControls.Literal();
                resultMessage.Text = "<p>" + simDPFRespuesta.MensajeResultado + "</p>";

                this.Controls.Clear();
                this.Controls.Add(resultMessage);
            }
        }

        private string GetFormatedResult(decimal interes, decimal iva, decimal montoInteresConNit, decimal montoInteresSinNit, decimal montoRetencionIva)
        {
            string theResult = string.Format(
                "<p>Interés ganado: <b>{0}</b></p>" +
                "<p>IVA: <b>{1}</b></p>" +
                "<p>Monto interés con NIT: <b>{2}</b></p>" +
                "<p>Monto interés sin NIT: <b>{3}</b></p>" +
                "<p>Monto retención IVA: <b>{4}</b></p>",
                interes.ToString("N"), iva.ToString("N"), montoInteresConNit.ToString("N"), montoInteresSinNit.ToString("N"), montoRetencionIva.ToString("N"));

            return theResult;
        }
    }
}
