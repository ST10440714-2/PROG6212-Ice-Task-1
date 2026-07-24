using System;
using System.Linq;

namespace StudentResultsSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentCollection studentCollection = new StudentCollection();

            // Add 15 students
            studentCollection.AddStudent(new Student { StudentID = 1, Name = "Ethan", Course = "PRSE", Result = 92, Age = 21 });
            studentCollection.AddStudent(new Student { StudentID = 2, Name = "Mia", Course = "INSY", Result = 74, Age = 19 });
            studentCollection.AddStudent(new Student { StudentID = 3, Name = "Noah", Course = "PROG", Result = 58, Age = 22 });
            studentCollection.AddStudent(new Student { StudentID = 4, Name = "Ava", Course = "CLOUD", Result = 87, Age = 20 });
            studentCollection.AddStudent(new Student { StudentID = 5, Name = "Lucas", Course = "PRSE", Result = 46, Age = 23 });
            studentCollection.AddStudent(new Student { StudentID = 6, Name = "Zoe", Course = "INSY", Result = 81, Age = 20 });
            studentCollection.AddStudent(new Student { StudentID = 7, Name = "Daniel", Course = "PROG", Result = 69, Age = 21 });
            studentCollection.AddStudent(new Student { StudentID = 8, Name = "Chloe", Course = "CLOUD", Result = 95, Age = 22 });
            studentCollection.AddStudent(new Student { StudentID = 9, Name = "Ryan", Course = "PRSE", Result = 63, Age = 19 });
            studentCollection.AddStudent(new Student { StudentID = 10, Name = "Olivia", Course = "INSY", Result = 78, Age = 20 });
            studentCollection.AddStudent(new Student { StudentID = 11, Name = "Caleb", Course = "PROG", Result = 54, Age = 24 });
            studentCollection.AddStudent(new Student { StudentID = 12, Name = "Layla", Course = "CLOUD", Result = 89, Age = 21 });
            studentCollection.AddStudent(new Student { StudentID = 13, Name = "Nathan", Course = "PRSE", Result = 71, Age = 22 });
            studentCollection.AddStudent(new Student { StudentID = 14, Name = "Emily", Course = "INSY", Result = 38, Age = 18 });
            studentCollection.AddStudent(new Student { StudentID = 15, Name = "Jason", Course = "PROG", Result = 97, Age = 23 });

            // Display all students
            Console.WriteLine("{0,-10}{1,-15}{2,-20}{3,-10}{4,-5}",
                "Student ID", "Name", "Course", "Result", "Age");
            Console.WriteLine(new string('-', 65));

            foreach (Student student in studentCollection.GetAllStudents())
            {
                Console.WriteLine("{0,-10}{1,-15}{2,-20}{3,-10}{4,-5}",
                    student.StudentID,
                    student.Name,
                    student.Course,
                    student.Result,
                    student.Age);
            }

            Console.WriteLine();

            //==================================================
            // Question 5.1
            //==================================================

            Console.WriteLine("Students sorted with result higher than 50");

            var passedStudents = studentCollection.GetAllStudents()
              .Where(s => s.Result >= 50)
              .OrderByDescending(s => s.Result)
              .ThenBy(s => s.Name)
              .Select(s => new
               {
              s.Name,
              s.Course,
              s.Result
             });

            foreach (var student in passedStudents)
            {
                Console.WriteLine();
                Console.WriteLine("Name: " + student.Name);
                Console.WriteLine("Course: " + student.Course);
                Console.WriteLine("Result: " + student.Result);
            }

            //==================================================
            // Question 5.2
            //==================================================

            double average = studentCollection.GetAllStudents().Average(s => s.Result);

            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Overall Average: " + average.ToString("F2"));

            //==================================================
            // Question 5.3
            //==================================================

            Console.WriteLine();
            Console.WriteLine("Students Above Average");

            var aboveAverage = studentCollection.GetAllStudents()
                .Where(s => s.Result > average)
                .OrderByDescending(s => s.Result);

            foreach (var student in aboveAverage)
            {
                Console.WriteLine($"{student.Name,-15}{student.Course,-20}{student.Result}");
            }

            //==================================================
            // Question 5.4
            //==================================================

            Console.WriteLine();
            Console.Write("Enter a course name: ");
            string course = Console.ReadLine();

            var studentsInCourse = studentCollection.GetAllStudents()
                .Where(s => s.Course.Equals(course, StringComparison.OrdinalIgnoreCase));

            if (studentsInCourse.Any())
            {
                Console.WriteLine();

                foreach (var student in studentsInCourse)
                {
                    Console.WriteLine($"{student.Name,-15}{student.Result}");
                }
            }
            else
            {
                Console.WriteLine("No students were found for the selected course.");
            }

            //==================================================
            // Question 5.5
            //==================================================

            Console.WriteLine();
            Console.WriteLine("Students Grouped By Course");

            var groups = studentCollection.GetAllStudents()
                .GroupBy(s => s.Course);

            foreach (var group in groups)
            {
                Console.WriteLine();
                Console.WriteLine("Course: " + group.Key);

                foreach (var student in group)
                {
                    Console.WriteLine($"{student.Name,-15}{student.Result}");
                }
            }

            //==================================================
            // Question 5.6
            //==================================================

            Console.WriteLine();
            Console.WriteLine("Top 3 Students");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("{0,-10}{1,-15}{2,-20}{3,-10}",
                "Position", "Name", "Course", "Result");

            var topThree = studentCollection.GetAllStudents()
                .OrderByDescending(s => s.Result)
                .Take(3)
                .ToList();

            for (int i = 0; i < topThree.Count; i++)
            {
                Console.WriteLine("{0,-10}{1,-15}{2,-20}{3,-10}",
                    i + 1,
                    topThree[i].Name,
                    topThree[i].Course,
                    topThree[i].Result);
            }

            Console.ReadLine();
        }
    }
}

/*
Question 1.1 – Definition of an Indexer

An indexer is a special feature in C# that allows an object to be accessed
using array-style syntax without exposing the underlying collection directly.

Purpose of an Indexer:
- The purpose of an indexer is to provide an easy and convenient way to access
  or modify data stored inside an object using an index.

How an Indexer allows an object to be accessed like an array:
- An indexer enables objects to be accessed with square brackets ([]), just
  like an array. For example:
      studentCollection[0]
  instead of calling a method such as GetStudent(0).

Role of the 'this' keyword:
- The 'this' keyword is used to declare an indexer because it represents the
  current object. It tells the compiler that the object itself can be indexed.
  Example:
      public Student this[int index]
      {
          get { return students[index]; }
          set { students[index] = value; }
      }

Difference between an Indexer and a Normal Property:
- A normal property has a name and is used to access a single value, for
  example:
      student.Name
- An indexer does not have a name. Instead, it uses the 'this' keyword and
  allows access to multiple values by using an index, for example:
      studentCollection[0]
*/
