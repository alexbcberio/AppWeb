using System;
using System.Data.SqlClient;

namespace sqlServerDb
{
    public class Connection
    {
        private bool connected;
        private SqlConnection connection;

        public Connection(string connectionString)
        {
            connected = false;
            connection = new SqlConnection(connectionString);
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
         * Opens a connection if its not already connected and creates a SqlCommand.
         */
        private SqlCommand createCommand(string query)
        {
            if (!connected)
            {
                Open();
            }

            return new SqlCommand(query, connection);
        }
    }
}
