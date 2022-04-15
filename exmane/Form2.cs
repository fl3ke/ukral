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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        static public bool change;
        static public string  id;
        static public string fio;
        static public string login;
        static public string pass;
        static public string propid;
        private void Form2_Load(object sender, EventArgs e)
        {
            DBConnection.GetWorkers();
            dataGridView1.DataSource = DBConnection.dtWork;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            change = false;
            Form3 frm = new Form3();
            frm.ShowDialog();
            DBConnection.GetWorkers();
            dataGridView1.DataSource = DBConnection.dtWork;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            change = true;
            id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            fio = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            login = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            pass = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            propid = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            Form3 frm = new Form3();
            frm.ShowDialog();
            DBConnection.GetWorkers();
            dataGridView1.DataSource = DBConnection.dtWork;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("ВЫ действительно хотите удалить?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DBConnection.DeleteWorkers(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    DBConnection.GetWorkers();
                    dataGridView1.DataSource = DBConnection.dtWork;
                }
            }
            catch
            {
                MessageBox.Show("Запись уже исползвуетя !");
            }
        }
    }
}
