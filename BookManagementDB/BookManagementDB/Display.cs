using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementDB
{
    class Display
    {
        public void Mainmenu()
        {
            Console.WriteLine("\t\tWelcome Online Libary");
            Console.WriteLine("\n\n\t\t1. Membership Login");
            Console.WriteLine("\n\t\t2. Membership Join");
            
            Console.WriteLine("\n\t\t ☞ : ");
        }

        public void AdministrationMode()
        {
            Console.WriteLine("\n\n\t\t1. Members List");
            Console.WriteLine("\n\t\t2. Books List");
            Console.WriteLine("\n\t3. Add Books");
            Console.WriteLine("\n\t4. Exit");
            Console.WriteLine("\n\t\t ☞ : ");
        }
        public void LoginMember()
        {
            Console.WriteLine("\n\n\t\t1. Want to Rent Book");
            Console.WriteLine("\n\t\t2. Return Book");
            Console.WriteLine("\n\t3. Confrim Which Books are rented and How long can rent");
            Console.WriteLine("\n\t4. Logout");
            Console.WriteLine("\n\t\t ☞ : ");
        }
        //public void JoinMember()
        //{
        //    Console.WriteLine("\n\n\t\tName: ");
        //    Console.WriteLine("\n\t\tBirth: ");
        //    Console.WriteLine("\n\tId: ");
        //    Console.WriteLine("\n\tPassword: ");
        //}
    }
}
