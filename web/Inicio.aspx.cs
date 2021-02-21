using System;
using System.Drawing;
using System.Data.SqlClient;
using sqlServerDb;

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
            Connection con = new Connection((string)Application.Get("connectionString"));

            string sql = $"select pass from usuarios where email = '{userEmail.Text}';";
            SqlDataReader r = con.ExecuteReader(sql);

            if (r.Read())
            {
                string pass = r.GetString(0);

                success = pass == userpass.Text;
            }

            r.Close();
            con.Close();

            if (success)
            {
                Session.Add("logged", true);
                Session.Add("email", userEmail.Text);

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