using System;
using System.Web.UI;
using sqlServerDb;

namespace web
{
    public partial class WebForm2 : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                string email = Request.Form.Get("email");
                string name = Request.Form.Get("nombre");
                string surnames = Request.Form.Get("apellidos");
                string password = Request.Form.Get("password");
                string rol = Request.Form.Get("rol").ToLower();

                Random rnd = new Random();
                int confirmNumber = rnd.Next(10^5, 2147483647);

                string sql = $"insert into usuarios" +
                    $"(email, nombre, apellidos, numconfir, confirmado, tipo, pass) values" +
                    $"('{email}', '{name}', '{surnames}', {confirmNumber}, 0, '{rol}', '{password}');";
                
                Connection con = new Connection((string)Application.Get("connectionString"));
                
                int res = con.ExecuteNonQuery(sql);
                
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

                    MailClient.sendMail(email, subject, body);

                    Response.Redirect("Inicio.aspx");
                }
            }
        }
    }
}