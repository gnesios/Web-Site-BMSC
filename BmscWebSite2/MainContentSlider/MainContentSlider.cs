using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Collections.Generic;

namespace BmscWebSite2.MainContentSlider
{
    [ToolboxItemAttribute(false)]
    public class MainContentSlider : WebPart
    {
        #region Web part parameters
        private string spPictureLibrary;
        [Personalizable(PersonalizationScope.Shared),
        WebBrowsable(true),
        WebDisplayName("Imágenes"),
        WebDescription("Nombre de la biblioteca de imágenes a usar."),
        Category("Configuración")]
        public string SpPictureLibrary
        {
            get { return spPictureLibrary; }
            set { spPictureLibrary = value; }
        }

        /*private int spPicturesLimit;
        [Personalizable(PersonalizationScope.Shared),
        WebBrowsable(true),
        WebDisplayName("Límite"),
        WebDescription("Número máximo de imágenes a mostrar."),
        Category("Configuración")]
        public int SpPicturesLimit
        {
            get { return spPicturesLimit; }
            set { spPicturesLimit = value; }
        }*/
        #endregion

        public MainContentSlider () : base()
        {
            SpPictureLibrary = "Imágenes Rotador Principal";
            //SpPicturesLimit = 10;
        }

        protected override void CreateChildControls()
        {
            try
            {
                string[] formatedPictures = this.RetrieveFormatedPicturesFromLibrary(spPictureLibrary.Trim());
                LiteralControl sliderScript = new LiteralControl();

                sliderScript.Text = string.Format(
                    "<div class='slider_back'><div id='slider_control'>" +
                    "{0}" +
                    "</div></div>" +
                    "<div class='slider_back'><div id='slider_control_mobile'>" +
                    "{1}" +
                    "</div></div>",
                    formatedPictures[0], formatedPictures[1]);

                this.Controls.Add(sliderScript);
            }
            catch (Exception ex)
            {
                LiteralControl errorMessage = new LiteralControl();
                //errorMessage.Text = "El control no fué configurado correctamente.";
                errorMessage.Text = ex.Message;

                this.Controls.Clear();
                this.Controls.Add(errorMessage);
            }
        }

        /// <summary>
        /// Recupera los valores ya formateados para las imágenes de la biblioteca dada.
        /// </summary>
        /// <param name="libraryName"></param>
        /// <returns></returns>
        private string[] RetrieveFormatedPicturesFromLibrary(string libraryName)
        {
            using (SPSite sps = new SPSite(SPContext.Current.Web.Url))
            using (SPWeb spw = sps.OpenWeb())
            {
                string[] formatedPictures = {"", ""};

                SPQuery query = new SPQuery();
                query.Query = "<OrderBy><FieldRef Name='ID' Ascending='FALSE' /></OrderBy>" +
                    "<Where><Eq><FieldRef Name='_ModerationStatus' /><Value Type='ModStat'>0</Value>" +
                    "</Eq></Where>";
                SPListItemCollection pictures = spw.Lists[libraryName].GetItems(query);

                for (int i = 0; i < pictures.Count; i++)
                {
                    SPListItem picture = pictures[i];
                    
                    string title = picture.Title;
                    string url = "/" + picture.Url;
                    string link = "javascript:;";
                    try
                    {//Si no existe el campo 'Enlace', la operacion continua
                        if (picture["Enlace"] != null || !string.IsNullOrEmpty(picture["Enlace"].ToString()))
                            link = picture["Enlace"].ToString().Remove(picture["Enlace"].ToString().IndexOf(','));
                    }
                    catch { }

                    if (picture["Rotador"].ToString() == "MOVIL")
                    {
                        formatedPictures[1] = formatedPictures[1] + string.Format(
                            "<div class='slider-item'><a href='{0}'><img src='{1}' alt='{2}'></a></div>",
                            link, url, title);
                    }
                    else
                    {//ESTANDAR
                        formatedPictures[0] = formatedPictures[0] + string.Format(
                            "<div class='slider-item'><a href='{0}'><img src='{1}' alt='{2}'></a></div>",
                            link, url, title);
                    }
                }

                return formatedPictures;
            }
        }
    }
}
