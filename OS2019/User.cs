using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS2019
{

    public class User
    {
        public string account, password, role;
        public User(string account, string password, string role)
        {
            this.account = account;
            this.password = password;
            this.role = role;
        }

    }

}
