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
    public partial class SearchTransactionForm : Form
    {
        public SearchTransactionForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cName = textBox1.Text;
            string sName = textBox2.Text;
            AdminCtrl.SearchTransaction(cName, sName, listView1);
        }
    }
}
