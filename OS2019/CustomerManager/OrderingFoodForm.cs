using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OS2019.CustomerManager
{
    public partial class OrderingFoodForm : Form
    {
        public OrderingFoodForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OrderingFoodCtrl.searchStore(listView1,textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OrderingFoodCtrl.loadMenu(listView1, listView2);
        }

        private void listView2_DoubleClick(object sender, EventArgs e)
        {
            OrderingFoodCtrl.loadSelectedMeal(listView2,listView3);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int sum=0;
            int i = 0;
            for(;i<listView3.Items.Count;i++)
            {
                sum += int.Parse(listView3.Items[i].SubItems[2].Text);
            }
            DialogResult dr= MessageBox.Show("您一共需要支付" +sum.ToString() + "元","支付提醒", MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
            if (dr == DialogResult.OK)
            {
                OrderingFoodCtrl.AddRecord(listView1, listView3);
                MessageBox.Show("下单成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
