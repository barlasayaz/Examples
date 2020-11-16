namespace DegerlendirmeSorulari
{
    using System;
    using System.Reflection;
    using System.Collection;

    class Program
    {
        static void Main(string[] args)
        {
            int müşteriNumarası = 15000000;

            CalistirmaMotoru.KomutCalistir("MuhasebeModulu", "MaaşYatır", new object[] { müşteriNumarası }, 0);

            CalistirmaMotoru.KomutCalistir("MuhasebeModulu", "YıllıkÜcretTahsilEt", new object[] { müşteriNumarası }, 5);

            CalistirmaMotoru.BekleyenİslemleriGerceklestir();
        }
    }

    public class CalistirmaMotoru
    {

        public static object[] KomutCalistir(BekleyenIslemler bekleyenIslem)
        {
            if(bekleyenIslem.ertelenecekSure == 0)
            {
                CalistirmaMotoru.KomutCalistir(bekleyenIslem);

            }
            else
            {
                VeritabaniIslemleri.BekleyenIslemlerTablosunaYaz(bekleyenIslem.ModulSinifAdi,bekleyenIslem.MethodAdi,bekleyenIslem.Inputs);
            }
        }

        public static object[] KomutCalistir(string modulSinifAdi,string methodAdi,object[] inputs)
        {
                MuhasebeModulu muhasebe = new MuhasebeModulu();
                Type type = muhasebe.GetType();

                MethodInfo methodInfo = type.GetMethod(methodAdi, BindingFlags.NonPublic | BindingFlags.Instance);
                object classInstance = Activator.CreateInstance(type, null);

                if (methodInfo != null && classInstance != null)
                {
                    object result = methodInfo.Invoke(classInstance, inputs);
                }

        }

        public static void BekleyenİslemleriGerceklestir()
        {
            while(true)
            {
              System.Threading.Thread.Sleep(1000000);
              List<BekleyenIslemler> bekleyenIslemler =  CalistirilacakIslemVarMi();
              for (int i = 0; i < bekleyenIslemler.Count; i++)
              {
                  KomutCalistir(bekleyenIslemler[i].ModulSinifAdi, bekleyenIslemler[i].MethodAdi, bekleyenIslemler[i].Inputs);
              }
            }
        }
    }

    public class MuhasebeModulu
    {
        private void MaasYatir(int müşteriNumarası)
        {
            // gerekli işlemler gerçekleştirilir.
            Console.WriteLine(string.Format("{0} numaralı müşterinin maaşı yatırıldı.", müşteriNumarası));
        }

        private void YıllıkUcretTahsilEt(int müşteriNumarası)
        {
            // gerekli işlemler gerçekleştirilir.
            Console.WriteLine("{0} numaralı müşteriden yıllık kart ücreti tahsil edildi.", müşteriNumarası);
        }

        private void OtomatikOdemeleriGerceklestir(int müşteriNumarası)
        {
            // gerekli işlemler gerçekleştirilir.
            Console.WriteLine("{0} numaralı müşterinin otomatik ödemeleri gerçekleştirildi.", müşteriNumarası);
        }
    }

    public class VeritabaniIslemleri
    {

        public static void BekleyenIslemlerTablosunaYaz(string modulSinifAdi, string methodAdi, object[] inputs, int ertelenecekSure) {}

        public static list<BekleyenIslemler> CalistirilacakIslemVarMi() {}
    }

    public class BekleyenIslemler
    {
        string ModulSinifAdi {get; set;} 
        string MethodAdi  {get; set;} 
        object[] Inputs {get; set;}  
        int ErtelenecekSure {get; set;}  
    }
}


