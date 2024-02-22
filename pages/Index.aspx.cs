using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CrudBasico.pages {

    public partial class Index : System.Web.UI.Page
    {

        //Referencia a la cadena de Conexion
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        //Este Metodo es para que al momento de cargar se cargue el Crud
        void CargarTabla()
        {
            SqlCommand cmd = new SqlCommand("SP_LOAD", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gvusuarios.DataSource = dt;
            gvusuarios.DataBind();
            con.Close();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarTabla();
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/pages/CRUD.aspx?op=C");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        protected void btnRead_Click(object sender, EventArgs e)
        {

            string id;
            Button btnConsultar = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)btnConsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;
            Response.Redirect("~/pages/CRUD.aspx?id=" + id + "&op=R");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string id;
            Button btnConsultar = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)btnConsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;
            Response.Redirect("~/pages/CRUD.aspx?id=" + id + "&op=U");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string id;
            Button btnConsultar = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)btnConsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;
            Response.Redirect("~/pages/CRUD.aspx?id=" + id + "&op=D");
        }
    }

}

