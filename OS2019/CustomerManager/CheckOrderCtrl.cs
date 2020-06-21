using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OS2019.CustomerManager
{
    public class CheckOrderCtrl:Utiles
    {
        public static void loadAllOrders(ListView lv,string name)
        {
            string sql = "select * from record a";
            sql += " inner join customers b on a.cName =b.cName";
            sql += " where a.cName='" + name + "'";
            string[] ch = { "用户名", "商家名","菜名", "价格", "时间" };
            fillListView(lv, sql, ch);
        }
        public static void loadSumOrders(ListView lv, string name)
        {
            string sql = "select cName,storeName,sum(price),time from record ";
            sql += " where cName='" + name + "'";
            sql += " group by cName,storeName,time ";
            string[] ch = { "用户名", "商家名","总价格", "时间" };
            fillListView(lv, sql, ch);
        }

    }
}
