using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;
using BusinessLogiclayer;
using DatabaseLogicLayer;


namespace TelefonRehberi
{
    public partial class Form1 : Form
    {
        BusinessLogiclayer.BLL bll;

        public Form1()
        {
            InitializeComponent();
            bll = new BLL();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btn_giris_Click(object sender, EventArgs e)
        {
            int returnValues= bll.SistemKontrol(txt_kullanici_adi.Text, txt_kullanici_sifre.Text);
            if (returnValues > 0)
            {
                AnaForm af = new AnaForm();
                af.Show();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Girişi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }


        }
    }
}
