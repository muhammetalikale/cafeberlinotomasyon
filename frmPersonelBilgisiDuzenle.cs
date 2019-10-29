using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeBerlinOtomasyon
{
    public partial class frmPersonelBilgisiDuzenle : Form
    {
        public frmPersonelBilgisiDuzenle()
        {
            InitializeComponent();
        }

        private void frmPersonelBilgisiDuzenle_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select KULLANICIADI from personel", cVeritabani.conn);
            cVeritabani.baglantiKontrol();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cbKullaniciAdi.Items.Add(dr["KULLANICIADI"]);
            }
            dr.Close();
            cVeritabani.conn.Close();
        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            if(cPersonelIslemleri.PersonelDuzenle(txtKullaniciAdi, txtParola, txtAd, txtSoyad, cbKullaniciAdi.SelectedItem))
            {
                MessageBox.Show("Bilgiler Başarıyla Düzenlendi.");
                txtAd.Text = "";
                txtKullaniciAdi.Text = "";
                txtParola.Text = "";
                txtSoyad.Text = "";
            }
            else
            {
                MessageBox.Show("Bilgi Düzenleme İşlemi Başarısız Oldu.");
            }
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bu Pencereyi Kapatmak İstediğinize Emin misiniz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
