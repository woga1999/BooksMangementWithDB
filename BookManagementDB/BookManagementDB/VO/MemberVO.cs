using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementDB
{
    class MemberVO
    {
        private string memberName;
        //private string memberNum;
        private string memberBirth;
        private string identiification;
        private string password;

        public MemberVO(string id, string pwd, string name, string birthday) //개인적인 정보들이기 때문에 private로 선언하고 정보를 뺴온다.
        {
            identiification = id;
            password = pwd;
            memberName = name;
            memberBirth = birthday;
        }

        public string name
        {
            get { return memberName; }
            set { memberName = value; }
        }

        public string birthday
        {
            get { return memberBirth; }
            set { memberBirth = value; }
        }

        public string id
        {
            get { return identiification; }
            set { identiification = value; }
        }

        public string pwd
        {
            get { return password; }
            set { password = value; }
        }
    }
}
