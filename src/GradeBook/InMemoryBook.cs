using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

        //C Sharp is a single inhertencae Langauage, but you can specfiy more than one Interface
        public class InMemoryBook : Book
        {
            private List<double> grades;

            public string Name { get; set; }

            //Readonly fields can only be overwirriten in constructors
            readonly string category = "Science";

            /*
             const keyword is more strict than readonly -- can only be written when intialised 
             a public const field is read avalible to the rest of the program

            const field is treated at static member(Attribute of a class not instance)
             */
            public const string CLASSGRADE = "9A";

            public InMemoryBook(string name) : base(name)
            {
                grades = new List<double>();
                Name = name;
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

            public override void AddGrade(double studentGrade)
            {
                if (studentGrade <= 100 && studentGrade >= 0)
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

            public override event GradeAddedDelegate GradeAdded;


            public override Statistics GetStatistics()
            {
                Statistics result = new Statistics();


                foreach (double grade in grades)
                {
                    result.Add(grade);
                }

                return result;
            }
        }
    }

