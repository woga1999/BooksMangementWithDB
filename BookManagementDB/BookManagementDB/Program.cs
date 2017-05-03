using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementDB
{
    class Program
    {
        private Singletone main = Singletone.getsingletone();
        static void Main(string[] args)
        {

            Singletone.getsingletone().getMenu().Connection();

        }
    }
}
