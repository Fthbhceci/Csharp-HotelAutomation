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
    public partial class SifremiUnuttum : Form
    {
        public SifremiUnuttum()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("data source=.; Initial Catalog=OtelKayıt; Integrated security=true");
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("select Sifre from Personeller where İşyeriSicilNo='" + textBox1.Text + "' And gizlibilgi= '" + textBox2.Text + "'", baglan);
                SqlDataReader dr = komut.ExecuteReader();
                if (textBox1.Text != "" && textBox2.Text != "")
                {

                    if (dr.Read())
                    {
                        label4.Visible = false;
                        label3.Text = "              "+"Şifreniz :  " + " " + dr["Sifre"].ToString();
                        baglan.Close();

                    }
                    else
                    {

                        MessageBox.Show("\n"+"Girdiğiniz bilgilere ait personel bulunamadı !","                                       " + "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        label4.Text = "UYARI:";
                        label3.Text = "Eğer gizli bilginizi bilmiyorsanız yöneticinizden isteyin";
                        baglan.Close();


                    }
                }
                else
                {

                    MessageBox.Show("\n"+"Lütfen Alanları Boş Bırakmayınız", "                                       " + "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    baglan.Close();
                }
               
            }
            catch 
            
            {
                MessageBox.Show("\n"+"Girdiğiniz bilgilere ait personel bulunamadı", "                                       " + "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                baglan.Close();
            }
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

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("\n"+"Şifre değiştirme bölümünden çıkış yapıyorsunuz?", "                                       " + "UYARI", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                FrmGiris fr = new FrmGiris();
                fr.Show();
                this.Hide();
            }
         

            }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmGiris fr = new FrmGiris();
            fr.Show();
            this.Hide();
        }
    }
}
