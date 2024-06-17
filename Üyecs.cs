using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace WindowsFormsApp35
{
    public partial class Üyecs : Form
    {
        public Üyecs()
        {
            InitializeComponent();
        }
        // Veritabanı bağlantısını tanımlar
        SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-U94TVFHL\SQLEXPERSS;Initial Catalog=Gymdb;Integrated Security=True");

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();   // Sayfayı kapatma butonunu çalıştırır
        }

        private void Üyecs_Load(object sender, EventArgs e)
        {
                
        }

        private void button5_Click(object sender, EventArgs e)
        {  // üye ekleme
            connection.Open();
           // SQL insert sorgusu
            SqlCommand cmd = new SqlCommand("insert into UserTable(UserName,UserPhoneNo,UserAge,UserPayment,UserId)values(@p1,@p2,@p3,@p4,@p5)",connection);
            // SQL komutuna parametreler ekler
            cmd.Parameters.AddWithValue("@p1", AdSoyadTb.Text.Trim());
            cmd.Parameters.AddWithValue("@p2", TelefonTb.Text.Trim());
            cmd.Parameters.AddWithValue("@p3", YasTb.Text.Trim());
            cmd.Parameters.AddWithValue("@p4", ÖdemeTb.Text.Trim());
            cmd.Parameters.AddWithValue("@p5", textBoxId.Text.Trim());
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Kayıt Başarıyla Gerçekleşti");
            AdSoyadTb.Text = ""; // Text box'ları temizler
            TelefonTb.Text = "";// Text box'ları temizler
            YasTb.Text = "";// Text box'ları temizler
            ÖdemeTb.Text = "";// Text box'ları temizler
            textBoxId.Text = "";// Text box'ları temizler
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Geri butonuna basıldığında anasayfaya geçiş yapar
            Anasayfa anasayfa = new Anasayfa();
            anasayfa.Show();
            this.Hide(); // Mevcut formu gizler

        }

        private void button3_Click(object sender, EventArgs e)
        { 
            // Reset butonuna basıldığında text box'ları temizler
            AdSoyadTb.Text = "";
            TelefonTb.Text = "";
            YasTb.Text = "";
            ÖdemeTb.Text= "";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}

