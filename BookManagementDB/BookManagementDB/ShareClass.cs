using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using MySql.Data.MySqlClient;

namespace BookManagementDB
{
    class Singletone
    { //여기서 싱글톤 하기
        private static Singletone singletone;
        Login login;
        Display display;
        Book book;
        Member member;
        Menu menu;
        Administrator administrator;
        List<BookVO> booklist = new List<BookVO>();
        List<MemberVO> memberlist = new List<MemberVO>();

        private Singletone()
        {
            login = new Login();
            display = new Display();
            book = new Book();
            member = new Member();
            menu = new Menu();
            administrator = new Administrator();
            
        }
        public Login getLogin()
        {
            return login;
        }
        public static Singletone getsingletone()
        {
            if (singletone == null) singletone = new Singletone();
            return singletone;
        }
        public Member getMember()
        {
            return member;
        }
        public Menu getMenu()
        {
            return menu;
        }
        public Administrator getAdministrator()
        {
            return administrator;
        }
       
    }
}
