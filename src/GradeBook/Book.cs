using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook
{
    /*Abstract Class

   abstract classes can have abstract methods which tell the C# complier
   that any class that inhertitce from the abstract class, must have a method 
   (AddGrade in this case) with the same name and signiture that explicty states the
   implentation of the method.

   TL;DR Abstract method -> Don't have to explcity define a method
         Class inhertiing from Abstract Class -> must `override` method (using override keyword)
         and explictilty define the method (same with virtual methods)

  */
    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double studentGrade);

        public abstract Statistics GetStatistics();

    }
}
