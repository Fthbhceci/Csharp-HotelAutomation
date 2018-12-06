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
    public partial class tummusteriler : Form
    {
        public tummusteriler()
        {
            InitializeComponent();
        }
        SqlConnection baglan=new SqlConnection("Data Source=.;Initial Catalog=OtelKayıt;Integrated Security=True");

        private void verilerigöster()
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *from müşteriler", baglan);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {

                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["Id"].ToString();
                ekle.SubItems.Add(oku["Adı"].ToString());
                ekle.SubItems.Add(oku["Soyadı"].ToString());
                ekle.SubItems.Add(oku["TC"].ToString());
                ekle.SubItems.Add(oku["Email"].ToString());
                ekle.SubItems.Add(oku["Telefon"].ToString());
                ekle.SubItems.Add(oku["OdaNo"].ToString());
                ekle.SubItems.Add(oku["GirisTarihi"].ToString());
                ekle.SubItems.Add(oku["Cikistarihi"].ToString());
                ekle.SubItems.Add(oku["Ücret"].ToString());
                listView1.Items.Add(ekle);

            }
            baglan.Close();
        
        
        
        }
        




        private void tummusteriler_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;

            maskedTextBox3.Enabled = false;
            textBox4.Enabled = false;
            maskedTextBox1.Enabled = false;
            textBox5.Enabled = false;
            dtpgiristarihi.Enabled = false;
            dtpcikistarihi.Enabled = false;
            textBox3.Enabled = false;
            verilerigöster();
            timer1.Start();
        }
      


        private void button2_Click(object sender, EventArgs e)
        {
         
            
            if (textBox1.Text != "" && textBox2.Text !="" && textBox3.Text!="" && maskedTextBox1.Text!="" && maskedTextBox3.Text!="" && textBox4.Text!="")
            {
                baglan.Open();
                SqlCommand komut1 = new SqlCommand("update müşteriler set Adı='" + textBox1.Text.ToString() + "' ,Soyadı='" + textBox2.Text.ToString() + "' ,TC='" + maskedTextBox3.Text.ToString() + "'  ,Email='" + textBox4.Text.ToString() + "' ,Telefon='" + maskedTextBox1.Text.ToString() + "' ,OdaNo='" + textBox5.Text.ToString() + "' ,GirisTarihi='" + dtpgiristarihi.Text.ToString() + "' ,CikisTarihi='" + dtpcikistarihi.Text.ToString() + "' ,Ücret='" + textBox3.Text.ToString() + "'  where Id=" + id + " ", baglan);
                komut1.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Güncelleme Başarıyla Yapıldı");
                verilerigöster();
                
                textBox1.Text = "";
                textBox2.Text = "";
                maskedTextBox3.Text = "";
                textBox4.Text = "";
                maskedTextBox1.Text = "";
                textBox5.Text = "";
                dtpgiristarihi.Text = "";
                dtpcikistarihi.Text = "";
                textBox3.Text = "";

                textBox1.Enabled = false ;
                textBox2.Enabled = false;
                maskedTextBox3.Enabled = false;
                textBox4.Enabled = false;
                maskedTextBox1.Enabled = false;
                textBox5.Enabled = false;
                dtpgiristarihi.Enabled = false;
                dtpcikistarihi.Enabled = false;
                textBox3.Enabled = false;
            }
            else 
            {
                MessageBox.Show("Lütfen Güncellemek İstediğiniz Kişiyi Seçin", "                                         " + "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                DialogResult dr = MessageBox.Show("Silmek İstediğinize Emin misiniz?", "                                      "+"UYARI", MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
                if (dr == DialogResult.OK)
                {
                    baglan.Open();
                    SqlCommand komut2 = new SqlCommand("Delete From müşteriler where Id=(" + id + ")", baglan);
                    komut2.ExecuteNonQuery();
                    baglan.Close();
                    verilerigöster();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    maskedTextBox3.Text = "";
                    textBox4.Text = "";
                    maskedTextBox1.Text = "";
                    textBox5.Text = "";
                    dtpgiristarihi.Text = "";
                    dtpcikistarihi.Text = "";
                    textBox3.Text = "";

                    textBox1.Enabled =false;
                    textBox2.Enabled = false;

                    maskedTextBox3.Enabled = false;
                    textBox4.Enabled = false;
                    maskedTextBox1.Enabled = false;
                    textBox5.Enabled = false;
                    dtpgiristarihi.Enabled = false;
                    dtpcikistarihi.Enabled = false;
                    textBox3.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Lütfen Silmek İstediğiniz Kişiyi Seçin", "                                         " + "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox6.Text != "")
            {



                listView1.Items.Clear();
      
                baglan.Open();
                
                SqlCommand komut2 = new SqlCommand("select * from Müşteriler where TC like '%"+ textBox6.Text +"%' ", baglan);
                SqlDataReader oku2 = komut2.ExecuteReader();
                if (oku2.Read())
                {
                    ListViewItem ekle = new ListViewItem();
                    ekle.Text = oku2["Id"].ToString();
                    ekle.SubItems.Add(oku2["Adı"].ToString());
                    ekle.SubItems.Add(oku2["Soyadı"].ToString());
                    ekle.SubItems.Add(oku2["TC"].ToString());
                    ekle.SubItems.Add(oku2["Email"].ToString());
                    ekle.SubItems.Add(oku2["Telefon"].ToString());
                    ekle.SubItems.Add(oku2["OdaNo"].ToString());
                    ekle.SubItems.Add(oku2["GirisTarihi"].ToString());
                    ekle.SubItems.Add(oku2["Cikistarihi"].ToString());
                    ekle.SubItems.Add(oku2["Ücret"].ToString());
                    listView1.Items.Add(ekle);
                    textBox6.Text = "";


                    baglan.Close();




                }
                else
                {
                    MessageBox.Show("Böyle bir kayıt bulunamadı!", "                                 " + "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    baglan.Close();
                    textBox6.Text = "";
                }
                
            }
            else
            {
                MessageBox.Show("Lütfen arama kısmına değer giriniz!", "                                         " + "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
            
            
            }
        }

       
        int id = 0;
        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {

            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[2].Text;
            maskedTextBox3.Text = listView1.SelectedItems[0].SubItems[3].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[4].Text;
            maskedTextBox1.Text = listView1.SelectedItems[0].SubItems[5].Text;
            textBox5.Text = listView1.SelectedItems[0].SubItems[6].Text;
            dtpgiristarihi.Text = listView1.SelectedItems[0].SubItems[7].Text;
            dtpcikistarihi.Text = listView1.SelectedItems[0].SubItems[8].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[9].Text;

            textBox1.Enabled = true;
            textBox2.Enabled = true;

            maskedTextBox3.Enabled = true;
            textBox4.Enabled = true;
            maskedTextBox1.Enabled = true;
            textBox5.Enabled = true;
            dtpgiristarihi.Enabled = true;
            dtpcikistarihi.Enabled = true;
            textBox3.Enabled = true;

        }

  

    

        private void button7_Click(object sender, EventArgs e)
        {
            if (label11.Text == dtpcikistarihi.Text)
            {

                if (textBox1.Text != "" && textBox2.Text != "")
                {
                    DialogResult dr = MessageBox.Show("Hesap işlemini doğruluyormusunuz? \n \n Odanın hesabı : " + textBox3.Text.ToString() + "TL", "Hesap İşlemleri", MessageBoxButtons.OKCancel);

                    baglan.Open();
                    SqlCommand komut3 = new SqlCommand("Delete From müşteriler where Id=(" + id + ")", baglan);
                    if (dr == DialogResult.OK)
                    {


                        string komut = "insert into GeçmişMüşteriler (Adı,Soyadı,TC,Email,Telefon,OdaNo,GirisTarihi,CikisTarihi,Ücret) values(@Adı,@Soyadı,@TC,@Email,@Telefon,@OdaNo,@GirisTarihi,@CikisTarihi,@Ücret)";
                        SqlCommand kmt = new SqlCommand(komut, baglan);
                        kmt.Parameters.AddWithValue("@Adı", textBox1.Text);
                        kmt.Parameters.AddWithValue("@Soyadı", textBox2.Text);
                        kmt.Parameters.AddWithValue("@TC", maskedTextBox3.Text);
                        kmt.Parameters.AddWithValue("@Email", textBox4.Text);
                        kmt.Parameters.AddWithValue("@Telefon", maskedTextBox1.Text);
                        kmt.Parameters.AddWithValue("@OdaNo", textBox5.Text);
                        kmt.Parameters.AddWithValue("@GirisTarihi", dtpgiristarihi.Text);
                        kmt.Parameters.AddWithValue("@CikisTarihi", dtpcikistarihi.Text);
                        kmt.Parameters.AddWithValue("@Ücret", textBox3.Text);
                        kmt.ExecuteNonQuery();
                        komut3.ExecuteNonQuery();
                        int a = Convert.ToInt32(textBox3.Text);
                        SqlCommand komut5 = new SqlCommand("insert into Kasa (Diğer,Faturalar,Tarih,Ücret) values ('"+label13.Text+ "  "+textBox5.Text+"','"+label14.Text+"','"+dtpcikistarihi.Text.ToString()+"','"+textBox3.Text+"')", baglan);
                        komut5.ExecuteNonQuery();
                        baglan.Close();
                        baglan.Close();
                        MessageBox.Show("\n"+"Hesap alma işlemi başarıyla gerçekleşti","                                              " + "BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                        baglan.Close();
                        verilerigöster();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        maskedTextBox3.Text = "";
                        textBox4.Text = "";
                        maskedTextBox1.Text = "";
                        textBox5.Text = "";
                        dtpgiristarihi.Text = "";
                        dtpcikistarihi.Text = "";
                        textBox3.Text = "";
                        textBox1.Enabled = false;
                        textBox2.Enabled = false;

                        maskedTextBox3.Enabled = false;
                        textBox4.Enabled = false;
                        maskedTextBox1.Enabled = false;
                        textBox5.Enabled = false;
                        dtpgiristarihi.Enabled = false;
                        dtpcikistarihi.Enabled = false;
                        textBox3.Enabled = false;


                    }
                    else if (dr == DialogResult.Cancel)
                    {
                        MessageBox.Show("Hesap Alma İşlemi İptal Edildi", "                                     " + "BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                        baglan.Close();
                        verilerigöster();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        maskedTextBox3.Text = "";
                        textBox4.Text = "";
                        maskedTextBox1.Text = "";
                        textBox5.Text = "";
                        dtpgiristarihi.Text = "";
                        dtpcikistarihi.Text = "";
                        textBox3.Text = "";
                        textBox1.Enabled = false;
                        textBox2.Enabled = false;

                        maskedTextBox3.Enabled = false;
                        textBox4.Enabled = false;
                        maskedTextBox1.Enabled = false;
                        textBox5.Enabled = false;
                        dtpgiristarihi.Enabled = false;
                        dtpcikistarihi.Enabled = false;
                        textBox3.Enabled = false;

                    }
                }
                else
                {

                    MessageBox.Show("Kapatmak istediğiniz hesabı seçiniz", "                                     " + "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            else
            {
                MessageBox.Show("\n"+"Odanın Çıkış Tarihi Gelmediği İçin Kapatamazsınız", "                                              " + "UYARI",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            }
        
        
        
        
        
        
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        
            label11.Text = DateTime.Now.ToLongDateString();
        }


        private void dtpcikistarihi_ValueChanged(object sender, EventArgs e)
        {
           
            if (dtpcikistarihi.Value < dtpgiristarihi.Value)
            {

                dtpcikistarihi.Text = DateTime.Today.ToString(dtpgiristarihi.CustomFormat);

            }
            else if (dtpgiristarihi.Text == dtpcikistarihi.Text)
            {

                textBox3.Text = "50";
            
            }
            else
            {
                int ucret;
                DateTime kücüktarih = Convert.ToDateTime(dtpgiristarihi.Text);
                DateTime büyüktarih = Convert.ToDateTime(dtpcikistarihi.Text);
                TimeSpan sonuc =
                    büyüktarih - kücüktarih;
                label12.Text = sonuc.TotalDays.ToString();
                ucret = Convert.ToInt32(label12.Text) * 50;
                textBox3.Text = ucret.ToString();
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            frmanamenu fr = new frmanamenu();
            fr.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Programı Kapatmak İstediğinize Eminmisiniz?", "                                              " + "UYARI", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            verilerigöster();
        }
    }
}
