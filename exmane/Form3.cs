using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace exmane
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox3.Text != ""))
            {
                if (!Form2.change)
                {
                    if (DBConnection.AddWorkers(textBox1.Text, textBox2.Text, textBox3.Text, comboBox1.SelectedValue.ToString()))
                    {
                        this.Close();
                    }
                }
                else
                     if (DBConnection.ChangeWorkers(Form2.id,textBox1.Text, textBox2.Text, textBox3.Text, comboBox1.SelectedValue.ToString()))
                {
                    this.Close();
                }

            }
            else
            {
                MessageBox.Show("Заполните поля");
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            if (Form2.change)
            {
                textBox1.Text =Form2.fio;
                textBox2.Text = Form2.login;
                textBox3.Text = Form2.pass;
                comboBox1.SelectedValue = Form2.propid;
            }
            DBConnection.GetPropusk();
            comboBox1.DataSource = DBConnection.dtProp;
            comboBox1.DisplayMember = "nomer";
            comboBox1.ValueMember = "propusk";
        }
    }
}
