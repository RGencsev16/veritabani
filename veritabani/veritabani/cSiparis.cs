using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Windows.Forms;

namespace veritabani
{
    class cSiparis
    {
        cGenel gnl = new cGenel();

        #region Fields
        private int _Id;
        private int _adisyonId;
        private int _urunId;
        private int _adet;
        private int _masaId;
        #endregion

        #region Properties
        public int Id { get => _Id; set => _Id = value; }
        public int AdisyonId { get => _adisyonId; set => _adisyonId = value; }
        public int UrunId { get => _urunId; set => _urunId = value; }
        public int Adet { get => _adet; set => _adet = value; }
        public int MasaId { get => _masaId; set => _masaId = value; }
        #endregion

        public void GetByOrder( ListView lv, int AdisyonId)
        {
            OracleConnection connection = new OracleConnection();
            OracleCommand cmd = new OracleCommand("Select URUNAD, FIYAT, Satislar.ID, Satislar.URUNID, Satislar.ADET, From Satislar Inner Join URUNLER on Satislar.URUNID = Urunler.ID" +
                "where ADISYONID =:AdisyonId", gnl.connection());
            OracleDataReader dataReader = null;

            cmd.Parameters.Add("AdisyonId", OracleDbType.Int32).Value = AdisyonId;
           

            try
            {

                connection.Open();
                dataReader = cmd.ExecuteReader();
                int sayac = 0;
                while (dataReader.Read())
                {
                    lv.Items.Add(dataReader["URUNAD"].ToString());
                    lv.Items[sayac].SubItems.Add(dataReader["ADET"].ToString());
                    lv.Items[sayac].SubItems.Add(dataReader["URUNID"].ToString());
                    lv.Items[sayac].SubItems.Add(Convert.ToString(Convert.ToDecimal(dataReader["FIYAT"])* Convert.ToDecimal(dataReader["ADET"])));
                    lv.Items[sayac].SubItems.Add(dataReader["ID"].ToString());

                    sayac++;

                }

            }
            catch (OracleException exception)
            {
                string hata = exception.Message;
                
            }
            finally
            {
                dataReader.Close();
                connection.Dispose();
                connection.Close();
            }
            
        }

        public bool SetSaveOrder(cSiparis bilgiler)
        {
            bool sonuc = false;
            
            OracleConnection connection = new OracleConnection();
            OracleCommand cmd = new OracleCommand("Insert Into Satislar(ADISYONID, URUNID, ADET, MASAID) values(adisyonId, urunId, adet, masaId)", gnl.connection());
            
            cmd.Parameters.Add("AdisyonId", OracleDbType.Int32).Value = AdisyonId;


            try
            {

                connection.Open();
                int sayac = 0;

                cmd.Parameters.Add("adisyonId", OracleDbType.Int32).Value = bilgiler._adisyonId;
                cmd.Parameters.Add("urunId", OracleDbType.Int32).Value = bilgiler._urunId;
                cmd.Parameters.Add("adet", OracleDbType.Int32).Value = bilgiler._adet;
                cmd.Parameters.Add("masaId", OracleDbType.Int32).Value = bilgiler._masaId;

                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());

                

            }
            catch (OracleException exception)
            {
                string hata = exception.Message;

            }
            finally
            {
                connection.Dispose();
                connection.Close();
            }

            return Convert.ToBoolean(sonuc);

        }

    }
}
