using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementDB
{
    class Login
    {
        string inputId = null;
        string inputPwd = null;
        private static ShareClass share = ShareClass.getShareClass();
        public void login()
        {
            Console.Clear();
            share.getDisplay().loginDisplay("Member Login");
            Console.SetCursorPosition(22, 6);
            inputId = Console.ReadLine(); 
            Console.SetCursorPosition(22, 10);
            inputPwd = share.getException().inputpwd(); //패스워드 *표시 하는 예외처리
             share.getMemberTable().loginUsingDB(inputId, inputPwd); 
            
        }
        public void adminLogin()
        {
            Console.Clear();
            share.getDisplay().loginDisplay("Administrator Login");
            Console.SetCursorPosition(22, 6);
            inputId = Console.ReadLine();
            Console.SetCursorPosition(22, 10);
            inputPwd = share.getException().inputpwd();
            if (inputId == "admin")
            {
                if (inputPwd == "admin")
                {
                    share.getMenu().menuLoginAdmin();
                }
                else
                {
                    Console.SetCursorPosition(22, 15);
                    Console.WriteLine("접근 불가");
                }
            }
            else
            {
                Console.SetCursorPosition(22, 15);
                Console.WriteLine("접근 불가");
            }
            share.getMenu().mainMenu();
        }
    }
}
