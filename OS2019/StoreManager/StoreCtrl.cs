using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Data.OleDb;

namespace OS2019.StoreManager
{
    public class StoreCtrl:Utiles
    {           
        public static  void listInfo(Store s,ListView lv)
        {
            string sql = "select account,storeName,address,storeId from store";
            sql += " where account='" + s.account + "'";
            string[] ch = { "用户名", "店名", "地址", "商家编号" };
            fillListView(lv, sql, ch);
        }
        public static  void updateInfo(Store s)
        {          
            string sql = " update store set storeName='"+s.storeName +"'";
            sql += " where account='"+s.account+"'";         
            execNonQuery(sql);
        }
        public static  void updateAddress(Store s)
        {
            string sql = " update store set address='" + s.address + "'";
            sql += " where account='" + s.account+"'";
            execNonQuery(sql);
        }
        public static  void loadAllMeals(ListView lv, Store s)
        {
            string sql = "select m.mealId,mealName,mealType,price from menu m";
            sql += " inner join storeMenu sm on m.mealId=sm.mealId";
            sql += " inner join store s on sm.storeId=s.storeId";
            sql += " where s.account='" + s.account  + "'";
            sql += " order by mealType";
            string[] ch = { "编号", "菜名", "种类", "价格" };
            fillListView(lv, sql, ch);
        }
        
        public  static  void saveMeal(Store s,Meal m)
        {
            string sql1 = "insert into menu (mealName,price,mealType,mealId) values('";
            sql1 += m.mealName + "','" + m.price + "','" + m.mealType + "','" + m.mealId + "')";
            execNonQuery(sql1);
            string sql3 = "select * from store";
            sql3 += " where store.account='" + s.account + "'";
            List<object[]> a = execQuery(sql3);
            s.storeId = a[0][3].ToString ();
            string sql2 = "insert into storeMenu (storeId,mealId) values('";
            sql2 += s.storeId +"','"+ m.mealId +"')";          
            execNonQuery(sql2);
        }
        public  static  void updatePrice(Meal m)
        {
            string sql = "update menu set price='" + m.price  + "'";
            sql += " where mealId='"+m.mealId +"'";
            execNonQuery(sql);
        }
        public  static  void deleteMeal(Meal m)
        {
            string sql4 = "delete from storeMenu where mealId='" + m.mealId + "'";
            execNonQuery(sql4);
            string sql2 = "delete from menu where mealId='" + m.mealId + "'";          
            execNonQuery(sql2);                     
        }
        public static  void loadAllOrders(ListView lv,Store s)
        {
            string sql = "select cName,mealName,price,time from record r";
            sql += " inner join store s on r.storeName =s.storeName";            
            sql += " where s.account='" + s.account + "'";
            string[] ch = { "用户名", "菜名", "价格", "时间" };
            fillListView(lv, sql, ch);
        }
        public static void loadName(Store s)
        {           
            string sql = "select storeName from store";
            sql += " where store.account='"+s.account +"'";
            List<object[]> a = execQuery(sql);
            s.storeName = a[0][0].ToString();            
        }
        public static void loadSumOrders(ListView lv, Store s)
        {
            string sql = "select cName,sum(price),time from record r";
            sql += " inner join store s on r.storeName =s.storeName";
            sql += " where s.account='" + s.account + "'";            
            sql += " group by cName,time ";
            string[] ch = { "用户名",  "总价格", "时间" };
            fillListView(lv, sql, ch);
        }
    }
}
