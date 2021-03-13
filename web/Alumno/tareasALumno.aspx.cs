using System;
using System.Data;
using SqlServerDb;
using System.Data.SqlClient;

namespace web.Alumno
{
    public partial class alumno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadSubjects();
            }

            LoadSubjectTasks();
        }

        private string sessionMail()
        {
            return (string) Session["email"];
        }

        private void LoadSubjects()
        {
            Student s = new Student();

            SqlCommand subjects = s.GetStudentSubjects(sessionMail());

            SqlDataAdapter da = new SqlDataAdapter(subjects);
            DataSet ds = new DataSet();

            da.Fill(ds);

            codasig.DataSource = ds;
            codasig.DataTextField = "codigoasig";
            codasig.DataBind();
        }

        private void LoadSubjectTasks()
        {
            Student s = new Student();

            SqlCommand tasks = s.GetStudentTasks(sessionMail(), codasig.SelectedValue);

            SqlDataAdapter da = new SqlDataAdapter(tasks);
            DataSet ds = new DataSet();

            da.Fill(ds);

            tasksGrid.DataSource = ds;
            tasksGrid.DataBind();
        }

        protected void tasksGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cod = tasksGrid.SelectedRow.Cells[1].Text;
            Response.Redirect($"InstanciarTarea.aspx?codigo={cod}");
        }
    }
}