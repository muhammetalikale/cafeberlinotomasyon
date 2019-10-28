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
    class cPersonelIslemleri
    {
        public static bool PersonelEkle(TextBox kAdi, TextBox kparola, TextBox tAd, TextBox tSoyad)
        {
            cVeritabani.conn.Close();
            cVeritabani.baglantiKontrol();
            try
            {
                string sorgu = "insert into personel (AD,SOYAD,KULLANICIADI,PAROLA) values (@ad,@soyad,@kullaniciadi,@parola)";
                SqlCommand cmd = new SqlCommand(sorgu, cVeritabani.conn);
                cmd.Parameters.AddWithValue("@ad", tAd.Text);
                cmd.Parameters.AddWithValue("@soyad", tSoyad.Text);
                cmd.Parameters.AddWithValue("@kullaniciadi", kAdi.Text);
                cmd.Parameters.AddWithValue("@parola", kparola.Text);
                cmd.ExecuteNonQuery();
                cVeritabani.conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
