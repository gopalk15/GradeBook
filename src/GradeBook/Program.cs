using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book("Kaylin's Grade Book");

            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.5);
            Statistics stats = book.GetStatistics();
            Console.WriteLine($"The low grade is {stats.Low}");
            Console.WriteLine($"The high grade is {stats.High}");
            Console.WriteLine($"The average grade is {stats.Average}");





        }
    }
}
