using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook
{
    class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
            Name = name;
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double studentGrade)
        {
            using(StreamWriter writer = File.AppendText($"C:\\Users\\kaylin\\git\\GradeBook\\{Name}.txt"))
            {
                writer.WriteLine(studentGrade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
        }

        public override Statistics GetStatistics()
        {
            Statistics result = new Statistics();
            using (StreamReader reader = File.OpenText($"C:\\Users\\kaylin\\git\\GradeBook\\{Name}.txt"))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    double number = double.Parse(line);
                    result.Add(number);
                    //Reads Next line
                    line = reader.ReadLine();

                }
                
            }

            return result;
        }
    }
}
