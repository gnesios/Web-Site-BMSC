using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace BmscWebSite2_ImportedSolutions.Layouts.BmscWebSite2_ImportedSolutions
{
    public partial class ConsultaViviendaResultado : UnsecuredLayoutsPageBase
    {
        protected override bool AllowAnonymousAccess
        {
            get
            {
                //return base.AllowAnonymousAccess;
                return true;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string ci = Request.QueryString["ci"];
                string[] datosSorteo = this.GetDatosSorteo(ci);

                if (datosSorteo == null)
                {
                    ltrMessage.Text = "<p>Usted <strong style='text-transform:uppercase'>no está habilitad@</strong> para participar del sorteo.</p>";
                }
                else
                {
                    ltrMessage.Text = string.Format(
                        "<p>Nombre cliente: <strong style='text-transform: uppercase'>{0}</strong></p>" +
                        "<p>Número cupón: <strong>{1}</strong></p>" +
                        "<p style='margin:20px 0;'>Usted <strong style='text-transform:uppercase;color:#7dbe30'>si está habilitad@</strong> para participar del sorteo.</p>",
                        datosSorteo[0], datosSorteo[1]);
                }
            }
            catch (Exception ex)
            {
                ltrMessage.Text = "Servicio no disponible, por favor inténtelo más tarde.";
                //ltrMessage.Text = ex.Message;
            }
        }

        private string[] GetDatosSorteo(string ci)
        {
            string[] datosSorteo = null;

            #region SQL Connection
            System.Configuration.ConnectionStringSettings conexionCupones =
                System.Configuration.ConfigurationManager.ConnectionStrings["DataBMSC"];

            string queryString =
                "SELECT nombre, numero " +
                "FROM cupones.cuponesGral " +
                "WHERE identidad = HASHBYTES('SHA1', CAST(@ci as nvarchar))";
            SqlParameter pCi = new SqlParameter("@ci", SqlDbType.NVarChar);
            pCi.Value = ci;

            SqlConnection con = new SqlConnection(conexionCupones.ConnectionString);
            SqlCommand cmd = new SqlCommand(queryString, con);
            SqlDataReader dataReader = null;
            cmd.Parameters.Add(pCi);

            try
            {
                con.Open();
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    datosSorteo = new string[2];
                    datosSorteo[0] = dataReader["nombre"].ToString();
                    datosSorteo[1] = dataReader["numero"].ToString();
                    break;
                }
            }
            catch (Exception ex)
            {
                ltrMessage.Text = "Servicio no disponible, por favor inténtelo más tarde.";
            }
            finally
            {
                dataReader.Close();
                con.Close();
            }
            #endregion

            return datosSorteo;
        }
    }
}
