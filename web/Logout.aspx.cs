using System;
using System.Web.Security;

namespace web
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // does not trigger from session_end method of global.asac
            removeUserFromApplication();

            FormsAuthentication.SignOut();
            Session.Abandon();
            Session.RemoveAll();
            Response.Write("<script>alert('Bye bye')</script>");
            Response.Redirect("Inicio.aspx");
        }

        private void removeUserFromApplication()
        {
            if (Session["tipo"] == null)
            {
                return;
            }

            UsersManager usrsMgr = (UsersManager)Application.Get("userManager");
            string email = (string)Session["email"];
            string userType = (string)Session["tipo"];

            if (userType == "alumno")
            {
                usrsMgr.removeStudent(email);
            }
            else
            {
                usrsMgr.removeOther(email);
            }

            Application.Set("userManager", usrsMgr);
        }
    }
}