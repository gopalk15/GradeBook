using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook
{
    /* In dotnet every class has a base class
      Every class will derive from System.Object (System namespace) */
    public class NamedObject
    {
        public string Name { get; set; }
        
        public NamedObject(string name)
        {
            Name = name;
        }
    }
}
