using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);
    public class Book
    {
        private List<double> grades;
        
        public string BookName { get; set; }

        //Readonly fields can only be overwirriten in constructors
        readonly string category = "Science";

        /*
         const keyword is more strict than readonly -- can only be written when intialised 
         a public const field is read avalible to the rest of the program

        const field is treated at static member(Attribute of a class not instance)
         */
        public const string CLASSGRADE = "9A";

        public Book(string name)
        {
            grades = new List<double>();
            BookName = name;
        }

        
        /*
         Methodoverloading...
        C# looks at the signiture of the method not just the name of the method
        -Signiture includes things such as parameter types and the number of parameters
        
        the method AddGrade that takes a `char` has a different signiture 
        to the method AddGrade that takes a `double`.

        Note: return type is not included in the signiture of a method
         */
        public void AddGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                case 'D':
                    AddGrade(60);
                    break;
                default:
                    AddGrade(0);
                    break;
            } 
        }

        public void AddGrade(double studentGrade)
        {
            if(studentGrade <= 100 && studentGrade >= 0)
            {
                grades.Add(studentGrade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(studentGrade)}");
            }
        }


        //Creating a event member

        public event GradeAddedDelegate GradeAdded;


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
            switch (result.Average)
            {
                case var d when d >= 90.0:
                    result.Letter = 'A';
                    break;
                
                case var d when d >= 80.0:
                    result.Letter = 'B';
                    break;

                
                case var d when d >= 70.0:
                    result.Letter = 'C';
                    break;

                case var d when d >= 60.0:
                    result.Letter = 'D';
                    break;

                default:
                    result.Letter = 'F';
                    break;


            }

            return result;
        }
    }
}
