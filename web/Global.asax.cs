using System;
using System.Configuration;
using SqlServerDb;

namespace web
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Application.Set("connectionString", ConfigurationManager.ConnectionStrings["sqlServer"].ConnectionString);
            Connection.ConnectionString = (string) Application.Get("connectionString");

            Application.Set("userManager", new UsersManager());
        }

        //protected void Session_Start(object sender, EventArgs e)
        protected void Application_PostAcquireRequestState(object sender, EventArgs e)
        {
            if (Session["tipo"] == null)
            {
                return;
            }

            UsersManager usrsMgr = (UsersManager) Application.Get("userManager");
            string email = (string) Session["email"];
            string userType = (string) Session["tipo"];

            if (userType == "alumno")
            {
                usrsMgr.addStudent(email);
            } else {
                usrsMgr.addOther(email);
            }

            Application.Set("userManager", usrsMgr);
        }
        protected void Session_End(object sender, EventArgs e)
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

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}