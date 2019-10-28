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
    public partial class frmMasalar : Form
    {
        public frmMasalar()
        {
            InitializeComponent();
        }

        private void personelEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonelEkle frmKullaniciEkle = new frmPersonelEkle();
            frmKullaniciEkle.ShowDialog();
        }
    }
}
