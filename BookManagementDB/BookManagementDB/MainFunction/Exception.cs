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

        public string exceptKey(string key, string key2, string key3, string key4) //key 값들에 대한 예외처리
        {
            while (true)
            {
                Console.SetCursorPosition(33, 10);
                Console.Write("\t\t\t : ");
                input = Console.ReadLine();
                if (input == "") { input.Replace(input, "                                   "); continue; }
                else if (input == key) { break; }
                else if (input == key2) { break; }
                else if (input == key3) { break; }
                else if (input == key4) { break; }
                else
                {
                    input.Replace(input, "                                ");
                    continue;
                }
            }
            return input;
        }

        public string exceptSwitchEntry(int first, int last) //스위치 문을 이용할 때 쓰이는 입력 예외처리
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
                {
                    continue;
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

        public string inputpwd() //패스워드입력하면 *모양으로 나오게 하는 메서드
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
      
        public string matchpw() //입력한 패스워드랑 유저가 로그인 한 아이디와 맞는지 확인하는 메서드 맞으면 행동이 되고 맞지않으면 입력값을 받게
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

        public string loginId() //로그인 할 때 아이디 입력받는 칸에 빈칸으로 두고 넘어갈려 하면 입력하라는 창이 뜨게한다
        {
            while (true)
            {
                Console.SetCursorPosition(22, 6);
                input = Console.ReadLine();
                Regex regex = new Regex(@"^[ ]");
                Boolean ismatch = regex.IsMatch(input);
                if (input == "" || ismatch) { Console.WriteLine("\n\n\n\n\n\n\t 아이디를 입력해주세요"); }
                
                else { break; }
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

        public string inputIdWhenDelete(string direct) //정보 추가할 때와 다르게 지울 때는 존재해야 지울 수 있게 한다
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

        public string onlyNumPrice(string message) //가격입력 시 0000원이나 0원 10원은 통상적으로 존재하지 않으니 입력 제한을 둔다
        {
            while (true)
            {
                Console.Write("\t {0} : ", message);
                input = Console.ReadLine();
                Regex regex = new Regex(@"^[1-9]{1}[0-9]{3,9}$");
                Boolean ismatch = regex.IsMatch(input);
                if (ismatch)
                {
                    if (input == "") { continue; }
                    else
                    {
                        break;
                    }
                }
                else if (!ismatch) { Console.WriteLine("\t 똑바로 입력해주세요 4~10자리 내 숫자만 입력 가능합니다"); }
            }
            return input;
        }

        public string onlySixNumDigits() //생년월일 6자리를 입력받을 시 쓰인다 
        {
            while (true)
            {
                Console.Write("\t Birth(Only 6digits): ");
                input = Console.ReadLine();
                Regex regex = new Regex(@"^[0-9]{2}[0-1]{1}[0-9]{1}[0-3]{1}[0-9]{1}$");

                Boolean ismatch = regex.IsMatch(input);
                if (ismatch)
                {
                    if(input == "000000") { Console.WriteLine("\t 존재하지않습니다."); }
                    else
                    {
                        break;
                    }
                }
                else if (!ismatch) { Console.WriteLine("\t 6자리 생년월일을 입력해주세요."); }
            }
            return input;
        }

        public string exceptString(string message) //문자열들을 입력받을 때 쓰인다
        {
            while (true)
            {
                Console.Write("\t {0} : ", message);
                input = Console.ReadLine();
                Regex regex = new Regex(@"^[가-힣a-zA-Z0-9]{1,20}");
                Boolean ismatch = regex.IsMatch(input);
                if (ismatch)
                {
                    break;
                }
                else if (!ismatch) { Console.WriteLine("\t 다시 입력해주세요(20자리이내 제한)"); }
            }
            return input;
        }

        public string exceptName(string message) //문자열들을 입력받을 때 쓰인다
        {
            while (true)
            {
                Console.Write("\t {0} : ", message);
                input = Console.ReadLine();
                Regex regex = new Regex(@"^[가-힣]{2,10}");
                Boolean ismatch = regex.IsMatch(input);
                Regex regex2 = new Regex(@"^[A-Z]{1}[a-z]{1,9}");
                Boolean ismatch2 = regex2.IsMatch(input);
                if (ismatch || ismatch2)
                {
                    break;
                }
                else if (!ismatch)
                {if (!ismatch2)
                    {
                        Console.WriteLine("\t if you entry Name first 'a-z', Upper(2~10 Digits)");
                    }
                    else
                    {
                        Console.WriteLine("\t 다시 입력해주세요(2~10자리이내 제한)");
                    } }
               
            }
            return input;
        }

        public string exceptSearchWord(string put) //검색 시 존재하는 데이터들과 맞는지 검사한다
        {
            while (true)
            {
                Console.Write("\n\t\t : ");
                input = Console.ReadLine();
                Regex regex = new Regex(@"^[가-힣a-zA-Z0-9]{1,20}");
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

        public void goBack(string where) //뒤로가고싶은 구간에 쓰인다
        {
            while (true)
            {
                Console.Write("\n\n\t wanna back put <back> : ");
                input = Console.ReadLine();
                Regex regex = new Regex(@"^[a-z]");
                Boolean ismatch = regex.IsMatch(input);
                if (ismatch)
                {
                    if (input == "back" && where == "membersearch") { share.getMenu().searchAboutMembers(); break; }
                    if (input == "back" && where == "booksearch") { share.getMenu().searchAboutBook(); break; }
                    if (input == "back" && where == "memberlogin") { share.getMenu().menuOnLogin(); break; }
                }
                else if (!ismatch) { Console.Write("\t\t\t\t Nope"); }
            }
        }

        public string inputNo() //책 번호 입력 시 중복인지 검사하고 입력제한을 둔다
        {
            while (true)
            {
                Console.Write("\n\t BookNo : ");
                input = Console.ReadLine();
                Regex regex = new Regex(@"^[0-9]{1,10}$");
                Boolean ismatch = regex.IsMatch(input);
                if (ismatch)
                {
                    bool IsExistedNo = share.getBookTable().IsNoDuplication(input);
                    if (IsExistedNo.Equals(true)) { Console.WriteLine("  존재하는 No입니다.     "); }
                    else if (IsExistedNo.Equals(false)) { break; }
                }
                else if (input == "back") { Console.Clear(); share.getMenu().menuLoginAdmin(); }
                else if (!ismatch)
                {
                    Console.WriteLine("  1~20자리 내 숫자 입력만 가능합니다.  ");
                }
            }
            return input;
        }
        public string inputNoWhenDelete() //책 번호를 통해 지울 때 존재하는지 검사한다
        {
            while (true)
            {
                Console.Write("\n\t Put BookNo : ");
                input = Console.ReadLine();
                Regex regex = new Regex(@"^[0-9]{1,10}$");
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

        public string checkRentBookNo() //빌리고 반납할 때 넘버도 같이 입력받는데 빌렸던 책 넘버여야 반납할 수 있게 한다
        {
            while (true)
            {
                Console.Write("\n\t BookNo : ");
                input = Console.ReadLine();
                Regex regex = new Regex(@"^[0-9]{1,10}$");
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

        public string checkRentBookName(string no) //빌린 책 넘버와 제목이 맞는지 검사한다.
        {
            while (true)
            {
                Console.Write("\n\t BookName : ");
                input = Console.ReadLine();
                Regex regex = new Regex(@"^[가-힣a-zA-z0-9]{1,20}");
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
        
        public string checkNoWhenRent() //책 빌릴 때 존재하는 책 번호인지 검사하고 대출 불가능 상태이면 빌리지 못하게 한다.
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

        public string checkNameNo(string bookNo) //그리고 빌릴 때 기존 데이터 책 번호와 제목이 맞는지 검사한다.
        {
            while (true)
            {
                Console.Write("\t BookName : ");
                input = Console.ReadLine();
                Regex regex = new Regex(@"^[가-힣a-zA-z0-9]{1,20}");
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
