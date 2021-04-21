using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web
{
    public partial class coordinador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            deployedhorasmedias.WebService1 serv = new deployedhorasmedias.WebService1();

            Label4.Text = "Horas medias estimadas por los alumnos: " + serv.getHorasMedia(DropDownList1.Text.ToString());


        }
    }
}