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
            share.getDisplay().status(message); //등록 시 보일 디스플레이
            membervo.id = share.getException().inputId("\t ID"); //ID의 예외처리 6~10자리 사이 숫자와영어 조합만 가능
            Console.Write("\t Password: ");
            membervo.pwd = Console.ReadLine(); //회원정보 등록할 때는 비밀번호가 보이게 한다.
            Console.Write("\t Name: ");
            membervo.name = Console.ReadLine();
            Console.Write("\t Birth(Only 6digits): ");
            membervo.birthday = Console.ReadLine();

            new MemberVO(membervo.id, membervo.pwd, membervo.name, membervo.birthday);
            share.getMemberTable().addMemberInDB(membervo.id, membervo.pwd, membervo.name, membervo.birthday); //데이터베이스에 정보 추가

        }

        public void deleteMember()
        {
            Console.Clear();
            share.getMemberTable().memberAllSearchOfDB();
            Console.WriteLine("\n\t Put to delete Member's Name and Id ");
            string input2 = share.getException().inputId("\t ID");
            Console.Write("\t Member Name: ");
            input = Console.ReadLine();

            share.getMemberTable().deleteMemberInDB(input2, input, "님 정보가 삭제되었습니다.");
                           

            //존재하지 않으니 전 메뉴 모음으로 돌아가기, 삭제했으니 전 메뉴 모음으로 돌아가기
        }

        public void modifyMember() //회원이 로그인해서 회원수정하고 싶을 때
        {
            Console.WriteLine("\n\t If you want to modify info that you put 'PassWord'! ");
            Console.Write("\t Password: ");
            input = share.getException().matchpw();

            share.getMemberTable().deleteMemberInDB(share.getLoginId(), input, "님");
            addMember("Membership Modify");
        }
        public void searchMember()
        {

        }
    }
}
