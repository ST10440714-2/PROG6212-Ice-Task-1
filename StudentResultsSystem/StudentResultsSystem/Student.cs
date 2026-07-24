using System;

namespace StudentResultsSystem
{
    //=========================================================
    // Student Class
    // Stores the information for a single student.
    //=========================================================
    public class Student
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string Course { get; set; }
        public double Result { get; set; }
        public int Age { get; set; }

        public void DisplayDetails()
        {
            Console.WriteLine($"{StudentID} {Name} {Course} {Result} {Age}");
        }
    }
}