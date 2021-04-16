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

            Application.Set("usersManager", new UsersManager());
        }

        // protected void Session_Start(object sender, EventArgs e)
        protected void Application_PostAcquireRequestState(object sender, EventArgs e)
        {
            try
            {
                if (
                    Session["tipo"] == null ||
                    Session["email"] == null ||
                    Session["tipo"] == null
                ) {
                    return;
                }
            } catch (Exception ex) {
                return;
            }

            Application.Lock();

            UsersManager usrsMgr = Application.Get("usersManager") as UsersManager;
            string email = Session["email"] as string;
            string userType = Session["tipo"] as string;

            if (userType == "alumno")
            {
                usrsMgr.addStudent(email);
            } else {
                usrsMgr.addOther(email);
            }

            Application.Set("usersManager", usrsMgr);

            Application.UnLock();
        }
        protected void Session_End(object sender, EventArgs e)
        {
            if (
                Session["tipo"] == null ||
                Session["email"] == null ||
                Session["tipo"] == null
            ) {
                return;
            }
            
            Application.Lock();

            UsersManager usrsMgr = Application.Get("usersManager") as UsersManager;
            string email = Session["email"] as string;
            string userType = Session["tipo"] as string;

            if (userType == "alumno")
            {
                usrsMgr.removeStudent(email);
            }
            else
            {
                usrsMgr.removeOther(email);
            }

            Application.Set("usersManager", usrsMgr);

            Application.UnLock();
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}