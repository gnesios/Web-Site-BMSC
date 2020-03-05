using System;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;

namespace BmscWebSite2_Simulators.IncrementalDPFSimulator
{
    [ToolboxItemAttribute(false)]
    public partial class IncrementalDPFSimulator : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public IncrementalDPFSimulator()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();

            #region Contact form
            string url = string.Format("/Paginas/formularios/SimuladorPasivo.aspx?producto=DPF%20Incremental");

            ltrFormLink.Text = string.Format("<a class='link' href='#' onclick=\"OpenInDialog(500,500,true,true,true,'{0}','me interesa un crédito');\">estoy interesado en el producto</a>",
                url);
            #endregion
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void lnkConfirm_Click(object sender, EventArgs e)
        {
            Microsoft.SharePoint.SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                string moneda = ddlMoneda.SelectedValue;
                string monto = this.StripTagsCharArray(txbMonto.Text);

                string url = string.Format("/_layouts/BmscWebSite2_Simulators/DPFIncrementalResultado.aspx?moneda={0}&monto={1}",
                    moneda, monto);
                this.ShowBasicDialog(url, "dpf incremental");
            });
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
