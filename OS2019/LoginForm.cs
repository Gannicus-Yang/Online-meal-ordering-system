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
using OS2019.CustomerManager;

namespace OS2019
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        public static User u = null;
        public static User getUser()
        {
            return u;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String UserAccount = tbAccount.Text;
            String pass = tbPassword.Text;
            String role = cbRole.Text;
            u = UserCtrl.validUser(UserAccount, pass, role);
            if (u != null)
            {
               
                if (role.Trim () == "商家")
                {
                    StoreManager.StoreForm stf = new StoreManager.StoreForm();
                    stf.Show();
                }
                if (role.Trim() == "顾客")
                {
                    CustomerManager.CustomerForm ctf = new CustomerManager.CustomerForm();
                    ctf.ShowDialog();
                }
                if (role.Trim() == "平台管理员")
                {
                    AdminManager.AdminForm adf = new AdminManager.AdminForm();
                    adf.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("用户名或密码错误");
                return;
            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
           
        }
        private Hashtable ht;
        private void LoginForm_Load(object sender, EventArgs e)
        {
            ht = AdminManager.AdminCtrl.getRoleList();
            cbRole.Items.Clear();
            foreach (DictionaryEntry de in ht)
            {
                cbRole.Items.Add((string)de.Key);
            }
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            RegisterForm rf = new RegisterForm();
            rf.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChangePasswordForm cf = new ChangePasswordForm();
            cf.Show();
        }

        private void cbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbRole.Text.Trim() == "顾客")
            {
                button2.Visible = true;
                button3.Visible = true;
            }
        }
    }
}
