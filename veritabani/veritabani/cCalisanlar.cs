using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;


namespace veritabani
{
  
    ///veritabanındaki bilgilere göre propertiesler oluşturulacak
    class cCalisanlar
    {
        cGenel gnl = new cGenel();

        #region Fields
        private int _CalisanId;
        private int _CalisanUnvanId;
        private string _CalisanAdi;
        private string _CalisanSoyadi;
        private string _CalisanParola;
        private string _CalisanKullaniciAdi;
        private bool _CalisanDurum;

        #endregion

        #region Properties
        public int CalisanId { get => _CalisanId; set => _CalisanId = value; }
        public int CalisanUnvanId { get => _CalisanUnvanId; set => _CalisanUnvanId = value; }
        public string CalisanAdi { get => _CalisanAdi; set => _CalisanAdi = value; }
        public string CalisanSoyadi { get => _CalisanSoyadi; set => _CalisanSoyadi = value; }
        public string CalisanParola { get => _CalisanParola; set => _CalisanParola = value; }
        public string CalisanKullaniciAdi { get => _CalisanKullaniciAdi; set => _CalisanKullaniciAdi = value; }
        public bool CalisanDurum { get => _CalisanDurum; set => _CalisanDurum = value; }

        #endregion

        public bool calisanEntryControl(string password, int userName)
        {
            //Burada giriş kontrolü yapyoruz o sebeple veritabanından çalışan ıd ve parola alıyoruz

            bool result = false;

            OracleConnection connection = new OracleConnection();
            OracleCommand cmd = new OracleCommand("Select * From  where KULLANICIADI=:kullaniciAdi and SIFRE=:sifre", gnl.connection());
            cmd.Parameters.Add("kullaniciAdi", OracleDbType.Varchar2).Value = userName;
            cmd.Parameters.Add("sifre", OracleDbType.Varchar2).Value = password;

            try
            {

                connection.Open();
                result = Convert.ToBoolean(cmd.ExecuteScalar());

            }
            catch (OracleException exception )
            {
                string hata = exception.Message;
                throw;
            }

            return result;
        }

        public void calisanGetByInformation(ComboBox cb)
        {
            cb.Items.Clear();

            OracleConnection connection = new OracleConnection();
            OracleCommand cmd = new OracleCommand("Select * From TBL_PERSONELLER ", gnl.connection());

            connection.Open();

            OracleDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                cCalisanlar calisanlar = new cCalisanlar();
                
                calisanlar._CalisanId = Convert.ToInt32(dataReader["ID"]);
                calisanlar._CalisanUnvanId = Convert.ToInt32(dataReader["UNVANID"]);
                calisanlar._CalisanAdi = Convert.ToString(dataReader["AD"]);
                calisanlar._CalisanSoyadi = Convert.ToString(dataReader["SOYAD"]);
                calisanlar._CalisanParola = Convert.ToString(dataReader["PAROLA"]);
                calisanlar._CalisanKullaniciAdi = Convert.ToString(dataReader["KULLANICIADI"]);
                calisanlar._CalisanDurum = Convert.ToBoolean(dataReader["DURUM"]);

                cb.Items.Add(calisanlar);

            }

            dataReader.Close();
            connection.Close();
                

            
            
        }

        public override string ToString()
        {
            return CalisanAdi + " " + CalisanSoyadi;
        }

    }
}
