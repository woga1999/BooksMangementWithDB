using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using MySql.Data.MySqlClient;

namespace BookManagementDB
{
    class Book
    {
        private static ShareClass share = ShareClass.getShareClass();
        public BookVO bookvo = new BookVO(null, null, null, null, false);
        public List<BookVO> bookList = new List<BookVO>();
        public void addBook()
        {
            Console.WriteLine("\t\t -Add books-          ");
            Console.WriteLine(" ");
            Console.WriteLine("\t Title : ");
            bookvo.bookName = Console.ReadLine();

            Console.Write("\t Author : ");
            bookvo.author = Console.ReadLine(); //회원정보 등록할 때는 보이게 한다.

            Console.Write("\t Price : ");
            bookvo.price = Console.ReadLine();

            Console.Write("\t Volume : ");
            bookvo.volume = Console.ReadLine();

            bookList.Add(new BookVO(bookvo.bookName, bookvo.author, bookvo.price, bookvo.volume, false));
            share.getDataBase().addBookInDB(bookvo.bookName, bookvo.author, bookvo.price, bookvo.volume, "대여 가능");

        }

        public void modifyBook()
        {

        }

        public void deleteBook()
        {

        }

        public void searchBook()
        {

        }

    }
}
