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
        string no = null;
        string bookname = null;
        string author = null;
        string price = null;
        string renting = null;
        public void addBookInDB(string no, string bookTitle, string author, string price, string renting)
        {
            strConn = "Server=localhost; Database=bookmanage; Uid=root; Pwd=1206";
            conn = new MySqlConnection(strConn); //MySQL 연결

            conn.Open();

            string sql = "insert into book values('"+no+"','" + bookTitle + "', '" + author + "', '" + price + "', '" + renting + "');";
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

        public void deleteBookInDB(string no, string message)
        {
            strConn = "Server=localhost; Database=bookmanage; Uid=root; Pwd=1206";
            conn = new MySqlConnection(strConn); //MySQL 연결

            conn.Open();
            string sql = "delete from book where no = '" + no + "'; ";
            MySqlCommand cmd = new MySqlCommand(sql, conn); // command
            if (cmd.ExecuteNonQuery() == 1)
            {
                Console.Clear();
                Console.WriteLine("\n\n\n\n");
                Console.WriteLine("\t\t"+ message);
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
            Console.Clear();
            strConn = "Server=localhost;Database=bookmanage;Uid=root;Pwd=1206";
            conn = new MySqlConnection(strConn);  // conncet MySQL
            conn.Open();
            String sql = "select * from book;";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            int count = 3;
            share.getDisplay().bookBar();
            while (reader.Read())
            {
                no = reader["no"].ToString();
                bookname = reader["bookname"].ToString();
                author = reader["author"].ToString();
                price = reader["price"].ToString();
                renting = reader["isRent"].ToString();
                Console.SetCursorPosition(8, count);
                Console.Write(no);
                Console.SetCursorPosition(15, count);
                Console.Write(bookname);
                Console.SetCursorPosition(58, count);
                Console.Write(author);
                Console.SetCursorPosition(80, count);
                Console.Write(price);
                Console.SetCursorPosition(95, count);
                Console.Write(renting);
                count += 2;
            }

            reader.Close();
            conn.Close();
        }

        public bool IsNoDuplication(string no)
        {
            strConn = "Server=localhost;Database=bookmanage;Uid=root;Pwd=1206";
            conn = new MySqlConnection(strConn);  // conncet MySQL
            conn.Open();
            String sql = "select * from book;";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            bool duplication = false;
            while (reader.Read())
            {
                string bookNo = reader["no"].ToString();
                if (no == bookNo) { duplication = true; break; }
                else
                {
                    duplication = false;
                }

            }
            reader.Close();
            conn.Close();

            return duplication;

        }
        public void searchBooks(string titleOrAuthorOr, string searchWord)
        {
            int cnt = 0, count = 3;
            Console.Clear();
            strConn = "Server=localhost;Database=bookmanage;Uid=root;Pwd=1206";
            conn = new MySqlConnection(strConn);  // conncet MySQL
            conn.Open();
            String sql = "select * from book where " + titleOrAuthorOr + " like '" + searchWord + "%" + "';";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            share.getDisplay().bookBar();
            while (reader.Read())
            {
                no = reader["no"].ToString();
                bookname = reader["bookname"].ToString();
                author = reader["author"].ToString();
                price = reader["price"].ToString();
                renting = reader["isRent"].ToString();
                if (bookname.Contains(searchWord) || author.Contains(searchWord) || price.Contains(searchWord))
                {
                    cnt++;
                    Console.SetCursorPosition(8, count);
                    Console.Write(no);
                    Console.SetCursorPosition(15, count);
                    Console.Write(bookname);
                    Console.SetCursorPosition(58, count);
                    Console.Write(author);
                    Console.SetCursorPosition(80, count);
                    Console.Write(price);
                    Console.SetCursorPosition(95, count);
                    Console.Write(renting);
                    count += 2;
                    share.getException().goBack("booksearch");
                }
            }
            if(cnt == 0)
            {
                Console.Clear();
                Console.WriteLine("\t\t"+titleOrAuthorOr+" 내에서 "+ searchWord+"에 대한 검색결과가 없습니다");
                Thread.Sleep(800);
                share.getException().goBack("booksearch");
            }
            reader.Close();
            conn.Close();
        }

        public void changeRenting(string renting, string no) //대출 불가능으로 가능으로 바꾸거나 대출 가능을 불가능으로 바꾼다
        {
            strConn = "Server=localhost; Database=bookmanage; Uid=root; Pwd=1206";
            conn = new MySqlConnection(strConn); 

            conn.Open();
            //update ABCDE set column1='xyz' where no='3'
            string sql = "update book set isRent ='" + renting +"'"+ " where no ="+"'"+no+"';";
            MySqlCommand cmd = new MySqlCommand(sql, conn); 
            if (cmd.ExecuteNonQuery() == 1)
            {
                Console.Clear();
                Console.WriteLine("\n\n\n\n");
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

        public bool checkNo(string bookNo) //목록에 없는 No를 입력하면 없다고 뜨게끔 DB 내 데이터들을 검사한다
        {
            strConn = "Server=localhost;Database=bookmanage;Uid=root;Pwd=1206";
            conn = new MySqlConnection(strConn);  // conncet MySQL
            conn.Open();
            bool isCheckNo = true;
            String sql = "select * from book ;";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                no = reader["no"].ToString();
                if (bookNo == no)
                {
                    isCheckNo = true;
                    break;
                }
                else
                {
                    isCheckNo = false;
                }
            }
            reader.Close();
            conn.Close();

            return isCheckNo;
        }

        public bool checkIsRent(string bookNo) //No를 입력하는데 대출불가능이면 빌릴수없게 끔 DB를 이용해 데이터들을 비교한다
        {
            strConn = "Server=localhost;Database=bookmanage;Uid=root;Pwd=1206";
            conn = new MySqlConnection(strConn);  // conncet MySQL
            bool isRenting = true;
            conn.Open();
            String sql = "select * from book where no='" + bookNo + "';";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                no = reader["no"].ToString();
                bookname = reader["bookname"].ToString();
                renting = reader["isRent"].ToString();
                if (renting == "대출 불가능")
                {
                    isRenting = false;
                }
                else if (renting == "대출 가능")
                {
                    isRenting = true;
                }
            }
            reader.Close();
            conn.Close();
            return isRenting;
        }


        public bool checkBookTitle(string bookNo, string bookTitle) //넘버와 북타이틀이 다르면 책제목 다르다고 DB내 데이터들 비교한다
        { 
            strConn = "Server=localhost;Database=bookmanage;Uid=root;Pwd=1206";
            conn = new MySqlConnection(strConn);
            bool isMatchNoAndTitle = true;
            conn.Open();
            String sql = "select * from book where no ='" + bookNo + "';";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                no = reader["no"].ToString();
                bookname = reader["bookname"].ToString();
                if(bookNo == no)
                {
                    if(bookTitle == bookname)
                    {
                        isMatchNoAndTitle = true;
                    }
                    else if (bookTitle != bookname)
                    {
                        isMatchNoAndTitle = false;
                    }
                }

            }
            reader.Close();
            conn.Close();
            return isMatchNoAndTitle;
        }
    }
}
