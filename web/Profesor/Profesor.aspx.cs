using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Alumno
{
    public partial class Profesor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UsersManager mgr = (UsersManager) Application.Get("usersManager");

            otherLoggedLabel.Text = $"Hay {mgr.countOthers()} profesores conectados";
            studentLoggedLabel.Text = $"Hay {mgr.countStudents()} estudiantes conectados.";
            
            otherAccounts.Items.Clear();
            foreach (string user in mgr.getOthers())
            {
                otherAccounts.Items.Add(user);
            }

            studentAccounts.Items.Clear();
            foreach (string user in mgr.getStudents())
            {
                studentAccounts.Items.Add(user);
            }
        }
    }
}