using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using MySql.Data.MySqlClient;

namespace BookManagementDB
{
    class ShareClass
    { // 싱글톤 하기
        private static ShareClass shareclass;
        Login login;
        Display display;
        Book book;
        Member member;
        Menu menu;
        Exception exception;
        DataBase database;
        private ShareClass()
        {
            login = new Login();
            display = new Display();
            book = new Book();
            member = new Member();
            menu = new Menu();
            exception = new Exception();
            database = new DataBase();
        }

        public Login getLogin()
        {
            return login;
        }

        public static ShareClass getShareClass()
        {
            if (shareclass == null) shareclass = new ShareClass();
            return shareclass;
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

        public DataBase getDataBase()
        {
            return database;
        }

        public Exception getException()
        {
            return exception;
        }
    }
}
