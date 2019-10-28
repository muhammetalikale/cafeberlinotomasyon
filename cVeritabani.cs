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
    class cVeritabani
    {
        public static SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-2F6LDTS;Initial Catalog=cafeberlin;Integrated Security=True"); //Veritabanı bağlantısı
        public static void baglantiKontrol() //Bağlantı kapalı ise açmak için
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    conn.Open();
                }
                catch
                {
                    MessageBox.Show("Veritabanı Bağlantısı Yapılamadı");
                    Application.Exit();
                }
            }
        }
        public static DataTable VeriGetir (string sql) //Tüm veri tabanı işlemleri için
        {
            cVeritabani.conn.Close();
            baglantiKontrol();
            DataTable dt = new DataTable();
            SqlDataAdapter adptr = new SqlDataAdapter(sql, conn);
            adptr.Fill(dt);

            return dt;
        }
    }
}
