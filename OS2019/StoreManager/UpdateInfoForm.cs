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
    public partial class UpdateInfoForm : Form
    {
        public UpdateInfoForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Store s = new Store();            
            if (comboBox1.Text.Trim () == "店名")
            {
                if (textBox1.Text != " ")
                { 
                    s.storeName=textBox1.Text;
                    StoreCtrl.updateInfo(s);
                }
            }
            else if (comboBox1.Text.Trim () == "地址")
            {
                if (textBox1.Text != " ")
                { 
                    s.address=textBox1.Text;
                    StoreCtrl.updateAddress(s);
                }
            }
            StoreCtrl.listInfo(s, listView1 );
        }
       

       
    }
}
