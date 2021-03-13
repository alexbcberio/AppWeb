using System;
using System.Data;
using SqlServerDb;

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

            DataSet subjects = s.GetStudentSubjects(sessionMail());

            codasig.DataSource = subjects;
            codasig.DataTextField = "codigoasig";
            codasig.DataBind();
        }

        private void LoadSubjectTasks()
        {
            Student s = new Student();

            DataSet tasks = s.GetStudentTasks(sessionMail(), codasig.SelectedValue);

            tasksGrid.DataSource = tasks;
            tasksGrid.DataBind();
        }

        protected void tasksGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cod = tasksGrid.SelectedRow.Cells[1].Text;
            Response.Redirect($"InstanciarTarea.aspx?codigo={cod}");
        }
    }
}