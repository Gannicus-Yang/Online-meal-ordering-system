using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace OS2019
{
    public class Utiles
    {
        static OleDbConnection conn = new OleDbConnection();
        static Utiles()
        {
            string path = Application.StartupPath;
            string file = path + "\\" + "config.txt";
            StreamReader sr = new StreamReader(file);
            string line = sr.ReadLine();
            conn.ConnectionString = line;
        }
            
        public static void fillListView(ListView lv, String sql, string[] ch)
        {
            lv.View = View.Details;    //定义列表显示的方式
            lv.MultiSelect = false; // 不可以多行选择
            lv.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lv.Visible = true;
            lv.GridLines = true;//画表格线
            lv.FullRowSelect = true;//点击时整行选中
            lv.Columns.Clear(); //将原有的列清空
            lv.Items.Clear();// 将原有的行清空
            if (ch != null)
            {
                for (int i = 0; i < ch.Length; i++)
                { //     设置表头信息
                    lv.Columns.Add(ch[i], 80, HorizontalAlignment.Center);
                }
            }
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            try
            {
                conn.Open();
                OleDbDataReader dbReader = cmd.ExecuteReader();
                object[] values = new object[dbReader.FieldCount]; // 对应一条记录
                if (ch == null)
                {
                    for (int i = 0; i < dbReader.FieldCount; i++)
                    {
                        lv.Columns.Add(dbReader.GetName(i), 80, HorizontalAlignment.Center);
                    }
                }
                while (dbReader.Read())
                {
                    dbReader.GetValues(values);//将一样的数据读进values数组中
                    ListViewItem li = new ListViewItem();//形成一个表项
                    li.SubItems.Clear();
                    li.SubItems[0].Text = values[0].ToString().Trim ();//设置第一列
                    for (int i = 1; i < values.Length; i++)
                        li.SubItems.Add(values[i].ToString().Trim ()); //其余的列
                    lv.Items.Add(li);
                }
            }
            catch (OleDbException ex)
            {
                string s = ex.ToString();
                MessageBox.Show(s);
            }
            finally
            {
                conn.Close();
            }
        }
        public static void execNonQuery(string sql)
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand(sql, conn); //创建命令
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (OleDbException ex)
            {
                string s = ex.ToString();
                MessageBox.Show(s);
            }
            finally
            {
                conn.Close();
            }

        }
        public static List<object[]> execQuery(string sql)
        {
            List<object[]> result = new List<object[]>();
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            try
            {
                conn.Open();
                OleDbDataReader dbReader = cmd.ExecuteReader();
                while (dbReader.Read())
                {
                    object[] values = new object[dbReader.FieldCount];
                    dbReader.GetValues(values);//将一行的数据读进values数组中
                    result.Add(values);
                }
            }
            catch (OleDbException ex)
            {
                string s = ex.ToString();
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

    }





}

