using System;
using System.Drawing;
using System.Data.SqlClient;
using SqlServerDb;

namespace web
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            bool success = false;
            Connection con = new Connection();
            String tipo="";

            //string sql = $"select pass from usuarios where email = '{userEmail.Text}';";
            //SqlDataReader r = con.ExecuteReader(sql);
            SqlDataReader r = con.Login(userEmail.Text);


            if (r.Read())
            {
                string pass = r.GetString(0);
                r.Close();
                tipo = con.getTipo(userEmail.Text);

                success = pass == userpass.Text;


            }
            else { r.Close(); }

            
            con.Close();

            if (success)
            {
                Session.Add("logged", true);
                Session.Add("email", userEmail.Text);
                Session.Add("tipo", tipo);

                if (tipo.Equals("Profesor")) { Response.Redirect("Profesor/Profesor.aspx"); }
                else { Response.Redirect("Alumno/Alumno.aspx"); }

                loginInfo.Text = "¡Sesión iniciada!";
                loginInfo.ForeColor = Color.Green;
            } else
            {
                loginInfo.Text = "Combinación de email y contraseña incorrecta.";
                loginInfo.ForeColor = Color.Red;
            }
        }

    }
}