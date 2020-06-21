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
    public partial class ChangePasswordForm : Form
    {
        public ChangePasswordForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChangePasswordCtrl.change(textBox4.Text,textBox1 .Text.Trim ());
            MessageBox.Show("密码修改成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ChangePasswordCtrl.showquestion(textBox2, textBox1.Text);
            }
            catch (Exception err)
            {
                MessageBox.Show ("您输入账号有误","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Trim() == ChangePasswordCtrl.answer(textBox1.Text).Trim())
            {
                label4.Visible = true;
                textBox4.Visible = true;
            }
            else
            {
                MessageBox.Show("您输入的答案不正确！");
            }
        }
    }
}
