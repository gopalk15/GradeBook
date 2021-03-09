using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook
{
    public class Book
    {
        private List<double> grades;
        public string BookName;

        public Book(string name)
        {
            grades = new List<double>();
            BookName = name;
        }

        public void AddGrade(double studentGrade)
        {
            grades.Add(studentGrade);
        }

        public Statistics GetStatistics()
        {
            Statistics result = new Statistics();

            result.Average = 0.0;
            result.Low = double.MaxValue;
            result.High = double.MinValue;

            foreach (double grade in grades)
            {
                //Compute sum 
                result.Average += grade;
                //Find lowest Grade
                result.Low = Math.Min(grade, result.Low);
                //Find higest Grade
                result.High = Math.Max(grade, result.High);
            }

            //Compute Average 
            result.Average /= grades.Count;

            return result;
        }
    }
}
