using System;
using System.Data.SqlClient;
using sqlServerDb;

namespace web
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string mail = Request.Params.Get("email");
                string code = Request.Params.Get("confirmationCode");

                if (
                    mail != null &&
                    code != null
                )
                {
                    email2.Text = mail;
                    passchangeCode.Text = code;
                }
            }
        }

        protected void requestChange_Click(object sender, EventArgs e)
        {
            Connection con = new Connection((string)Application.Get("connectionString"));
            
            string mail = email.Text;
            string sql = $"select count(*) from Usuarios where email = '{mail}';";

            int exists = (int)con.ExecuteScalar(sql);

            if (exists == 0)
            {
                requestChangeError.Text = "El email indicado no está dado de alta en la plataforma.";
                email2.Text = "";
                con.Close();
                return;
            }

            Random rnd = new Random();
            int confirmCode = rnd.Next(10 ^ 5, 2147483647);

            sql = $"update usuarios set codpass = {confirmCode} where email = '{mail}';";
            int dbUpdated = con.ExecuteNonQuery(sql);

            if (dbUpdated == 0)
            {
                requestChangeError.Text = "Error executando sentencia SQL.";
                email2.Text = "";
                con.Close();
                return;
            }

            string protocol = Request.ServerVariables["HTTPS"].ToLower() == "on" ? "https" : "http";
            string server = Request.ServerVariables["SERVER_NAME"];
            string port = Request.ServerVariables["SERVER_PORT"];
            string url = $"{protocol}://{server}:{port}/CambiarPassword.aspx?email={mail}&confirmationCode={confirmCode}&method=email";

            string body = $"<h1>Solicitud de cambio de contraseña</h1><p>Hola, introduce el siguiente código " +
                $"para proceder a cambiar la clave de tu cuenta:</p><h2>{confirmCode.ToString()}</h2><p>También puedes pulsar <a href='{url}'>este enlace</a>.</p><hr>" +
                $"<p style='text-align:center;font-size:.75rem;'>Este mensaje se ha enviado de forma automática</p>";
            string subject = "Cambio de contraseña";

            MailClient.sendMail(mail, subject, body);

            email2.Text = mail;
            email.Text = "";
            requestChangeOk.Text = "Se ha enviado un email con un código de confirmación.";

            con.Close();
        }

        protected void change_Click(object sender, EventArgs e)
        {
            Connection con = new Connection((string)Application.Get("connectionString"));
            string sql = $"update usuarios set pass = '{password.Text}', codpass = null where email = '{email2.Text}' and codpass = {passchangeCode.Text};";

            int updateDb = con.ExecuteNonQuery(sql);

            if (updateDb < 1)
            {
                changeError.Text = "Combinación de email y clave de confirmación errónea.";
                con.Close();
                return;
            }

            changeOk.Text = "La contraseña se ha actualizado correctamente.";

            email2.Text = "";
            passchangeCode.Text = "";
            homeLink.Visible = true;
            con.Close();
        }
    }
}