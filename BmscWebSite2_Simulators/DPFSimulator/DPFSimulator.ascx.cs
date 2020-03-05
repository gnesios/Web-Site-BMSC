using System;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;

using BMSC.Services.Simuladores.Contracts;

namespace BmscWebSite2_Simulators.DPFSimulator
{
    [ToolboxItemAttribute(false)]
    public partial class DPFSimulator : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public DPFSimulator()
        {
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
                ltrMessage.Text = ex.Message;
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

            InformacionInicialRespuesta infoInicialRespuesta = simServiceClient.ObtenerInformacionInicial(infoInicialPeticion);

            #region Populate web controls
            ddlPlazo.DataSource = infoInicialRespuesta.ListaPlazosDPF;
            ddlPlazo.DataBind();
            #endregion

            #region Contact form
            string url = string.Format("/Paginas/formularios/SimuladorPasivo.aspx?producto=DPF");

            ltrFormLink.Text = string.Format("<a class='link' href='#' onclick=\"OpenInDialog(500,500,true,true,true,'{0}','me interesa un crédito');\">estoy interesado en el producto</a>",
                url);
            #endregion
        }

        protected void lnkConfirm_Click(object sender, EventArgs e)
        {
            string moneda = ddlMoneda.SelectedValue;
            string monto = this.StripTagsCharArray(txbMonto.Text);
            string plazo = ddlPlazo.SelectedValue;

            string url = string.Format("/_layouts/BmscWebSite2_Simulators/DPFResultado.aspx?moneda={0}&monto={1}&plazo={2}",
                moneda, monto, plazo);
            this.ShowBasicDialog(url, "dpf");
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
            sb.AppendLine(@"width: 500, height: 500, allowMaximize: false, showClose: true");
            sb.AppendLine(@"};");
            sb.AppendLine(@"SP.UI.ModalDialog.showModalDialog(options);");
            sb.AppendLine(@"}");
            sb.AppendLine(@"</script>");
            ltrScriptLoader.Text = sb.ToString();
        }

        //Remove html characters from a string
        private string StripTagsCharArray(string source)
        {
            char[] array = new char[source.Length];
            int arrayIndex = 0;
            bool inside = false;

            for (int i = 0; i < source.Length; i++)
            {
                char let = source[i];
                if (let == '<')
                {
                    inside = true;
                    continue;
                }
                if (let == '>')
                {
                    inside = false;
                    continue;
                }
                if (!inside)
                {
                    array[arrayIndex] = let;
                    arrayIndex++;
                }
            }

            string theResult = new string(array, 0, arrayIndex);

            if (theResult.Contains("&") || theResult.Contains("'"))
                theResult = System.Text.RegularExpressions.Regex.Replace(theResult, "[&#;/']", "");

            return theResult;
        }
    }
}
