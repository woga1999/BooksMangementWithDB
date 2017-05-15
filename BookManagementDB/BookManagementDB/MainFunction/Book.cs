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
        string input = null;

        public void addBook(string message) //관리자 모드일 때 등록가능
        {
            Console.Clear();
            Console.WriteLine("\t\t - {0} -          ", message);
            Console.WriteLine(" ");
            Console.WriteLine("\n\t Put BookNo : ");
            string no = share.getException().inputNo();
            string bookName = share.getException().exceptString("Book Title");
            
            string author = share.getException().exceptString("Author"); //회원정보 등록할 때는 보이게 한다.

            string price = share.getException().onlyNumPrice("Price");

            share.getBookTable().addBookInDB(no, bookName, author, price, "대출 가능");

        }

        public void modifyBook() //관리자 모드 일 때
        {
            share.getBookTable().booksAllSearchOfDB();
            Console.WriteLine("\n\t Wanna modify, Put BookNo : ");
            input = share.getException().inputNoWhenDelete();

            share.getBookTable().deleteBookInDB(input, " ");
                    addBook("BookInfo Modify");
              
        }

        public void deleteBook() 
        {
            Console.Write("\n\t Wanna Delete");
            input = share.getException().inputNoWhenDelete();
            share.getBookTable().deleteBookInDB(input, " 책 정보가 삭제되었습니다.");
        }

        public void searchBook(string category) //유저도 검색할 수 있다
        {
            Console.Write("\n\t Put wanna search keyword   <back> = back");
            input = share.getException().exceptString("Keyword");

            share.getBookTable().searchBooks(category, input);
        }

    }
}
