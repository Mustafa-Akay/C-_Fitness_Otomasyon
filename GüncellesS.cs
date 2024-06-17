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
    public partial class GüncellesS : Form
    {
        public GüncellesS()
        {
            InitializeComponent();
        }
        // Veritabanı bağlantısını tanımlar...
        SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-U94TVFHL\SQLEXPERSS;Initial Catalog=Gymdb;Integrated Security=True");
        // Veritabanı verilerini saklamak için bir DataSet oluşturur
        DataSet sda2 = new DataSet();
        private void Uyeler()
        {
            connection.Open();
            
            // Veritabanı bağlantısını açar
            SqlDataAdapter sda = new SqlDataAdapter("Select * from UserTable", connection); //// Veritabanından verileri çeker
           
            sda.Fill(sda2, "UserTable");
            dataGridView1ÜyeListeleme.DataSource = sda2.Tables["UserTable"]; // Verileri DataGridView'e bağlar
            connection.Close(); // Veritabanı bağlantısını kapatır

        }
        int key = 0;  // Seçilen üyenin ID sini tutar
        private void dataGridView1ÜyeListeleme_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Uyeler();

        }

        private void GüncellesS_Load(object sender, EventArgs e)
        {
            Uyeler(); // Form yüklendiğinde üyeleri listele
        }

        private void label7_Click(object sender, EventArgs e)
        {
            // Uygulamayı kapatır
            Application.Exit(); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Reset butonuna basıldığında text box'ları temizler
            textBoxÜyeAdı.Text = "";
            textBoxTelefonNo.Text = "";
            textBoxYaş.Text = "";
            textBoxÜcret.Text = "";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Geri butonuna basıldığında anasayfaya geçiş yapar //sayfalar arası geçiş yapmayı sağlayan kod
            Anasayfa anasayfa = new Anasayfa();
            anasayfa.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            // Silinecek üyenin seçilmediği durumunda uyarı verir
            
            
            

                try
                {

                    connection.Open(); // Veritabanı bağlantısını açar
                    string query = "delete from UserTable where UserName=@name";  // Silme sorgusunu oluşturur
                    SqlCommand cmd = new SqlCommand(query, connection); // SQL komutunu hazırlar
                    cmd.Parameters.AddWithValue("@name", textBoxÜyeAdı.Text);
                   
                    
                    cmd.ExecuteNonQuery(); // Komutu çalıştırır
                    MessageBox.Show("Üye Başarıyla Silindi ");
                    connection.Close(); // Veritabanı bağlantısını kapatır
                    Uyeler(); // Üyeleri yeniden yükler

                }
                catch (Exception Ex) // Hata mesajını gösterir
                {
                    MessageBox.Show(Ex.Message);
                }
            

            
        }

        private void button5_Click(object sender, EventArgs e)
        {

            //Güncelle butonuna basıldığında gerekli alanlar boş ise uyarı verir
            //if (key == 0 || textBoxÜyeAdı.Text == "" || textBoxTelefonNo.Text == "" || textBoxYaş.Text == "" || textBoxÜcret.Text == "")
            //{
            //    MessageBox.Show("Eksik Bilgi");
            //}
            
                try
                {
                    connection.Open(); // Veritabanı bağlantısını açar
                    // Güncelleme sorgusunu oluşturur
                    string query = "update UserTable set UserName=@UserName" + "UserPhoneNo=@UserPhoneNo" + "UserAge=@UserAge" +  "UserPayment=@UserPayment" ;
                    
                    SqlCommand cmd = new SqlCommand(query, connection); // SQL komutunu hazırlar
               
                    cmd.ExecuteNonQuery(); // Veriler saklandı
                    MessageBox.Show("Üye Başarıyla Güncellendi");
                    connection.Close(); // Veritabanı bağlantısını kapatır
                    Uyeler(); // Üyeleri yeniden yükler

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            

            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1ÜyeListeleme_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBoxÜyeAdı.Text = dataGridView1ÜyeListeleme.CurrentRow.Cells[0].Value.ToString();
            textBoxTelefonNo.Text = dataGridView1ÜyeListeleme.CurrentRow.Cells[1].Value.ToString();
            textBoxYaş.Text = dataGridView1ÜyeListeleme.CurrentRow.Cells[2].Value.ToString();
            textBoxÜcret.Text = dataGridView1ÜyeListeleme.CurrentRow.Cells[3].Value.ToString();
        }
    }
}
