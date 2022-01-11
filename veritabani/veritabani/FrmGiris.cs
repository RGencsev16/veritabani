using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace veritabani
{
    public partial class FrmGiris : Form
    {
        
        public FrmGiris()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cCalisanlar calisanlar = new cCalisanlar();

            calisanlar.calisanGetByInformation(cbKullaniciAdi);



        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            cGenel gnl = new cGenel(); // oraclebağlantisi için bunu kullanacaz
            cCalisanlar calisanlar = new cCalisanlar();
            bool result = calisanlar.calisanEntryControl(txtSifre.Text, cGenel._calisanId);

            if (result)
            {
                this.Hide();
                frmMenu frmMenu = new frmMenu();
                frmMenu.Show();
            }
            else
            {
                MessageBox.Show("Şifreniz Hatalı Olabilir !", "!!! Uyarı !!!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }

        private void cbKullaniciAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            cCalisanlar calisanlar = (cCalisanlar)cbKullaniciAdi.SelectedItem;

            cGenel._calisanId = calisanlar.CalisanId;

            cGenel._unvanId = calisanlar.CalisanUnvanId;

        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Cıkmak istediğinize emi misiniz ?", " !!! Uyarı !!! ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        
    }
}
