﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BookManagementDB
{//입력, 겹칠 수 있는 것들, 오류 날 수 있는 것들의 예외 처리 등 
    class Exception
    { 
        string input = null;
        private static ShareClass share = ShareClass.getShareClass();
        public string exceptKey(string key, string key2, string key3, string key4)
        {
            
            while (true)
            {
                Console.Write("\t\t\t\t : ");
                input = Console.ReadLine();
                if (input == "") { continue; }
                else if (input == key) { break; }
                else if (input == key2) { break; }
                else if(input == key3) { break; }
                else if (input == key4) { break; }
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
            StringBuilder stringbuilder = new StringBuilder();
            while (true)
            {
                ConsoleKeyInfo cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }

                if (cki.Key == ConsoleKey.Backspace)
                {
                    if (stringbuilder.Length > 0)
                    {
                        Console.Write("\b\0\b");
                        stringbuilder.Length--;
                    }

                    continue;
                }

                Console.Write('*');
                stringbuilder.Append(cki.KeyChar);
            }

            return stringbuilder.ToString();
        }

        public string inputId(string direct) //back이 들어있는 예외처리함수
        {
            while (true)
            {
                Console.Write("{0} : ", direct);
                input = Console.ReadLine();
                bool IsExistId = share.getDataBase().IsIdDuplication(input);
                Regex regex = new Regex(@"^[a-zA-z0-9]{6,10}");
                Boolean ismatch = regex.IsMatch(input);
                if (ismatch)
                {
                    if (IsExistId == true) { Console.WriteLine("\t\t존재하는 ID입니다."); }
                    else if (IsExistId == false) { break; }
                }
                else if(input == "back") { share.getMenu().mainMenu(); }
                else if (!ismatch) { Console.WriteLine("아이디 설정은 6~10자리 사이 숫자와영어 조합만 가능합니다."); }
            }
            return input;
        }

        public string onlyNum(string message)
        {
            while (true)
            {
                Console.Write("\t {0} : ", message);
                input = Console.ReadLine();
                Regex regex = new Regex(@"^[0-9]");
                Boolean ismatch = regex.IsMatch(input);
                if (ismatch)
                {
                    break; 
                }
                else if (!ismatch) { Console.WriteLine("숫자만 입력 가능합니다"); }
            }
            return input;
        }

        public string notEnter(string message)
        {
            while (true)
            {
                Console.Write("\t {0} : ", message);
                input = Console.ReadLine();
                //Regex regex = new Regex(@"^[가-힣a-zA-Z]");
                //Boolean ismatch = regex.IsMatch(input);
                if (input == "")
                {
                    continue;
                }
                else
                {
                    break;
                }
            }
            return input;
        }
    }
    
}
