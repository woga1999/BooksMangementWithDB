﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementDB
{//화면에 출력 될 메서드들
    class Display
    {
        public void mainMenuDisplay()
        {
            Console.WriteLine("\t    Welcome Online Libary Program");
            Console.WriteLine("\n\n\t\t1. Membership Login");
            Console.WriteLine("\n\t\t2. Membership Join");
            Console.WriteLine("\n\t\t3. Exit");
            Console.Write("\n\n ");
        }

        public void administrationModeDisplay()
        {
            Console.WriteLine("\n\n\t1. Members Search");
            Console.WriteLine("\n\t2. Member Delete");
            Console.WriteLine("\n\t3. Add Books");
            Console.WriteLine("\n\t4. Delete Books");
            Console.WriteLine("\n\t5. Modify Books");
            Console.WriteLine("\n\t6. Exit");
            Console.WriteLine();
        }

        public void LoginMemberDisplay()
        {
            Console.WriteLine("\n\n\t\t1. Want to Rent Book");
            Console.WriteLine("\n\t\t2. Return Book");
            Console.WriteLine("\n\t\t3. Modify MyInfo");
            Console.WriteLine("\n\t\t4. Confirm Which Books are rented and How long can rent");
            Console.WriteLine("\n\t\t5. Searching Book");
            Console.WriteLine("\n\t\t6. Logout");
            Console.WriteLine();
        }

        public void loginDisplay(string message)
        {
            Console.WriteLine("\n         {0}                    \n", message);
            Console.WriteLine();
            Console.WriteLine("         +------------------------------------+");
            Console.WriteLine("         |                                    |");
            Console.WriteLine("         | Login    :                         |");
            Console.WriteLine("         |                                    |");
            Console.WriteLine("         +------------------------------------+");
            Console.WriteLine("         |                                    |");
            Console.WriteLine("         | Password :                         |");
            Console.WriteLine("         |                                    |");
            Console.WriteLine("         +------------------------------------+");
            Console.WriteLine();
        }

        public void membershipBar()
        {
            Console.WriteLine();
            Console.WriteLine(String.Format("\t ID\t\t  PassWord \t\t Name \t\t\tBirth"));
            Console.WriteLine("\t==========================================================================");
            Console.WriteLine("");
        }

        public void bookBar()
        {
            Console.WriteLine();
            Console.WriteLine(String.Format("\t No \tTitle \t\t\t\t\t Author \t\t Price \t\tIsrent"));
            Console.WriteLine("\t===================================================================================================");
            Console.WriteLine();

        }
        public void rentBookBar()
        {
            Console.WriteLine();
            Console.WriteLine(String.Format("\t  UserId \t      No \t Title \t\t\t\t RentDay \t\t ReturnDay"));
            Console.WriteLine("\t===========================================================================================================");
            Console.WriteLine();

        }
        public void status(string message)
        {
            Console.WriteLine("\t\t -{0}-          ", message);
            Console.WriteLine("                                       Wanna back put <back> in ID");
            Console.WriteLine("");
        }
        public void bookSearchDisplay()
        {
            Console.WriteLine("\n\n\t\t1. Books Searhing : All");
            Console.WriteLine("\n\t\t2. Books Searching : Author");
            Console.WriteLine("\n\t\t3. Books Searching : BookName");
            Console.WriteLine("\n\t\t4. Books Searching : Price");
            Console.WriteLine("\n\t\t5. Back");
        }
        public void memberSearchDisplay()
        {
            Console.WriteLine("\n\n\t\t1. Member Searhing : All");
            Console.WriteLine("\n\t\t2. Member Searching : ID");
            Console.WriteLine("\n\t\t3. Member Searching : Name");
            Console.WriteLine("\n\t\t4. Back");

        }
    }
}
