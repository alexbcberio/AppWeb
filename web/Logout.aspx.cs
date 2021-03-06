using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.RemoveAll();
            Response.Write("<script>alert('Bye bye')</script>");
            Response.Redirect("Inicio.aspx");
        }
    }
}