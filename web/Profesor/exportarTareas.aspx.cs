using System;
using System.Data;
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
            DataRowCollection tasks = ds.Tables[0].Rows;

            // No hay tareas a exportar
            if (tasks.Count == 0) {
                statusLabel.Text = "No hay tareas para exportar";
                statusLabel.Visible = true;
                return;
            }

            string savePath = Server.MapPath("../App_Data/" + subjectsDropdown.SelectedValue + ".xml");
            createTasksXml(tasks, savePath);

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

        private void createTasksXml(DataRowCollection tasks, string savePath)
        {
            XmlDocument xml = new XmlDocument();
            XmlElement tasksElem = xml.CreateElement("tareas");
            xml.AppendChild(tasksElem);

            // iterate each row
            foreach (DataRow task in tasks)
            {
                XmlElement taskElem = xml.CreateElement("tarea");

                // iterate each row column
                foreach (DataColumn col in task.Table.Columns)
                {
                    string name = col.ColumnName;
                    XmlElement field = xml.CreateElement(name);

                    // create the XML element
                    switch (name)
                    {
                        case "codigo":
                            taskElem.SetAttribute(name, task.Field<string>(name));
                            field = null;
                            break;
                        case "descripcion":
                        case "tipotarea":
                            field.InnerText = task.Field<string>(name).ToString();
                            break;
                        case "hestimadas":
                            field.InnerText = task.Field<int>(name).ToString();
                            break;
                        case "explotacion":
                            field.InnerText = task.Field<bool>(name).ToString();
                            break;
                    }

                    if (field != null)
                    {
                        taskElem.AppendChild(field);
                    }
                }

                xml.DocumentElement.AppendChild(taskElem);
            }

            xml.Save(savePath);
        }
    }
}