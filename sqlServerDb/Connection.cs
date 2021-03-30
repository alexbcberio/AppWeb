using System;
using System.Data;
using System.Data.SqlClient;

namespace SqlServerDb
{
    public class Connection
    {
        private static string _connectionString;
        private bool connected;
        protected SqlConnection connection;

        /*
         * connectionString setter
         */
        public static string ConnectionString
        {
            set { _connectionString = value; }
        }

        public Connection()
        {
            connected = false;
            connection = new SqlConnection(_connectionString);
        }

        /*
         * Opens a connection to the database
         */
        public void Open()
        {
            if (!connected)
            {
                try
                {
                    connection.Open();
                    connected = true;
                } catch (Exception e)
                {
                    Console.WriteLine("Error opening connection to database.");
                    Console.Write(e.Message);
                }
            }
        }

        /*
         * Closes the connection with the database
         */
        public void Close()
        {
            if (connected)
            {
                connection.Close();
                connected = false;
            }
        }

        /*
         * Executes the given query returning a scalar.
         */
        public object ExecuteScalar(string query)
        {
            SqlCommand command = createCommand(query);

            return command.ExecuteScalar();
        }

        /*
         * Executes the given query returning the number of affected rows.
         */
        public int ExecuteNonQuery(string query)
        {
            SqlCommand command = createCommand(query);

            return command.ExecuteNonQuery();
        }

        /*
         * Executes the given query returning a SqlDataReader.
         */
        public SqlDataReader ExecuteReader(string query)
        {
            SqlCommand command = createCommand(query);

            return command.ExecuteReader();
        }

        /*
         * check if given email is in DB returning a SqlDataReader.
         */
        public SqlDataReader Login(string email)
        {
            string sql = $"select pass from usuarios where email = '"+email+"';";
            SqlDataReader r = ExecuteReader(sql);
            return r;

        }

        /*
        * Insert a User into Db .
        */
        public int Register(string email, string name, string surnames,int confirm_number,String tipo,String Password)
        {
            string sql = $"insert into usuarios" +
                     $"(email, nombre, apellidos, numconfir, confirmado, tipo, pass) values" +
                     $"('{email}', '{name}', '{surnames}', {confirm_number}, 0, '{tipo}', '{Password}');";

            int r = ExecuteNonQuery(sql);
            return r;

        }
        /*
        * Update user status in DB given his Email and confirmation number 
        */
        public int UpdateUserStatus(string email, int confirm_number)
        {
            string sql = $"update usuarios set " +
                $"confirmado = 1, numconfir = 0 " +
                $"where email = '{email}' and numconfir = {confirm_number} and confirmado = 0;";

            int r = ExecuteNonQuery(sql);
            return r;

        }
             /*
        * check if given email is in Database
        */
        public int emailExsist(string email)
        {
            string sql = $"select count(*) from Usuarios where email = '{email}';";

            int r = (int)ExecuteScalar(sql);
            return r;

        }
        /*
        * Update user pass in DB given his Email and codepass and Set his new Password 
        */
        public int UpdatePassword(string email, String codepass,String new_pass)
        {
            string sql = $"update usuarios set pass = '{new_pass}', codpass = null where email = '{email}' and codpass = {codepass};";


            int r = ExecuteNonQuery(sql);
            return r;

        }

        /*
       * Set given  codepass in table for given email
       */
        public int setCodePass(string email, int codepass)
        {
           String sql = $"update usuarios set codpass = {codepass} where email = '{email}';";


            int r = ExecuteNonQuery(sql);
            return r;

        }
        /*
      * Return tipo of a given email
      */
        public String getTipo(string email)
        {
            //String sql = $"select tipo from Usuarios where email='" + email + "';";

            string tipo = "";

            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();

            SqlCommand com = new SqlCommand("getTipo", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("email",new SqlParameter()).Value = email;
            SqlDataReader r = com.ExecuteReader();
            if (r.Read()) {
                 tipo = r.GetString(0);
            }

            r.Close();
            con.Close();

            return tipo;

        }
        /*
      * Return sQL aDATPTER OF tAREAS gENERICAS
      */
        public SqlDataAdapter getTareasGenericas()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from TareasGenericas", connection);
            return da;
        }



        /*
         * Opens a connection if its not already connected and creates a SqlCommand.
         */
        protected SqlCommand createCommand(string query)
        {
            if (!connected)
            {
                Open();
            }

            return new SqlCommand(query, connection);
        }

        public bool repeatedTarea(string codigo)
        {

            String sql = ("select codigo from TareasGenericas where codigo='"+ codigo + "';");
            
            SqlDataReader reader = ExecuteReader(sql);
            bool repeat;
            if (reader.Read())
            {
                repeat = reader["codigo"].ToString() == codigo;
            }
            else
            {
                repeat = false;
            }

            reader.Close();
            return repeat;
        }
    }
}
