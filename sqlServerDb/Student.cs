using System.Data.SqlClient;

namespace SqlServerDb
{
    public class Student : Connection
    {
        private string email;
        public Student(string email): base()
        {
            this.email = email;
        }

        public SqlCommand GetStudentSubjects()
        {
            string query = $"select gc.codigoasig from EstudiantesGrupo eg, GruposClase gc where eg.Grupo = gc.codigo and eg.Email = '{email}';";

            return createCommand(query);
        }

        public SqlCommand GetStudentTasks(string subjectCode)
        {
            string columns = "tg.Codigo, tg.Descripcion, tg.CodAsig, tg.HEStimadas";
            string query = $"select {columns} from TareasGenericas tg where CodAsig = '{subjectCode}' except select {columns} from TareasGenericas tg inner join EstudiantesTareas et on tg.Codigo = et.CodTarea where CodAsig = '{subjectCode}' and et.Email = '{email}';";

            return createCommand(query);
        }

        public SqlCommand GetStudentInstantiatedTasks()
        {
            string query = $"select * from EstudiantesTareas where Email = '{email}';";

            return createCommand(query);
        }

        public bool instantiateTask(string taskId, int estimatedTime, int realTime)
        {
            string query = $"insert into EstudiantesTareas" +
                $"(Email, CodTarea, HEstimadas, HReales) values" +
                $"('{email}', '{taskId}', {estimatedTime}, {realTime})";

            int inserts = ExecuteNonQuery(query);

            return inserts == 1;
        }
    }
}
