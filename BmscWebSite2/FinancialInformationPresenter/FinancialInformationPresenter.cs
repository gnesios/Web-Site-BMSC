using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace BmscWebSite2.FinancialInformationPresenter
{
    [ToolboxItemAttribute(false)]
    public class FinancialInformationPresenter : WebPart
    {
        #region Global variables
        string TheList = "Parámetros del Sitio";
        #endregion

        protected override void CreateChildControls()
        {
            try
            {
                string formatedValues = this.RetrieveFormatedValuesFromList(TheList);
                LiteralControl financialScript = new LiteralControl();

                if (string.IsNullOrEmpty(formatedValues))
                {
                    financialScript.Text = "No existen valores para información financiera.";
                }
                else
                {
                    financialScript.Text = string.Format(
                        "<div class='content_area4'>" +
                        "<div class='icon'></div>" +
                        "<div class='title'>información financiera</div>" +
                        "<div class='separator'></div>" +
                        "<div class='info'><ul class='financial-info'>" +
                        "{0}" +
                        "</ul></div>",
                        formatedValues);
                }

                this.Controls.Add(financialScript);
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
                    "<OrderBy><FieldRef Name='ID' /></OrderBy>" +
                    "<Where><And>" +
                    "<Eq><FieldRef Name='Title' /><Value Type='Text'>Información Financiera</Value></Eq>" +
                    "<Eq><FieldRef Name='_ModerationStatus' /><Value Type='ModStat'>0</Value></Eq>" +
                    "</And></Where>";
                SPListItemCollection items = spw.Lists[listName].GetItems(query);

                foreach (SPListItem item in items)
                {
                    formatedValues = formatedValues + string.Format(
                        "<li>{0}</li>", item["Valor"].ToString());
                }

                return formatedValues;
            }
        }
    }
}
