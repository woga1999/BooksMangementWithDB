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
        public void rentSearch(string userid)
        {
            Console.Clear();
            strConn = "Server=localhost;Database=bookmanage;Uid=root;Pwd=1206";
            conn = new MySqlConnection(strConn);  
            conn.Open();
            String sql = "select * from rent where memberid like '" + userid +"';";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            string id = null;
            string title = null;
            string during = null;
            share.getDisplay().bookBar();
            while (reader.Read())
            {
                id = reader["memberid"].ToString();
                title = reader["bookname"].ToString();
                during = reader["duringrent"].ToString();

                cnt++;
                Console.WriteLine(String.Format("  " + id + "\t " + title + "\t\t" + during ));
            }
            if(cnt == 0) { Console.WriteLine("\n\t\t 빌린 책이 없습니다");Thread.Sleep(800); }

            reader.Close();
            conn.Close();
        }
    }
}
