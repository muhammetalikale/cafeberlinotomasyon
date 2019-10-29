using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeBerlinOtomasyon
{
    public partial class frmPersonelEkle : Form
    {
        public frmPersonelEkle()
        {
            InitializeComponent();
        }

        private void btnPersonelEkleVazgec_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bu Pencereyi Kapatmak İstediğinize Emin misiniz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
            
        }

        private void frmKullaniciEkle_Load(object sender, EventArgs e)
        {

        }

        private void btnPersonelEkleEkle_Click(object sender, EventArgs e)
        {
            if (txtPersonelEkleAd.Text.Equals("") || txtPersonelEkleKullaniciAdi.Text.Equals("") ||txtPersonelEkleParola.Text.Equals("") || txtPersonelEkleSoyad.Text.Equals("")) //Bilgilerde boşluk varsa
            {
                MessageBox.Show("Lütfen Bilgileri Eksiksiz Doldurunuz!");
                return;
            }
            else //Bilgiler eksiksiz ise
            {
                string sql = "select KULLANICIADI from personel where KULLANICIADI='" + txtPersonelEkleKullaniciAdi.Text + "'";
                if (cKontroller.veriVarmi(sql))
                {
                    MessageBox.Show("Halihazırda Böyle Bir Kullanıcı Olduğu İçin Ekleme İşlemi Yapamazsınız.");
                }
                else //Veritabanında aynı isimli bir kullanıcı yok ise
                {
                    if (cPersonelIslemleri.PersonelEkle(txtPersonelEkleKullaniciAdi, txtPersonelEkleParola, txtPersonelEkleAd, txtPersonelEkleSoyad))
                    {
                        MessageBox.Show("Personel başarıyla eklenmiştir.");
                        txtPersonelEkleAd.Text = "";
                        txtPersonelEkleKullaniciAdi.Text = "";
                        txtPersonelEkleParola.Text = "";
                        txtPersonelEkleSoyad.Text = "";
                    }
                    else
                        MessageBox.Show("Personel Ekleme İşlemi Başarısız Oldu.");
                }
            }
        }
    }
}
