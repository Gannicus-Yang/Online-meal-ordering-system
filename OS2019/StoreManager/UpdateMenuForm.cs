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
    public partial class UpdateMenuForm : Form
    {
        public UpdateMenuForm()
        {
            InitializeComponent();
        }
        
        
        private void UpdateMenuForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Store s1 = new Store();
            StoreCtrl.loadAllMeals(listView1,s1);
        }      

        private void button2_Click(object sender, EventArgs e)
        {
            Meal m1 = new Meal();
            Store s2 = new Store(); 
            string sql="select * from menu where 1=1";
            List<object []> a=Utiles .execQuery (sql);
            m1. mealId = (a.Count ()+1).ToString();
            m1. mealName = textBox2.Text;
            m1. mealType = comboBox1.Text;
            m1. price = textBox3.Text;
            StoreCtrl.saveMeal(s2,m1);
            button1_Click(null, null);
            textBox2.Clear();
            comboBox1.Text = "";
            textBox3.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Meal m2 = new Meal();         
            m2.mealId = textBox6.Text;
            StoreCtrl.deleteMeal(m2);
            button1_Click(null, null);
            textBox6.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Meal m3 = new Meal();
            m3.mealId = textBox4.Text;
            m3.price = textBox5.Text;
            StoreCtrl.updatePrice(m3);
            button1_Click(null, null);
            textBox4.Clear();
            textBox5.Clear();
        }
    }
}
