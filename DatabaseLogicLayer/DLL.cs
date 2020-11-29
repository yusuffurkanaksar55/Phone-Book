using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entities;

namespace DatabaseLogicLayer
{
    public class DLL
    {
        //Database baglanma, db işlemleri hep burada olacaktır.Db seviyesindeki kodların olduğu yerdir
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader reader;
        int returnValues;
        public DLL()
        {
            conn = new SqlConnection("data source=.; initial catalog=TelefonRehberi; Integrated Security=SSPI;");
        }
        public void BaglantıAyarla()
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
            else
            {
                conn.Close();
            }
        }

        public int SistemKontrol(Kullanici K)
        {
            try
            {
                cmd = new SqlCommand("select count(*) from Kullanici where KullaniciAdi=@KullaniciAdi and Sifre=@Sifre",conn);
                cmd.Parameters.Add("@KullaniciAdi", System.Data.SqlDbType.NVarChar).Value = K.KullaniciAdi;
                cmd.Parameters.Add("@Sifre", System.Data.SqlDbType.NVarChar).Value = K.Sifre;                
                BaglantıAyarla();
                returnValues = (int)cmd.ExecuteScalar();

            }
            catch (Exception)
            {
                                
            }
            finally
            {
                BaglantıAyarla();
            }
            return returnValues;
        }


        public int KayıtEkle(Rehber R)
        {
            try
            {
                cmd =new SqlCommand("insert into Rehber (ID,Isim,Soyisim,TelefonNumarasiI,TelefonNumarasiII,TelefonNumarasiIII,EmailAdres,WebAdres,Adres,Aciklama) values (@ID, @Isim, @Soyisim, @TelefonNumarasiI, @TelefonNumarasiII, @TelefonNumarasiIII, @EmailAdres, @WebAdres, @Adres, @Aciklama)",conn);
                cmd.Parameters.Add("@ID", System.Data.SqlDbType.UniqueIdentifier).Value = R.ID;
                cmd.Parameters.Add("@Isim", System.Data.SqlDbType.NVarChar).Value = R.Isim;
                cmd.Parameters.Add("@Soyisim", System.Data.SqlDbType.NVarChar).Value = R.Soyisim;
                cmd.Parameters.Add("@TelefonNumarasiI", System.Data.SqlDbType.NVarChar).Value = R.TelefonNumarasiI;
                cmd.Parameters.Add("@TelefonNumarasiII", System.Data.SqlDbType.NVarChar).Value = R.TelefonNumarasiII;
                cmd.Parameters.Add("@TelefonNumarasiIII", System.Data.SqlDbType.NVarChar).Value = R.TelefonNumarasiIII;
                cmd.Parameters.Add("@EmailAdres", System.Data.SqlDbType.NVarChar).Value = R.EmailAdres;
                cmd.Parameters.Add("@WebAdres", System.Data.SqlDbType.NVarChar).Value = R.WebAdres;
                cmd.Parameters.Add("@Adres", System.Data.SqlDbType.NVarChar).Value = R.Adres;
                cmd.Parameters.Add("@Aciklama", System.Data.SqlDbType.NVarChar).Value = R.Aciklama;
                BaglantıAyarla();
                returnValues=cmd.ExecuteNonQuery();
                
            }
            catch (Exception)
            {
                
            }
            finally
            {
                BaglantıAyarla();
            }
            return returnValues;

        }

        public int KayıtDüzenle(Rehber R)
        {
            try
            {
                cmd = new SqlCommand(@"Update Rehber Set Isim=@Isım,Soyisim=@Soyisim,TelefonNumarasiI=@TelefonNumarasiI,TelefonNumarasiII=@TelefonNumarasiII,TelefonNumarasiIII=@TelefonNumarasiIII,EmailAdres=@EmailAdres,WebAdres=@WebAdres,Adres=@Adres,Aciklama=@Aciklama where ID=@ID", conn);
                cmd.Parameters.Add("@ID", System.Data.SqlDbType.UniqueIdentifier).Value = R.ID;
                cmd.Parameters.Add("@Isim", System.Data.SqlDbType.NVarChar).Value = R.Isim;
                cmd.Parameters.Add("@Soyisim", System.Data.SqlDbType.NVarChar).Value = R.Soyisim;
                cmd.Parameters.Add("@TelefonNumarasiI", System.Data.SqlDbType.NVarChar).Value = R.TelefonNumarasiI;
                cmd.Parameters.Add("@TelefonNumarasiII", System.Data.SqlDbType.NVarChar).Value = R.TelefonNumarasiII;
                cmd.Parameters.Add("@TelefonNumarasiIII", System.Data.SqlDbType.NVarChar).Value = R.TelefonNumarasiIII;
                cmd.Parameters.Add("@EmailAdres", System.Data.SqlDbType.NVarChar).Value = R.EmailAdres;
                cmd.Parameters.Add("@WebAdres", System.Data.SqlDbType.NVarChar).Value = R.WebAdres;
                cmd.Parameters.Add("@Adres", System.Data.SqlDbType.NVarChar).Value = R.Adres;
                cmd.Parameters.Add("@Aciklama", System.Data.SqlDbType.NVarChar).Value = R.Aciklama;
                BaglantıAyarla();
                returnValues = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
               
            }
            finally
            {
                BaglantıAyarla();
            }
            return returnValues;


        }
        public int KayıtSil(Guid ID)
        {
            try
            {
                cmd = new SqlCommand(@"delete Rehber where ID=@ID", conn);
                cmd.Parameters.Add("@ID", System.Data.SqlDbType.UniqueIdentifier).Value =ID;                
                BaglantıAyarla();
                returnValues = cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {

            }
            finally
            {
                BaglantıAyarla();
            }
            return returnValues;
        }
        public SqlDataReader KayıtListe()
        {
            cmd = new SqlCommand("select *from Rehber", conn);
            BaglantıAyarla();
            return cmd.ExecuteReader();
        }

        public SqlDataReader KayıtListeID(Guid ID)
        {
            cmd = new SqlCommand("select *from Rehber where ID=@ID", conn);
            cmd.Parameters.Add("@ID", System.Data.SqlDbType.UniqueIdentifier).Value = ID;
            BaglantıAyarla();
            return cmd.ExecuteReader();
        }






    }
}
