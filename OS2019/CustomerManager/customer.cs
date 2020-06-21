using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS2019.CustomerManager
{
    public  class customer
    {
        string accout,name, passWord, secureQuestion, answer;
        public customer()
        {
            string sql = "select cName from customers";
            sql += " where account='"+LoginForm.u. account +"'";
            List<object[]> a = Utiles. execQuery(sql);
            this.name = a[0][0].ToString();
        }
        public string getName()
        {
            return name;
        }

    }
}
