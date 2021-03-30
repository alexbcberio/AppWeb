using System;
using System.Web.Security;

namespace web
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            FormsAuthentication.SignOut();
            Session.Abandon();
            Session.RemoveAll();
            Response.Write("<script>alert('Bye bye')</script>");
            Response.Redirect("Inicio.aspx");
        }
    }
}