using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using MySql.Data.MySqlClient;

namespace BookManagementDB
{
    class Member
    {
        private static ShareClass share = ShareClass.getShareClass();
        MemberVO membervo = new MemberVO(null, null, null, null, null);
        public void addMember()
        {

            membervo.id = share.getException().inputId("ID");
            Console.Write("Password: ");
            membervo.pwd = Console.ReadLine();

            
        }
        public void deleteMember()
        {

        }
        public void modifyMember()
        {

        }
        public void searchMember()
        {

        }
    }
}
