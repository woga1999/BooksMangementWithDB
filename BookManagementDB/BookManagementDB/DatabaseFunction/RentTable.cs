using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using MySql.Data.MySqlClient;

namespace BookManagementDB
{
    class RentTable
    {
        private static ShareClass share = ShareClass.getShareClass();
        String strConn;
        MySqlConnection conn;
        int cnt = 0;
        string id = null;
        string no = null;
        string title = null;
        string rentDay = null;
        string returnDay = null;
        public void rentSearch(string userid) //뭘 빌렸는지 로그인 한 본인 아이디에 관해서 출력
        {
            Console.Clear();
            strConn = "Server=localhost;Database=bookmanage;Uid=root;Pwd=1206";
            conn = new MySqlConnection(strConn);  
            conn.Open();
            String sql = "select * from rent where memberid ='" + userid +"';";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            share.getDisplay().rentBookBar();
            while (reader.Read())
            {
                id = reader["memberid"].ToString();
                no = reader["no"].ToString();
                title = reader["bookname"].ToString();
                rentDay = reader["rentday"].ToString();
                returnDay = reader["returnday"].ToString();
                cnt++;
                Console.WriteLine(String.Format("  " + id + " " + no+ "\t " + title + "\t\t" + rentDay + "  "+returnDay  ));
            }
            if(cnt == 0)
            {
                Console.WriteLine("\n\t\t 빌린 책이 없습니다");Thread.Sleep(800);
            }

            reader.Close();
            conn.Close();
            share.getException().goBack("memberlogin");
        }

        public void addRentTable(string bookNo, string bookTitle) //대출 시 rent 테이블에 들어갈 데이터 추가 쿼리문
        {
            strConn = "Server=localhost; Database=bookmanage; Uid=root; Pwd=1206";
            conn = new MySqlConnection(strConn);

            conn.Open();

            string sql = "insert into rent values('" + share.getLoginId()+ "','" + bookNo + "','" + bookTitle +"','"+ DateTime.Now+"','"+DateTime.Now.AddDays(7) + "' ); ";
            MySqlCommand cmd = new MySqlCommand(sql, conn); 

            if (cmd.ExecuteNonQuery() == 1)
            {
                Console.Clear();
                Console.WriteLine("\n\n\n\n");
                Console.WriteLine("\t\t"+ bookTitle + " 대여되셨습니다.");
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

        public void deleteRentTable(string bookTitle) //삭제쿼리문을 이용해 반납 함수 기능을 하게 한다
        {
            strConn = "Server=localhost; Database=bookmanage; Uid=root; Pwd=1206";
            conn = new MySqlConnection(strConn); 

            conn.Open();

            string sql = "delete from rent where bookname = '" + bookTitle + "'; ";
            MySqlCommand cmd = new MySqlCommand(sql, conn); 

            if (cmd.ExecuteNonQuery() == 1)
            {
                Console.Clear();
                Console.WriteLine("\n\n\n\n");
                Console.WriteLine("\t\t" + bookTitle+" 반납하셨습니다.");
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

        public bool checkRentBookNo(string bookNo) //rent 테이블 내 데이터들을 비교해서 빌린 책 넘버가 맞는지 확인
        {
            strConn = "Server=localhost; Database=bookmanage; Uid=root; Pwd=1206";
            conn = new MySqlConnection(strConn);
            bool isMatchNo = false;
            conn.Open();
            string sql = "select * from rent where memberid ='" + share.getLoginId() + "';";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string memberid = reader["memberid"].ToString();
                string no = reader["no"].ToString();
                string bookName = reader["bookname"].ToString();
                if (share.getLoginId() == memberid)
                {
                    if (bookNo == no)
                    {
                        isMatchNo = true;
                    }
                    else
                    {
                        isMatchNo = false;
                    }
                }
            }
            reader.Close();
            conn.Close();

            return isMatchNo;
        }
        public bool checkRentBookName(string bookNo,string bookTitle) //rent 테이블 내 빌린 책 넘버와 책 이름이 맞는지 비교한다
        {
            strConn = "Server=localhost; Database=bookmanage; Uid=root; Pwd=1206";
            conn = new MySqlConnection(strConn); 
            bool isMatchName = true;
            conn.Open();
            string sql = "select * from rent where memberid ='" + share.getLoginId() + "';";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string memberid = reader["memberid"].ToString();
                string no = reader["no"].ToString();
                string bookName = reader["bookname"].ToString();
                if (share.getLoginId() == memberid)
                {
                    if (bookNo == no)
                    {
                        if(bookTitle == bookName)
                        {
                            isMatchName = true;
                        }
                        else if (bookTitle != bookName)
                        {
                            isMatchName = false;
                        }
                    }
                }
            }
            reader.Close();
            conn.Close();

            return isMatchName;
        }

        public int rentCount(string userid) //뭘 빌렸는지 로그인 한 본인 아이디에 관해서 출력
        {
            Console.Clear();
            strConn = "Server=localhost;Database=bookmanage;Uid=root;Pwd=1206";
            conn = new MySqlConnection(strConn);
            conn.Open();
            String sql = "select * from rent where memberid ='" + userid + "';";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            share.getDisplay().rentBookBar();
            while (reader.Read())
            {
                id = reader["memberid"].ToString();
                no = reader["no"].ToString();
                title = reader["bookname"].ToString();
                rentDay = reader["rentday"].ToString();
                returnDay = reader["returnday"].ToString();
                cnt++;
              
            }

            reader.Close();
            conn.Close();

            return cnt;
        }

    }
}
