﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using MySql.Data.MySqlClient;

namespace BookManagementDB
{
    class ShareClass
    { // 싱글톤
        private static ShareClass shareclass;
        Login login;
        Display display;
        Book book;
        Member member;
        Menu menu;
        RentReturnBooks rentretun;
        Exception exception;
        MemberTable membertable;
        BookTable booktable;
        RentTable rentTable;
        private static string loginID = null;
        private ShareClass()
        {
            login = new Login();
            display = new Display();
            book = new Book();
            member = new Member();
            menu = new Menu();
            exception = new Exception();
            membertable = new MemberTable();
            booktable = new BookTable();
            rentTable = new RentTable();
            rentretun = new RentReturnBooks();
        }
        
       
        internal void setLoginId(string userid)
        {
            loginID = userid;
        }

        internal string getLoginId()
        {
            return loginID;
        }
        public static ShareClass getShareClass()
        {
            if (shareclass == null) shareclass = new ShareClass();
            return shareclass;
        }
        

        public Login getLogin()
        {
            return login;
        }

        public Member getMember()
        {
            return member;
        }

        public Book getBook()
        {
            return book;
        }

        public Menu getMenu()
        {
            return menu;
        }

        public Display getDisplay()
        {
            return display;
        }

        public MemberTable getMemberTable()
        {
            return membertable;
        }

        public Exception getException()
        {
            return exception;
        }
        public BookTable getBookTable()
        {
            return booktable;
        }
        public RentTable getRentTable()
        {
            return rentTable;
        }
        public RentReturnBooks getRentRetun()
        {
            return rentretun;
        }
    }
}
