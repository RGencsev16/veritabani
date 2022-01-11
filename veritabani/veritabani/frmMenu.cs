using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace veritabani
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void btnMasaSiparis_Click(object sender, EventArgs e)
        {
            frmMasalar frmMasalar = new frmMasalar();
            this.Close();
            frmMasalar.Show();

        }

        private void btnRezervasyon_Click(object sender, EventArgs e)
        {
            frmRezervasyon frmRezervasyon = new frmRezervasyon();
            this.Close();
            frmRezervasyon.Show();

        }

        private void btnPaketSiparis_Click(object sender, EventArgs e)
        {
            frmSiparis frmSiparis = new frmSiparis();
            this.Close();
            frmSiparis.Show();
        }

        private void btnMusteriler_Click(object sender, EventArgs e)
        {
            frmMusteriler frmMusteriler = new frmMusteriler();
            this.Close();
            frmMusteriler.Show();
        }

        private void btnKasaIslemleri_Click(object sender, EventArgs e)
        {
            frmKasaIslemleri frmKasaIslemleri = new frmKasaIslemleri();
            this.Close();
            frmKasaIslemleri.Show();
        }

        private void btnMutfak_Click(object sender, EventArgs e)
        {
            frmMutfak frmMutfak = new frmMutfak();
            this.Close();
            frmMutfak.Show();
        }

        private void btnAyarlar_Click(object sender, EventArgs e)
        {
            frmSettings frmSettings = new frmSettings();
            this.Close();
            frmSettings.Show();
      
        }

        private void btnKilit_Click(object sender, EventArgs e)
        {
            frmKilit frmKilit = new frmKilit();
            this.Close();
            frmKilit.Show();

        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Cıkmak istediğinize emi misiniz ?", " !!! Uyarı !!! ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
