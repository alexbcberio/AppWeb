using System;
using System.Data;
using System.IO;
using System.Xml;
using Newtonsoft.Json;
using SqlServerDb;
using Formatting = Newtonsoft.Json.Formatting;

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

            int codIdx = tasks.Columns.IndexOf("codigo");
            tasks.Columns[codIdx].ColumnMapping = MappingType.Attribute;

            string savePath = Server.MapPath("../App_Data/" + subjectsDropdown.SelectedValue + ".xml");
            FileStream fileStream = new FileStream(savePath, FileMode.Create);
            ds.WriteXml(fileStream);

            statusLabel.Text = $"Tareas exportadas en {subjectsDropdown.SelectedValue}.xml";
            statusLabel.Visible = true;
        }
        protected void exportJson_Click(object sender, EventArgs e)
        {
            DataSet ds = getGenericTasks();

            string savePathJson = Server.MapPath("../App_Data/" + subjectsDropdown.SelectedValue + ".json");
            string json = JsonConvert.SerializeObject(ds, Formatting.Indented);
            File.WriteAllText(savePathJson, json);

            statusLabel.Text = $"Tareas exportadas en {subjectsDropdown.SelectedValue}.json";
            statusLabel.Visible = true;
        }

        private DataSet getGenericTasks()
        {
            if (genericTasks == null)
            {
                genericTasks = t.GetGenericTasks(subjectsDropdown.SelectedValue);
            }
            
            DataTable tasks = genericTasks.Tables[0];

            // No hay tareas a exportar
            if (tasks.Rows.Count == 0)
            {
                statusLabel.Text = "No hay tareas para exportar";
                statusLabel.Visible = true;
            }

            genericTasks.DataSetName = "tareas";
            string dataSetName = genericTasks.DataSetName;
            tasks.TableName = dataSetName.Substring(0, dataSetName.Length - 1);

            return genericTasks;
        }

    }
}