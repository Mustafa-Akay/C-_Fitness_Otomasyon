using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp35
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {   // Bu olay işleyicisi Giriş buttonun tıklanması durumunda çalışır.
            if (textBoxKulanıcı.Text=="Mustafa Akay" && textBoxKulanıcıŞifre.Text == "1881")
            { // Girilen Veriler doğruysa ekrana mesaj gönderir
                MessageBox.Show("Hoşgeldiniz");
                Anasayfa anasayfa = new Anasayfa();
                anasayfa.Show();
                
            }
            else
            {
                //Girilen Veriler yanlış ise ekrana mesaj gönderir
                MessageBox.Show("Hatalı Giriş Yaptnız");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
