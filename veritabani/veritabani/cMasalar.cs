using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace veritabani
{
    class cMasalar
    {
        #region Fields
        private int _ID;
        private int _KAPASİTE;
        private int _SERVİSTURU;
        private int _DURUM;
        private int _ONAY;
        #endregion

        #region Properties
        public int ID { get => _ID; set => _ID = value; }
        public int KAPASİTE { get => _KAPASİTE; set => _KAPASİTE = value; }
        public int SERVİSTURU { get => _SERVİSTURU; set => _SERVİSTURU = value; }
        public int DURUM { get => _DURUM; set => _DURUM = value; }
        public int ONAY { get => _ONAY; set => _ONAY = value; }
        #endregion

        cGenel gnl = new cGenel();

        public string SessionSum(int state)
        {
            String dt = " ";

            OracleConnection connection = new OracleConnection();
            OracleCommand cmd = new OracleCommand("Select TARIH, MASAID From ADISYON Right Join MASALAR on ADISYON.MASAID = MASALAR.ID " +
                "where MASALAR.DURUM = @durum and ADISYON.DURUM = 0", gnl.connection());

            OracleDataReader dr = null;

            cmd.Parameters.Add("@durum", OracleDbType.Int32).Value = state;

            try
            {
                connection.Open();

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    dt = Convert.ToDateTime(dr["Tarih"]).ToString();
                }
            }
            catch (OracleException ex)
            {
                string hata = ex.Message;

                throw;
            }
            
            finally
            {
                dr.Close();
                connection.Dispose();
                connection.Close();
            }
            return dt;

            
         }

        public int TableGetByNumber(string tableValue)
        {
            string aa = tableValue;
            int length = aa.Length;

            return Convert.ToInt32(aa.Substring(length - 1, 1));

        }

        public int TableGetByState(int ButtonName, int state)
        {
            bool result = false;
            
            OracleConnection connection = new OracleConnection();
            OracleCommand cmd = new OracleCommand("Select Durum From MASALAR where ID=:TableId and DURUM =: state", gnl.connection());
            
            cmd.Parameters.Add("TableId", OracleDbType.Int32).Value = ButtonName;
            cmd.Parameters.Add("state", OracleDbType.Int32).Value = state;

            try
            {

                connection.Open();
                result = Convert.ToBoolean(cmd.ExecuteScalar());

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

            return result;

        }

        public int SetChangeTableState(string _buttonName, int durum)
        {
            OracleConnection connection = new OracleConnection();
            OracleCommand cmd = new OracleCommand("Update Masalar set DURUM =:durum where ID =: MasaId", gnl.connection());

            connection.Open();
            String aa = _buttonName;
            int uzunluk = aa.Length;
            cmd.Parameters.Add("durum", OracleDbType.Int32).Value = durum;
            cmd.Parameters.Add("MasaId", OracleDbType.Int32).Value = durum;
            cmd.ExecuteNonQuery();
            connection.Dispose();
            connection.Close();
            
        }
    }
}
