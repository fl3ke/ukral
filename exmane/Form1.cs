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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DBConnection.Connection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBConnection.Auth(textBox1.Text, textBox2.Text);
            switch (DBConnection.fio)
            {
                case null:
                    MessageBox.Show("Данные неверны");
                    break;


                default:
                    Form2 frm = new Form2();
                    frm.ShowDialog();
                    break;
            }

        }
    }
}