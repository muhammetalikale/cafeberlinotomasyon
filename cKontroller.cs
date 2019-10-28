using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;

namespace CafeBerlinOtomasyon
{
    class cKontroller
    {
        public static bool kullaniciKontrolu(String kulAdi, string parola) //Kullanıcı adı ve şifre kontrolü
        {
            cVeritabani.conn.Close();
            cVeritabani.baglantiKontrol();
            SqlCommand cmd = new SqlCommand("select ID from personel where KULLANICIADI=@kuladi and PAROLA=@parola", cVeritabani.conn);
            cmd.Parameters.Add("@kuladi", SqlDbType.NVarChar).Value = kulAdi;
            cmd.Parameters.Add("@parola", SqlDbType.NVarChar).Value = parola;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                dr.Close();
                cVeritabani.conn.Close();
                return true;

            }
            else
            {
                return false;
            }
        }
    }
}
