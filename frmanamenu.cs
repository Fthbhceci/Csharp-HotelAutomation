using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Otel_Kayıt_Otomasyonu
{
    public partial class frmanamenu : Form
    {
        public frmanamenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmyenimusteri fr= new frmyenimusteri();
            fr.Show();
            this.Hide();
            
        }

        private void frmanamenu_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void frmanamenu_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

      

        private void button2_Click(object sender, EventArgs e)
        {

            tummusteriler fr = new tummusteriler();
          
            fr.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmGiris frmr = new FrmGiris();
   
            frmr.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Programı Kapatmak İstediğinize Eminmisiniz?", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sifredegistir fr = new sifredegistir();
            fr.Show();
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Gecmismüsteriler fr = new Gecmismüsteriler();
            fr.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Kasa fr = new Kasa();
            fr.Show();
            this.Hide();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblzaman.Text = DateTime.Now.ToShortTimeString();
            lbltarih.Text = DateTime.Now.ToShortDateString();
        }

       
    }
}
