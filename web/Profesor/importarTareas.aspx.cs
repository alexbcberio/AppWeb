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
using System.Xml;

namespace web.Profesor
{
    public partial class importarTareas : System.Web.UI.Page
    {
        XmlDocument xmld;
        DataSet dsttareas;
        SqlDataAdapter daptareas;
        DataTable tbltareas;
        private SqlCommandBuilder cb;

        protected void Page_Load(object sender, EventArgs e)
        {


            Connection con = new Connection();
            dsttareas = new DataSet();
            daptareas = con.getTareasGenericas();
            cb = new SqlCommandBuilder(daptareas);
            daptareas.Fill(dsttareas, "TareasGenericas");
            tbltareas = dsttareas.Tables["TareasGenericas"];
            loadXmlfile();

        }

        protected void loadXmlfile() {
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
            transformby();
        }

        protected void Insertar_Click(object sender, EventArgs e)
        {
            try
            {
                XmlDocument xmld = new XmlDocument();

                xmld.Load(Server.MapPath("../App_Data/" + codasig.SelectedValue + ".xml"));
                XmlNodeList Tareas;
                Tareas = xmld.GetElementsByTagName("tarea");
                tbltareas = dsttareas.Tables["TareasGenericas"];
                //XmlNode tarea;
                foreach (XmlNode tarea in Tareas)
                {
                    Connection con = new Connection();
                    if (!con.repeatedTarea(tarea.Attributes["codigo"].Value.ToString()))
                    {
                        DataRow r = tbltareas.NewRow();
                        r["Codigo"] = tarea.Attributes["codigo"].Value.ToString();
                        r["Descripcion"] = tarea.ChildNodes[0].InnerText.ToString();
                        r["CodAsig"] = codasig.SelectedValue.ToString();
                        r["HEstimadas"] = int.Parse(tarea.ChildNodes[1].InnerText);
                        r["Explotacion"] = bool.Parse(tarea.ChildNodes[2].InnerText);
                        r["TipoTarea"] = tarea.ChildNodes[3].InnerText.ToString();
                        tbltareas.Rows.Add(r);
                    }

                }
                daptareas.UpdateCommand = cb.GetUpdateCommand();
                daptareas.Update(dsttareas, "TareasGenericas");
                daptareas.Update(tbltareas);
                tbltareas.AcceptChanges();
                ErrorMsg.Text = "Ok ho gaya bro";

            }
            catch (FileNotFoundException ex)
            {
                // Write error.
                ErrorMsg.Text = "No hay XML para importar";
            }

        }
        protected void transformby() {
            Xml1.TransformSource = Server.MapPath("../App_Data/VerTablatareas" + transformBy.SelectedValue + ".xsl");
        }
        protected void transformBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            transformby();

        }
    }
}