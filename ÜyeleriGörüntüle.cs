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
    public partial class ÜyeleriGörüntüle : Form
    {
        public ÜyeleriGörüntüle()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
             SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-U94TVFHL\SQLEXPERSS;Initial Catalog=Gymdb;Integrated Security=True");
        DataSet sda2= new DataSet();// Veritabanı verilerini saklamak için bir DataSet oluşturur
        private void Uyeler()
        {
            connection.Open(); // Veritabanı bağlantısını açar
            SqlDataAdapter sda = new SqlDataAdapter("Select * from UserTable", connection); // Veritabanından verileri çeker
            sda.Fill(sda2, "UserTable"); // Çekilen verileri DataSet'e doldurur
            dataGridView1ÜyeListeleme.DataSource = sda2.Tables["UserTable"]; // Verileri DataGridView'e bağlar
            connection.Close(); // Veritabanı bağlantısını kapatır

        }
        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Uygulamayı kapatır
        }

        private void dataGridView1ÜyeListeleme_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ÜyeleriGörüntüle_Load(object sender, EventArgs e)
        {
            Uyeler();
        }

        private void button2_Click(object sender, EventArgs e)
        { 
            //Üye ekleme sayfasına gönderen geri buttonun kodu
            Anasayfa Üyeekle = new Anasayfa();
            Üyeekle.Show(); // Anasayfa formunu gösterir
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Uyeler(); // Üyeleri listeleyen metodu çağırır
        }
        DataSet dt2 = new DataSet(); // Veritabanı verilerini saklamak için başka bir DataSet oluşturur
        private void ÜyeBulma()
        {
            //arama işlemini yapıyor
            connection.Open();
            // SQL arama sorgusunu oluşturur, % işaretleri ile arama yapar
            SqlCommand cmd = new SqlCommand("select * from UserTable where UserName like'% "+buttonAra.Text+"%'",connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1ÜyeListeleme.DataSource = ds.Tables[0]; // Çekilen verileri DataSet'e doldurur
            connection.Close();

        }
        private void button5_Click(object sender, EventArgs e)
        {
            ÜyeBulma(); // Üye bulma işlemini yapan metodu çağırır
            textBoxÜyeBulma.Text = ""; 
        }
    }
}
