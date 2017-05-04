using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementDB
{
    class BookVO
    {
        
        private string bookTitle;
        private string bookWriter;
        private string bookPrice;
        private string bookVolume;
        private bool lent;

        public BookVO(string bookName, string author, string price, string volume, bool Islend) //수정되면 안 되는 정보들이기에 private로 선언하고 값을 빼서 쓴다.
        {
            bookTitle = bookName;
            bookWriter = author;
            bookPrice = price;
            lent = Islend;
        }

        public string bookName
        {
            get { return bookTitle; }
            set { bookTitle = value; }
        }
        public string author
        {
            get { return bookWriter; }
            set { bookWriter = value; }
        }

        public string price
        {
            get { return bookPrice; }
            set { bookPrice = value; }
        }

        public string volume
        {
            get { return bookVolume; }
            set { bookVolume = value; }
        }

        public bool Islend
        {
            get { return lent; }
            set { lent = value; }
        }
    }
}
