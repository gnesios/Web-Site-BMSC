using System;
using System.ComponentModel;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace BmscWebSite2_Simulators.PassiveSimulator
{
    [ToolboxItemAttribute(false)]
    public partial class PassiveSimulator : WebPart
    {
        #region Web part parameters
        public enum Products { Ninguno, SuperMakroCuenta, Rendimax, Electronica, CuentaAhorro };
        private Products spProduct;
        [Personalizable(PersonalizationScope.Shared),
        WebBrowsable(true),
        WebDisplayName("Producto"),
        WebDescription("Producto asociado al simulador."),
        Category("Configuración")]
        public Products SpProduct
        {
            get { return spProduct; }
            set { spProduct = value; }
        }
        #endregion

        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public PassiveSimulator()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();

            ddlMoneda.Items.Add(new ListItem("(Moneda)", "0"));
            ddlMoneda.Items.Add(new ListItem("BOB", "1"));

            if (SpProduct != Products.Rendimax)
                ddlMoneda.Items.Add(new ListItem("USD", "2"));

            ddlMoneda.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (SpProduct == Products.Ninguno)
            {
                Literal errorMessage = new Literal();
                errorMessage.Text = "Este control no esta configurado correctamente.";

                this.Controls.Clear();
                this.Controls.Add(errorMessage);
            }
        }

        protected void lnkConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                string product = "";
                int M = Convert.ToInt32(txbMonto.Text);
                int P = Convert.ToInt32(ddlPlazo.SelectedItem.Text);
                double I = 0;
                double T = 0;

                switch (SpProduct)
                {
                    case Products.SuperMakroCuenta:
                        product = "Súper Makro Cuenta";
                        if (ddlMoneda.SelectedValue == "1") //BOB
                        {
                            if (M >= 0 && M <= 70000)
                                T = 0.02;
                            else if (M >= 70001)
                                T = 0.0001;
                        }
                        else //USD
                        {
                            T = 0.0001;
                        }
                        break;
                    case Products.Rendimax:
                        product = "Rendimax";
                        if (ddlMoneda.SelectedValue == "1") //BOB
                        {
                            if (M >= 0 && M <= 300000)
                                T = 0.03;
                            else if (M >= 300001)
                                T = 0.005;
                        }
                        break;
                    case Products.Electronica:
                        product = "Cuenta de Ahorro Electrónica";
                        if (ddlMoneda.SelectedValue == "1") //BOB
                        {
                            if (M >= 0 && M <= 70000)
                                T = 0.02;
                            else if (M >= 70001 && M <= 70700)
                                T = 0.0001;
                            else if (M >= 70701)
                                T = 0.0002;
                        }
                        else //USD
                        {
                            T = 0.0001;
                        }
                        break;
                    case Products.CuentaAhorro:
                        product = "Cuenta de Ahorro";
                        if (ddlMoneda.SelectedValue == "1") //BOB
                        {
                            if (M >= 0 && M <= 70000)
                                T = 0.02;
                            else if (M >= 70001 && M <= 800000)
                                T = 0.0001;
                            else if (M >= 800001)
                                T = 0.0002;
                        }
                        else //USD
                        {
                            if (M >= 0 && M <= 100000)
                                T = 0.0001;
                            else if (M >= 100001)
                                T = 0.0002;
                        }
                        break;
                    default:
                        break;
                }

                I = this.GetInterestRate(M, T, P);

                string queryString = string.Format(
                    "/Paginas/formularios/SimuladorPasivo.aspx?producto={0}&monto={1}&plazo={2}&interes={3}",
                    System.Web.HttpUtility.UrlEncode(product),
                    System.Web.HttpUtility.UrlEncode(M.ToString("0,0.00") + " " + ddlMoneda.SelectedItem.Text),
                    P,
                    System.Web.HttpUtility.UrlEncode(I.ToString("0,0.00") + " " + ddlMoneda.SelectedItem.Text));
                ltrMessage.Text = string.Format(
                    "<p class='result'>{0}</p>" +
                    "<a class='link' href='#' onclick=\"OpenInDialog(500,500,true,true,true,'{1}','interés generado');\">estoy interesado en el producto</a>",
                    I.ToString("0,0.00") + " " + ddlMoneda.SelectedItem.Text,
                    queryString);
            }
            catch (Exception ex)
            {
                //ltrMessage.Text = ex.Message;
                ltrMessage.Text = "Temporalmente fuera de servicio.";
            }
        }

        private double GetInterestRate(int M, double T, int P)
        {
            double interestRate = M * (Math.Pow(1 + T, P / 360) - 1);

            return interestRate;
        }
    }
}
