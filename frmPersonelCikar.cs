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
    public partial class frmPersonelCikar : Form
    {
        public frmPersonelCikar()
        {
            InitializeComponent();
        }

        private void frmPersonelCikar_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select KULLANICIADI from personel", cVeritabani.conn);
            cVeritabani.baglantiKontrol();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cbkAdi.Items.Add(dr["KULLANICIADI"]);
            }
            dr.Close();
            cVeritabani.conn.Close();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (cPersonelIslemleri.PersonelSil(cbkAdi))
            {
                MessageBox.Show("Personel Başarıyla Silinmiştir.");
            }
            else
            {
                MessageBox.Show("Personel Silme İşlemi Başarısız Oldu.");
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
