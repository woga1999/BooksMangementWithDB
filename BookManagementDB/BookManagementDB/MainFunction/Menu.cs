using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using MySql.Data.MySqlClient;

namespace BookManagementDB
{
    class Menu
    {
        private static ShareClass share = ShareClass.getShareClass();
        string input = null;

        public void mainMenu()
        {
            share.getDisplay().mainMenuDisplay();
            input = share.getException().exceptKey("1", "2", "/OpenAdmin");

            if(input == "1") { Console.Clear(); share.getLogin().login(); }
            else if(input =="2") { Console.Clear();  share.getMember().addMember(); }
            else if(input == "/OpenAdmin") { Console.Clear(); share.getLogin().adminLogin(); }
        }

        public void menuLoginAdmin()
        {
            share.getDisplay().administrationModeDisplay();
            input = share.getException().exceptSwitchEntry(1, 5);

            switch (input)
            {
                case "1":
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    break;
            }
        }

        public void menuOnLogin()
        {
            share.getDisplay().LoginMemberDisplay();
            input = share.getException().exceptSwitchEntry(1, 4);

            switch (input)
            {
                case "1":
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
            }
        }
    }
}
