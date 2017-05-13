using System;
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
                Console.SetCursorPosition(33, 10);
                Console.Write("\t\t\t : ");
                input = Console.ReadLine();
                if (input == "") { continue; }
                else if (input == key) { break; }
                else if (input == key2) { break; }
                else if (input == key3) { break; }
                else if (input == key4) { break; }
                else
                {
                    continue;
                }
            }
            return input;
        }

        public string exceptSwitchEntry(int first, int last)
        {
            string number = null;

            while (true)
            {
                Console.Write("\n\t\t : ");
                number = Console.ReadLine();
                Regex regex = new Regex(@"^[가-힣a-zA-Z]");
                Boolean ismatch = regex.IsMatch(number);
                Regex regex2 = new Regex(@"^[0-9]*$");
                Boolean ismatch2 = regex2.IsMatch(number);
                if (number == "")
                {
                    continue;
                }
                else if (ismatch)
                {continue;
                }
                else if (ismatch2)
                {
                    if (Int32.Parse(number) >= first && Int32.Parse(number) <= last)
                    {
                        break;
                    }
                    else
                    {
                        continue;
                    }
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
      
        public string matchpw()
        {
            bool isMatch = true;
            while (true)
            {
                input = inputpwd();
                isMatch = share.getMemberTable().checkIdOfPwd(share.getLoginId(), input);
                if (isMatch.Equals(true)) { break; }
                else if(isMatch.Equals(false)) { continue; }
            }

            return input;
        }
        
        public string inputIdWhenAdd(string direct) //ID를 입력했을 때 중복이면 입력하지못한다.
        {
            while (true)
            {
                Console.Write("{0} : ", direct);
                input = Console.ReadLine();
                bool IsExistedId = share.getMemberTable().IsIdDuplication(input);
                Regex regex = new Regex(@"^[a-zA-z0-9]{6,10}");
                Boolean ismatch = regex.IsMatch(input);
                if (ismatch)
                {
                    if (IsExistedId.Equals(true)) { Console.WriteLine("\t\t존재하는 ID입니다."); }
                    else if (IsExistedId.Equals(false)) { break; }
                }
                else if(input == "back") { Console.Clear();  share.getMenu().mainMenu(); }
                else if (!ismatch) { Console.WriteLine("아이디 설정은 6~10자리 사이 숫자나 영어로 저장 가능합니다."); }
            }
            return input;
        }
        public string inputIdWhenDelete(string direct)
        {
            while (true)
            {
                Console.Write("{0} : ", direct);
                input = Console.ReadLine();
                bool IsExistedId = share.getMemberTable().IsIdDuplication(input);
                Regex regex = new Regex(@"^[a-zA-z0-9]{6,10}");
                Boolean ismatch = regex.IsMatch(input);
                if (ismatch)
                {
                    if (IsExistedId.Equals(true)) { break; }
                    else if (IsExistedId.Equals(false))
                    {
                        Console.WriteLine("\t\t존재하지 않는 ID입니다.");
                        Console.WriteLine("\t\t목록을 참고하세요.                       <back> : 뒤로가기");
                    }
                }
                else if (input == "back") { Console.Clear(); share.getMenu().menuLoginAdmin(); }
                else if (!ismatch) { Console.WriteLine("올바른 아이디 형식이 아닙니다."); }
                else { continue; }
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
        public string exceptSearchWord(string put)
        {
            while (true)
            {
                Console.Write("\n\t\t : ");
                input = Console.ReadLine();
                Regex regex = new Regex(@"^[가-힣a-zA-Z0-9 ]");
                Boolean ismatch = regex.IsMatch(input);
                bool isFirst = share.getMemberTable().isMatchMember(put, input);
                if (ismatch)
                {
                    if (isFirst.Equals(true)) { break; }
                    if (input == "back") { share.getMenu().searchAboutMembers(); }
                    else if (isFirst.Equals(false)) { Console.WriteLine("다시 입력해주세요"); }
                }
                else if (!ismatch) { Console.WriteLine("다시 입력해주세요"); }
            }
            return input;
        }
        public void goBack(string where)
        {
            
            input = Console.ReadLine();
            Regex regex = new Regex(@"^[a-z]");
            Boolean ismatch = regex.IsMatch(input);
            if (ismatch)
            {
                if (input == "back" && where == "membersearch") { share.getMenu().searchAboutMembers(); }
                if (input == "back" && where == "booksearch") { share.getMenu().searchAboutBook(); }
            }
            else if (!ismatch) { Console.WriteLine("Nope"); }
        }
        public string inputNo()
        {
            while (true)
            {
                
                Console.SetCursorPosition(22, 19);
                input = Console.ReadLine();
                bool IsExistedNo = share.getBookTable().IsNoDuplication(input);
                Regex regex = new Regex(@"^[0-9]");
                Boolean ismatch = regex.IsMatch(input);
                if (ismatch)
                {
                    if (IsExistedNo.Equals(true)) { Console.WriteLine("\t\t존재하는 No입니다.     \n"); }
                    else if (IsExistedNo.Equals(false)) { break; }
                }
                else if (input == "back") { Console.Clear(); share.getMenu().menuLoginAdmin(); }
                else if (!ismatch) { Console.WriteLine("\t\t숫자 입력만 가능합니다.");
                }
            }
            return input;
        }
        public string inputNoWhenDelete()
        {
            while (true)
            {
                Console.WriteLine("\n\t Put BookNo : ");
                input = Console.ReadLine();
                bool IsExistedNo = share.getBookTable().IsNoDuplication(input);
                Regex regex = new Regex(@"^[0-9]");
                Boolean ismatch = regex.IsMatch(input);
                if (ismatch)
                {
                    if (IsExistedNo.Equals(true)) { break; }
                    else if (IsExistedNo.Equals(false)) { Console.WriteLine("\t\t존재하지 않는 No입니다.       \n"); }
                }
                else if (input == "back") { Console.Clear(); share.getMenu().menuLoginAdmin(); break; }
                else if (!ismatch) { Console.WriteLine("\t\t숫자 입력만 가능합니다."); }
            }
            return input;
        }

        public string checkRentBookNo()
        {
            while (true)
            {
                Console.Write("\n\t BookNo : ");
                input = Console.ReadLine();
                bool IsMatchNo = share.getRentTable().checkRentBookNo(input);
                Regex regex = new Regex(@"^[0-9]");
                Boolean ismatch = regex.IsMatch(input);
                if (ismatch)
                {
                    if (IsMatchNo.Equals(true)) { break; }
                    else if (IsMatchNo.Equals(false)) { Console.WriteLine("\t\t목록에 없는 No입니다.       \n"); }
                }
                else if (!ismatch) { Console.WriteLine("\t\t숫자 입력만 가능합니다."); }
            }
            return input;
        }

        public string checkRentBookName(string no)
        {
            while (true)
            {
                Console.Write("\n\t BookName : ");
                input = Console.ReadLine();
                bool IsMatchName = share.getRentTable().checkRentBookName(no, input);
                Regex regex = new Regex(@"^[가-힣a-zA-z]");
                Boolean ismatch = regex.IsMatch(input);
                if (ismatch)
                {
                    if (IsMatchName.Equals(true)) { break; }
                    else if (IsMatchName.Equals(false)) { Console.WriteLine("\t\t 책 이름과 번호가 맞지않습니다.       \n"); }
                }
                else if (!ismatch) { Console.WriteLine("\t\t다시 입력해주세요~"); }
            }
            return input;
        }

    }

}
