using System;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;

using BMSC.Services.Simuladores.Contracts;

namespace BmscWebSite2_Simulators.CreditSimulator
{
    [ToolboxItemAttribute(false)]
    public partial class CreditSimulator : WebPart
    {
        const string CREDITO_VIVIENDA_SOCIAL = "Vivienda social";

        InformacionInicialRespuesta infoInicialRespuesta;

        #region Web part parameters
        private string spTipoCredito;
        [Personalizable(PersonalizationScope.Shared),
        WebBrowsable(true),
        WebDisplayName("Tipo de crédito"),
        WebDescription("Nombre del tipo de crédito a ser usado."),
        Category("Configuración")]
        public string SpTipoCredito
        {
            get { return spTipoCredito; }
            set { spTipoCredito = value; }
        }
        #endregion

        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public CreditSimulator()
        {
            SpTipoCredito = "TODOS";
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();

            try
            {
                this.GetSimulatorInitialValues();
            }
            catch (Exception ex)
            {
                this.Controls.Clear();
                System.Web.UI.WebControls.Literal errorMessage = new System.Web.UI.WebControls.Literal();
                errorMessage.Text = ex.Message;
                this.Controls.Add(errorMessage);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private void GetSimulatorInitialValues()
        {
            SimuladoresServiceClient simServiceClient = new SimuladoresServiceClient();
            InformacionInicialPeticion infoInicialPeticion = new InformacionInicialPeticion();

            infoInicialPeticion.Usuario = System.Configuration.ConfigurationManager.AppSettings["SimuladoresUsuario"];
            infoInicialPeticion.Password = System.Configuration.ConfigurationManager.AppSettings["SimuladoresContrasena"];

            infoInicialRespuesta = simServiceClient.ObtenerInformacionInicial(infoInicialPeticion);

            #region Populate web controls
            ddlTipoCredito.DataSource = this.GetListaTiposCredito(infoInicialRespuesta.ListaTiposCredito);
            ddlTipoCredito.DataTextField = "Nombre";
            ddlTipoCredito.DataValueField = "Nombre";//IdTipoCredito
            ddlTipoCredito.DataBind();

            if (SpTipoCredito.Trim() != CREDITO_VIVIENDA_SOCIAL)
            {
                txbValor.Visible = false;
                rfvValor.Enabled = false;
                rgvValor.Enabled = false;
            }
            #endregion

            #region Contact form
            string url = "";

            if (this.GetListaTiposCredito(infoInicialRespuesta.ListaTiposCredito).Length == 1)
            {
                string productName = this.GetListaTiposCredito(infoInicialRespuesta.ListaTiposCredito)[0].Nombre;
                url = string.Format("/Paginas/formularios/SimuladorPasivo.aspx?producto={0}&monto=0&plazo=0&interes=0", productName);
            }
            else
                ltrFormLink.Visible = false;

            ltrFormLink.Text = string.Format("<a class='link' href='#' onclick=\"OpenInDialog(500,500,true,true,true,'{0}','me interesa un crédito');\">estoy interesado en el producto</a>",
                url);
            #endregion
        }

        private TipoCreditoInfo[] GetListaTiposCredito(TipoCreditoInfo[] tipoCreditoInfo)
        {
            if (SpTipoCredito.ToUpper().Trim() == "TODOS")
                return tipoCreditoInfo;

            TipoCreditoInfo[] newListaTiposCredito = new TipoCreditoInfo[1];
            foreach (TipoCreditoInfo item in infoInicialRespuesta.ListaTiposCredito)
            {
                if (item.Nombre == SpTipoCredito.Trim())
                {
                    newListaTiposCredito[0] = item;

                    return newListaTiposCredito;
                }
            }

            return null;
        }

        protected void lnkConfirm_Click(object sender, EventArgs e)
        {
            //string tipo = Microsoft.SharePoint.Utilities.SPHttpUtility.HtmlEncode(ddlTipoCredito.SelectedItem.Text);
            string plazo = ddlPlazo.SelectedItem.Value;
            string cesantia = ddlCesantia.SelectedItem.Value;
            string monto = txbMonto.Text;
            string tasaFija = hdfTasaFija.Value;
            string spread = hdfSpread.Value;
            string tasaVariable = hdfTasaVariable.Value;
            string tre = hdfTre.Value;
            string nombre = "";
            string valor = "";

            if (SpTipoCredito.Trim() == CREDITO_VIVIENDA_SOCIAL)
            {
                nombre = "vs";
                valor = txbValor.Text;
            }

            string url = string.Format("/_layouts/BmscWebSite2_Simulators/CreditoResultado.aspx?plazo={0}&cesantia={1}&monto={2}&tasaf={3}&spread={4}&tasav={5}&tre={6}&nombre={7}&valor={8}",
                plazo, cesantia, monto, tasaFija, spread, tasaVariable, tre, nombre, valor);
            this.ShowBasicDialog(url, SpTipoCredito.ToLower());
        }

        private void ShowBasicDialog(string Url, string Title)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendLine(@"<script type=""text/ecmascript"" language=""ecmascript"">");
            sb.AppendLine(@"SP.SOD.executeFunc('sp.js', 'SP.ClientContext', openBasicServerDialog);");
            sb.AppendLine(@"function openBasicServerDialog() {");
            sb.AppendLine(@"  var options = {");
            sb.AppendLine(string.Format(@"url: '{0}',", Url));
            sb.AppendLine(string.Format(@"title: '{0}',", Title));
            sb.AppendLine(@"width: 900, height: 600, allowMaximize: true, showClose: true,");
            sb.AppendLine(@"dialogReturnValueCallback: function (dialogResult, value) { window.top.location = window.top.location; }"); //to reload the parent page
            sb.AppendLine(@"};");
            sb.AppendLine(@"SP.UI.ModalDialog.showModalDialog(options);");
            sb.AppendLine(@"}");
            sb.AppendLine(@"</script>");
            ltrScriptLoader.Text = sb.ToString();
        }

        protected void ddlTipoCredito_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (TipoCreditoInfo tipoCredito in infoInicialRespuesta.ListaTiposCredito)
	        {
                if (tipoCredito.Nombre == ddlTipoCredito.SelectedValue)
                {
                    ddlPlazo.DataSource = tipoCredito.PlazosDisponibles;
                    ddlPlazo.DataTextField = "PlazoEnMeses";
                    ddlPlazo.DataValueField = "IdPlazoTipoCredito";
                    ddlPlazo.DataBind();
                    ddlPlazo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("(Plazo, en meses)", "-1"));
                    ddlPlazo.SelectedIndex = 0;

                    break;
                }
	        }
        }

        protected void ddlPlazo_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (TipoCreditoInfo tipoCredito in infoInicialRespuesta.ListaTiposCredito)
            {
                if (tipoCredito.Nombre == ddlTipoCredito.SelectedValue)
                {
                    foreach (PlazoTipoCreditoInfo plazoDisponible in tipoCredito.PlazosDisponibles)
                    {
                        if (plazoDisponible.IdPlazoTipoCredito == Int32.Parse(ddlPlazo.SelectedItem.Value))
                        {
                            ddlCesantia.DataSource = plazoDisponible.Cesantias;
                            ddlCesantia.DataBind();
                            ddlCesantia.Items.Insert(0, new System.Web.UI.WebControls.ListItem("(Seguro de cesantía)", "-1"));
                            ddlCesantia.SelectedIndex = 0;

                            hdfTasaFija.Value = plazoDisponible.TasaFija.ToString("N");
                            hdfSpread.Value = plazoDisponible.SpreadFijo.ToString("N");
                            hdfTasaVariable.Value = plazoDisponible.TasaVariableAPartirDelMes.ToString();
                            hdfTre.Value = plazoDisponible.TRE.ToString("N");

                            break;
                        }
                    }

                    break;
                }
            }
        }
    }
}
