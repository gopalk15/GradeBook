using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook
{
    /*
      Interfaces are similar to an abstract class, however an interface is pure
     It only gives a blueprint of the kind of members (attributes and methods) a class must have
     (at a minium). Unlike a abstract class that can contain explictly defined methods and fields

     An Interface desicbes the members that should be avalible on a specfic object type.
     This means that it is assumed that members defined in an interface are public

  */
    public interface IBook
    {
        void AddGrade(double studentGrade);
        string Name { get; }
        event GradeAddedDelegate GradeAdded;

    }
}
