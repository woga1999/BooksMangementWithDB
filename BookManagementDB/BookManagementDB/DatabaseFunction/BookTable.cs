using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using MySql.Data.MySqlClient;

namespace BookManagementDB
{//Book 테이블 이용해 쓰는 기능들

    class BookTable
    {
        private static ShareClass share = ShareClass.getShareClass();
        String strConn;
        MySqlConnection conn;

        public void addBookInDB(string no, string bookTitle, string author, string price, string amount)
        {
            strConn = "Server=localhost; Database=bookmanage; Uid=root; Pwd=1206";
            conn = new MySqlConnection(strConn); //MySQL 연결

            conn.Open();

            string sql = "insert into book values('"+no+"','" + bookTitle + "', '" + author + "', '" + price + "', '" + amount + "');";
            MySqlCommand cmd = new MySqlCommand(sql, conn); // command
            if (cmd.ExecuteNonQuery() == 1)
            {
                Console.Clear();
                Console.WriteLine("\n\n\n\n");
                Console.WriteLine("\t\t" + bookTitle + " 등록되었습니다. ");
                Thread.Sleep(1000);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Database Error!!");
                Thread.Sleep(1000);
            }

            conn.Close();
        }

        public void deleteBookInDB(string bookTitle)
        {
            strConn = "Server=localhost; Database=bookmanage; Uid=root; Pwd=1206";
            conn = new MySqlConnection(strConn); //MySQL 연결

            conn.Open();
            string sql = "delete from member where memberid = '" + bookTitle + "'; ";
            MySqlCommand cmd = new MySqlCommand(sql, conn); // command
            if (cmd.ExecuteNonQuery() == 1)
            {
                Console.Clear();
                Console.WriteLine("\n\n\n\n");
                Console.WriteLine("\t\t" + bookTitle + " 책 정보가 삭제되었습니다.");
                Thread.Sleep(1000);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Database Error!!");
                Thread.Sleep(1000);
            }

            conn.Close();
        }

        public void booksAllSearchOfDB()
        {
            strConn = "Server=localhost;Database=bookmanage;Uid=root;Pwd=1206";
            conn = new MySqlConnection(strConn);  // conncet MySQL
            conn.Open();
            String sql = "select * from book;";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            string isrent = null;
            string bookname = null;
            string author = null;
            string price = null;
            string volume = null;
            share.getDisplay().bookBar();
            while (reader.Read())
            {
                bookname = reader["bookname"].ToString();
                author = reader["author"].ToString();
                price = reader["price"].ToString();
                volume = reader["volume"].ToString();
                isrent = reader["isrent"].ToString();


                Console.WriteLine(String.Format("  " + bookname + "\t " + author + "\t " + price + "\t\t" + volume + "\t" + isrent));
            }

            reader.Close();
            conn.Close();
        }
    }
}
