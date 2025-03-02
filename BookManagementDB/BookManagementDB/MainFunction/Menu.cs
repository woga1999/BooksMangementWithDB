﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using MySql.Data.MySqlClient;

namespace BookManagementDB
{//메뉴 모음
    class Menu
    {
        private static ShareClass share = ShareClass.getShareClass();
        string input = null;

        public void mainMenu()
        {
            Console.Clear();
            share.getDisplay().mainMenuDisplay();
            input = share.getException().exceptKey("1", "2", "3","/");

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
                Console.WriteLine("                            프로그램 종료합니다 ");
            }
            else if(input == "/")
            {
                share.getLogin().adminLogin();
            } //숨겨진 관리자 모드 오직 관리자만이 아는 명령어
        }
        
        public void adminMenu() //관리자모드로 가서 로그인 후 뜨는 관리자가 관리하는 메뉴
        {
            Console.Clear();
            share.getDisplay().administrationModeDisplay();
            input = share.getException().exceptSwitchEntry(1, 6);

            switch (input)
            {
                case "1": //등록한 회원 정보들을 검색해서 출력 아니면 전체출력
                    searchAboutMembers();
                    break;
                case "2": //회원삭제
                    share.getMember().deleteMember();
                    adminMenu();
                    break;
                case "3": //책 추가
                    share.getBook().addBook("Add BookInfo");
                    adminMenu();
                    break;
                case "4": //책 목록 보며 삭제할 책 고르기
                    share.getBookTable().booksAllSearchOfDB();
                    share.getBook().deleteBook();
                    break;
                case "5": //책 목록 보며 수정할 책 고르기
                    share.getBookTable().booksAllSearchOfDB();
                    share.getBook().modifyBook();
                    adminMenu();
                    break;
                case "6": //나가기 
                    Console.WriteLine("                        관리자모드 종료합니다 ");
                    Thread.Sleep(800);
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
                    share.getRentRetun().rentBook();
                    menuOnLogin();
                    break;
                case "2": //책 반납하는 함수
                    share.getRentRetun().returnBook();
                    menuOnLogin();
                    break;
                case "3": //회원 수정하는 함수
                    share.getMember().modifyMember();
                    menuOnLogin();
                    break;
                case "4": //대여기간과 뭘 빌렸는지 확인하는 함수
                    share.getRentTable().rentSearch(share.getLoginId(),"빌린");
                    share.getException().goBack("memberlogin");
                    break;
                case "5": //책 검색하기
                    searchAboutBook();
                    break;
                case "6":
                    Console.Clear();
                    Console.WriteLine("\n\n\t\t 로그아웃 됐습니다."); //메인메뉴로 돌아가기 : 로그아웃했으니
                    Thread.Sleep(800);
                    mainMenu();
                    break;
            }
        }

        public void searchAboutBook() //책 검색창
        {
            Console.Clear();
            share.getDisplay().bookSearchDisplay();
            input = share.getException().exceptSwitchEntry(1, 5);

            switch (input)
            {
                case "1": //책 전체 출력
                    share.getBookTable().booksAllSearchOfDB();
                    share.getException().goBack("booksearch");
                    break;
                case "2": //책 저자으로 검색
                    share.getBook().searchBook("author");
                    break;
                case "3": //책 이름으로 검색
                    share.getBook().searchBook("bookname");
                    break;
                case "4": //책 가격으로 검색
                    share.getBook().searchBook("price");
                    break;
                case "5": //유저로그인 후 창으로 뜨기
                    menuOnLogin();
                    break;
            }
        }
        public void searchAboutMembers() //멤버 검색 메뉴
        {
            Console.Clear();
            share.getDisplay().memberSearchDisplay();
            input = share.getException().exceptSwitchEntry(1, 4);

            switch (input)
            {
                case "1": //멤버 전체 출력
                    share.getMemberTable().memberAllSearchOfDB();
                    share.getException().goBack("membersearch");
                    break;
                case "2": //멤버 아이디 검색
                    share.getMember().searchMembers("memberid");
                    break;
                case "3": //멤버 이름으로 검색
                    share.getMember().searchMembers("name");
                    break;
                case "4": //관리인 로그인 창으로 
                    adminMenu();
                    break;
            }
        }
    }
    
}
