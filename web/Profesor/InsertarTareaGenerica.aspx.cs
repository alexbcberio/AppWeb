using System;
using System.Data;
using System.Data.SqlClient;
using SqlServerDb;


using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Profesor
{
    public partial class InsertarTareaGenerica : System.Web.UI.Page
    {
        private DataTable dt;
        private SqlDataAdapter da;
        private DataSet ds;
        private SqlCommandBuilder cb;

        protected void Page_Load(object sender, EventArgs e)
        {

            Connection con = new Connection();
            ds = new DataSet();
            da = con.getTareasGenericas();
            da.Fill(ds, "TareasGenericas");
            cb = new SqlCommandBuilder(da);
            dt = ds.Tables[0];

        }

        protected void añadir_Click(object sender, EventArgs e)
        {
            Connection con = new Connection();
            if (!con.repeatedTarea(codigo.Text.ToString()))
            {
                DataRow dr = dt.NewRow();
                dr["Codigo"] = codigo.Text.ToString();
                dr["Descripcion"] = desc.Text.ToString();
                dr["CodAsig"] = asig.Text.ToString();
                dr["HEstimadas"] = horas.Text.ToString();
                dr["Explotacion"] = false;
                dr["TipoTarea"] = tipo.Text.ToString();
                dt.Rows.Add(dr);
                da.UpdateCommand = cb.GetUpdateCommand();
                da.Update(ds, "TareasGenericas");
                da.Update(dt);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('¡Tarea añadida ')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('¡Tarea Repetida')", true);
            }
            
        }
    }
}