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
    public partial class UpdateInfoForm : Form
    {
        public UpdateInfoForm()
        {
            InitializeComponent();
        }
        public  void showif()
        {
            UpdateInfoCtrl.showIf(LoginForm.u.account,richTextBox1, richTextBox2);
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            UpdateInfoCtrl.update(richTextBox4.Text ,richTextBox3.Text);
            MessageBox.Show("修改成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
