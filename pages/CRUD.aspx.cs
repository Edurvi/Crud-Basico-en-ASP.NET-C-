using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CrudBasico.pages
{

    public partial class CRUD : System.Web.UI.Page
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        public static string sID = "-1";
        public static string sOpc = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            //Captura de los datos que enviamos
            //Obtener el ID
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    sID = Request.QueryString["id"].ToString();
                    cargarDatos();
                    txtFecha.TextMode = TextBoxMode.DateTime;
                }

                if (Request.QueryString["op"] != null)
                {
                    sOpc = Request.QueryString["op"].ToString();
                    switch (sOpc)
                    {
                        case "C":
                            this.lblTitulo.Text = "INGRESAR NUEVO USUARIO";
                            this.btnCreate.Visible = true;
                            break;
                        case "R":
                            this.lblTitulo.Text = "Consulta de Usuario";
                            break;
                        case "U":
                            this.lblTitulo.Text = "Modificar Usuario";
                            this.btnUpdate.Visible = true; 
                            break;
                        case "D":
                            this.lblTitulo.Text = "Eliminar Usuario";
                            this.btnEliminar.Visible = true;
                            break;
                    }
                }

            }
        }

        void cargarDatos()
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("SP_READ", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@Id", SqlDbType.Int).Value = sID;
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            DataRow row = dt.Rows[0];
            txtNombre.Text = row[1].ToString();
            txtEdad.Text = row[2].ToString();
            txtEmail.Text = row[3].ToString();
            DateTime d = (DateTime)row[4];
            txtFecha.Text = d.ToString("dd/MM/yyyy");
            con.Close();

        }


        protected void btnCreate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SP_CREATE", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = txtNombre.Text;
            cmd.Parameters.Add("@EDAD", SqlDbType.Int).Value = txtEdad.Text;
            cmd.Parameters.Add("@CORREO", SqlDbType.VarChar).Value = txtEmail.Text;
            cmd.Parameters.Add("@FECHA_NACIMIENTO", SqlDbType.Date).Value = txtFecha.Text;
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Index.aspx"); //Redirecciona al index
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SP_UPDATE", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = sID;
            cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = txtNombre.Text;
            cmd.Parameters.Add("@EDAD", SqlDbType.Int).Value = txtEdad.Text;
            cmd.Parameters.Add("@CORREO", SqlDbType.VarChar).Value = txtEmail.Text;
            cmd.Parameters.Add("@FECHA_NACIMIENTO", SqlDbType.Date).Value = txtFecha.Text;
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Index.aspx"); //Redirecciona al index
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SP_DELETE", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = sID;
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Index.aspx"); //Redirecciona al index
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx"); //Redirecciona al index

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SP_ELIMINAR", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = sID;
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Index.aspx"); //Redirecciona al index
        }
    }
}