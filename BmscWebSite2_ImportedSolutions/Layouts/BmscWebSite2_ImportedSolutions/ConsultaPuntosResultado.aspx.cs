using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace BmscWebSite2_ImportedSolutions.Layouts.BmscWebSite2_ImportedSolutions
{
    public partial class ConsultaPuntosResultado : UnsecuredLayoutsPageBase
    {
        public SqlDataAdapter sqlAdaptador;

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
            #region get the DataSource
            DataSet theDataSet = new DataSet();

            try
            {
                string ci = Request.QueryString["ci"];

                theDataSet = this.GetDatosPuntos(ci);
                this.GridViewFormat(theDataSet);
            }
            catch (Exception ex)
            {
                ltrMessage.Text = ex.Message;
                theDataSet = null;
            }
            #endregion
        }

        private void GridViewFormat(DataSet theDataSet)
        {
            dtvPuntos.GridLines = GridLines.None;
            dtvPuntos.CellSpacing = 2;
            dtvPuntos.AutoGenerateRows = false;
            dtvPuntos.Attributes.Add("style", "font-weight: bold;");
            dtvPuntos.DataSource = theDataSet;
            dtvPuntos.FieldHeaderStyle.Font.Bold = false;
            BoundField bfNombre = new BoundField();
            BoundField bfGrupo = new BoundField();
            bfNombre.DataField = "CDP_NOMBRE"; bfNombre.HeaderText = "Nombre cliente: ";
            bfGrupo.DataField = "CDP_GRUPO"; bfGrupo.HeaderText = "Grupo: ";
            dtvPuntos.Fields.Add(bfNombre);
            dtvPuntos.Fields.Add(bfGrupo);
            dtvPuntos.DataBind();

            grvPuntos.AutoGenerateColumns = false;
            grvPuntos.GridLines = GridLines.None;
            grvPuntos.DataSource = theDataSet;
            grvPuntos.AlternatingRowStyle.BackColor = System.Drawing.Color.White;
            grvPuntos.RowStyle.BackColor = System.Drawing.Color.FromArgb(247, 247, 247);
            BoundField bfCategoria = new BoundField();
            BoundField bfAccion = new BoundField();
            BoundField bfPuntos = new BoundField();
            bfCategoria.DataField = "CDP_CATEGORIA"; bfCategoria.HeaderText = "DETALLE DE PUNTOS ACUMULADOS";
            bfAccion.DataField = "CDP_ACCION"; bfAccion.HeaderText = "";
            bfPuntos.DataField = "CDP_PUNTOS"; bfPuntos.HeaderText = "PUNTOS";
            grvPuntos.EmptyDataText = "No existen puntos asociados al documento ingresado.";
            grvPuntos.Columns.Add(bfCategoria);
            grvPuntos.Columns.Add(bfAccion);
            grvPuntos.Columns.Add(bfPuntos);
            grvPuntos.DataBind();
        }

        private DataSet GetDatosPuntos(string ci)
        {
            DataSet theDataSet = new DataSet();

            System.Configuration.ConnectionStringSettings conexionPuntos =
                    System.Configuration.ConfigurationManager.ConnectionStrings["DataBMSC"];

            string sqlQuery = " SELECT CDP_DOCUMENTOID, CDP_NOMBRE, " +
                              " CDP_GRUPO, CDP_SECUENCIA, CDP_CATEGORIA, CDP_ACCION, CDP_PUNTOS " +
                              " FROM puntos.BMET_CPDETALLEPUNTOS " +
                              //" WHERE CDP_DOCUMENTOID = @ci " +
                              " WHERE CDP_DOCUMENTOID = HASHBYTES('SHA1', CAST(@ci as nvarchar)) " +
                              " ORDER BY CDP_DOCUMENTOID ASC, CDP_CODIGOCLUB ASC, CDP_SECUENCIA ASC ";

            SqlParameter pCi = new SqlParameter("@ci", SqlDbType.NVarChar);
            //pCi.Value = this.GetSHA1(ci);
            pCi.Value = ci;

            SqlConnection con = new SqlConnection(conexionPuntos.ConnectionString);
            SqlDataAdapter dap = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            cmd.Parameters.Add(pCi);
            dap.SelectCommand = cmd;

            con.Open();
            dap.Fill(theDataSet);
            con.Close();

            return theDataSet;
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
