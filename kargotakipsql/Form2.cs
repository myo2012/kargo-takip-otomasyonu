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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet();
        SqlConnection conn = new SqlConnection("Data Source=CODER\\SQLEXPRESS;Initial Catalog=hasan;Integrated Security=TRUE");
        SqlDataAdapter da = new SqlDataAdapter();


        private void button1_Click(object sender, EventArgs e)
        {
           

            da.InsertCommand = new SqlCommand("INSERT INTO musteri VALUES(@mno,@madsoyad,@mtel,@madres)", conn);
            da.InsertCommand.Parameters.Add("@mno", SqlDbType.Int).Value = textBox1.Text;
            da.InsertCommand.Parameters.Add("@madsoyad", SqlDbType.VarChar).Value = textBox2.Text;
            da.InsertCommand.Parameters.Add("@mtel", SqlDbType.VarChar).Value = textBox3.Text;
            da.InsertCommand.Parameters.Add("@madres", SqlDbType.VarChar).Value = textBox4.Text;

            conn.Open();

            da.InsertCommand.ExecuteNonQuery();

            conn.Close();


            MessageBox.Show("EKLENDİ");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            da.SelectCommand = new SqlCommand("select * from musteri",conn);
            ds.Clear();
            da.Fill(ds);
            dg.DataSource = ds.Tables[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            da.SelectCommand = new SqlCommand("SELECT * FROM musteri WHERE mno=@mno", conn);
            da.SelectCommand.Parameters.Add("@mno", SqlDbType.Int).Value = textBox5.Text;
            conn.Open();
            ds.Clear();
            da.Fill(ds, "musteri");
            dg.DataSource = ds.Tables["musteri"];

            conn.Close();
        }
    }
}
