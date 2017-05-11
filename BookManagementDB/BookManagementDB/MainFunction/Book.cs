using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BookManagementDB
{//도서와 관련된 기능 메서드들을 모아놓은 클래스
    class Book
    { 
        private static ShareClass share = ShareClass.getShareClass();
        public BookVO bookvo = new BookVO(null, null, null, null, false);
        string input = null;

        public void addBook(string message) //관리자 모드일 때 등록가능
        {
            Console.WriteLine("\t\t - {0} -          ", message);
            Console.WriteLine(" ");
            string no = Console.ReadLine();
            bookvo.bookName = share.getException().notEnter("Book Title");
            
            bookvo.author = share.getException().notEnter("Author"); //회원정보 등록할 때는 보이게 한다.

            bookvo.price = share.getException().onlyNum("Price");
            
            bookvo.volume = share.getException().onlyNum("Volume");

            share.getBookTable().addBookInDB(no, bookvo.bookName, bookvo.author, bookvo.price);

        }

        public void modifyBook() //관리자 모드 일 때
        {
            Console.WriteLine("\n\t 수정하고 싶으시면 책 제목과 저자를 입력해주세요! ");
            input = share.getException().notEnter("Book Title");
            
            string input2 = share.getException().notEnter("Author");
            if (input == bookvo.bookName)
            {
                if (input2 == bookvo.author)
                {
                    share.getBookTable().deleteBookInDB(input);
                    addBook("BookInfo Modify");
                }
                else
                    Console.WriteLine("존재하지 않는 도서입니다.");
            }
            else
                Console.WriteLine("제목이 동일한 책이 없습니다.");
        }

        public void deleteBook() 
        {

        }

        public void printAllBook() //유저도 검색할 수 있다
        {

        }

    }
}
