using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace kargotakipsql
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=CODER\\SQLEXPRESS;Initial Catalog=hasan;Integrated Security=TRUE");
        SqlDataAdapter da = new SqlDataAdapter();
        public static string id, pw;
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select kadi,sifre From admin ",conn);

            conn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                id = dr["kadi"].ToString();
                pw = dr["sifre"].ToString();
            }
            conn.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (id == textBox1.Text && pw == textBox2.Text)
            {
               
                MessageBox.Show("Hatalı Giriş");
            }
            else
            {
                groupBox1.Visible = true;
                groupBox2.Visible = false;
               
            }
        }
    }
}
