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
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OrderingFoodForm off = new OrderingFoodForm();
            off.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdateInfoForm uif = new UpdateInfoForm();
            uif.Show();
            uif.showif();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckOrderForm cof=new CheckOrderForm() ;
            cof.Show();

        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            customer c = new customer();
            this .Text = c.getName().Trim()+"，您好！";            
        }
    }
}
