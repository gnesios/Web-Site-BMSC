using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

using BMSC.Services.Simuladores.Contracts;

namespace BmscWebSite2_Simulators.Layouts.BmscWebSite2_Simulators
{
    public partial class DPFIncrementalResultado : UnsecuredLayoutsPageBase
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

                this.GetSimulatorResult(moneda, monto);
            }
            catch (Exception ex)
            {
                ltrMessage.Text = ex.Message;
            }
        }

        private void GetSimulatorResult(string moneda, string monto)
        {
            SimuladoresServiceClient simServiceClient = new SimuladoresServiceClient();
            SimulacionDPFIncrementalPeticion simDPFIncrementalPeticion = new SimulacionDPFIncrementalPeticion();
            SimulacionDPFIncrementalRespuesta simDPFIncrementalRespuesta = new SimulacionDPFIncrementalRespuesta();

            simDPFIncrementalPeticion.Usuario = System.Configuration.ConfigurationManager.AppSettings["SimuladoresUsuario"];
            simDPFIncrementalPeticion.Password = System.Configuration.ConfigurationManager.AppSettings["SimuladoresContrasena"];
            simDPFIncrementalPeticion.Moneda = Int32.Parse(moneda);
            simDPFIncrementalPeticion.Monto = Decimal.Parse(monto);

            simDPFIncrementalRespuesta = simServiceClient.SimularDPFIncremental(simDPFIncrementalPeticion);

            EmisionDPFIncrementalInfo[] emisiones = simDPFIncrementalRespuesta.Emisiones;
            string totalInteresGanado = simDPFIncrementalRespuesta.TotalInteresGanado.ToString("N");

            ltrMessage.Text = this.GetFormatedResult(emisiones, totalInteresGanado);

            if (simDPFIncrementalRespuesta.Resultado != 0)
            {
                System.Web.UI.WebControls.Literal resultMessage = new System.Web.UI.WebControls.Literal();
                resultMessage.Text = "<p>" + simDPFIncrementalRespuesta.MensajeResultado + "</p>";

                this.Controls.Clear();
                this.Controls.Add(resultMessage);
            }
        }

        private string GetFormatedResult(EmisionDPFIncrementalInfo[] emisiones, string totalInteresGanado)
        {
            string theResult = "";

            string fmtTotalInteresGanado = string.Format("<p>Total interés ganado: <b>{0}</b></p>", totalInteresGanado);
            string fmtEmisiones = string.Format(
                "<table id='generictable'>" +
                "<thead>" +
                "<tr><th>número emisión</th><th>nombre emisión</th><th>interés ganado</th></tr>" +
                "</thead>" +
                "<tbody>"+
                "{0}" +
                "</tbody>",
                this.GetFormatedEmissionsRows(emisiones));

            theResult = fmtTotalInteresGanado + fmtEmisiones;

            return theResult;
        }

        private string GetFormatedEmissionsRows(EmisionDPFIncrementalInfo[] emisiones)
        {
            string theResult = "";

            foreach (EmisionDPFIncrementalInfo emision in emisiones)
            {
                theResult = theResult + string.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td></tr>",
                    emision.NumeroEmision, emision.NombreEmision, emision.InteresGanado.ToString("N"));
            }

            return theResult;
        }
    }
}
