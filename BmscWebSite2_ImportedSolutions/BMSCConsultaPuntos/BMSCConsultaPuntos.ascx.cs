using System;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;

namespace BmscWebSite2_ImportedSolutions.BMSCConsultaPuntos
{
    [ToolboxItemAttribute(false)]
    public partial class BMSCConsultaPuntos : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public BMSCConsultaPuntos()
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
            if (Validate())
            {
                string ci = this.StripTagsCharArray(txbDocumento.Text.Trim());

                string url = string.Format("/_layouts/BmscWebSite2_ImportedSolutions/ConsultaPuntosResultado.aspx?ci={0}", ci);
                this.ShowBasicDialog(url, "puntos acumulados");
                lblCaptcha.Text = "";
            }
            else
            {
                lblCaptcha.Text = "CAPTCHA incorrecto.";
                ltrScriptLoader.Text = "";
            }
            
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
            sb.AppendLine(@"width: 600, height: 500, allowMaximize: false, showClose: true");
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

        #region reCAPTCHA
        private bool Validate()
        {
            string Response = this.Page.Request["g-recaptcha-response"];//Getting Response String Appned to Post Method
            bool Valid = false;

            string SecretKey = System.Configuration.ConfigurationManager.AppSettings["SecretKey"];
            System.Net.HttpWebRequest req = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(
                string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}",
                SecretKey, Response));

            try
            {
                using (System.Net.WebResponse wResponse = req.GetResponse())
                {
                    using (System.IO.StreamReader readStream = new System.IO.StreamReader(wResponse.GetResponseStream()))
                    {
                        string jsonResponse = readStream.ReadToEnd();
                        System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
                        MyObject data = js.Deserialize<MyObject>(jsonResponse);// Deserialize Json 
                        Valid = Convert.ToBoolean(data.success);
                    }
                }

                return Valid;
            }
            catch (System.Net.WebException ex)
            {
                throw ex;
            }
        }

        private class MyObject { public string success { get; set; } }
        #endregion
    }
}
