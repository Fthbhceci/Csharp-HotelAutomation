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
    public partial class Gecmismüsteriler : Form
    {
        public Gecmismüsteriler()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data source=.; Initial Catalog=OtelKayıt; Integrated security= true");
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                SqlDataAdapter da = new SqlDataAdapter("select* from GeçmişMüşteriler where  Adı like '" + textBox1.Text + "%' or Soyadı like '" + textBox1.Text + "%' or TC like '" + textBox1.Text + "%' or Email like '" + textBox1.Text + "%' or Telefon like '" + textBox1.Text + "%'  or GirisTarihi like '" + textBox1.Text + "%' or CikisTarihi like '" + textBox1.Text + "%'", baglan);
                DataSet ds = new DataSet();

                baglan.Open();
                da.Fill(ds, "GeçmişMüşteriler");
                dataGridView1.DataSource = ds.Tables["GeçmişMüşteriler"];
                baglan.Close();
                textBox1.Clear();

            }
            else
            {
                MessageBox.Show("Lütfen aramak istediğiniz kişi bilgilerini giriniz!", "                                            " + "UYARI",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void verilerigöster()
        {
            dataGridView1.Columns.Clear();




        
                SqlDataAdapter da = new SqlDataAdapter("select* from GeçmişMüşteriler", baglan);
                DataSet ds = new DataSet();

                baglan.Open();
                da.Fill(ds, "GeçmişMüşteriler");
                dataGridView1.DataSource = ds.Tables["GeçmişMüşteriler"];
                baglan.Close();
             
           
                  
          



        }
        private void button2_Click(object sender, EventArgs e)
        {
            verilerigöster();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Programı Kapatmak İstediğinize Eminmisiniz?", "                                              " + "UYARI", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                Application.Exit();
            }
        }

   
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
    
                string a = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = a;
            textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            if (textBox2.Text != "" && textBox3.Text != "")

            {
           
                MessageBox.Show("Adı: " + textBox2.Text + "\n" + "\n" + "Soyadı: " + textBox3.Text + "\n" + "\n" + "TC: " + textBox4.Text + "\n" + "\n" + "Email: " + textBox5.Text + "\n" + "\n" + "Telefon: " + textBox6.Text + "\n" + "\n" + "Oda No: " + textBox7.Text + "\n" + "\n" + "Giriş Tarihi: " + textBox8.Text + "\n" + "\n" + "Çıkış Tarihi: " + textBox9.Text + "\n" + "\n" + "Ücret: " + textBox10.Text, "                               " + "BİLGİ");
         

            }
            else 
            {
                MessageBox.Show("Lütfen bilgisini görmek istediğiniz kişiyi seçiniz", "                                   " + "UYARI",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Gecmismüsteriler_Load(object sender, EventArgs e)
        {
            verilerigöster();
        
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            frmanamenu fr = new frmanamenu();
            fr.Show();
            this.Hide();
        }
       
 

    }
}
