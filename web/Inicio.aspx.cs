using System;
using System.Drawing;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
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
            String tipo = "";
            SqlDataReader r = con.Login(userEmail.Text);


            if (r.Read())
            {
                string pass = r.GetString(0);
                tipo = con.getTipo(userEmail.Text);

                success = checkPassword(pass, userpass.Text);
            }

            r.Close();
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

        private bool checkPassword(string dbPass, string pass)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            md5.Initialize();

            byte[] passHashByte = md5.ComputeHash(Encoding.UTF8.GetBytes(pass));
            StringBuilder passHash = new StringBuilder();

            for (int i = 0; i < passHashByte.Length; i++)
            {
                passHash.Append(passHashByte[i].ToString("x2"));
            }

            return dbPass == passHash.ToString();
        }

    }
}