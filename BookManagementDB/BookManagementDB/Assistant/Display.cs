using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementDB
{
    class Display
    {
        public void mainMenuDisplay()
        {
            Console.WriteLine("\t\tWelcome Online Libary");
            Console.WriteLine("\n\n\t\t1. Membership Login");
            Console.WriteLine("\n\t\t2. Membership Join");
            Console.WriteLine("\n\t\t3. Exit");
            Console.Write("\n\n ");
        }

        public void administrationModeDisplay()
        {
            Console.WriteLine("\n\n\t\t1. Members List");
            Console.WriteLine("\n\t\t2. Books List");
            Console.WriteLine("\n\t3. Add Books");
            Console.WriteLine("\n\t4. Exit");
            Console.WriteLine("\n\t\t ☞ : ");
        }

        public void LoginMemberDisplay()
        {
            Console.WriteLine("\n\n\t\t1. Want to Rent Book");
            Console.WriteLine("\n\t\t2. Return Book");
            Console.WriteLine("\n\t\t3. Modify myinfo");
            Console.WriteLine("\n\t4. Confirm Which Books are rented and How long can rent");
            Console.WriteLine("\n\t5. Logout");
            Console.WriteLine("\n\t\t ☞ : ");
        }

        public void login()
        {
            Console.WriteLine("      +-------------------------------+");
            Console.WriteLine("      |                               |");
            Console.WriteLine("      | Login    :                    |");
            Console.WriteLine("      |                               |");
            Console.WriteLine("      +-------------------------------+");
            Console.WriteLine("      |                               |");
            Console.WriteLine("      | Password :                    |");
            Console.WriteLine("      |                               |");
            Console.WriteLine("      +-------------------------------+");
            Console.WriteLine();
        }

        public void membershipBar()
        {
            Console.WriteLine();
            Console.WriteLine(String.Format("\tID\t\tPassWord\t\tName\t\tBirth"));
            Console.WriteLine("====================================================================");
            Console.WriteLine("");
        }

        public void bookBar()
        {
            Console.WriteLine();
            Console.WriteLine(String.Format("\tTitle\t\tAuthor\t\tPrice\t\tVolumn"));
            Console.WriteLine("====================================================================");
            Console.WriteLine();

        }
    }
}
