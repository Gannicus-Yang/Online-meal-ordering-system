using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OS2019.StoreManager
{
    public partial class StoreForm : Form
    {
        public StoreForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateMenuForm umf = new UpdateMenuForm();
            umf.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckOrderForm cof = new CheckOrderForm();
            cof.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdateInfoForm uif = new UpdateInfoForm();
            uif.ShowDialog();
        }

        private void StoreForm_Load(object sender, EventArgs e)
        {
            Store s = new Store();
            StoreCtrl.loadName(s);
            this.Text = s.storeName;
        }
    }
}
