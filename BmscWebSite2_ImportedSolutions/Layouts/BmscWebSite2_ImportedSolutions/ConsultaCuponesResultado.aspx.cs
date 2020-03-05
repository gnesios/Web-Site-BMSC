using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace BmscWebSite2_ImportedSolutions.Layouts.BmscWebSite2_ImportedSolutions
{
    public partial class ConsultaCuponesResultado : UnsecuredLayoutsPageBase
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
                string cuenta = Request.QueryString["cuenta"];
                string ci = Request.QueryString["ci"];

                List<string> listCupones = this.GetDatosCupones(cuenta, ci);
                string nombreCliente = "";
                string cuponesCliente = "";

                bool band = true;
                foreach (string cupon in listCupones)
                {
                    if (band)
                    {
                        nombreCliente = cupon;
                        band = false;
                    }
                    else
                    {
                        cuponesCliente = cuponesCliente + string.Format("<li>{0}</li>", cupon);
                    }
                }

                if (string.IsNullOrEmpty(nombreCliente))
                    ltrMessage.Text = "Los datos ingresados no son correctos. Por favor inténtalo nuevamente.";
                else
                    ltrMessage.Text = string.Format("<p>Nombre cliente: <strong style='text-transform: uppercase'>{0}</strong></p><p>Cantidad cupones: <b>{1}</b></p><p>Cupones: <ul>{2}</ul></p>",
                        nombreCliente, listCupones.Count - 1, cuponesCliente);
            }
            catch (Exception ex)
            { 
                ltrMessage.Text = ex.Message; 
            }
        }

        private List<string> GetDatosCupones(string cuenta, string ci)
        {
            List<string> cupones = new List<string>();

            try
            {
                System.Configuration.ConnectionStringSettings conexionCupones =
                    System.Configuration.ConfigurationManager.ConnectionStrings["DataBMSC"];

                string queryString = "SELECT nombre, numero " +
                                     "FROM cupones.cupones " +
                                     //"WHERE cuenta = @cuenta AND identidad = @ci AND cliente = @codigo " +
                                     "WHERE cuenta = HASHBYTES('SHA1', CAST(@cuenta as nvarchar)) AND " +
                                     "identidad = HASHBYTES('SHA1', CAST(@ci as nvarchar)) " +
                                     "ORDER BY numero asc";

                SqlParameter pCuenta = new SqlParameter("@cuenta", SqlDbType.NVarChar);
                SqlParameter pCi = new SqlParameter("@ci", SqlDbType.NVarChar);
                //pCuenta.Value = this.GetSHA1(cuenta);
                //pCi.Value = this.GetSHA1(ci);
                //pCodigo.Value = this.GetSHA1(codigo);
                pCuenta.Value = cuenta;
                pCi.Value = ci;

                SqlConnection con = new SqlConnection(conexionCupones.ConnectionString);
                SqlCommand cmd = new SqlCommand(queryString, con);
                cmd.Parameters.Add(pCuenta);
                cmd.Parameters.Add(pCi);

                con.Open();
                SqlDataReader dataReader = cmd.ExecuteReader();

                bool band = true;
                while (dataReader.Read())
                {
                    if (band)
                    {
                        cupones.Add(dataReader["nombre"].ToString());
                        band = false;
                    }

                    cupones.Add(dataReader["numero"].ToString());
                }

                dataReader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                cupones.Clear();
                cupones.Add(ex.Message);
            }

            return cupones;
        }

        private string GetSHA1(string value)
        {
            System.Security.Cryptography.SHA1 sha1 = new System.Security.Cryptography.SHA1CryptoServiceProvider();

            byte[] theBytes = sha1.ComputeHash(System.Text.Encoding.UTF8.GetBytes(value));
            System.Text.StringBuilder sb = new System.Text.StringBuilder(theBytes.Length * 2);

            foreach (byte item in theBytes)
            {
                sb.Append(item.ToString("X2")); //x2 for lowercase
            }

            return sb.ToString();
        }
    }
}
