using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhaHangApi.ENTITY
{
    public class Account
    {
        string userName;
        string passWord;
        int type;
        int idEmployee;

        public string UserName
        {
            get
            {
                return userName;
            }

            set
            {
                userName = value;
            }
        }

        public string PassWord
        {
            get
            {
                return passWord;
            }

            set
            {
                passWord = value;
            }
        }

        public int Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        public int IdEmployee
        {
            get
            {
                return idEmployee;
            }

            set
            {
                idEmployee = value;
            }
        }
    }
}
