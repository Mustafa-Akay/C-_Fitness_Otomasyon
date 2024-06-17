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
    public partial class Ödemeler : Form
    {
        public Ödemeler()
        {
            InitializeComponent();
        }
        // Veritabanı bağlantısını tanımlar
        SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-U94TVFHL\SQLEXPERSS;Initial Catalog=Gymdb;Integrated Security=True");
        private void FillName()
        {
            //girili üyelerin comboxa getirmesini sağlayan kod
            connection.Open();
            SqlCommand cmd = new SqlCommand("Select  UserName from UserTable", connection); // Veritabanından kullanıcı adlarını seçer
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable(); // Sorguyu çalıştırır ve veri okuyucuyu başlatır
            dt.Columns.Add("UserName", typeof(string));// DataTable'a UserName sütunu ekler
            dt.Load(rdr);
            comboBoxAdSoyad.ValueMember = "UserName"; // Veri okuyucudaki verileri DataTable'a yükler   // Combo box'ın değer üyesini ayarlar
            comboBoxAdSoyad.DataSource = dt;
            connection.Close();
        }
        private void ÜyeBulma()
        {
            connection.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select * from PaymentTable where PaymentUser=("+textBoxAra.Text+")", connection); // Arama sorgusunu çalıştırır
            sda.Fill(dt2, "UserTable"); // Sonuçları DataSet'e doldurur
            dataGridView1Ödemeler.DataSource = dt2.Tables["UserTable"]; // Sonuçları DataSet'e doldurur
            connection.Close();

        }
        DataSet dt2 = new DataSet(); // Veritabanı verilerini saklamak için bir DataSet oluşturur
        private void Uyeler() 
        {
            connection.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select * from PaymentTable", connection); // Veritabanından tüm ödeme verilerini çeker
            sda.Fill(dt2, "UserTable"); // Verileri DataSet'e doldurur
            dataGridView1Ödemeler.DataSource = dt2.Tables["UserTable"];  // Verileri DataGridView'e bağlar
            connection.Close();

        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //resetleme butonu kodu
            comboBoxAdSoyad.Text = "";
            textBoxÜcret.Text = "";
            textBoxPaymentId.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // geriye basınca anasayfaya yönlendiren tuş
            Anasayfa Anasayfa = new Anasayfa();
            Anasayfa.Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            FillName(); // Üye isimlerini combo box'a doldurur
            Uyeler();  // Tüm üyeleri listeler
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBoxAdSoyad.Text==""||textBoxÜcret.Text=="")
            {
                MessageBox.Show("Eksik Bilgi Girdiniz");
            }
            else
            {
                string Ödemeperiyot = dateTimePickerÖdemeayı.Value.ToString() + dateTimePickerÖdemeayı.Value.Year.ToString();
                connection.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select count(*) from PaymentTable where PaymentUser='"+comboBoxAdSoyad.SelectedValue.ToString()+"' and PaymentMonth='"+ Ödemeperiyot+"'",connection);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString()=="1") // bu kod bu ay zaten ödeme yapıldığını vericek
                {
                    MessageBox.Show("Bu Ay Ödeme Yapıldı"); 
                }
                else
                {
                    // Yeni ödeme ekler
                    SqlCommand cmd = new SqlCommand("insert into  PaymentTable(PaymentId,PaymentMiktar,PaymentMonth) values(@p1,@p2,@p3)",connection);
                    cmd.Parameters.AddWithValue("@p1", textBoxPaymentId.Text); // PaymentId parametresini ekler
                    cmd.Parameters.AddWithValue("@p2", textBoxÜcret.Text.Trim()); // PaymentMiktar parametresini ekler
                    cmd.Parameters.AddWithValue("@p3", dateTimePickerÖdemeayı.Text);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Ödeme Eklendi");



                }
                    connection.Close();
                    Uyeler();// Üyeleri yeniler
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Uygulamayı kapatır
        }

        private void dataGridView1Ödemeler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ÜyeBulma(); //Üye bulma daki üyeleir bulak bulmak için
            textBoxAra.Text = ""; // arama yaptıktan sonra kutuyu siler
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Uyeler(); // yenile butununa basınca üyeleri listelemek için
        }

        private void dateTimePickerÖdemeayı_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBoxAdSoyad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
