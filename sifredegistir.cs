using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Otel_Kayıt_Otomasyonu
{
    public partial class sifredegistir : Form
    {
        public sifredegistir()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("data source =.; Initial Catalog=OtelKayıt;Integrated security=true");
        private void button1_Click(object sender, EventArgs e)
        {  if (textBox3.Text == textBox4.Text)
                {
                    if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
                    {
                        baglan.Open();
                        SqlCommand komut = new SqlCommand("Select * from Personeller where İşyeriSicilNo='" + textBox1.Text + "' and Sifre='"+textBox2.Text+"'", baglan);
                        SqlDataReader dr = komut.ExecuteReader();
                        if (dr.Read())
                        {
                            baglan.Close();
                            baglan.Open();
                            SqlCommand cmd = new SqlCommand("update Personeller set Sifre='" + textBox3.Text + "' where İşyeriSicilNo='" + textBox1.Text + "'  ", baglan);
                            cmd.ExecuteNonQuery();



                            MessageBox.Show("Şifre Değiştirme Tamamlandı");
                            baglan.Close();
                            this.Hide();
                        }
                        else
                        {

                            MessageBox.Show("Böyle bir kullanıcı kayıtlı değildir");
                            baglan.Close();
                        }
                    }
                     
                    else
                    {
                        MessageBox.Show("Lütfen boş alan bırakmayınız");
                        baglan.Close();
                    }

                }
                else
                {
                    MessageBox.Show("İki Yeni Şifre Alanı Uyuşmuyor");
                    baglan.Close();

                }
            
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
