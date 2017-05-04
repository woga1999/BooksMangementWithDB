using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using MySql.Data.MySqlClient;

namespace BookManagementDB
{//도서와 관련된 기능 메서드들을 모아놓은 클래스
    class Book
    { 
        private static ShareClass share = ShareClass.getShareClass();
        public BookVO bookvo = new BookVO(null, null, null, null, false);
        //public List<BookVO> bookList = new List<BookVO>();
        public void addBook() //관리자 모드일 때 등록가능
        {
            Console.WriteLine("\t\t -Add books-          ");
            Console.WriteLine(" ");
            Console.WriteLine("\t Title : ");
            bookvo.bookName = Console.ReadLine();

            Console.Write("\t Author : ");
            bookvo.author = Console.ReadLine(); //회원정보 등록할 때는 보이게 한다.
            
            bookvo.price = share.getException().onlyNum("Price");
            
            bookvo.volume = share.getException().onlyNum("Volume");

            //bookList.Add(new BookVO(bookvo.bookName, bookvo.author, bookvo.price, bookvo.volume, false));
            share.getDataBase().addBookInDB(bookvo.bookName, bookvo.author, bookvo.price, bookvo.volume, "대여 가능");

        }

        public void modifyBook() //관리자 모드 일 때
        {

        }

        public void deleteBook() 
        {

        }

        public void printAllBook() //유저도 검색할 수 있다
        {

        }

    }
}
