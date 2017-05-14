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
                Regex regex = new Regex(@"^[a-zA-z][a-zA-z0-9]{5,15}$");
                Boolean ismatch = regex.IsMatch(input);
                if (ismatch)
                {
                    bool IsExistedId = share.getMemberTable().IsIdDuplication(input);
                    if (IsExistedId.Equals(true)) { Console.WriteLine("\t\t존재하는 ID입니다."); }
                    else if (IsExistedId.Equals(false)) { break; }
                }
                else if(input == "back") { Console.Clear();  share.getMenu().mainMenu(); }
                else if (!ismatch) { Console.WriteLine("ID는 영문자로 시작하여 숫자를 포함할 수 있으며(한글 및 특수문자 제외), 6자리 이상 16자리 이하입니다."); }
            }
            return input;
        }
        public string inputIdWhenDelete(string direct)
        {
            while (true)
            {
                Console.Write("{0} : ", direct);
                input = Console.ReadLine();
                Regex regex = new Regex(@"^[a-zA-z][a-zA-z0-9]{5,15}$");
                Boolean ismatch = regex.IsMatch(input);
                if (ismatch)
                {

                    bool IsExistedId = share.getMemberTable().IsIdDuplication(input);
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
                Regex regex = new Regex(@"^[0-9]*$");
                Boolean ismatch = regex.IsMatch(input);
                if (ismatch)
                {
                    if (input == "") { continue; }
                    else
                    {
                        break;
                    }
                }
                else if (!ismatch) { Console.WriteLine("\t 숫자만 입력 가능합니다"); }
            }
            return input;
        }

        public string onlySixNumDigits()
        {
            while (true)
            {
                Console.Write("\t Birth(Only 6digits): ");
                input = Console.ReadLine();
                Regex regex = new Regex(@"^[0-9]{6}*$");
                Boolean ismatch = regex.IsMatch(input);
                if (ismatch)
                {
                    if (input == "") { continue; }
                    else
                    {
                        break;
                    }
                }
                else if (!ismatch) { Console.WriteLine("\t 6자리 숫자만 입력 가능합니다"); }
            }
            return input;
        }
        public string exceptString(string message)
        {
            while (true)
            {
                Console.Write("\t {0} : ", message);
                input = Console.ReadLine();
                Regex regex = new Regex(@"^[가-힣a-zA-Z]");
                Boolean ismatch = regex.IsMatch(input);
                if (ismatch)
                {
                    break;
                }
                else if (!ismatch) { Console.WriteLine("\t다시 입력해주세요"); }
            }
            return input;
        }
        public string exceptSearchWord(string put)
        {
            while (true)
            {
                Console.Write("\n\t\t : ");
                input = Console.ReadLine();
                Regex regex = new Regex(@"^[가-힣a-zA-Z0-9]");
                Boolean ismatch = regex.IsMatch(input);
                if (ismatch)
                {
                    bool isFirst = share.getMemberTable().isMatchMember(put, input);
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
            while (true)
            {
                Console.Write("\t wanna back put <back> : ");
                input = Console.ReadLine();
                Regex regex = new Regex(@"^[a-z]");
                Boolean ismatch = regex.IsMatch(input);
                if (ismatch)
                {
                    if (input == "back" && where == "membersearch") { share.getMenu().searchAboutMembers(); break; }
                    if (input == "back" && where == "booksearch") { share.getMenu().searchAboutBook(); break; }
                    if (input == "back" && where == "memberlogin") { share.getMenu().menuOnLogin(); break; }
                }
                else if (!ismatch) { Console.WriteLine("Nope"); }
            }
        }

        public string inputNo()
        {
            while (true)
            {
                Console.SetCursorPosition(22, 19);
                input = Console.ReadLine();
                Regex regex = new Regex(@"^[0-9]");
                Boolean ismatch = regex.IsMatch(input);
                if (ismatch)
                {
                    bool IsExistedNo = share.getBookTable().IsNoDuplication(input);
                    if (IsExistedNo.Equals(true)) { Console.WriteLine("\t\t존재하는 No입니다.     \n"); }
                    else if (IsExistedNo.Equals(false)) { break; }
                }
                else if (input == "back") { Console.Clear(); share.getMenu().menuLoginAdmin(); }
                else if (!ismatch)
                {
                    Console.WriteLine("\t\t숫자 입력만 가능합니다.");
                }
            }
            return input;
        }
        public string inputNoWhenDelete()
        {
            while (true)
            {
                Console.Write("\n\t Put BookNo : ");
                input = Console.ReadLine();
                Regex regex = new Regex(@"^[0-9]");
                Boolean ismatch = regex.IsMatch(input);
                if (ismatch)
                {
                    bool isExistedNo = share.getBookTable().IsNoDuplication(input);
                    if (isExistedNo.Equals(true)) { break; }
                    else if (isExistedNo.Equals(false)) { Console.WriteLine("\t\t존재하지 않는 No입니다.       \n"); }
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
                Regex regex = new Regex(@"^[0-9]");
                Boolean ismatch = regex.IsMatch(input);
                if (ismatch)
                {
                    bool isMatchNo = share.getRentTable().checkRentBookNo(input);
                    if (isMatchNo.Equals(true)) { break; }
                    else if (isMatchNo.Equals(false)) { Console.WriteLine("\t\t목록에 없는 No입니다.       \n"); }
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
                Regex regex = new Regex(@"^[가-힣a-zA-z]");
                Boolean ismatch = regex.IsMatch(input);
                if (ismatch)
                {
                    bool isMatchName = share.getRentTable().checkRentBookName(no, input);
                    if (isMatchName.Equals(true)) { break; }
                    else if (isMatchName.Equals(false)) { Console.WriteLine("\t\t 빌린 책 이름과 번호가 맞지않습니다.       \n"); }
                }
                else if (!ismatch) { Console.WriteLine("\t\t다시 입력해주세요~"); }
            }
            return input;
        }
        
        public string checkNoWhenRent()
        {
            while (true)
            {
                Console.Write("\t BookNo : ");
                input = Console.ReadLine();
                bool isCheckNo = share.getBookTable().checkNo(input);
                
                if (isCheckNo.Equals(true))
                {
                    bool isRenting = share.getBookTable().checkIsRent(input);
                    if (isRenting.Equals(true))
                    {
                        break;
                    }
                    else if (isRenting.Equals(false))
                    {
                        Console.WriteLine("대출 불가능 합니다.");
                    }
                }
                else if (isCheckNo.Equals(false))
                {
                    Console.WriteLine("\t 목록에 없는 책 No입니다");
                }
            }
            return input;
        }

        public string checkNameNo(string bookNo)
        {
            while (true)
            {
                Console.Write("\t BookName : ");
                input = Console.ReadLine();
                Regex regex = new Regex(@"^[가-힣a-zA-z]");
                Boolean ismatch = regex.IsMatch(input);
                if (ismatch)
                {
                    bool isMatchBookNo = share.getBookTable().checkBookTitle(bookNo, input);
                    if (isMatchBookNo.Equals(true))
                    {
                        break;
                    }
                    else if (isMatchBookNo.Equals(false))
                    {
                        Console.WriteLine("책 번호와 이름이 맞지 않습니다. 다시 입력해주세요");
                    }
                }
                else if (!ismatch) { Console.WriteLine("\t\t다시 입력해주세요~"); }
            }

            return input;
        }

    }

}
