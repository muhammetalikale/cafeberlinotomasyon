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
    public partial class frmGiris : Form
    {
        public frmGiris()
        {
            InitializeComponent();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Programı kapatmak istediğinize emin misiniz?","Uyarı!",MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            if (txtKullaniciAdi.Text.Equals(""))
            {
                MessageBox.Show("Lütfen Kullanıcı Adı Alanını Boş Bırakmayınız!");
                return;
            }
            else if (txtSifre.Text.Equals(""))
            {
                MessageBox.Show("Lütfen Parola Alanını Boş Bırakmayınız!");
                return;
            }
            if (cKontroller.kullaniciKontrolu(txtKullaniciAdi.Text, txtSifre.Text) == true)
            {
                this.Hide();
                frmMasalar frmMasalar = new frmMasalar();
                frmMasalar.ShowDialog();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı yada Parola Yanlış!");
            }
        }
    }
}
