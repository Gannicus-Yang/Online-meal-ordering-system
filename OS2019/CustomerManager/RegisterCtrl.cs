using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OS2019.CustomerManager
{
    public class RegisterCtrl : Utiles
    {
        public static int register(string a, string b, string c, string d, string e)
        {
            if (c == b)
            {
                string sql1 = "insert into users values('";
                sql1 += a + "','";//账号
                sql1 += b + "','";//密码
                sql1 += "2')";  //角色
                execNonQuery(sql1);
                string sql2 = "insert into securequestion values('";
                sql2 += a + "','";
                sql2 += d + "','";
                sql2 += e + "')";
                execNonQuery(sql2);
                MessageBox.Show("恭喜您注册成功！");
                return 1;
            }
            else
            {
                MessageBox.Show("两次密码输入不一致");
                return 0;
            }
        }
    }
}
