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
        public static bool PersonelEkle(TextBox kAdi, TextBox kParola, TextBox tAd, TextBox tSoyad)
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
                cmd.Parameters.AddWithValue("@parola", kParola.Text);
                cmd.ExecuteNonQuery();
                cVeritabani.conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
       
        public static bool PersonelDuzenle(TextBox kAdi, TextBox kParola, TextBox tAd, TextBox tSoyad, object cbkAdi)
        {
            cVeritabani.conn.Close();
            cVeritabani.baglantiKontrol();

            if (kAdi.Text != "")
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("update personel set KULLANICIADI=@KULLANICIADI where KULLANICIADI=@kullaniciadi", cVeritabani.conn);
                    cmd.Parameters.AddWithValue("@kullaniciadi", cbkAdi);
                    cmd.Parameters.AddWithValue("@KULLANICIADI", kAdi.Text);
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    return false;
                }
            }

            if(kParola.Text != "")
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("update personel set PAROLA=@PAROLA where KULLANICIADI=@kullaniciadi", cVeritabani.conn);
                    cmd.Parameters.AddWithValue("@kullaniciadi", cbkAdi);
                    cmd.Parameters.AddWithValue("@PAROLA", kParola.Text);
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    return false;
                }
            }

            if (tAd.Text != "")
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("update personel set AD=@AD where KULLANICIADI=@kullaniciadi", cVeritabani.conn);
                    cmd.Parameters.AddWithValue("@kullaniciadi", cbkAdi);
                    cmd.Parameters.AddWithValue("@AD", tAd.Text);
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    return false;
                }
            }
            if (tSoyad.Text != "")
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("update personel set SOYAD=@SOYAD where KULLANICIADI=@kullaniciadi", cVeritabani.conn);
                    cmd.Parameters.AddWithValue("@kullaniciadi", cbkAdi);
                    cmd.Parameters.AddWithValue("@SOYAD", tSoyad.Text);
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    return false;
                }
            }

            return true;
        }

        public static bool PersonelSil(ComboBox kAdi)
        {
            cVeritabani.conn.Close();
            cVeritabani.baglantiKontrol();
            try
            {
                SqlCommand cmd = new SqlCommand("delete from personel where KULLANICIADI=@KULLANICIADI", cVeritabani.conn);
                cmd.Parameters.AddWithValue("@KULLANICIADI", kAdi.SelectedItem);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
