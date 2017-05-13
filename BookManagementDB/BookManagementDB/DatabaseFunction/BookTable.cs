﻿using System;
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
            
            share.getDisplay().bookBar();
            while (reader.Read())
            {
                no = reader["no"].ToString();
                bookname = reader["bookname"].ToString();
                author = reader["author"].ToString();
                price = reader["price"].ToString();
                renting = reader["isRent"].ToString();

                Console.WriteLine(String.Format("  " + no + "  "+ bookname + "\t\t" + author + "\t" + price +" "+renting));
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
            int cnt = 0;
            strConn = "Server=localhost;Database=bookmanage;Uid=root;Pwd=1206";
            conn = new MySqlConnection(strConn);  // conncet MySQL
            conn.Open();
            share.getDisplay().membershipBar();
            String sql = "select * from book where " + titleOrAuthorOr + " like '" + searchWord + "%" + "';";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
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
                    Console.WriteLine(String.Format("  " + no + "  " + bookname + "\t\t" + author + "\t" + price + " " + renting));
                    share.getException().goBack("booksearch");
                }
            }
            if(cnt == 0)
            {
                Console.WriteLine("\t\t"+titleOrAuthorOr+" 내에서 "+ searchWord+"에 대한 검색결과가 없습니다");
                Thread.Sleep(800);
                share.getException().goBack("booksearch");
            }
            reader.Close();
            conn.Close();
        }

        public void changeRenting(string renting, string no)
        {
            strConn = "Server=localhost; Database=bookmanage; Uid=root; Pwd=1206";
            conn = new MySqlConnection(strConn); //MySQL 연결

            conn.Open();
            //update ABCDE set column1='xyz' where no='3'
            string sql = "update book set isRent ='" + renting +"'"+ " where no ="+"'"+no+"';";
            MySqlCommand cmd = new MySqlCommand(sql, conn); // command
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
        public void checkNo(string bookNo) //대출목록에 없는 No를 입력하면 없다고 뜨게
        {
            strConn = "Server=localhost;Database=bookmanage;Uid=root;Pwd=1206";
            conn = new MySqlConnection(strConn);  // conncet MySQL
            conn.Open();
            String sql = "select * from book ;";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                no = reader["no"].ToString();
                bookname = reader["bookname"].ToString();
                author = reader["author"].ToString();
                price = reader["price"].ToString();
                string renting = reader["isRent"].ToString();
               
            }
            reader.Close();
            conn.Close();
        }
        public void checkIsRent(string bookNo) //No를 입력하는데 대출불가능이면 빌릴수없다
        {
            strConn = "Server=localhost;Database=bookmanage;Uid=root;Pwd=1206";
            conn = new MySqlConnection(strConn);  // conncet MySQL
            conn.Open();
            String sql = "select * from book where ='" + bookNo + "';";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                no = reader["no"].ToString();
                bookname = reader["bookname"].ToString();
                author = reader["author"].ToString();
                price = reader["price"].ToString();
                string renting = reader["isRent"].ToString();
                if (renting == "대출 불가능")
                {
                    Console.WriteLine("대출 불가능 합니다.");
                }
                else if (renting == "대출 가능")
                {

                }
            }
            reader.Close();
            conn.Close();
        }


        public void checkBookTitle(string bookNo) //넘버와 북타이틀이 다르면 책제목 다르다고
        { 
            strConn = "Server=localhost;Database=bookmanage;Uid=root;Pwd=1206";
            conn = new MySqlConnection(strConn);  // conncet MySQL
            conn.Open();
            String sql = "select * from book ;";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                

            }
            reader.Close();
            conn.Close();
        }
    }
}
