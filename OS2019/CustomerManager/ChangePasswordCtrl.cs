using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace OS2019.CustomerManager
{
    public class ChangePasswordCtrl : Utiles
    {
        public static void change(string newpassword, string account)
        {
            string sql = "update users set password ='" + newpassword + "' where account='" + account + "'";
            execNonQuery(sql);
        }
        public static void showquestion(TextBox t1, string account)
        {
            string sql = "select question from securequestion where account='";
            sql += account + "'";
            List<object[]> a = execQuery(sql);
            t1.Text = a[0][0].ToString();
        }
        public static string answer(string account)
        {
            string sql = "select answer from securequestion where account='";
            sql += account + "'";
            return execQuery(sql)[0][0].ToString();
        }
    }
}
