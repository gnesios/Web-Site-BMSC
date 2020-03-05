using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace BmscWebSite2_ImportedSolutions.BMSCConsultaCupones
{
    [ToolboxItemAttribute(false)]
    public partial class BMSCConsultaCupones : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public BMSCConsultaCupones()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void lnkConfirm_Click(object sender, EventArgs e)
        {
            string cuenta = this.StripTagsCharArray(txbCuenta.Text.Trim());
            string ci = this.StripTagsCharArray(txbDocumento.Text.Trim());

            if (ddlTipoDocumento.SelectedItem.Value == "1")
                ci = ci + ddlDepartamento.SelectedValue;

            string url = string.Format("/_layouts/BmscWebSite2_ImportedSolutions/ConsultaCuponesResultado.aspx?cuenta={0}&ci={1}",
                cuenta, ci);
            this.ShowBasicDialog(url, "cupones asignados");
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
            sb.AppendLine(@"width: 500, height: 600, allowMaximize: false, showClose: true,");
            sb.AppendLine(@"dialogReturnValueCallback: function (dialogResult, value) { window.top.location = window.top.location; }"); //to reload the parent page
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

        protected void ddlTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTipoDocumento.SelectedItem.Value == "1") //CI
            {
                ddlDepartamento.Visible = true;
                rfvDepartamento.Enabled = true;
            }
            else //OTRO DOCUMENTO
            {
                ddlDepartamento.Visible = false;
                rfvDepartamento.Enabled = false;
            }
        }
    }
}
