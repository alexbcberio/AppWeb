using SqlServerDb;
using System;
using System.Data;
using System.Data.SqlClient;

namespace web.Alumno
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string code = Request.QueryString.Get("codigo");
                DataSet ds = (DataSet) Session["subjectsDataSet"];

                email.Text = (string) Session["email"];
                task.Text = code;

                estimatedTime.Text = ds.Tables["TareasGenericas"].Rows.Find(code).ItemArray[3].ToString();
                realTime.Focus();
                
                loadInstantiatedGrid();
            }
        }

        private void loadInstantiatedGrid()
        {
            string email = (string) Session["email"];

            Student s = new Student(email);
            SqlCommand instantiatedTasks = s.GetStudentInstantiatedTasks();

            SqlDataAdapter da = new SqlDataAdapter(instantiatedTasks);
            DataSet ds = new DataSet();
            da.Fill(ds);

            instantiatedTasksGrid.DataSource = ds;
            instantiatedTasksGrid.DataBind();
        }

        protected void create_Click(object sender, EventArgs e)
        {
            bool success = false;

            if (task.Text.Length > 0)
            {
                string email = (string) Session["email"];
            
                Student s = new Student(email);

                success = s.instantiateTask(task.Text, int.Parse(estimatedTime.Text), int.Parse(realTime.Text));
            }

            msg.Text = success
                ? "Tarea instanciada con éxito"
                : "Ha ocurrido un error al instanciar la tarea";

            task.Text = "";
            estimatedTime.Text = "";
            realTime.Text = "";

            loadInstantiatedGrid();
        }
    }
}