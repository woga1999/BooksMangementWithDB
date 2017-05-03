using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BookManagementDB
{
    class Exception
    {
        string input = null;
        private static ShareClass share = ShareClass.getShareClass();
        public string exceptKey(string key, string key2, string key3)
        {
            
            while (true)
            {
                Console.Write("\t\t\t\t : ");
                input = Console.ReadLine();
                if (input == "") { continue; }
                else if (input == key) { break; }
                else if (input == key2) { break; }
                else if(input == key3) { break; }
                else
                    continue;
            }
            return input;
        }

        public string exceptSwitchEntry(int first, int last)
        {
            string number = null;

            while (true)
            {
                Console.Write("\t  : ");
                number = Console.ReadLine();
                Regex regex = new Regex(@"^[가-힣a-zA-Z]");
                Boolean ismatch = regex.IsMatch(number);
                if (number == "")
                {
                    continue;
                }
                else if (ismatch) { continue; }
                else if (Int32.Parse(number) >= first && Int32.Parse(number) <= last)
                {
                    break;
                }

                else
                {
                    continue;
                }
            }
            return number;

        }
        public string inputpwd()
        {
            input = Console.ReadLine();

            return input;
        }
        public string inputId(string direct)
        {
            while (true)
            {
                Console.Write("{0} : ", direct);
                input = Console.ReadLine();
                Regex regex = new Regex(@"^[a-zA-z0-9]{6,10}");
                Boolean ismatch = regex.IsMatch(input);
                if (ismatch)
                {
                    break;
                }
                else if(input == "back") { share.getMenu().mainMenu(); }
                else if (!ismatch) { Console.WriteLine("아이디 설정은 6~10자리 사이 숫자와영어 조합만 가능합니다."); }
            }
            return input;
        }
    }
    
}
