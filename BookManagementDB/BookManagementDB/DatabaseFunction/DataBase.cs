using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using MySql.Data.MySqlClient;

namespace BookManagementDB
{//Membership 데이터베이스 이용해 쓰는 기능들 모아놓은 클래스
    class DataBase
    {
        private static ShareClass share = ShareClass.getShareClass();
        String strConn;
        MySqlConnection conn;
        string memberid = null;
        string password = null;
        string name = null;
        string birth = null;
        public void addMemberInDB(string memberId, string memberPwd, string memberName, string memberBirth)
        {
                        
            strConn = "Server=localhost; Database=bookmanage; Uid=root; Pwd=1206";
            conn = new MySqlConnection(strConn); //MySQL 연결
            
            conn.Open();

            string sql = "insert into member values('" + memberId + "', '" + memberPwd + "', '" + memberName + "', '" + memberBirth + "');";
            MySqlCommand cmd = new MySqlCommand(sql, conn); // command
            int count = (int)cmd.ExecuteScalar();
            if (count > 0) { Console.Write("already exist in Database"); share.getMember().addMember("Membership OnemoreEntry"); }
            else if (count == 0)
            {
                if (cmd.ExecuteNonQuery() == 1)
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\n\n");
                    Console.WriteLine("\t\t" + memberName + "님 환영합니다");
                    Thread.Sleep(1000);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Database Error!!");
                    Thread.Sleep(1000);
                }
            }
            
            conn.Close();
            
        }

        public void deleteMemberInDB(string memberId, string memberName/*, string memberPwd, , string memberBirth, string whichBookRented, string duringRent*/)
        {

            strConn = "Server=localhost; Database=bookmanage; Uid=root; Pwd=1206";
            conn = new MySqlConnection(strConn); //MySQL 연결

            conn.Open();

            string sql = "delete from member where memberid = '" + memberId + "'; ";
            MySqlCommand cmd = new MySqlCommand(sql, conn); // command
            if (cmd.ExecuteNonQuery() == 1)
            {
                Console.Clear();
                Console.WriteLine("\n\n\n\n");
                Console.WriteLine("\t\t" + memberName + "님 정보가 삭제되었습니다.");
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

        public void memberAllSearchOfDB()
        {
            strConn = "Server=localhost;Database=bookmanage;Uid=root;Pwd=1206";
            conn = new MySqlConnection(strConn);  // conncet MySQL
            conn.Open();
            String sql = "select * from member;";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
           
            share.getDisplay().membershipBar();
            while (reader.Read())
            {
                memberid = reader["memberid"].ToString();
                password = reader["password"].ToString();
                name = reader["name"].ToString();
                birth = reader["birth"].ToString();
                

                Console.WriteLine(String.Format("  "+ memberid + "\t " + password + "\t " + name + "\t\t" + birth));
            }

            reader.Close();
            conn.Close();   
        }

        public bool IsIdDuplication(string userid)
        {
            strConn = "Server=localhost;Database=bookmanage;Uid=root;Pwd=1206";
            conn = new MySqlConnection(strConn);  // conncet MySQL
            conn.Open();
            String sql = "select * from member;";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            string memberid = share.getMember().membervo.id;
            bool duplication = false;
            while (reader.Read())
            {
                memberid = reader["memberid"].ToString();
                if (userid == memberid) { duplication = true; }
            else
            {
                duplication = false;
            }

            }
            
            
            return duplication;
        }

        public int loginUsingDB(string input, string input2)
        {
            int cnt = 0;
            strConn = "Server=localhost;Database=bookmanage;Uid=root;Pwd=1206";
            conn = new MySqlConnection(strConn);  // conncet MySQL
            conn.Open();
            String sql = "select * from member;";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                memberid = reader["memberid"].ToString();
                password = reader["password"].ToString();
                if (input == memberid)
                {
                    if (input2 == password)
                    {
                        Console.Clear();
                        Console.WriteLine("\n\n\t\t로그인되셨습니다.");
                    }
                    else
                     cnt++;
                }
                else
                    cnt++;
            }
            return cnt;
        }
    }
}
