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

            if(input == "1") { Console.Clear(); share.getLogin().login(); } //등록한 정보가 있으면 로그인 창으로 
            else if(input =="2") { Console.Clear();  share.getMember().addMember(); } //회원 등록하기
            else if (input == "3") { Console.Clear(); Console.WriteLine("                            프로그램 종료합니다 "); }
            else if(input == "/OpenAdmin") { Console.Clear(); share.getLogin().adminLogin(); } //숨겨진 관리자 모드 오직 관리자만이 아는 명령어
        }

        public void menuLoginAdmin()
        {
            share.getDisplay().administrationModeDisplay();
            input = share.getException().exceptSwitchEntry(1, 4);

            switch (input)
            {
                case "1": //등록한 회원 정보들을 한꺼번에 볼 수 있게
                   
                    break;
                case "2": //등록한 책 정보들 한꺼번에 볼 수 있게
                    
                    break;
                case "3": //책 추가
                    
                    break;
                case "4": //나가기 
                    Console.WriteLine("                        관리자모드 종료합니다 ");
                    mainMenu();
                    break;
            }
        }

        public void menuOnLogin()
        {
            share.getDisplay().LoginMemberDisplay();
            input = share.getException().exceptSwitchEntry(1, 5);

            switch (input)
            {
                case "1": //책 대출하는 함수
                    break;
                case "2": //책 반납하는 함수
                    break;
                case "3": //회원 수정하는 함수
                    break;
                case "4": //대여기간과 뭘 빌렸는지 확인하는 함수
                    break;
                case "5":
                    mainMenu(); //메인메뉴로 돌아가기 : 로그아웃했으니
                    break;
            }
        }
    }
}
