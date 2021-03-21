using System;
using System.Data;
using System.Data.SqlClient;

namespace SqlServerDb
{
    public class Teacher : Connection
    {
        private string email;
        public Teacher(string email) : base()
        {
            this.email = email;
        }

        public DataSet GetSubjects()
        {
            string query = $"select codigoasig from GruposClase gc, ProfesoresGrupo pg where gc.codigo = pg.codigogrupo and pg.email = '{email}'";

            SqlCommand sql = createCommand(query);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql);

            da.Fill(ds);

            return ds;
        }

        public DataSet GetGenericTasks(string subjectCode)
        {
            string query = $"select codigo, descripcion, hestimadas, explotacion, tipotarea from TareasGenericas where CodAsig = '{subjectCode}'";

            SqlCommand sql = createCommand(query);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql);

            da.Fill(ds);

            return ds;
        }
    }
}
