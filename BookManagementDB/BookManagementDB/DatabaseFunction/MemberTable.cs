using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using MySql.Data.MySqlClient;

namespace BookManagementDB
{//Member 테이블 이용해 쓰는 기능들 모아놓은 클래스

    class MemberTable
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

            conn.Close();
        }

        public void deleteMemberInDB(string memberId, string message) //삭제 쿼리 문을 이용한 데이터 삭제
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
                Console.WriteLine("\t\t"  + message);
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

        public void memberAllSearchOfDB() //DB 내 저장한 데이터들 모두 출력
        {
            strConn = "Server=localhost;Database=bookmanage;Uid=root;Pwd=1206";
            conn = new MySqlConnection(strConn);  
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


                Console.WriteLine(String.Format("  " + memberid + "\t " + password + "\t\t" + name + "\t\t" + birth));
            }

            reader.Close();
            conn.Close();
            share.getException().goBack("membersearch");
        }

        public bool IsIdDuplication(string userid) //Id가 DB내 데이터를 비교하여 존재하는지 
        {
            strConn = "Server=localhost;Database=bookmanage;Uid=root;Pwd=1206";
            conn = new MySqlConnection(strConn);  
            conn.Open();
            String sql = "select * from member;";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            bool duplication = false;
            while (reader.Read())
            {
                memberid = reader["memberid"].ToString();
                if (userid == memberid) { duplication = true; break; }
                else
                {
                    duplication = false;
                }

            }
            reader.Close();
            conn.Close();

            return duplication;
        }

        public bool checkIdOfPwd(string userid, string pwd)
        {
            strConn = "Server=localhost;Database=bookmanage;Uid=root;Pwd=1206";
            conn = new MySqlConnection(strConn);  // conncet MySQL
            bool isMatchPwd = true;
            conn.Open();
            String sql = "select * from member;";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                memberid = reader["memberid"].ToString();
                password = reader["password"].ToString();
                if (memberid == userid)
                {
                    if (password == pwd)
                    {
                        Console.WriteLine("\t 확인되었습니다.");
                        Thread.Sleep(800);
                        isMatchPwd = true;
                    }
                    else if (password != pwd)
                    {
                        Console.WriteLine("\t 비밀번호가 맞지 않습니다.");
                        Thread.Sleep(800);
                        isMatchPwd = false;
                    }
                }

            }

            reader.Close();
            conn.Close();

            return isMatchPwd;
        }

        public void loginUsingDB(string input, string input2)
        {
            strConn = "Server=localhost;Database=bookmanage;Uid=root;Pwd=1206";
            conn = new MySqlConnection(strConn);  // conncet MySQL
            bool login = true;
            conn.Open();
            String sql = "select * from member;";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                memberid = reader["memberid"].ToString();
                password = reader["password"].ToString();
                name = reader["name"].ToString();
                if (input == memberid)
                {
                    if (input2 == password)
                    {
                        Console.Clear();
                        saveMemberID(memberid);
                        login = true;
                        Console.WriteLine("\n\n\t\t" + name + "님 로그인되셨습니다."); //로그인 성공! 로그인시 뜨는 화면으로 들어간다
                        Thread.Sleep(800);
                        share.getMenu().menuOnLogin();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\n\n\t 비밀번호 오류");
                        Thread.Sleep(800);
                        share.getLogin().login(); //다시한번 로그인 창
                    }
                }
                else
                {
                    login = false;
                }

            }
            if (login.Equals(false))
            {
                Console.WriteLine("\n\n\t 아이디가 존재하지 않습니다");
                Thread.Sleep(800);
                share.getMenu().mainMenu();
            }
            reader.Close();
            conn.Close();
        }

        internal void saveMemberID(string userId)
        {
            share.setLoginId(userId);
        }

        public void searchMembers(string nameOrId, string searchWord)
        {
            strConn = "Server=localhost;Database=bookmanage;Uid=root;Pwd=1206";
            conn = new MySqlConnection(strConn);  // conncet MySQL
            conn.Open();
            share.getDisplay().membershipBar();
            String sql = "select * from member where "+ nameOrId + " like '" + searchWord + "%" + "';";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                memberid = reader["memberid"].ToString();
                password = reader["password"].ToString();
                name = reader["name"].ToString();
                birth = reader["birth"].ToString();
                if (name.Contains(searchWord) || memberid.Contains(searchWord))
                {
                    Console.WriteLine(String.Format("  " + memberid + "\t " + password + "\t\t" + name + "\t\t" + birth));
                    share.getException().goBack("membersearch");
                }

            }
            reader.Close();
            conn.Close();
        }

        public bool isMatchMember(string nameOrId, string checkWord) //booktable과는 비슷한 방식의 search 
        {
            strConn = "Server=localhost;Database=bookmanage;Uid=root;Pwd=1206";
            conn = new MySqlConnection(strConn);
            bool isMatch = false;
            conn.Open();
            String sql = "select * from member where " + nameOrId + " like '" + checkWord+ "%" + "';";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                isMatch = true;

            }
            if (isMatch.Equals(false))
            {
                isMatch = false;
            }
                reader.Close();
            conn.Close();
            return isMatch;
        }
    }
}
