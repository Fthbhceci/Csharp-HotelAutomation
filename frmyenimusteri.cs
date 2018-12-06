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
    public partial class frmyenimusteri : Form
    {
        public frmyenimusteri()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source =.;Initial Catalog=OtelKayıt; Integrated Security= True");
        private void button1_Click(object sender, EventArgs e)
        {
            textBox5.Text = "101";
        }

        private void dtpcikistarihi_ValueChanged(object sender, EventArgs e)
        {
            if (dtpcikistarihi.Value < dtpgiristarihi.Value)
            {
         
                dtpcikistarihi.Text = DateTime.Today.ToString(dtpgiristarihi.CustomFormat);
                
            }
            else
            {
                int ucret;
                DateTime kücüktarih = Convert.ToDateTime(dtpgiristarihi.Text);
                DateTime büyüktarih = Convert.ToDateTime(dtpcikistarihi.Text);
                TimeSpan sonuc =
                    büyüktarih - kücüktarih;
                label10.Text = sonuc.TotalDays.ToString();
                ucret = Convert.ToInt32(label10.Text) * 50;
                textBox3.Text = ucret.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmanamenu fr = new frmanamenu();
            fr.Show();
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox5.Text = button8.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox5.Text = button6.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox5.Text = button4.Text;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox5.Text = button14.Text;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox5.Text = button10.Text;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox5.Text = button11.Text;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox5.Text = button12.Text;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox5.Text = button17.Text;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox5.Text = button15.Text;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox5.Text = button16.Text;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            textBox5.Text = button18.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox5.Text = button5.Text;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox5.Text = button13.Text;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox5.Text = button9.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox5.Text = button7.Text;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            textBox5.Text = button1.Text;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            textBox5.Text = button20.Text;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            textBox5.Text = button24.Text;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            textBox5.Text = button22.Text;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            textBox5.Text = button21.Text;
        }

        private void button26_Click(object sender, EventArgs e)
        {
            textBox5.Text = button26.Text;
        }

        private void button25_Click(object sender, EventArgs e)
        {
            textBox5.Text = button25.Text;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            textBox5.Text = button23.Text;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            textBox5.Text = button19.Text;
        }

        private void btnkyt_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "" || maskedTextBox3.Text == "" || textBox4.Text == "" || maskedTextBox1.Text == "" || textBox5.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Lütfen Boş Alan Bırakmayınız");
            }
            else
            {
                baglan.Open();

                string komut = "insert into Müşteriler (Adı,Soyadı,TC,Email,Telefon,OdaNo,GirisTarihi,CikisTarihi,Ücret) values(@Adı,@Soyadı,@TC,@Email,@Telefon,@OdaNo,@GirisTarihi,@CikisTarihi,@Ücret)";
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
                baglan.Close();
                MessageBox.Show("Kayıt Başarıyla Oluşturuldu");
                textBox1.Clear();
                textBox2.Clear();
                maskedTextBox3.Clear();
                textBox4.Clear();
                maskedTextBox1.Clear();
                textBox5.Clear();

                dtpgiristarihi.Text = DateTime.Today.ToString(dtpgiristarihi.CustomFormat);

                dtpcikistarihi.Text = DateTime.Today.ToString(dtpgiristarihi.CustomFormat);
                textBox3.Clear();
                baglan.Close();
                frmyenimusteri fr = new frmyenimusteri();
                fr.Show();
                this.Hide();


            }





        }

        private void frmyenimusteri_Load(object sender, EventArgs e)
        {
            // 101
            baglan.Open();
            SqlCommand komut1 = new SqlCommand("select * from Müşteriler where OdaNo=101", baglan);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                button8.Text = dr1["OdaNo"].ToString() + " " +"Dolu";

            }
            baglan.Close();
            if (button8.Text != "101")
            {
                button8.BackColor = Color.Red;
                button8.Enabled = false;
            }
            // 102
         baglan.Open();
            SqlCommand komut2 = new SqlCommand("select * from Müşteriler where OdaNo=102", baglan);
            SqlDataReader dr2 = komut2.ExecuteReader();   
            while (dr2.Read())
            {
                button6.Text = dr2["OdaNo"].ToString() + " " + "Dolu";

            }
            baglan.Close();
            if (button6.Text != "102")
            {
                button6.BackColor = Color.Red;
                button6.Enabled = false;
            }
            // 103
            baglan.Open();
            SqlCommand komut3 = new SqlCommand("select * from Müşteriler where OdaNo=103", baglan);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                button4.Text = dr3["OdaNo"].ToString() + " " + "Dolu";

            }
            baglan.Close();
            if (button4.Text != "103")
            {
                button4.BackColor = Color.Red;
                button4.Enabled = false;
            }
            // 104
            baglan.Open();
            SqlCommand komut4 = new SqlCommand("select * from Müşteriler where OdaNo=104", baglan);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                button14.Text = dr4["OdaNo"].ToString() + " " + "Dolu";

            }
            baglan.Close();
            if (button14.Text != "104")
            {
                button14.BackColor = Color.Red;
                button14.Enabled = false;
            }
            // 105
            baglan.Open();
            SqlCommand komut5 = new SqlCommand("select * from Müşteriler where OdaNo=105", baglan);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                button10.Text = dr5["OdaNo"].ToString() + " " + "Dolu";

            }
            baglan.Close();
            if (button10.Text != "105")
            {
                button10.BackColor = Color.Red;
                button10.Enabled = false;
            }
            //106
            baglan.Open();
            SqlCommand komut6 = new SqlCommand("select * from Müşteriler where OdaNo=106", baglan);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                button11.Text = dr6["OdaNo"].ToString() + " " + "Dolu";

            }
            baglan.Close();
            if (button11.Text != "106")
            {
                button11.BackColor = Color.Red;
                button11.Enabled = false;
            }
            // 107
            baglan.Open();
            SqlCommand komut7 = new SqlCommand("select * from Müşteriler where OdaNo=107", baglan);
            SqlDataReader dr7 = komut7.ExecuteReader();
            while (dr7.Read())
            {
                button12.Text = dr7["OdaNo"].ToString() + " " + "Dolu";

            }
            baglan.Close();
            if (button12.Text != "107")
            {
                button12.BackColor = Color.Red;
                button12.Enabled = false;
            }
            // 108
            baglan.Open();
            SqlCommand komut8 = new SqlCommand("select * from Müşteriler where OdaNo=108", baglan);
            SqlDataReader dr8 = komut8.ExecuteReader();
            while (dr8.Read())
            {
                button17.Text = dr8["OdaNo"].ToString() + " " + "Dolu";

            }
            baglan.Close();
            if (button17.Text != "108")
            {
                button17.BackColor = Color.Red;
                button17.Enabled = false;
            }
            // 201
            baglan.Open();
            SqlCommand komut9 = new SqlCommand("select * from Müşteriler where OdaNo=201", baglan);
            SqlDataReader dr9 = komut9.ExecuteReader();
            while (dr9.Read())
            {
                button15.Text = dr9["OdaNo"].ToString() + " " + "Dolu";

            }
            baglan.Close();
            if (button15.Text != "201")
            {
                button15.BackColor = Color.Red;
                button15.Enabled = false;
            }
            // 202 
            baglan.Open();
            SqlCommand komut10 = new SqlCommand("select * from Müşteriler where OdaNo=202", baglan);
            SqlDataReader dr10 = komut10.ExecuteReader();
            while (dr10.Read())
            {
                button16.Text = dr10["OdaNo"].ToString() + " " + "Dolu";

            }
            baglan.Close();
            if (button16.Text != "202")
            {
                button16.BackColor = Color.Red;
                button16.Enabled = false;
            }
            // 203
            baglan.Open();
            SqlCommand komut11 = new SqlCommand("select * from Müşteriler where OdaNo=203", baglan);
            SqlDataReader dr11 = komut11.ExecuteReader();
            while (dr11.Read())
            {
                button18.Text = dr11["OdaNo"].ToString() + " " + "Dolu";

            }
            baglan.Close();
            if (button18.Text != "203")
            {
                button18.BackColor = Color.Red;
                button18.Enabled = false;
            }
            // 204
            baglan.Open();
            SqlCommand komut12 = new SqlCommand("select * from Müşteriler where OdaNo=204", baglan);
            SqlDataReader dr12 = komut12.ExecuteReader();
            while (dr12.Read())
            {
                button5.Text = dr12["OdaNo"].ToString() + " " + "Dolu";

            }
            baglan.Close();
            if (button5.Text != "204")
            {
                button5.BackColor = Color.Red;
                button5.Enabled = false;
            }
            // 205
            baglan.Open();
            SqlCommand komut13 = new SqlCommand("select * from Müşteriler where OdaNo=205", baglan);
            SqlDataReader dr13 = komut13.ExecuteReader();
            while (dr13.Read())
            {
                button13.Text = dr13["OdaNo"].ToString() + " " + "Dolu";

            }
            baglan.Close();
            if (button13.Text != "205")
            {
                button13.BackColor = Color.Red;
                button13.Enabled = false;
            }
            // 206
            baglan.Open();
            SqlCommand komut14 = new SqlCommand("select * from Müşteriler where OdaNo=206", baglan);
            SqlDataReader dr14 = komut14.ExecuteReader();
            while (dr14.Read())
            {
                button9.Text = dr14["OdaNo"].ToString() + " " + "Dolu";

            }
            baglan.Close();
            if (button9.Text != "206")
            {
                button9.BackColor = Color.Red;
                button9.Enabled = false;
            }
            // 207
            baglan.Open();
            SqlCommand komut15 = new SqlCommand("select * from Müşteriler where OdaNo=207", baglan);
            SqlDataReader dr15 = komut15.ExecuteReader();
            while (dr15.Read())
            {
                button7.Text = dr15["OdaNo"].ToString() + " " + "Dolu";

            }
            baglan.Close();
            if (button7.Text != "207")
            {
                button7.BackColor = Color.Red;
                button7.Enabled = false;
            }
            // 208
            baglan.Open();
            SqlCommand komut16 = new SqlCommand("select * from Müşteriler where OdaNo=208", baglan);
            SqlDataReader dr16 = komut16.ExecuteReader();
            while (dr16.Read())
            {
                button1.Text = dr16["OdaNo"].ToString() + " " + "Dolu";

            }
            baglan.Close();
            if (button1.Text != "208")
            {
                button1.BackColor = Color.Red;
                button1.Enabled = false;
            }
            // 301
            baglan.Open();
            SqlCommand komut17 = new SqlCommand("select * from Müşteriler where OdaNo=301", baglan);
            SqlDataReader dr17 = komut17.ExecuteReader();
            while (dr17.Read())
            {
                button20.Text = dr17["OdaNo"].ToString() + " " + "Dolu";

            }
            baglan.Close();
            if (button20.Text != "301")
            {
                button20.BackColor = Color.Red;
                button20.Enabled = false;
            }
            // 302
            baglan.Open();
            SqlCommand komut18 = new SqlCommand("select * from Müşteriler where OdaNo=302", baglan);
            SqlDataReader dr18 = komut18.ExecuteReader();
            while (dr18.Read())
            {
                button24.Text = dr18["OdaNo"].ToString() + " " + "Dolu";

            }
            baglan.Close();
            if (button24.Text != "302")
            {
                button24.BackColor = Color.Red;
                button24.Enabled = false;
            }
            // 303
            baglan.Open();
            SqlCommand komut19 = new SqlCommand("select * from Müşteriler where OdaNo=303", baglan);
            SqlDataReader dr19 = komut19.ExecuteReader();
            while (dr19.Read())
            {
                button22.Text = dr19["OdaNo"].ToString() + " " + "Dolu";

            }
            baglan.Close();
            if (button22.Text != "303")
            {
                button22.BackColor = Color.Red;
                button22.Enabled = false;
            }
            // 304
            baglan.Open();
            SqlCommand komut20 = new SqlCommand("select * from Müşteriler where OdaNo=304", baglan);
            SqlDataReader dr20 = komut20.ExecuteReader();
            while (dr20.Read())
            {
                button21.Text = dr20["OdaNo"].ToString() + " " + "Dolu";

            }
            baglan.Close();
            if (button21.Text != "304")
            {
                button21.BackColor = Color.Red;
                button21.Enabled = false;
            }
            // 305
            baglan.Open();
            SqlCommand komut21 = new SqlCommand("select * from Müşteriler where OdaNo=305", baglan);
            SqlDataReader dr21 = komut21.ExecuteReader();
            while (dr21.Read())
            {
                button26.Text = dr21["OdaNo"].ToString() + " " + "Dolu";

            }
            baglan.Close();
            if (button26.Text != "305")
            {
                button26.BackColor = Color.Red;
                button26.Enabled = false;
            }
            // 306
            baglan.Open();
            SqlCommand komut22 = new SqlCommand("select * from Müşteriler where OdaNo=306", baglan);
            SqlDataReader dr22 = komut22.ExecuteReader();
            while (dr22.Read())
            {
                button25.Text = dr22["OdaNo"].ToString() + " " + "Dolu";

            }
            baglan.Close();
            if (button25.Text != "306")
            {
                button25.BackColor = Color.Red;
                button25.Enabled = false;
            }
            // 307
            baglan.Open();
            SqlCommand komut23 = new SqlCommand("select * from Müşteriler where OdaNo=307", baglan);
            SqlDataReader dr23 = komut23.ExecuteReader();
            while (dr23.Read())
            {
                button23.Text = dr23["OdaNo"].ToString() + " " + "Dolu";

            }
            baglan.Close();
            if (button23.Text != "307")
            {
                button23.BackColor = Color.Red;
                button23.Enabled = false;
            }
            // 308
            baglan.Open();
            SqlCommand komut24 = new SqlCommand("select * from Müşteriler where OdaNo=308", baglan);
            SqlDataReader dr24 = komut24.ExecuteReader();
            while (dr24.Read())
            {
                button19.Text = dr24["OdaNo"].ToString() + " " + "Dolu";

            }
            baglan.Close();
            if (button19.Text != "308")
            {
                button19.BackColor = Color.Red;
                button19.Enabled = false;
            }
        }

 

        private void button2_Click_1(object sender, EventArgs e)
        {
            frmanamenu frmrmr = new frmanamenu();
            frmrmr.Show();
            this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Programı Kapatmak İstediğinize Eminmisiniz?", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
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

   

    

      

       

     

    }
}