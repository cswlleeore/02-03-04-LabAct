using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRun.Student
{
    internal class Dacquel : Student
    {
        public override void Run()
        {
            string author = "Caswell";

            Console.WriteLine("=== GRADE CALCULATOR ===\n");
            Console.Write("Enter Student Name: ");
            string studentName = Console.ReadLine();

            Console.Write("\nHow many courses do you want to enter? ");
            int courseCount = int.Parse(Console.ReadLine());
            string[] courses = new string[courseCount];
            double[] grades = new double[courseCount];

            Console.Clear();
            Console.WriteLine("=== INPUT SECTION ===");
            Console.WriteLine("Enter the course name and grade for each subject.\n");

           
            for (int i = 0; i < courseCount; i++)
            {
                Console.Write($"Enter course {i + 1} name: ");
                courses[i] = Console.ReadLine();

                Console.Write($"Enter grade for {courses[i]} (69 - 100): ");
                grades[i] = double.Parse(Console.ReadLine());
                Console.WriteLine();
            }

            Console.Clear();
            Console.WriteLine("=== RESULTS ===");
            Console.WriteLine($"Student: {studentName}\n");

            double sum = 0;
            double maxGrade = grades[0];
            double minGrade = grades[0];

            for (int i = 0; i < courseCount; i++)
            {
                string equivalent = GetEquivalent(grades[i]);

                Console.WriteLine($"{courses[i]} | {grades[i]} | {equivalent}");

                sum += grades[i];
                maxGrade = Math.Max(maxGrade, grades[i]);
                minGrade = Math.Min(minGrade, grades[i]);

                if (equivalent == "5.00")
                {
                    Console.WriteLine("\n⚠ A failing grade was found. Stopping calculations early...");
                    break;
                }
            }

            double average = sum / courseCount;
            string overallEquivalent = GetEquivalent(average);

            Console.WriteLine("\n=== CALCULATIONS ===");
            Console.WriteLine("Maximum Grade: " + maxGrade);
            Console.WriteLine("Minimum Grade: " + minGrade);
            Console.WriteLine("Average Grade: " + Math.Round(average, 2));
            Console.WriteLine("Overall Grade: " + Math.Round(average, 2));
            Console.WriteLine("Equivalent Grade: " + overallEquivalent);

            Console.WriteLine("\nAuthor: " + author);
        }

        static string GetEquivalent(double grade)
        {
            if (grade >= 97 && grade <= 100) return "1.00";
            else if (grade >= 94) return "1.25";
            else if (grade >= 91) return "1.50";
            else if (grade >= 88) return "1.75";
            else if (grade >= 85) return "2.00";
            else if (grade >= 82) return "2.25";
            else if (grade >= 79) return "2.50";
            else if (grade >= 76) return "2.75";
            else if (grade == 69) return "3.00";
            else return "5.00"; // Fail
        }
    }
}
