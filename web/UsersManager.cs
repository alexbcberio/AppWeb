using System.Collections;

namespace web
{
    public class UsersManager
    {
        private ArrayList students;
        private ArrayList others;

        public UsersManager()
        {
            this.students = new ArrayList();
            this.others = new ArrayList();
        }

        public bool hasStudent(string email)
        {
            return students.Contains(email);
        }

        public int countStudents()
        {
            return students.Count;
        }

        public void addStudent(string email)
        {
            if (!hasStudent(email))
            {
                students.Add(email);
            }
        }

        public string[] getStudents()
        {
            return students.ToArray(typeof (string)) as string[];
        }

        public void removeStudent(string email)
        {
            if (hasStudent(email))
            {
                students.Remove(email);
            }
        }

        public bool hasOther(string email)
        {
            return others.Contains(email);
        }

        public int countOthers()
        {
            return others.Count;
        }

        public void addOther(string email)
        {
            if (!hasOther(email))
            {
                others.Add(email);
            }
        }

        public string[] getOthers()
        {
            return others.ToArray(typeof(string)) as string[];
        }

        public void removeOther(string email)
        {
            if (hasOther(email))
            {
                others.Remove(email);
            }
        }
    }
}