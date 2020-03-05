using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

using BMSC.Services.Simuladores.Contracts;

namespace BmscWebSite2_Simulators.Layouts.BmscWebSite2_Simulators
{
    public partial class CreditoResultado : UnsecuredLayoutsPageBase
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
                string plazo = Request.QueryString["plazo"];
                string cesantia = Request.QueryString["cesantia"];
                string monto = Request.QueryString["monto"];
                string tasaFija = Request.QueryString["tasaf"];
                string spread = Request.QueryString["spread"];
                string tasaVariable = Request.QueryString["tasav"];
                string tre = Request.QueryString["tre"];
                string nombre = Request.QueryString["nombre"];
                string valor = Request.QueryString["valor"];

                this.GetSimulatorResult(plazo, cesantia, monto, tasaFija, spread, tasaVariable, tre, nombre, valor);
            }
            catch (Exception ex)
            {
                ltrMessage.Text = ex.Message;
            }
        }

        private void GetSimulatorResult(string plazo, string cesantia, string monto, string tasaFija, string spread,
            string tasaVaraible, string tre, string nombre, string valorComercial)
        {
            SimuladoresServiceClient simServiceClient = new SimuladoresServiceClient();
            CuotaInfo[] cuotas = null;
            string cuotaMaxima = string.Empty;
            
            bool validData = true;
            System.Web.UI.WebControls.Literal resultMessage = new System.Web.UI.WebControls.Literal();

            if (nombre == "vs") //Vivienda social
            {
                SimulacionCreditoViviendaSocialPeticion simCreditoViviendaSocialPeticion = new SimulacionCreditoViviendaSocialPeticion();
                SimulacionCreditoViviendaSocialRespuesta simCreditoViviendaSocialRespuesta = new SimulacionCreditoViviendaSocialRespuesta();

                simCreditoViviendaSocialPeticion.Usuario = System.Configuration.ConfigurationManager.AppSettings["SimuladoresUsuario"];
                simCreditoViviendaSocialPeticion.Password = System.Configuration.ConfigurationManager.AppSettings["SimuladoresContrasena"];
                simCreditoViviendaSocialPeticion.Cesantia = cesantia;
                simCreditoViviendaSocialPeticion.IdPlazoTipoCredito = Int32.Parse(plazo);
                simCreditoViviendaSocialPeticion.Monto = Decimal.Parse(monto);
                simCreditoViviendaSocialPeticion.ValorComercial = Decimal.Parse(valorComercial);

                simCreditoViviendaSocialRespuesta = simServiceClient.SimularCreditoViviendaSocial(simCreditoViviendaSocialPeticion);
                
                cuotas = simCreditoViviendaSocialRespuesta.Cuotas;
                cuotaMaxima = simCreditoViviendaSocialRespuesta.CuotaMaxima.ToString("N");

                if (simCreditoViviendaSocialRespuesta.Resultado != 0)
                {
                    validData = false;
                    resultMessage.Text = "<p>" + simCreditoViviendaSocialRespuesta.MensajeResultado + "</p>";
                }
            }
            else //Todos los demas
            {
                SimulacionCreditoPeticion simCreditoPeticion = new SimulacionCreditoPeticion();
                SimulacionCreditoRespuesta simCreditoRespuesta = new SimulacionCreditoRespuesta();

                simCreditoPeticion.Usuario = System.Configuration.ConfigurationManager.AppSettings["SimuladoresUsuario"];
                simCreditoPeticion.Password = System.Configuration.ConfigurationManager.AppSettings["SimuladoresContrasena"];
                simCreditoPeticion.Cesantia = cesantia;
                simCreditoPeticion.IdPlazoTipoCredito = Int32.Parse(plazo);
                simCreditoPeticion.Monto = Decimal.Parse(monto);

                simCreditoRespuesta = simServiceClient.SimularCredito(simCreditoPeticion);

                cuotas = simCreditoRespuesta.Cuotas;
                cuotaMaxima = simCreditoRespuesta.CuotaMaxima.ToString("N");

                if (simCreditoRespuesta.Resultado != 0)
                { 
                    validData = false;
                    resultMessage.Text = "<p>" + simCreditoRespuesta.MensajeResultado + "</p>";
                }
            }

            if (validData)
            {
                ltrMessage.Text = string.Format(
                    "<p>Tasa fija: <b>{0} %</b></p>" +
                    "<p>Spread: <b>{1} %</b></p>" +
                    "<p>Tasa variable a partir del mes: <b>{2}</b></p>" +
                    "<p>Tre: <b>{3} %</b></p>" +
                    "<p>Cuota máxima: <b>{4} Bs</b></p>",
                    tasaFija, spread, tasaVaraible, tre, cuotaMaxima);

                grvCuotas.DataSource = cuotas;
                grvCuotas.DataBind();
            }
            else
            {
                this.Controls.Clear();
                this.Controls.Add(resultMessage);
            }
        }
    }
}
