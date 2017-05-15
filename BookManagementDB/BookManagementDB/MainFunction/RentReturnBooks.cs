using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementDB
{
    class RentReturnBooks
    {
        DateTime currentTime = DateTime.Now;
        private static ShareClass share = ShareClass.getShareClass();
        string bookNo = null;
        string bookName = null;

        public void rentBook() //대출
        {
            share.getBookTable().booksAllSearchOfDB();
            Console.WriteLine("\n\t목록을 보고 빌리고 싶은 No와 책 이름을 입력해주세요");

            bookNo = share.getException().checkNoWhenRent(); 
            bookName = share.getException().checkNameNo(bookNo);
            int cnt = share.getRentTable().rentCount(share.getLoginId());

            if (cnt < 3) //3권 만 빌릴 수 있다 대출 제한
            {
                share.getBookTable().changeRenting("대출 불가능", bookNo);
                share.getRentTable().addRentTable(bookNo,bookName);
                cnt++;
            }
            else if (cnt >= 3)
            {
                Console.Clear();
                Console.WriteLine("\n\n\n\n");
                Console.WriteLine(" 대출은 최대 3권까지만 가능합니다.");
                share.getMenu().menuOnLogin();
            }
        }
        public void returnBook() //반납
        {
            share.getRentTable().rentSearch(share.getLoginId());

            Console.WriteLine("\n\t 본인 목록 보고 반납할 책 No와 이름을 입력해주세요");
            bookNo = share.getException().checkRentBookNo(); //목록에없는 책 넘버와 다르면 놉 
            bookName = share.getException().checkRentBookName(bookNo); //목록에서 다른 걸 고르면 놉
            share.getBookTable().changeRenting("대출 가능", bookNo);
            share.getRentTable().deleteRentTable(bookName);

        }
    }
}
