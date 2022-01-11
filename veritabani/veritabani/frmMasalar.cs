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
    public partial class frmMasalar : Form
    {
        public frmMasalar()
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

        private void btnMasa1_Click(object sender, EventArgs e)
        {
            frmSiparis frmSiparis = new frmSiparis();
            
            int uzunluk = btnMasa1.Text.Length;
            cGenel._ButtonValue = btnMasa1.Text.Substring(uzunluk-6, 6);
            cGenel._ButtonName = btnMasa1.Name;
            this.Close();

            frmSiparis.ShowDialog();


        }

        private void btnMasa2_Click(object sender, EventArgs e)
        {
            frmSiparis frmSiparis = new frmSiparis();

            int uzunluk = btnMasa2.Text.Length;
            cGenel._ButtonValue = btnMasa2.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa2.Name;
            this.Close();

            frmSiparis.ShowDialog();
        }

        private void btnMasa3_Click(object sender, EventArgs e)
        {
            frmSiparis frmSiparis = new frmSiparis();

            int uzunluk = btnMasa3.Text.Length;
            cGenel._ButtonValue = btnMasa3.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa3.Name;
            this.Close();

            frmSiparis.ShowDialog();
        }

        private void btnMasa4_Click(object sender, EventArgs e)
        {
            frmSiparis frmSiparis = new frmSiparis();

            int uzunluk = btnMasa4.Text.Length;
            cGenel._ButtonValue = btnMasa4.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa4.Name;
            this.Close();

            frmSiparis.ShowDialog();
        }

        private void btnMasa5_Click(object sender, EventArgs e)
        {
            frmSiparis frmSiparis = new frmSiparis();

            int uzunluk = btnMasa5.Text.Length;
            cGenel._ButtonValue = btnMasa5.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa5.Name;
            this.Close();

            frmSiparis.ShowDialog();
        }

        private void btnMasa6_Click(object sender, EventArgs e)
        {
            frmSiparis frmSiparis = new frmSiparis();

            int uzunluk = btnMasa6.Text.Length;
            cGenel._ButtonValue = btnMasa6.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa6.Name;
            this.Close();

            frmSiparis.ShowDialog();
        }

        private void btnMasa7_Click(object sender, EventArgs e)
        {
            frmSiparis frmSiparis = new frmSiparis();

            int uzunluk = btnMasa7.Text.Length;
            cGenel._ButtonValue = btnMasa7.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa7.Name;
            this.Close();

            frmSiparis.ShowDialog();
        }

        private void btnMasa8_Click(object sender, EventArgs e)
        {
            frmSiparis frmSiparis = new frmSiparis();

            int uzunluk = btnMasa8.Text.Length;
            cGenel._ButtonValue = btnMasa8.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa8.Name;
            this.Close();

            frmSiparis.ShowDialog();
        }

        private void btnMasa9_Click(object sender, EventArgs e)
        {
            frmSiparis frmSiparis = new frmSiparis();

            int uzunluk = btnMasa9.Text.Length;
            cGenel._ButtonValue = btnMasa9.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa9.Name;
            this.Close();

            frmSiparis.ShowDialog();
        }

        private void btnMasa10_Click(object sender, EventArgs e)
        {
            frmSiparis frmSiparis = new frmSiparis();

            int uzunluk = btnMasa10.Text.Length;
            cGenel._ButtonValue = btnMasa10.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa10.Name;
            this.Close();

            frmSiparis.ShowDialog();
        }

        cGenel gnl = new cGenel();

        private void frmMasalar_Load(object sender, EventArgs e)
        {
            OracleConnection connection = new OracleConnection();
            OracleCommand cmd = new OracleCommand("Select DURUM, ID From  MASALAR", gnl.connection());

            OracleDataReader dataReader = null;

            connection.Open();

            dataReader = cmd.ExecuteReader();

            while(dataReader.Read())
            {

                foreach(Control item in this.Controls)
                {
                    if (item is Button)
                    {
                        if (item.Name == "btnMasa" + dataReader["ID"].ToString() && dataReader["DURUM"].ToString() == "1")
                        {
                            item.BackColor = Color.Green;
                        }

                        else if (item.Name == "btnMasa" + dataReader["ID"].ToString() && dataReader["DURUM"].ToString() == "2")
                        {
                            cMasalar masalar = new cMasalar();
                            DateTime dt1 = Convert.ToDateTime(masalar.SessionSum(2));
                            DateTime dt2 = DateTime.Now;

                            string st1 = Convert.ToDateTime(masalar.SessionSum(2)).ToShortTimeString();
                            string st2 = DateTime.Now.ToShortTimeString();

                            DateTime t1 = dt1.AddMinutes(DateTime.Parse(st1).TimeOfDay.TotalMinutes);
                            DateTime t2 = dt2.AddMinutes(DateTime.Parse(st2).TimeOfDay.TotalMinutes);

                            var fark = t2 - t1;

                           item.Text = String.Format("{0}{1}{2}",
                               fark.Days > 0 ? string.Format("[0]Gün", fark.Days) : " ",
                                fark.Hours > 0 ? string.Format("[0] Saat", fark.Hours) : " ",
                                fark.Minutes > 0 ? string.Format("[0] Dakika", fark.Minutes) : " ").Trim() + "\n\n\nMasa" + dataReader["ID"].ToString();

                            item.BackColor = Color.Red;
                        }
                        else if(item.Name == "btnMasa" + dataReader["ID"].ToString() && dataReader["DURUM"].ToString() == "3")
                        {
                            item.BackColor = Color.DarkBlue;
                        }
                        else if (item.Name == "btnMasa" + dataReader["ID"].ToString() && dataReader["DURUM"].ToString() == "4")
                        {
                            item.BackColor = Color.Gold;
                        }
                    }
                }

            }
        }
    }
}
