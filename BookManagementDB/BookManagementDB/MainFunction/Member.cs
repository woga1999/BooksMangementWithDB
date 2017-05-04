using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using MySql.Data.MySqlClient;

namespace BookManagementDB
{//회원 등록, 삭제, 수정 등 회원 관련한 기능들
    class Member
    {
        private static ShareClass share = ShareClass.getShareClass();
        public MemberVO membervo = new MemberVO(null, null, null, null);
        
        string input = null;
        public void addMember(string message) //회원정보 등록할 때 필요하다.
        {
            share.getDisplay().status(message);
            membervo.id = share.getException().inputId("\t ID");
            Console.Write("\t Password: ");
            membervo.pwd = Console.ReadLine(); //회원정보 등록할 때는 보이게 한다.
            Console.Write("\t Name: ");
            membervo.name = Console.ReadLine();
            Console.Write("\t Birth: ");
            membervo.birthday = Console.ReadLine();

            new MemberVO(membervo.id, membervo.pwd, membervo.name, membervo.birthday);
            share.getDataBase().addMemberInDB(membervo.id, membervo.pwd, membervo.name, membervo.birthday);

        }

        public void deleteMember()
        {
            Console.WriteLine("\n\t Put Member's Name and Id ");
            Console.Write("\t Member Name: ");
            input = Console.ReadLine();
            string input2 = share.getException().inputId("\t ID");

            if (input == membervo.name)
            {
                if (input2 == membervo.id)
                {
                            share.getDataBase().deleteMemberInDB(membervo.id,membervo.name);
                            //int removeIndex = index;
                            //memberList.RemoveAt(removeIndex);
                            //share.getDataBase().deleteMemberInDB(memberList[removeIndex].id, memberList[removeIndex].pwd, memberList[removeIndex].name, memberList[removeIndex].birthday, memberList[removeIndex].rentbook, memberList[removeIndex].duringrent);
                }
                else
                    Console.WriteLine("Not exist Member");
            }
            else
                Console.WriteLine("Not exist Name.");

            //존재하지 않으니 전 메뉴 모음으로 돌아가기, 삭제했으니 전 메뉴 모음으로 돌아가기
        }

        public void modifyMember() //회원이 로그인해서 회원수정하고 싶을 때
        {
            Console.WriteLine("\n\t If you want to modify info that you put 'ID' and 'PassWord'! ");
            input = share.getException().inputId("\t ID");
            Console.Write("\t Password: ");
            string input2 = share.getException().inputpwd();
            if (input == membervo.id)
            {
                if (input == membervo.pwd)
                {
                    share.getDataBase().deleteMemberInDB(membervo.id, membervo.name);
                    addMember("Membership Modify");
                }
                else
                    Console.WriteLine("Not exist Member");
            }
            else
                Console.WriteLine("Not exist ID");
        }
        public void searchMember()
        {

        }
    }
}
