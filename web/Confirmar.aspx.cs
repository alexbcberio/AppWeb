using System;
using SqlServerDb;

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
                Response.StatusCode = 400;
                errorMsg.Text = "Error: combinación de email y código de confirmación erróneos.";
                return;
            }
            
            try
            {
                confirmNumber = int.Parse(Request.QueryString.Get("confirmationCode"));
            } catch (Exception err)
            {
                Response.StatusCode = 400;
                errorMsg.Text = "Error: combinación de email y código de confirmación erróneos.";
                return;
            }

            string sql = $"update usuarios set " +
                $"confirmado = 1, numconfir = 0 " +
                $"where email = '{email}' and numconfir = {confirmNumber} and confirmado = 0;";

            Connection con = new Connection((string) Application.Get("connectionString"));
            int res = con.ExecuteNonQuery(sql);
            con.Close();

            if (res == 0)
            {
                Response.StatusCode = 400;
                errorMsg.Text = "Error: combinación de email y código de confirmación erróneos.";
                return;
            }

            Response.Redirect("Inicio.aspx");
        }
    }
}