using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace BmscWebSite2_ImportedSolutions.BMSCLecturaCotizaciones
{
    [ToolboxItemAttribute(false)]
    public class BMSCLecturaCotizaciones : WebPart
    {
        private Literal lblCotizaciones;

        protected override void CreateChildControls()
        {
            try
            {
                lblCotizaciones = new Literal();
                lblCotizaciones.ID = "lblCotizaciones";

                this.LeerCotizaciones();

                this.Controls.Add(lblCotizaciones);
            }
            catch (Exception ex)
            {
                Literal errorMessage = new Literal();
                errorMessage.Text = ex.Message;
                //errorMessage.Text = "";

                this.Controls.Clear();
                this.Controls.Add(errorMessage);
            }
        }

        protected void LeerCotizaciones()
        {
            string lectura;
            string dolarC, dolarV, dolarO, ufvC, ufvV, cmvC, cmvV, treME, treMN, treMV, treUFV;

            System.IO.TextReader tr = new System.IO.StreamReader(this.RecuperarParametros());
            lectura = tr.ReadLine().Replace(',', '|').Replace('.', ',');
            tr.Close();

            string[] lecturaArray = lectura.Trim().Split('|');
            dolarC = String.Format("{0:#,0.000}", Convert.ToDouble(lecturaArray[0]));
            dolarV = String.Format("{0:#,0.000}", Convert.ToDouble(lecturaArray[1]));
            dolarO = String.Format("{0:#,0.000}", Convert.ToDouble(lecturaArray[3]));
            ufvC = String.Format("{0:#,0.00000}", Convert.ToDouble(lecturaArray[6]));
            ufvV = String.Format("{0:#,0.00000}", Convert.ToDouble(lecturaArray[7]));
            cmvC = String.Format("{0:#,0.000}", Convert.ToDouble(lecturaArray[8]));
            cmvV = String.Format("{0:#,0.000}", Convert.ToDouble(lecturaArray[9]));
            treME = String.Format("{0:#,0.00}", Convert.ToDouble(lecturaArray[10]));
            treMN = String.Format("{0:#,0.00}", Convert.ToDouble(lecturaArray[11]));
            treMV = String.Format("{0:#,0.00}", Convert.ToDouble(lecturaArray[12]));
            treUFV = String.Format("{0:#,0.00}", Convert.ToDouble(lecturaArray[13]));

            string formatedValues =
                String.Format(
                "<li><b>Dólar</b> Compra: {0} | Venta: {1} | Oficial: {2}</li>" +
                "<li><b>UFV</b> Compra: {3} | Venta: {4} <b>CMV</b> Compra: {5} | Venta: {6}</li>" +
                "<li><b>TRe</b> ME: {7} | <b>TRe</b> MN: {8} | <b>TRe</b> MV: {9} | <b>TRe</b> UFV: {10}</li>",
                dolarC, dolarV, dolarO, ufvC, ufvV, cmvC, cmvV, treME, treMN, treMV, treUFV);
            lectura = string.Format(
                "<div class='content_area4'>" +
                "<div class='icon'></div>" +
                "<div class='title'>información financiera</div>" +
                "<div class='separator'></div>" +
                "<div class='info'><ul class='financial-info'>" +
                "{0}" +
                "</ul></div>",
                formatedValues);

            lblCotizaciones.Text = lectura;
        }

        public string RecuperarParametros()
        {
            string nombre;
            string ruta;

            using (SPSite sps = new SPSite(SPContext.Current.Web.Url))
            using (SPWeb spw = sps.OpenWeb())
            {
                /*SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    sitio = new SPSite(sitioSP);
                    sitioWeb = sitio.RootWeb;
                });*/

                SPList parametrosGlobales = spw.Lists["Parámetros del Sitio"];

                foreach (SPListItem elemento in parametrosGlobales.Items)
                {
                    if (elemento["Aplicación"] != null &&
                        elemento["Aplicación"].ToString().Trim() == "Lectura cotizaciones" &&
                        elemento["Estado de aprobación"].ToString() == "0")
                    {
                        nombre = elemento.Title;
                        ruta = elemento["Ruta archivo"].ToString();

                        if (!ruta.Trim().EndsWith(@"\"))
                            ruta = ruta.Trim() + @"\";

                        return ruta + nombre;
                    }
                }

                return "";
            }
        }
    }
}
