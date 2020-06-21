using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OS2019.CustomerManager
{
    public  class UpdateInfoCtrl:Utiles
    {
        public  static  void update(string question,string answer)
        {
            string sql2 = " update securequestion set account='" + LoginForm.u.account + "'";
            if (question  != "")
                sql2 += " ,question='" + question  + "'";
            if (answer  != "")
                sql2 += " ,answer='" + answer + "'";
            sql2+=" where account='" + LoginForm.u. account + "'";
            execNonQuery(sql2);
        }
        public static void showIf(string account,RichTextBox rt1, RichTextBox rt2)
        {
            string sql = "select a.account,question,answer";
            sql += " from customers a inner join securequestion b on a.account=b.account ";
            sql += " where a.account='" + account  + "'";
            execQuery(sql);
            List <object []> ob= execQuery(sql);
            if (ob.Count != 0)
            {
                rt1.Text = ob[0][1].ToString();
                rt2.Text = ob[0][2].ToString();
            }
            else
            {
                MessageBox.Show("请先创建密保问题！");
            }
        }
    }
}
