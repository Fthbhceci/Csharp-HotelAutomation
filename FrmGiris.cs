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
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=.;Initial catalog=OtelKayıt;Integrated Security=True");
        
        private void FrmGiris_Load(object sender, EventArgs e)
        {
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderColor = Color.Black;
            tboxıd.Text = Properties.Settings.Default.KullanıcıId;
          
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
                {
                    baglanti.Open();
                    string giris = "SELECT * FROM Personeller WHERE İşyeriSicilNo=@İşyeriSicilNo AND  Sifre=@Sifre";
                    SqlCommand kmtgiris = new SqlCommand(giris, baglanti);
                    kmtgiris.Parameters.AddWithValue("@İşyeriSicilNo", tboxıd.Text);
                    kmtgiris.Parameters.AddWithValue("@Sifre", tboxsifre.Text);
                    SqlDataReader dr = kmtgiris.ExecuteReader();





                    if (tboxıd.Text != "" && tboxsifre.Text != "")
                    {
                        if (dr.Read())
                        {

                            frmanamenu fr = new frmanamenu();
                            MessageBox.Show("\n \nPROGRAMA HOŞGELDİN " + dr["PersonelAdı"].ToString() + " " + dr["PersonelSoyadı"] + "\n\n", "                                 Mesaj");
                            fr.Show();
                            this.Hide();




                        }
                        else
                        {
                            MessageBox.Show("kullanıcı adı veya şifre yalnış");
                            baglanti.Close();

                        }
                    }
                    else
                    {
                        MessageBox.Show("Alanları Boş Bırakmayınız");
                        baglanti.Close();
                    }

                }
                catch
                {
                    MessageBox.Show("kullanıcı adı veya şifre yalnış");
                    tboxıd.Text = "";
                    tboxsifre.Text = "";
                    baglanti.Close();
                }
            
      
        }  
        private void tboxıd_Click(object sender, EventArgs e)
        {
           
        }

        private void FrmGiris_Shown(object sender, EventArgs e)
        {
            if (tboxıd.Text == "")
            {
                tboxıd.Focus();
            }
            else
            {
                tboxsifre.Focus();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                Properties.Settings.Default.KullanıcıId = tboxıd.Text;
                Properties.Settings.Default.Save();
            }
            else
            {

                Properties.Settings.Default.KullanıcıId= null;
                Properties.Settings.Default.Save();
            }
        }

        private void Unut(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.KullanıcıId = null;
            Properties.Settings.Default.Save();
        }

        private void FrmGiris_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SifremiUnuttum fr = new SifremiUnuttum();
            fr.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel1_MouseClick(object sender, MouseEventArgs e)
        {
            SifremiUnuttum fr = new SifremiUnuttum();
            fr.Show();
            this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("\n"+"Programı kapatmak istediğinize emin misiniz?", "                                                 " + "UYARI", MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void tboxıd_KeyPress(object sender, KeyPressEventArgs e)
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
