using System;
using TestRun.Student;

    internal class StudentSelector
    {
        public static void RunSelectedStudent(string name)
        {
        //DO NOT TOUCH THIS FILE
        //DO NOT TOUCH THIS FILE
        //DO NOT TOUCH THIS FILE

        string fullClassName = $"TestRun.Student.{name}";
            Type? studentType = Type.GetType(fullClassName);

            if (studentType == null)
            {
                // Try to get the type from the current assembly if not found
                studentType = typeof(Student).Assembly.GetType(fullClassName);
            }

            if (studentType != null && typeof(Student).IsAssignableFrom(studentType))
            {
                Student student = (Student)Activator.CreateInstance(studentType)!;
                student.Run();
            }
            else
            {
                Console.WriteLine($"Could not find class '{name}'. Did you name it correctly?");
            }
        }
    }

