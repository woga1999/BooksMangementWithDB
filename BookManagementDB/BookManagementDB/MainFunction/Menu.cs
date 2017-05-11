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
            Console.Clear();
            share.getDisplay().mainMenuDisplay();
            input = share.getException().exceptKey("1", "2", "3","/OpenAdmin");

            if(input == "1")   //등록한 정보가 있으면 로그인 창으로 
            {
                Console.Clear();
                share.getLogin().login();
            } 
            else if(input =="2") //회원 등록하기
            {
                Console.Clear();
                share.getMember().addMember("Membership Join");
                mainMenu();
            } 
            else if (input == "3") //종료
            {
                Console.Clear();
                Console.WriteLine("                            프로그램 종료합니다 ");
            }
            else if(input == "/OpenAdmin") {  share.getLogin().adminLogin(); } //숨겨진 관리자 모드 오직 관리자만이 아는 명령어
        }

        public void menuLoginAdmin()
        {
            Console.Clear();
            share.getDisplay().administrationModeDisplay();
            input = share.getException().exceptSwitchEntry(1, 6);

            switch (input)
            {
                case "1": //등록한 회원 정보들을 검색해서 출력 아니면 전체출력
                    searchAboutMembers();
                    break;
                case "2":
                    share.getMember().deleteMember();
                    menuLoginAdmin();
                    break;
                case "3": //책 목록 보며 책 추가
                    share.getBook().addBook("Add BookInfo");
                    menuLoginAdmin();
                    break;
                case "4": //책 목록 보며 삭제할 책 고르기
                    share.getBook().deleteBook();
                    Console.Clear();
                    menuLoginAdmin();
                    break;
                case "5": //책 목록 보며 수정할 책 고르기
                    share.getBook().modifyBook();
                    Console.Clear();
                    menuLoginAdmin();
                    break;
                case "6": //나가기 
                    Console.WriteLine("                        관리자모드 종료합니다 ");
                    Thread.Sleep(800);
                    Console.Clear();
                    mainMenu();
                    break;
            }
        }

        public void menuOnLogin()
        {
            Console.Clear();
            share.getDisplay().LoginMemberDisplay();
            input = share.getException().exceptSwitchEntry(1, 6);

            switch (input)
            {
                case "1": //책 대출하는 함수
                    menuOnLogin();
                    break;
                case "2": //책 반납하는 함수
                    menuOnLogin();
                    break;
                case "3": //회원 수정하는 함수
                    share.getMember().modifyMember();
                    menuOnLogin();
                    break;
                case "4": //대여기간과 뭘 빌렸는지 확인하는 함수
                    break;
                case "5": //책 검색하기
                    menuOnLogin();
                    break;
                case "6":
                    Console.WriteLine("로그아웃 합니다."); //메인메뉴로 돌아가기 : 로그아웃했으니
                    Thread.Sleep(800);
                    break;
            }
        }

        public void searchAboutBook()
        {
            Console.Clear();
            share.getDisplay().bookSearchDisplay();
            input = share.getException().exceptSwitchEntry(1, 5);

            switch (input)
            {
                case "1": //책 전체 출력
                    searchAboutBook();
                    break;
                case "2": //책 저자으로 검색
                    searchAboutBook();
                    break;
                case "3": //책 이름으로 검색
                    searchAboutBook();
                    break;
                case "4": //책 가격으로 검색
                    searchAboutBook();
                    break;
                case "5": //로그인하고 난 후 창으로 뜨기
                    menuOnLogin();
                    break;
            }
        }
        public void searchAboutMembers()
        {
            Console.Clear();
            share.getDisplay().memberSearchDisplay();
            input = share.getException().exceptSwitchEntry(1, 4);

            switch (input)
            {
                case "1": //멤버 전체 출력
                    searchAboutMembers();
                    break;
                case "2": //멤버 아이디 검색
                    searchAboutMembers();
                    break;
                case "3": //멤버 이름으로 검색
                    searchAboutMembers();
                    break;
                case "4": //관리인 로그인 창으로 
                    menuLoginAdmin();
                    break;
            }
        }
    }
    
}
