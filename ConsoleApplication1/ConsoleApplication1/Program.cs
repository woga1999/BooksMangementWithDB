using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = "Tom,Scott,Bob".Split(',').ToList<string>();
            foreach(string name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
