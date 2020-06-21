using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OS2019.StoreManager;

namespace OS2019.AdminManager
{
    public partial class InputStoreForm : Form
    {
        public InputStoreForm()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Store s = new Store();
            string sql = "select * from store where 1=1";
            List<object[]> a = Utiles.execQuery(sql);
            s.storeId = (a.Count() + 1).ToString();
            s.account = textBox1.Text;           
            s.storeName = textBox2.Text;
            s.address = textBox3.Text;
            string pass = textBox7.Text;
            if (AdminCtrl.ValidAccount(s.account))
            { AdminCtrl.saveStore(s,pass);
            MessageBox.Show("账号创建成功!");
            }
            else
            {MessageBox.Show("账号已存在！"); }
           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string a = textBox5.Text;
            string b =textBox6.Text;
            AdminCtrl.searchStore(a, b, listView1);
        }
    }
}
