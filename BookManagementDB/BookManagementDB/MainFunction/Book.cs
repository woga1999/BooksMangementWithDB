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
        public void addBook()
        {

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
