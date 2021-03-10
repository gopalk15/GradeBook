using System;
using System.Globalization;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new DiskBook("Kaylin's Grade Book");
            book.GradeAdded += OnGradeAdded;
            EnterGrade(book);
            Statistics stats = book.GetStatistics();
           
            Console.WriteLine($"The low grade is {stats.Low}");
            Console.WriteLine($"The high grade is {stats.High}");
            Console.WriteLine($"The average grade is {stats.Average}");
            Console.WriteLine($"The letter grade is {stats.Letter}");

        }

        private static void EnterGrade(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Input Student Grade or 'q' to quit ");
                string input = Console.ReadLine();
                if (input.Equals("Q") || input.Equals("q"))
                {
                    break;
                }

                try
                {
                    double inputGrade = double.Parse(input, CultureInfo.InvariantCulture);
                    book.AddGrade(inputGrade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added");

        }
    }
}
