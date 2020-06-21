using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OS2019.CustomerManager
{
    public class OrderingFoodCtrl:Utiles
    {
        public static string storename;
        public static void searchStore(ListView lv,string name)
        {
            string sql = "select storeName,address,assessment";
            sql += " from store a inner join storeassessment b on a.storeId=b.storeId  where";
            if (name != null)
                sql += " 1=1 and storeName like '";
            sql+=name+"%'";
            Utiles.execQuery(sql);
            string[] ch = { "名称","地址","评分" };
            Utiles.fillListView(lv,sql,ch);
        }
        public static void loadMenu(ListView lv1,ListView lv2)
        {
            storename = lv1.SelectedItems[0].SubItems[0].Text.ToString();
            if (lv1.SelectedItems.Count == 1)
            {
                string sql = "select mealName,mealType,price";
                sql += " from menu a inner join storeMenu b on a.mealId=b.mealId ";
                sql += " inner join store c on b.storeId=c.storeId ";
                sql += " where c.storeName='" + storename + "'";
                Utiles.execQuery(sql);
                string[] ch = { "菜品名称", "类型", "价格" };
                Utiles.fillListView(lv2, sql, ch);
            }
        }
        public static void loadSelectedMeal(ListView lv1,ListView lv2)
        {
            lv2.View = View.Details; 
            lv2.MultiSelect = false; 
            lv2.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lv2.Visible = true;
            lv2.GridLines = true;
            lv2.FullRowSelect = true;
            string[] ch = { "菜品名称", "类型", "价格" };
            if (ch != null&&lv2.Columns.Count ==0)
            {
                for (int i = 0; i < ch.Length; i++)
                { //     设置表头信息
                    lv2.Columns.Add(ch[i], 100, HorizontalAlignment.Center);
                }
            }
            string  [] a={"","",""};
                if (ch == null)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        lv2.Columns.Add(ch[i], 100, HorizontalAlignment.Center);
                    }
                }
             
                for (int i = 0; i < 3; i++)
                {
                    a[i]=lv1.SelectedItems[0].SubItems[i].Text.ToString();
                    
                }
                ListViewItem li = new ListViewItem();//形成一个表项
                li.SubItems.Clear();
                li.SubItems[0].Text = a[0].ToString();//设置第一列
                for (int j = 1; j < a.Length; j++)
                    li.SubItems.Add(a[j].ToString()); //其余的列
                lv2.Items.Add(li);
        }
        public static void AddRecord(ListView lv1,ListView lv2)
        {
            string sql1 = "select cName from customers";           
            sql1 += " where account='" + LoginForm.u.account + "'";
            string  cname=execQuery(sql1)[0][0].ToString ();

            for (int i = 0; i < lv2.Items.Count; i++)
            {
                string [] sql=new string [lv2 .Items .Count ];
                sql[i] = "insert into record(cName,storeName,mealname,price,time) values('";
                sql[i] += cname + "','" + storename + "','" + lv2.Items[i].SubItems[0].Text + "','" + lv2.Items[i].SubItems[2].Text + "','" + DateTime.Now .ToString() + "')";
                execNonQuery(sql[i]);
            }
        }
    }
}
