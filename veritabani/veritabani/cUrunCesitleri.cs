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
    class cUrunCesitleri
    {
        cGenel gnl = new cGenel();

        #region Fields
        private int _UrunTurNo;
        private string _KategoriAd;
        private string _Aciklama;
        #endregion

        #region Properties
        public int UrunTurNo { get => _UrunTurNo; set => _UrunTurNo = value; }
        public string KategoriAd { get => _KategoriAd; set => _KategoriAd = value; }
        public string Aciklama { get => _Aciklama; set => _Aciklama = value; }
        #endregion

        public void GetByProductTypes(ListView cesitler, Button btn)
        {
            cesitler.Items.Clear();
            OracleConnection connection = new OracleConnection();
            OracleCommand cmd = new OracleCommand("Select URUNAD, FIYAT, Urunler.ID, Urunler.URUNID  From Kategoriler Inner Join URUNLER on Kategoriler.ID = Urunler.KATEGORIID" +
                "where Urunler.KATEGORIID =:KategoriId", gnl.connection());
            OracleDataReader dataReader = null;

            string aa = btn.Name;
            int uzunluk = aa.Length;

            cmd.Parameters.Add("KategoriId", OracleDbType.Int32).Value = aa.Substring(uzunluk - 1, 1);

            connection.Open();
            dataReader = cmd.ExecuteReader();

            int i = 0;

            while (dataReader.Read())
            {
                cesitler.Items.Add(dataReader["URUNAD"].ToString());
                cesitler.Items[i].SubItems.Add(dataReader["FIYAT"].ToString());
                cesitler.Items[i].SubItems.Add(dataReader["Id"].ToString());
                i++;

            }
                dataReader.Close();
                connection.Dispose();
                connection.Close();
            
        }


    }
}
