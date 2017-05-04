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
        private string rentWhichBook;
        private string duringRent;

        public MemberVO(string id, string pwd, string name, string birthday, string rentbook, string duringrent) //개인적인 정보들이기 때문에 private로 선언하고 정보를 뺴온다.
        {
            identiification = id;
            password = pwd;
            memberName = name;
            memberBirth = birthday;
            rentWhichBook = rentbook;
            duringRent = duringrent;
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

        public string rentbook
        {
            get { return rentWhichBook; }
            set { rentWhichBook = value; }
        }

        public string duringrent
        {
            get { return duringRent; }
            set { duringRent = value; }
        }
    }
}
