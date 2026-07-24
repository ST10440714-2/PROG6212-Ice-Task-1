using System.Collections.Generic;

namespace StudentResultsSystem
{
    //=========================================================
    // StudentCollection Class
    // Stores and manages a collection of Student objects.
    //=========================================================
    public class StudentCollection
    {
        private List<Student> students = new List<Student>();

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public List<Student> GetAllStudents()
        {
            return students;
        }

        public int Count
        {
            get { return students.Count; }
        }
    }
}