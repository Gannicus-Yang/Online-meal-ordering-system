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
    public partial class CheckOrderForm : Form
    {
        public CheckOrderForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            customer c=new customer();
            CheckOrderCtrl.loadAllOrders(listView1,c.getName());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            customer c = new customer();
            CheckOrderCtrl.loadSumOrders(listView2, c.getName());
        }
    }
}
