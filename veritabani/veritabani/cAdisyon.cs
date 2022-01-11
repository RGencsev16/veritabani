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
    class cAdisyon
    {
        cGenel gnl = new cGenel();
        #region Fields
        private int _Id;
        private int _ServisTurNo;
        private decimal _Tutar;
        private DateTime _Tarih;
        private int _CalisanId;
        private int _Durum;
        private int _MasaId;
        #endregion

        #region Properties
        public int Id { get => _Id; set => _Id = value; }
        public int ServisTurNo { get => _ServisTurNo; set => _ServisTurNo = value; }
        public decimal Tutar { get => _Tutar; set => _Tutar = value; }
        public DateTime Tarih { get => _Tarih; set => _Tarih = value; }
        public int CalisanId { get => _CalisanId; set => _CalisanId = value; }
        public int Durum { get => _Durum; set => _Durum = value; }
        public int MasaId { get => _MasaId; set => _MasaId = value; }
        #endregion

        public int GetByAddittion(int MasaId)
        {
            OracleConnection connection = new OracleConnection();
            OracleCommand cmd = new OracleCommand("Select Top 1 ID From Adisyonlar where MASAID=:MasaId Order By ID desc", gnl.connection());
            cmd.Parameters.Add("MasaId", OracleDbType.Int32).Value = MasaId;


            try
            {

                connection.Open();
                MasaId = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch (OracleException exception)
            {
                string hata = exception.Message;
            }
            finally
            {
                connection.Close();
            }
         
            return MasaId;

        }

        public int SetByAddittionNew(cAdisyon bilgiler )
        {
            bool sonuc = false;

            OracleConnection connection = new OracleConnection();
            OracleCommand cmd = new OracleCommand("Insert Into ADISYON(SERVISTURNO, TARIH, CALISANID, MASAID, DURUM) values = :sevisTurNo, :tarih, :calisanId, :masaId, :durum", gnl.connection());
            OracleDataReader dataReader = null;

            //cmd.Parameters.Add("AdisyonId", OracleDbType.Int32).Value = AdisyonId;


            try
            {

                connection.Open();
                dataReader = cmd.ExecuteReader();
                int sayac = 0;
                while (dataReader.Read())
                {
                    cmd.Parameters.Add("servisTurNo", OracleDbType.Int32).Value = bilgiler._ServisTurNo;
                    cmd.Parameters.Add("tarih", OracleDbType.Date).Value = bilgiler._Tarih;
                    cmd.Parameters.Add("calisanId", OracleDbType.Int32).Value = bilgiler._CalisanId;
                    cmd.Parameters.Add("masaId", OracleDbType.Int32).Value = bilgiler._MasaId;
                    cmd.Parameters.Add("durum", OracleDbType.Char).Value = 0;

                    sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());
                }

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

            return Convert.ToInt32(sonuc);
        }
    }
}
