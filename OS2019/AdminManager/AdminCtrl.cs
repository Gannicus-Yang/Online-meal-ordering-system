using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using OS2019.StoreManager;

namespace OS2019.AdminManager
{
    public class AdminCtrl:Utiles
    {
        public static void saveStore(Store s,string pass)
        {
            string sql1 = " insert into users values('" + s.account + "','" + pass + "','1')";
            execNonQuery(sql1);
            string sql2 = "insert into store(account,storeName,address,storeId) values('";
            sql2 += s.account + "','" + s.storeName + "','" + s.address + "','" + s.storeId  + "')";
            execNonQuery(sql2);
        }
        public static void searchStore(string storeName, string address, ListView lv)
        {
            string sql = "select account,storeName,address,storeId";
            sql += " from store where 1=1";
            if (!storeName.Equals(" "))
            {
                sql += " and storeName like'" + storeName + "%'";
            }
            if (!address.Equals(" "))
            {
                sql += " and address like'" + address + "%'";
            }
            string[] ch = { "用户名", "店名", "地址", "商家编号"};
            fillListView(lv, sql, ch);
        }
        public static void SearchCustomer(string name, ListView lv)
        {
            string sql = "select account,cName,sex,birthday";
            sql += " from customers where cName like'" + name + "%'";
            string[] ch = { "用户名", "姓名", "性别", "生日" };
            fillListView(lv, sql, ch);
        }
        public static void SearchTransaction(string cName,string sName, ListView lv)
        {
            string sql = "select cName,storeName,mealname,price,time";
            sql += " from record where 1=1 ";
            if (cName.Trim()!="")
            {
                sql += " and cName='" + cName + "'";
            }
            if (sName .Trim()!="")
            {
                sql += " and storeName='" + sName + "'";
            }
            string[] ch = { "顾客名", "商家名", "菜名", "价格" ,"时间"};
            fillListView(lv, sql, ch);
        }
        public static bool ValidAccount(string account)
        {
           string sql = "select account from users where account='" + account + "'";
           List<object[]> ans=execQuery(sql);
           if (ans.Count==1)
           return false;
           else
           return true;
         }
        public static Hashtable getRoleList()
        {
            Hashtable ht = new Hashtable();
            string sql = "select role,roleRight from roleRight order by role";
            List<object[]> list = execQuery(sql);
            for (int i = 0; i < list.Count; i++)
            {
                object[] o = list[i];
                ht.Add(o[1].ToString(), o[0].ToString());
            }
            return ht;
        }

    }
}
