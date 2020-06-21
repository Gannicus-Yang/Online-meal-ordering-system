using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace OS2019.StoreManager
{
    public partial class CheckOrderForm : Form
    {
        public CheckOrderForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Store s = new Store();
            StoreCtrl.loadAllOrders(listView1 , s);
        }

       

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Store s = new Store();
            StoreCtrl.loadSumOrders(listView2, s);
        }
    }
}
