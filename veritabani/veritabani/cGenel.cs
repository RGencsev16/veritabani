using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace veritabani
{
    /// buraya veritabanına bağlama işlerini yapıyoruz
    class cGenel
    {
      
        public OracleXmlCommandType CommandType { get; internal set; }

        public OracleConnection connection()
        {
            OracleConnection con = new OracleConnection("User Id = RUMEYSA; Password = 181816015; Data Source = //localhost:1521 / ORCL");
            con.Open();
            return con;
        }

        

        public static int _calisanId;
        public static int _unvanId;

        public static string _ButtonValue;
        public static string _ButtonName;







    }
}
