using System;
using System.Data;
using System.IO;
using System.Xml;
using SqlServerDb;

namespace web.Profesor
{
    public partial class exportarTareas : System.Web.UI.Page
    {
        private Teacher t;
        private DataSet genericTasks = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            t = new Teacher((string)Session["email"]);

            if (!Page.IsPostBack)
            {
                LoadDropdown();
            }

            LoadGenericTasks();
        }

        private void LoadDropdown()
        {
            subjectsDropdown.DataSource = t.GetSubjects();
            subjectsDropdown.DataTextField = "codigoasig";
            subjectsDropdown.DataBind();
        }

        private void LoadGenericTasks()
        {
            tasksGrid.DataSource = getGenericTasks();
            tasksGrid.DataBind();
        }

        protected void exportXml_Click(object sender, EventArgs e)
        {
            DataSet ds = getGenericTasks();
            DataTable tasks = ds.Tables[0];

            // No hay tareas a exportar
            if (tasks.Rows.Count == 0) {
                statusLabel.Text = "No hay tareas para exportar";
                statusLabel.Visible = true;
                return;
            }

            ds.DataSetName = "tareas";
            tasks.TableName = ds.DataSetName.Substring(0, ds.DataSetName.Length - 1);

            int codIdx = tasks.Columns.IndexOf("codigo");
            tasks.Columns[codIdx].ColumnMapping = MappingType.Attribute;

            string savePath = Server.MapPath("../App_Data/" + subjectsDropdown.SelectedValue + ".xml");
            FileStream fileStream = new FileStream(savePath, FileMode.Create);
            ds.WriteXml(fileStream);

            statusLabel.Text = $"Tareas exportadas en {subjectsDropdown.SelectedValue}.xml";
            statusLabel.Visible = true;
        }

        private DataSet getGenericTasks()
        {
            if (genericTasks == null)
            {
                genericTasks = t.GetGenericTasks(subjectsDropdown.SelectedValue);
            }

            return genericTasks;
        }

    }
}