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
    public partial class frmSiparis : Form
    {
        public frmSiparis()
        {
            InitializeComponent();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Cıkmak istediğinize emi misiniz ?", " !!! Uyarı !!! ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            frmMenu frmMenu = new frmMenu();
            this.Close();
            frmMenu.Show();
        }

        //Sayı tuşları event brleştirme
        void islem(Object sender, EventArgs ev)
        {
            Button button = sender as Button;

            switch (button.Name)
            {
                case "btn1":
                    tBAdet.Text += (1).ToString();
                    break;
                case "btn2":
                    tBAdet.Text += (2).ToString();
                    break;
                case "btn3":
                    tBAdet.Text += (3).ToString();
                    break;
                case "btn4":
                    tBAdet.Text += (4).ToString();
                    break;
                case "btn5":
                    tBAdet.Text += (5).ToString();
                    break;
                case "btn6":
                    tBAdet.Text += (6).ToString();
                    break;
                case "btn7":
                    tBAdet.Text += (7).ToString();
                    break;
                case "btn8":
                    tBAdet.Text += (8).ToString();
                    break;
                case "btn9":
                    tBAdet.Text += (9).ToString();
                    break;
                case "btn0":
                    tBAdet.Text += (0).ToString();
                    break;
                default:
                    MessageBox.Show("Sayı Giriniz");
                    break;
            }

        }

        int tableId; int AdditionId;
        private void frmSiparis_Load(object sender, EventArgs e)
        {
            lblMsaNo.Text = cGenel._ButtonValue;

            cMasalar masalar = new cMasalar();

            tableId = masalar.TableGetByNumber(cGenel._ButtonName);

            if(masalar.TableGetByState(tableId, 2) == true || masalar.TableGetByState(tableId, 4) == true)
            {
                cAdisyon adisyon = new cAdisyon();
                AdditionId = adisyon.GetByAddittion(tableId);
                cSiparis siparis = new cSiparis();
                siparis.GetByOrder(lVSiparisler, AdditionId);
            }

            btn1.Click += new EventHandler(islem);
            btn2.Click += new EventHandler(islem);
            btn3.Click += new EventHandler(islem);
            btn4.Click += new EventHandler(islem);
            btn5.Click += new EventHandler(islem);
            btn6.Click += new EventHandler(islem);
            btn7.Click += new EventHandler(islem);
            btn8.Click += new EventHandler(islem);
            btn9.Click += new EventHandler(islem);
            btn0.Click += new EventHandler(islem);

        }

        cUrunCesitleri cUrun = new cUrunCesitleri();
        private void btnAnaYemek1_Click(object sender, EventArgs e)
        {
            cUrun.GetByProductTypes(lvMenu, btnAnaYemek1);
        }

        private void btnİcecekler_Click(object sender, EventArgs e)
        {
            cUrun.GetByProductTypes(lvMenu, btnİcecekler);
        }

        private void btnTatlilar_Click(object sender, EventArgs e)
        {
            cUrun.GetByProductTypes(lvMenu, btnTatlilar);
        }

        private void btnSalata_Click(object sender, EventArgs e)
        {
            cUrun.GetByProductTypes(lvMenu, btnSalata);
        }

        private void bnFastFood_Click(object sender, EventArgs e)
        {
            cUrun.GetByProductTypes(lvMenu, bnFastFood);
        }

        private void btnCorba_Click(object sender, EventArgs e)
        {
            cUrun.GetByProductTypes(lvMenu, btnCorba);
        }

        private void btnMakarna_Click(object sender, EventArgs e)
        {
            cUrun.GetByProductTypes(lvMenu, btnMakarna);
        }

        private void btnAraSicak_Click(object sender, EventArgs e)
        {
            cUrun.GetByProductTypes(lvMenu, btnAraSicak);
        }

        int sayac = 0; int sayac1 = 0;

        private void lvMenu_DoubleClick(object sender, EventArgs e)
        {
            if(tBAdet.Text == "")
            {
                tBAdet.Text = "1";
            }

            if (lvMenu.Items.Count > 0)
            {
                sayac = lVSiparisler.Items.Count;

                lVSiparisler.Items.Add(lvMenu.SelectedItems[0].Text);
                lVSiparisler.Items[sayac].SubItems.Add(tBAdet.Text);
                lVSiparisler.Items[sayac].SubItems.Add(lvMenu.SelectedItems[0].SubItems[2].Text);
                lVSiparisler.Items[sayac].SubItems.Add((Convert.ToDecimal(lvMenu.SelectedItems[0].SubItems[1].Text) * Convert.ToDecimal
                    (tBAdet.Text)).ToString());
                lVSiparisler.Items[sayac].SubItems.Add("0");
                sayac1 = lvYeniEklenenler.Items.Count;
                lVSiparisler.Items[sayac].SubItems.Add(sayac.ToString());

                lvYeniEklenenler.Items.Add(AdditionId.ToString());
                lvYeniEklenenler.Items[sayac1].SubItems.Add(lvMenu.SelectedItems[0].SubItems[2].Text);
                lvYeniEklenenler.Items[sayac1].SubItems.Add(tBAdet.Text);
                lvYeniEklenenler.Items[sayac1].SubItems.Add(tableId.ToString());
                lvYeniEklenenler.Items[sayac1].SubItems.Add(sayac1.ToString());

                sayac1++;

                tBAdet.Text = " ";

            }
        }

        private void btnSiparis_Click(object sender, EventArgs e)
        {
            /*
             * 1 = masa boş
             * 2 = masa dolu
             * 3 = masa rezerve
             * 4 = masa rezerve ama dolu
             */
            cMasalar masalar = new cMasalar();
            frmMasalar frmMasalar = new frmMasalar();
            cAdisyon adisyon = new cAdisyon();
            cSiparis siparis = new cSiparis();

            bool sonuc = false;

            if(masalar.TableGetByState(tableId, 1) == true)
            {
                adisyon.ServisTurNo = 1;
                adisyon.CalisanId = 1;
                adisyon.MasaId = tableId;
                adisyon.Tarih = DateTime.Now;

                sonuc = Convert.ToBoolean(adisyon.SetByAddittionNew(adisyon));

                masalar.SetChangeTableState(cGenel._ButtonName, 2);

                if(lVSiparisler.Items.Count > 0)
                {
                    for(int i = 0; i < lVSiparisler.Items.Count; i++)
                    {
                        siparis.MasaId = tableId;
                        siparis.UrunId = Convert.ToInt32(lVSiparisler.Items[i].SubItems[2].Text);
                        siparis.AdisyonId = adisyon.GetByAddittion(tableId);
                        siparis.Adet = Convert.ToInt32(lVSiparisler.Items[i].SubItems[1].Text);
                        siparis.SetSaveOrder(siparis);
                    }
                    this.Close();
                    frmMasalar.Show();


                }



            }



        }

    }
}
