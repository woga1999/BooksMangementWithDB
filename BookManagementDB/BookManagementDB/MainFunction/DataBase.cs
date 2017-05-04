using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using MySql.Data.MySqlClient;

namespace BookManagementDB
{
    class DataBase
    {
        private static ShareClass share = ShareClass.getShareClass();
        String strConn;
        MySqlConnection conn;
        //string memberId = share.getMember().membervo.id;
        //string memberPwd = share.getMember().membervo.pwd;
        //string memberName = share.getMember().membervo.name;
        //string memberBirth = share.getMember().membervo.birthday;
        //string booktitle = share.getBook().bookvo.bookName;
        //string author = share.getBook().bookvo.author;
        //string price = share.getBook().bookvo.price;
        //string volume = share.getBook().bookvo.volume;
        public void addMemberInDB(string memberId, string memberPwd, string memberName, string memberBirth)
        {
            memberId = " "; memberPwd = " "; memberName = " "; memberBirth = " "; 
            
            strConn = "Server=localhost; Database=membership; Uid=root; Pwd=1206";
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

        public void deleteMemberInDB(string memberId, string memberPwd, string memberName, string memberBirth)
        {
            memberId = " "; memberPwd = " "; memberName = " "; memberBirth = " ";

            strConn = "Server=localhost; Database=membership; Uid=root; Pwd=1206";
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
    }
}
