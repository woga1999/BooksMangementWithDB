using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementDB
{
    class BookVO
    {
        private string bookNo;
        private string bookTitle;
        private string bookWriter;
        private string bookPrice;
        private bool lent;

        public BookVO(string bookName, string author, string price, bool Islend) //수정되면 안 되는 정보들이기에 private로 선언하고 값을 빼서 쓴다.
        {
            bookTitle = bookName;
            bookWriter = author;
            bookPrice = price;
            lent = Islend;
        }
        public string BookNo
        {
            get{ return bookNo; }
            set { bookNo = value; }
        }

        public string BookName
        {
            get { return bookTitle; }
            set { bookTitle = value; }
        }
        public string Author
        {
            get { return bookWriter; }
            set { bookWriter = value; }
        }

        public string Price
        {
            get { return bookPrice; }
            set { bookPrice = value; }
        }

        public bool Islend
        {
            get { return lent; }
            set { lent = value; }
        }
    }
}
