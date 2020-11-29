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

namespace TelefonRehberi
{
    public partial class AnaForm : Form
    {
        public AnaForm()
        {
            InitializeComponent();
        }          

       

        private void btn_yenikayit_Click(object sender, EventArgs e)
        {
            BusinessLogiclayer.BLL bll = new BusinessLogiclayer.BLL();
            int returnValues = bll.KayıtEkle(txt_y_isim.Text, txt_y_soyisim.Text, txt_y_tel1.Text, txt_y_tel2.Text, txt_y_tel3.Text, txt_y_email.Text, txt_y_web.Text, txt_y_adres.Text, txt_y_aciklama.Text);
            if (returnValues > 0)
            {
                ListeDoldur();
                MessageBox.Show("Yeni Kayıt Eklendi","Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }            

        }

      

        private void AnaForm_Load(object sender, EventArgs e)
        {

            ListeDoldur();
        }
        private void ListeDoldur()
        {
            BusinessLogiclayer.BLL bll = new BusinessLogiclayer.BLL();
            List<Rehber> RehberListesi = bll.KayıtListe();
            if(RehberListesi!=null && RehberListesi.Count > 0)
            {                
                lst_liste.DataSource = RehberListesi;
            }


        }

        private void lst_liste_DoubleClick(object sender, EventArgs e)
        {
            ListBox lst = (ListBox)sender;
            Rehber secilenKayıt = (Rehber)lst.SelectedItem;
            if (secilenKayıt != null)
            {
                txt_g_soyisim.Text = secilenKayıt.Soyisim;
                txt_g_isim.Text = secilenKayıt.Isim;
                txt_g_email.Text = secilenKayıt.EmailAdres;
                txt_g_adres.Text = secilenKayıt.Adres;
                txt_g_aciklama.Text = secilenKayıt.Aciklama;
                txt_g_tel1.Text = secilenKayıt.TelefonNumarasiI;
                txt_g_tel2.Text = secilenKayıt.TelefonNumarasiII;
                txt_g_tel3.Text = secilenKayıt.TelefonNumarasiIII;
                txt_g_web.Text = secilenKayıt.WebAdres;
            }


        }       

        private void btn_sil_Click(object sender, EventArgs e)
        {
            Guid ID = ((Rehber)lst_liste.SelectedItem).ID;
            BusinessLogiclayer.BLL bll = new BusinessLogiclayer.BLL();
            int returnValues=bll.KayıtSil(ID);
            if (returnValues > 0)
            {
                ListeDoldur();
                MessageBox.Show("Kayıt Silinmiştir", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btn_düzenle_Click(object sender, EventArgs e)
        {
            Guid ID = ((Rehber)lst_liste.SelectedItem).ID;
                BusinessLogiclayer.BLL bll = new BusinessLogiclayer.BLL();
                int returnValues = bll.KayıtDüzenle(ID, txt_g_isim.Text, txt_g_soyisim.Text, txt_g_tel1.Text, txt_g_tel2.Text, txt_g_tel3.Text, txt_g_email.Text, txt_g_web.Text, txt_g_web.Text, txt_g_adres.Text, txt_g_aciklama.Text);
                if (returnValues > 0)
                {
                    ListeDoldur();
                    MessageBox.Show("Kayıt Güncellendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        }
    }
}


