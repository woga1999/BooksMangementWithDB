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
        
        string input = null;
        public void addMember(string message) //회원정보 등록할 때 필요하다.
        {
            share.getDisplay().status(message); //등록 시 보일 디스플레이
            string memeberId = share.getException().inputIdWhenAdd("\t ID"); //ID의 예외처리 6~10자리 사이 숫자와영어 조합만 가능
            
            string memberPwd = share.getException().exceptString("Password"); //회원정보 등록할 때는 비밀번호가 보이게 한다.
            string memberName = share.getException().exceptName("Name");
            string memberBirthday = share.getException().onlySixNumDigits();
            
            share.getMemberTable().addMemberInDB(memeberId, memberPwd, memberName, memberBirthday); //데이터베이스에 정보 추가

        }

        public void deleteMember()
        {
            Console.Clear();
            
            share.getMemberTable().memberAllSearchOfDB();
            Console.WriteLine("\n\n\t Put to delete Member's Id ");
            string input2 = share.getException().inputIdWhenDelete("\t ID");
            bool isRent = share.getRentTable().Checkrentbook(input2);
            if (isRent.Equals(false))
            {
                share.getMemberTable().deleteMemberInDB(input2, "정보가 삭제되었습니다.");
            }
             else if (isRent.Equals(true))
            {
                Console.Write("\n\t\t대여 중인 책이 있으므로 삭제할 수 없습니다.");
                Thread.Sleep(800);
            }              
        }

        public void modifyMember() //회원이 로그인해서 회원수정하고 싶을 때
        {
            Console.Clear();
            Console.WriteLine("\n\t If you want to modify info that you put 'PassWord'! ");
            Console.Write("\t Password: ");
            input = share.getException().matchpw();

            share.getMemberTable().deleteMemberInDB(share.getLoginId(),  "\b\b");
            addMember("Membership Modify");
        }

        public void searchMembers(string putCategory)
        {
            Console.Write("\n\n\t Put wanna search keyword ");
            input = share.getException().exceptSearchWord(putCategory);

            share.getMemberTable().searchMembers(putCategory, input);
        }
       
    }
}
