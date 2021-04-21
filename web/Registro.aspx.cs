using System;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;
using SqlServerDb;

namespace web
{
    public partial class WebForm2 : Page
    {

        private string emaill;
        private string name;
        private String passwordd;
        private string roll;
        private string surnames;
        protected void Page_Load(object sender, EventArgs e)
        {
           

        }
        private string hashPassword(string pass)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            md5.Initialize();

            byte[] passHashByte = md5.ComputeHash(Encoding.UTF8.GetBytes(pass));
            StringBuilder passHash = new StringBuilder();

            for (int i = 0; i < passHashByte.Length; i++)
            {
                passHash.Append(passHashByte[i].ToString("x2"));
            }

            return passHash.ToString();
        }




        protected void password_TextChanged(object sender, EventArgs e)
        {
            passwordStrength.WebService2 serv = new passwordStrength.WebService2();
            String passwordd = password.Text;
            int str = serv.passStrength(passwordd);
            if (str < 1)
            {
                Label1.ForeColor = System.Drawing.Color.Red;
                Label1.Text = "Password is very Week Bro,And Strength is  = " + str;
                Button1.Enabled = false;
            }
            else if (str < 3)
            {
                Label1.ForeColor = System.Drawing.Color.Red;
                Label1.Text = "Password is Still Week Bro,And Strength is  = " + str;
                Button1.Enabled = false;
            }
            else
            {
                Label1.ForeColor = System.Drawing.Color.Green;
                Label1.Text = "Password is Good Bro,And Strength is  = " + str;
                Button1.Enabled = true;
            }

        }

        protected void email_TextChanged1(object sender, EventArgs e)
        {
            es.ehusw.Matriculas ser = new es.ehusw.Matriculas();
            if (ser.comprobar(email.Text.ToString()) == "NO")
            {
                emailval.ForeColor = System.Drawing.Color.Red;
                emailval.Text = "El email introducido no está matriculado.";
                Button1.Enabled = false;
            }
            else
            {
                emailval.ForeColor = System.Drawing.Color.Green;
                emailval.Text = "El email introducido está matriculado.";
                Button1.Enabled = true;
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            //string email = Request.Form.Get("email");
            emaill = email.Text;

            // string name = Request.Form.Get("nombre");
            name = nombre.Text;
            // string surnames = Request.Form.Get("apellidos");
            surnames = apellidos.Text;
            //string password = hashPassword(Request.Form.Get("password"));
            passwordd = hashPassword(password.Text);
            // string rol = Request.Form.Get("rol").ToLower();
            roll = rol.SelectedValue.ToLower();


            Random rnd = new Random();
            int confirmNumber = rnd.Next(10 ^ 5, 2147483647);

            Connection con = new Connection();

            int res = con.Register(emaill, name, surnames, confirmNumber, roll, passwordd);

            con.Close();

            if (res == 1)
            {
                string protocol = Request.ServerVariables["HTTPS"].ToLower() == "on" ? "https" : "http";
                string server = Request.ServerVariables["SERVER_NAME"];
                string port = Request.ServerVariables["SERVER_PORT"];

                string url = $"{protocol}://{server}:{port}/Confirmar.aspx?email={email}&confirmationCode={confirmNumber}&method=email";
                string body = $"<h1>Gracias por registrarte</h1><p>Pulsa <a href='{url}'>aquí</a> para activar tu cuenta.</p>" +
                    $"<p>¿Prefieres copiar el enlace a mano? Aquí lo tienes <a href='{url}'>{url}</a></p><hr>" +
                    $"<p style='text-align:center;font-size:.75rem;'>Este mensaje se ha enviado de forma automática</p>";

                string subject = "Confirmar cuenta";

                // MailClient.sendMail(email, subject, body);

                Response.Redirect("Inicio.aspx");
            }
        }
    }
    
}