using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementDB
{
    class Program
    {
        static void Main(string[] args)
        {
            //ShareClass share = ShareClass.getShareClass();
            //share.getMember().addMember();
            Menu menu = new Menu();
            menu.mainMenu();
        }
    }
}
