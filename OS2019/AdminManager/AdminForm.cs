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
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InputStoreForm isf = new InputStoreForm();
            isf.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SearchCustomerForm scf = new SearchCustomerForm();
            scf.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SearchTransactionForm stf = new SearchTransactionForm();
            stf.Show();
        }
    }
}
