using System;
using System.Drawing;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;
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
            SqlDataReader dr = con.Login(userEmail.Text);

            if (dr.Read())
            {
                string pass = dr.GetString(0);

                success = checkPassword(pass, userpass.Text);
            }

            dr.Close();
            con.Close();

            if (success)
            {
                string userType = getUserType(userEmail.Text);
                FormsAuthentication.RedirectFromLoginPage(userType, false);
                string redirUrl = FormsAuthentication.GetRedirectUrl(userType, false);

                Session.Add("logged", true);
                Session.Add("email", userEmail.Text);
                Session.Add("tipo", userType);

                if (redirUrl == "/")
                {
                    switch(userType)
                    {
                        case "alumno":
                            Response.Redirect("Alumno/Alumno.aspx");
                            break;
                        default:
                            Response.Redirect("Profesor/Profesor.aspx");
                            break;
                    }
                }

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

        private string getUserType(string email)
        {
            string type = null;

            switch(email)
            {
                case "vadillo@ehu.es":
                    type = "vadillo";
                    break;
                case "admin@ehu.es":
                    type = "admin";
                    break;
            }

            if (type == null)
            {
                Connection con = new Connection();
                
                type = con.getTipo(email);

                con.Close();
            }

            return type.ToLower();
        }
    }
}