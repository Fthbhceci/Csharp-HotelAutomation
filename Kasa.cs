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
    public partial class Kasa : Form
    {
        public Kasa()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("data source=.; initial catalog=OtelKayıt; integrated security=true;");
        private void button1_Click(object sender, EventArgs e)
        {
            frmanamenu fr = new frmanamenu();
            fr.Show();
            this.Hide();
        }



        private void verilerigöster()
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *from Kasa", baglan);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {

                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["Diğer"].ToString();
                ekle.SubItems.Add(oku["Faturalar"].ToString());
                ekle.SubItems.Add(oku["Tarih"].ToString());
                ekle.SubItems.Add(oku["Ücret"].ToString());
                listView1.Items.Add(ekle);

            }
            baglan.Close();



        }
        

        private void button5_Click(object sender, EventArgs e)
        {

            DialogResult dr = MessageBox.Show("Programı Kapatmak İstediğinize Eminmisiniz?", "                                              " + "UYARI", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void Kasa_Load(object sender, EventArgs e)
        {
         
            baglan.Open();
            SqlCommand komut= new SqlCommand("select SUM(Ücret) as Kasa from Kasa ",baglan);
            SqlDataReader dr= komut.ExecuteReader();
           while (dr.Read())
            {
                label1.Text = dr["Kasa"].ToString()+" "+"TL";
                
            }
           baglan.Close();

           verilerigöster();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            if (textBox4.Text != "" && textBox1.Text != "")
            {

                SqlCommand komut12 = new SqlCommand("insert into Kasa (Diğer,Faturalar,Tarih,Ücret) values ('"+label10.Text+"','" + textBox4.Text + "','" + dateTimePicker1.Text.ToString() + "','" + textBox1.Text + "')", baglan);

                komut12.ExecuteNonQuery();
                MessageBox.Show("Fatura İşlemi Kasaya Başarıyla İşlendi");
                baglan.Close();
                Kasa fr = new Kasa();
                fr.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Lütfen Eklemek İstediğiniz Alanları Boş Bırakmayınız");
                baglan.Close();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                label4.Visible = true;
                textBox1.Visible = true;
                dateTimePicker1.Visible = true;
                label5.Visible = true;
                button2.Visible = true;
                textBox4.Visible = true;
                label9.Visible = true;
                label11.Visible = true;
            }
            else
            {
                label4.Visible = false;
                textBox1.Visible = false;
                dateTimePicker1.Visible = false;
                label5.Visible = false;
                button2.Visible = false;
                textBox4.Visible = false;
                label9.Visible = false;
                label11.Visible = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                label7.Visible = true;
                textBox2.Visible = true;
                dateTimePicker2.Visible = true;
                label6.Visible = true;
                button3.Visible = true;
                textBox3.Visible = true;
                label8.Visible = true;
                label12.Visible = true;

                 
            }
            else 
            {

                label7.Visible = false;
                textBox2.Visible = false;
                dateTimePicker2.Visible = false;
                label6.Visible = false;
                button3.Visible = false;
                textBox3.Visible = false;
                label8.Visible = false;
                label12.Visible = false;
            
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglan.Open();
            if (textBox3.Text != "" && textBox2.Text != "")
            {
              
                SqlCommand komut13 = new SqlCommand("insert into Kasa (Diğer,Faturalar,Tarih,Ücret) values ('" + textBox3.Text + "','"+label10.Text+"','" + dateTimePicker2.Text.ToString() + "','" +textBox2.Text + "')", baglan);

                komut13.ExecuteNonQuery();
                MessageBox.Show("Diğer Tutar Kasaya Başarıyla İşlendi");
                baglan.Close();
                Kasa fr = new Kasa();
                fr.Show(); 
                this.Hide();

            }
            else
            {
                MessageBox.Show("Lütfen Eklemek İstediğiniz Alanları Boş Bırakmayınız");
                baglan.Close();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                radioButton1.Visible = true;
                radioButton2.Visible = true;
            }
            else
            {
                radioButton1.Visible = false;
                radioButton2.Visible = false;
                radioButton2.Checked = false;
                radioButton1.Checked = false;
                label7.Visible = false;
                textBox2.Visible = false;
                dateTimePicker2.Visible = false;
                label6.Visible = false;
                button3.Visible = false;
                textBox3.Visible = false;
                label8.Visible = false;
                label12.Visible = false;
                label4.Visible = false;
                textBox1.Visible = false;
                dateTimePicker1.Visible = false;
                label5.Visible = false;
                button2.Visible = false;
                textBox4.Visible = false;
                label9.Visible = false;
                label11.Visible = false;

            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled =false;
            }
            else if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

       
      
    }
}
