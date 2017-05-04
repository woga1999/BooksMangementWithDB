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
        public MemberVO membervo = new MemberVO(null, null, null, null);
        string input = null;
        public void addMember() //회원정보 등록할 때 필요하다.
        {
            Console.WriteLine("\t\t -Membership Join-          ");
            Console.WriteLine("                                       Wanna back put <back>");
            Console.WriteLine("");
            membervo.id = share.getException().inputId("\t ID");
            Console.Write("\t Password: ");
            membervo.pwd = share.getException().inputpwd();
            Console.Write("\t Name:");
            membervo.name = Console.ReadLine();
            Console.Write("\t Birth: ");
            membervo.birthday = Console.ReadLine();

            new MemberVO(membervo.id, membervo.pwd, membervo.name, membervo.birthday);
            share.getDataBase().addMemberInDB(membervo.id, membervo.pwd, membervo.name, membervo.birthday);

        }

        public void deleteMember()
        {
            Console.WriteLine("\n\t 삭제 할 Id와 Password를 입력해주세요");
            input = share.getException().inputId("\t ID");
            Console.Write("\t Password: ");
            string input2 = share.getException().inputpwd();
            if (input == membervo.id)
            {
                if (input == membervo.pwd)
                {
                    share.getDataBase().deleteMemberInDB(membervo.id, membervo.pwd, membervo.name, membervo.birthday);
                }
                else
                    Console.WriteLine("존재하지 않는 회원입니다.");
            }
            else
                Console.WriteLine("Id가 존재하지 않습니다.");
        }
        public void modifyMember() //회원이 로그인해서 회원수정하고 싶을 때
        {

        }
        public void searchMember()
        {

        }
    }
}
