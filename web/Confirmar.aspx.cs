using System;
using sqlServerDb;

namespace web
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string email = Request.QueryString.Get("email");
            int confirmNumber;

            if (email == null)
            {
                // realizamos el redirect desde el lado del servidor, Response.Redirect se
                // gestiona desde el navegador y es mas costoso para el servidor.
                Response.StatusCode = 400;
                return;
            }
            
            try
            {
                confirmNumber = int.Parse(Request.QueryString.Get("confirmationCode"));
            } catch (Exception err)
            {
                Response.StatusCode = 400;
                return;
            }

            string sql = $"update usuarios set " +
                $"confirmado = 1, numconfir = 0" +
                $"where email = '{email}' and numconfir = {confirmNumber} and confirmado = 0;";

            Connection con = new Connection();
            int res = con.ExecuteNonQuery(sql);
            con.Close();

            if (res == 0)
            {
                Response.StatusCode = 400;
                return;
            }

            Response.Redirect("Inicio.aspx");
        }
    }
}