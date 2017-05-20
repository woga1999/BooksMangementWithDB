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
        String strConn;
        MySqlConnection conn;
        int cnt = 0, count = 3;
        string id = null;
        string no = null;
        string title = null;
        string rentDay = null;
        string returnDay = null;
        public RentTable()
        {
            strConn = "Server=localhost; Database=bookmanage; Uid=root; Pwd=1206";
            
        }
        
        
        public void rentSearch(string userid, string message) //뭘 빌렸는지 로그인 한 본인 아이디에 관해서 출력
        {
            Console.Clear();
            conn = new MySqlConnection(strConn);  
            conn.Open();
            String sql = "select * from rent where memberid ='" + userid +"';";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            ShareClass.getShareClass().getDisplay().rentBookBar();
            while (reader.Read())
            {
                id = reader["memberid"].ToString();
                no = reader["no"].ToString();
                title = reader["bookname"].ToString();
                rentDay = reader["rentday"].ToString();
                returnDay = reader["returnday"].ToString();

                Console.SetCursorPosition(8, count);
                Console.Write(id);
                Console.SetCursorPosition(30, count);
                Console.Write(no);
                Console.SetCursorPosition(40, count);
                Console.Write(title);
                Console.SetCursorPosition(68, count);
                Console.Write(rentDay);
                Console.SetCursorPosition(95, count);
                Console.Write(returnDay);
                count += 2; cnt++;
            }
            if(cnt == 0)
            {
                Console.Clear();
                Console.WriteLine("\n\t\t {0} 책이 없습니다", message);Thread.Sleep(800);
            }

            reader.Close();
            conn.Close();
            
        }

        public void addRentTable(string bookNo, string bookTitle) //대출 시 rent 테이블에 들어갈 데이터 추가 쿼리문
        {
            
            conn = new MySqlConnection(strConn);

            conn.Open();

            string sql = "insert into rent values('" + ShareClass.getShareClass().getLoginId()+ "','" + bookNo + "','" + bookTitle +"','"+ DateTime.Now+"','"+DateTime.Now.AddDays(7) + "' ); ";
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
            conn = new MySqlConnection(strConn);
            bool isMatchNo = false;
            conn.Open();
            string sql = "select * from rent where memberid ='" + ShareClass.getShareClass().getLoginId() + "';";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string memberid = reader["memberid"].ToString();
                string no = reader["no"].ToString();
                string bookName = reader["bookname"].ToString();
                if (ShareClass.getShareClass().getLoginId() == memberid)
                {
                    if (bookNo == no)
                    {
                        isMatchNo = true;
                        break;
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
            conn = new MySqlConnection(strConn); 
            bool isMatchName = true;
            conn.Open();
            string sql = "select * from rent where memberid ='" + ShareClass.getShareClass().getLoginId() + "';";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string memberid = reader["memberid"].ToString();
                string no = reader["no"].ToString();
                string bookName = reader["bookname"].ToString();
                if (ShareClass.getShareClass().getLoginId() == memberid)
                {
                    if (bookNo == no)
                    {
                        if(bookTitle == bookName)
                        {
                            isMatchName = true;
                            break;
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

        public int rentCount(string userid) //뭘 빌렸는지 개수를 세서 대출 제한을 둘 수 있게 한다
        {
            Console.Clear();
            conn = new MySqlConnection(strConn);
            conn.Open();
            String sql = "select * from rent where memberid ='" + userid + "';";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            ShareClass.getShareClass().getDisplay().rentBookBar();
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

        public bool Checkrentbook(string userid)
        {
            conn = new MySqlConnection(strConn);
            conn.Open();
            bool isRent = false;
            String sql = "select * from rent where memberid ='" + userid + "';";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            
            while (reader.Read())
            {
                id = reader["memberid"].ToString();
                if (userid == id)
                {
                    isRent = true;
                    break;
                }
                else
                {
                    isRent = false;
                }
            }

            reader.Close();
            conn.Close();
            return isRent;
        }
    }
}
