using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS2019
{
    public class UserCtrl : Utiles
    {
        public static User validUser(string a, string b, string c)
        {
            string sql = "select  account,password,roleRight from users a inner join roleRight b on a.role=b.role ";
            sql += " where account='" + a + "' and password='" + b + "'and roleRight='" + c + "'";
            List<object[]> result = execQuery(sql);
            if (result.Count == 0)
                return null;
            User u = new User(a, b, c);
            return u;
        }
    }
}

