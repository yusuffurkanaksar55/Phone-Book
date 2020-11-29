using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DatabaseLogicLayer;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLogiclayer
{
    public class BLL
    {
        DatabaseLogicLayer.DLL dll;
        public BLL()
        {
            dll = new DLL();
        }
        public int KayıtDüzenle(Guid ID,string Isim, string Soyisim, string TelefonNumarasiI, string TelefonNumarasiII, string TelefonNumarasiIII, string EmailAdres, string WebAdres, string Adres, string Aciklama, string text)
        {
            if (ID!=Guid.Empty)
            {
                return dll.KayıtDüzenle(new Rehber()
                {
                    ID = ID,
                    Isim=Isim,
                    Soyisim=Soyisim,
                    EmailAdres=EmailAdres,
                    TelefonNumarasiI=TelefonNumarasiI,
                    TelefonNumarasiII=TelefonNumarasiII,
                    TelefonNumarasiIII=TelefonNumarasiIII,
                    WebAdres=WebAdres,
                    Adres=Adres,
                    Aciklama=Aciklama
                });
            }
            else
            {
                return -1;
            }
        }
        public int KayıtSil(Guid ID)
        {
            if (ID != Guid.Empty)
            {
                return dll.KayıtSil(ID);
            }
            else
            {
                return -1;
            }
        }
        public List<Rehber> KayıtListe()
        {
            List<Rehber> RehberListesi = new List<Rehber>();
            try
            {
                SqlDataReader reader = dll.KayıtListe();
                while (reader.Read())
                {
                    RehberListesi.Add(new Rehber()
                    {
                        ID = reader.IsDBNull(0) ? Guid.Empty : reader.GetGuid(0),
                        Isim=reader.IsDBNull(1)? string.Empty : reader.GetString(1),
                        Soyisim=reader.IsDBNull(2)?string.Empty : reader.GetString(2),
                        TelefonNumarasiI = reader.IsDBNull(3)?string.Empty : reader.GetString(3),
                        TelefonNumarasiII = reader.IsDBNull(4)?string.Empty : reader.GetString(4),
                        TelefonNumarasiIII = reader.IsDBNull(5)?string.Empty : reader.GetString(5),
                        EmailAdres=reader.IsDBNull(6)?string.Empty : reader.GetString(6),
                        WebAdres=reader.IsDBNull(7)?string.Empty : reader.GetString(7),
                        Adres=reader.IsDBNull(8)?string.Empty : reader.GetString(8),
                        Aciklama=reader.IsDBNull(9)?string.Empty : reader.GetString(9)
                    });
                        
                }
                reader.Close();
            }
            catch (Exception)
            {

            }
            finally
            {
                dll.BaglantıAyarla();   
            }
            return RehberListesi;
        }
        public Rehber KayıtListeID(Guid ID)
        {
            Rehber RehberKayıt = new Rehber();
            try
            {
                SqlDataReader reader = dll.KayıtListeID(ID);
                while (reader.Read())
                {
                    RehberKayıt=new Rehber()
                    {
                        ID = reader.IsDBNull(0) ? Guid.Empty : reader.GetGuid(0),
                        Isim = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                        Soyisim = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                        TelefonNumarasiI = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                        TelefonNumarasiII = reader.IsDBNull(4) ? string.Empty : reader.GetString(4),
                        TelefonNumarasiIII = reader.IsDBNull(5) ? string.Empty : reader.GetString(5),
                        EmailAdres = reader.IsDBNull(6) ? string.Empty : reader.GetString(6),
                        WebAdres = reader.IsDBNull(7) ? string.Empty : reader.GetString(7),
                        Adres = reader.IsDBNull(8) ? string.Empty : reader.GetString(8),
                        Aciklama = reader.IsDBNull(9) ? string.Empty : reader.GetString(9)
                    };

                }
                reader.Close();
            }
            catch (Exception)
            {

            }
            finally
            {
                dll.BaglantıAyarla();
            }
            return RehberKayıt;
        }




        public int SistemKontrol(string KullaniciAdi,string Sifre)
        {
            if(!string.IsNullOrEmpty(KullaniciAdi) && !string.IsNullOrEmpty(Sifre))
            {
                return dll.SistemKontrol(new Kullanici()
                {
                    KullaniciAdi=KullaniciAdi,
                    Sifre=Sifre
                });
            }
            else
            {
                return -1;
            }

        }


        public int KayıtEkle(string Isim,string Soyisim,string TelefonNumarasiI,string TelefonNumarasiII,string TelefonNumarasiIII,string EmailAdres,string WebAdres,string Adres,string Aciklama)
        {
            if(!string.IsNullOrEmpty(Isim) && !string.IsNullOrEmpty(Soyisim) && !string.IsNullOrEmpty(TelefonNumarasiI))
            {
                return dll.KayıtEkle(new Rehber()
                {
                    ID=Guid.NewGuid(),
                    Isim=Isim,
                    Soyisim=Soyisim,
                    TelefonNumarasiI=TelefonNumarasiI,
                    TelefonNumarasiII=TelefonNumarasiII,
                    TelefonNumarasiIII=TelefonNumarasiIII,
                    EmailAdres=EmailAdres,
                    WebAdres=WebAdres,
                    Adres=Adres,
                    Aciklama=Aciklama
                });




            }
            else
            {
                return -1;//eksik parametere hatası
            }

        }



    }
}
