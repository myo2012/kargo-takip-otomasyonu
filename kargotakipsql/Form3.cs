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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet();
        SqlConnection conn = new SqlConnection("Data Source=CODER\\SQLEXPRESS;Initial Catalog=hasan;Integrated Security=TRUE");
        SqlDataAdapter da = new SqlDataAdapter();

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("SELECT madsoyad,mtel,madres FROM musteri WHERE mno=@mno", conn);
            cmd.Parameters.Add("@mno", SqlDbType.Int).Value = textBox1.Text;

            conn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read()) 
            {
                label3.Text = dr["madsoyad"].ToString();
                label4.Text = dr["mtel"].ToString();
                label2.Text = dr["madres"].ToString();
             
            }

            conn.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            da.SelectCommand = new SqlCommand("SELECT * FROM kargo",conn);
            ds.Clear();
            da.Fill(ds);
            dg.DataSource = ds.Tables[0];
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            da.InsertCommand = new SqlCommand("INSERT INTO kargo VALUES(@gönderenad,@gönderentel,@gönderenadres,@alıcıad,@alıcıtel,@alıcıadres)", conn);
            da.InsertCommand.Parameters.Add("@gönderenad", SqlDbType.VarChar).Value = label3.Text;
            da.InsertCommand.Parameters.Add("@gönderentel", SqlDbType.VarChar).Value = label4.Text;
            da.InsertCommand.Parameters.Add("@gönderenadres", SqlDbType.VarChar).Value = label2.Text;
            da.InsertCommand.Parameters.Add("@alıcıad", SqlDbType.VarChar).Value = textBox2.Text;
            da.InsertCommand.Parameters.Add("@alıcıtel", SqlDbType.VarChar).Value = textBox3.Text;
            da.InsertCommand.Parameters.Add("@alıcıadres", SqlDbType.VarChar).Value = textBox4.Text;

            conn.Open();

            da.InsertCommand.ExecuteNonQuery();

            conn.Close();

            MessageBox.Show("Bilgileri başarı ile eklendi");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            da.SelectCommand = new SqlCommand("SELECT * FROM kargo WHERE gönderentel=@gönderentel", conn);
            da.SelectCommand.Parameters.Add("@gönderentel", SqlDbType.Int).Value = textBox5.Text;
            conn.Open();
            ds.Clear();
            da.Fill(ds, "kargo");
            dg.DataSource = ds.Tables["kargo"];

            conn.Close();
        }
    }
}
