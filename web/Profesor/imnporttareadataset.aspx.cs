using SqlServerDb;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Profesor
{
    public partial class imnporttareadataset : System.Web.UI.Page
    {
        
        
        private SqlDataAdapter dtadapter;
        private DataTable dttable;
        private SqlCommandBuilder cb;
        protected void Page_Load(object sender, EventArgs e)
        {
            loadXmlfile();

        }
        protected void loadXmlfile()
        {
            if (File.Exists(Server.MapPath("../App_Data/" + codasig.SelectedValue + ".xml")))
            {
                ErrorMsg.Text = "";
                Xml1.Visible = true;
                Xml1.DocumentSource = Server.MapPath("../App_Data/" + codasig.SelectedValue + ".xml");
                Xml1.TransformSource = Server.MapPath("../App_Data/VerTablatareashestimadas.xsl");
            }
            else
            {
                ErrorMsg.Text = "No hay XML a mostrar for this";
                Xml1.Visible = false;
            }
        }
        protected void codasig_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadXmlfile();
        }

        protected void Insertar_Click(object sender, EventArgs e)
        {
            try {
                Connection con = new Connection();

                dtadapter = con.getTareasGenericas();
                cb = new SqlCommandBuilder(dtadapter);

                DataSet set = new DataSet();
                set.ReadXml(Server.MapPath("../App_Data/HAS.xml"));
                DataTable tb = set.Tables[0];
                tb.Columns.Add("CodAsig");
                foreach (DataRow drow in tb.Rows)
                {
                    drow["CodAsig"] = codasig.SelectedValue;
                }
                dtadapter.UpdateCommand = cb.GetUpdateCommand();
                dtadapter.Update(set.Tables[0]);
                dtadapter.Update(tb);
                tb.AcceptChanges();
                ErrorMsg.Text = "Ok ho gaya bro";
            }
            catch (SqlException ex){
                ErrorMsg.Text = "Error, mybe already imported";

            }
        }
    }
}