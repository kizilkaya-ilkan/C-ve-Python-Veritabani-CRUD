using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;  // Access bağlantısı kurabilmek için.


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OleDbConnection con;
        OleDbDataAdapter da;
        OleDbCommand cmd;
        DataSet ds;

        void griddoldur()
        {
            con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Kitaplik.mdb;");
            da = new OleDbDataAdapter("SElect *from Kitaplar", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Kitaplar");
            dataGridView1.DataSource = ds.Tables["Kitaplar"];
            if (con.State == ConnectionState.Open) label7.Text = "Durum: Veri tabanı Bağlantı Yapıldı";
            else label7.Text = "Durum: Veri tabanı Bağlantı Kurulamadı";
            con.Close();

      
           

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            griddoldur();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "insert into Kitaplar(KitapAd,Yazar,Sayfa,Tur) values ('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            griddoldur();
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
        }
    }
}
