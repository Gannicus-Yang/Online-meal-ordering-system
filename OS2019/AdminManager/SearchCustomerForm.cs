using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OS2019.AdminManager
{
    public partial class SearchCustomerForm : Form
    {
        public SearchCustomerForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            AdminCtrl.SearchCustomer(name, listView1);
        }
    }
}
