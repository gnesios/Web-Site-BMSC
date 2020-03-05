using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace BmscWebSite2.MainContentPresenter
{
    [ToolboxItemAttribute(false)]
    public class MainContentPresenter : WebPart
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
        #endregion

        public MainContentPresenter () : base()
        {
            SpPictureLibrary = "Imágenes Presentador Principal";
        }

        protected override void CreateChildControls()
        {
            try
            {
                string formatedPictures = this.RetrieveFormatedPicturesFromLibrary(SpPictureLibrary.Trim());
                LiteralControl sliderScript = new LiteralControl();

                if (string.IsNullOrEmpty(formatedPictures))
                {
                    sliderScript.Text = "La biblioteca de imágenes se encuentra vacía.";
                }
                else
                {
                    sliderScript.Text = string.Format(
                        "<div id='grid-container' class='content_area3'>" +
                        "{0}" +
                        "</div>",
                        formatedPictures);
                }

                this.Controls.Add(sliderScript);
            }
            catch
            {
                LiteralControl errorMessage = new LiteralControl();
                errorMessage.Text = "El control no fué configurado correctamente.";

                this.Controls.Clear();
                this.Controls.Add(errorMessage);
            }
        }

        /// <summary>
        /// Recupera los valores ya formateados para las imágenes de la biblioteca dada.
        /// </summary>
        /// <param name="libraryName"></param>
        /// <returns></returns>
        private string RetrieveFormatedPicturesFromLibrary(string libraryName)
        {
            using (SPSite sps = new SPSite(SPContext.Current.Web.Url))
            using (SPWeb spw = sps.OpenWeb())
            {
                string formatedPictures = "";

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
                    string style = "grid-item";
                    try
                    {//Si no existe el campo 'Enlace', la operacion continua
                        if (picture["Enlace"] != null || !string.IsNullOrEmpty(picture["Enlace"].ToString()))
                            link = picture["Enlace"].ToString().Remove(picture["Enlace"].ToString().IndexOf(','));
                    }
                    catch { }
                    try
                    {//Si no existe el campo 'Estilo', la operacion continua
                        if (picture["Estilo"] != null || !string.IsNullOrEmpty(picture["Estilo"].ToString()))
                            style = picture["Estilo"].ToString().Trim();
                    }
                    catch { }

                    formatedPictures = formatedPictures + string.Format(
                        "<div class='{0}'><a href='{1}'><p>{2}</p><img src='{3}' alt=''></a></div>",
                        style, link, title, url);
                }

                return formatedPictures;
            }
        }
    }
}
