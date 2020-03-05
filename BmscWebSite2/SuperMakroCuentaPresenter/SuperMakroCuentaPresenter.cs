using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace BmscWebSite2.SuperMakroCuentaPresenter
{
    [ToolboxItemAttribute(false)]
    public class SuperMakroCuentaPresenter : WebPart
    {
        #region Web part parameters
        private string spLibrary;
        [Personalizable(PersonalizationScope.Shared),
        WebBrowsable(true),
        WebDisplayName("Lista consultada"),
        WebDescription("Nombre de la lista con los items a consumir."),
        Category("Configuración")]
        public string SpLibrary
        {
            get { return spLibrary; }
            set { spLibrary = value; }
        }

        private string spLink;
        [Personalizable(PersonalizationScope.Shared),
        WebBrowsable(true),
        WebDisplayName("Enlace dirigido"),
        WebDescription("URL para la redirección del enlace."),
        Category("Configuración")]
        public string SpLink
        {
            get { return spLink; }
            set { spLink = value; }
        }
        #endregion

        public SuperMakroCuentaPresenter () : base ()
        {
            SpLibrary = "Ganadores Súper Makro Cuenta";
            SpLink = "#";
        }

        protected override void CreateChildControls()
        {
            try
            {
                string formatedValues = this.RetrieveFormatedValuesFromList(SpLibrary.Trim());
                LiteralControl winnersScript = new LiteralControl();

                if (string.IsNullOrEmpty(formatedValues))
                {
                    winnersScript.Text = "No existen valores para ganadores.";
                }
                else
                {
                    winnersScript.Text = string.Format(
                        "<a class='makrolink' href='{0}'>" +
                        "<p class='title'>Ganador de la Makro Cuenta</p>" +
                        "{1}" +
                        "</a>",
                        SpLink, formatedValues);
                }

                this.Controls.Add(winnersScript);
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
        /// Recupera los valores ya formateados para los parámetros de la lista dada.
        /// </summary>
        /// <param name="listName"></param>
        /// <returns></returns>
        private string RetrieveFormatedValuesFromList(string listName)
        {
            using (SPSite sps = new SPSite(SPContext.Current.Web.Url))
            using (SPWeb spw = sps.OpenWeb())
            {
                string formatedValues = "";

                SPQuery query = new SPQuery();
                query.Query =
                    "<OrderBy><FieldRef Name='ID' Ascending='FALSE' /></OrderBy>" +
                    "<Where><Eq><FieldRef Name='_ModerationStatus' /><Value Type='ModStat'>0</Value>" +
                    "</Eq></Where>";
                query.RowLimit = 1;
                SPListItemCollection items = spw.Lists[listName].GetItems(query);

                foreach (SPListItem item in items)
                {
                    formatedValues = formatedValues + string.Format(
                        "<p class='subtitle'>{0}<br/><br/>Consulta todos los ganadores</p>",
                        item.Title.ToString());
                }

                return formatedValues;
            }
        }
    }
}
