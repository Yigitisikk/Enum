using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Enum
{
    internal class HesapMakinesi
    {
        Islem islem = null;
        DoubleInterface doubleIslem = null;
        IslemlerEnum islemTuru;
        int birinciSayi;
        int ikinciSayi;
        bool islemDoubleMi = false;

        public void Baslat()
        {
            islemTuru = IslemlerEnum.None;
            Console.WriteLine("Hesap Makinesi Çalışıyor");

            while(islemTuru != IslemlerEnum.Kapatma) 
            {
                Console.Clear();
                IslemSec();
                IslemOlustur(); 
                
                if(islem != null)
                {
                    var sonuc = IslemYap();
                    Console.WriteLine("Sonuç = {0}", sonuc);
                }
                if(doubleIslem != null)
                {
                    var sonuc = DoubleIslemYap();
                    Console.WriteLine("Sonuç = {0}", sonuc);
                }
                Console.ReadLine();
            }
        }

        int IslemYap()
        {
            Console.WriteLine("{0} işlemi yapılıyor.", islemTuru.ToString());

            birinciSayi = SayiAl(1);
            ikinciSayi = SayiAl(2);
            return islem.IslemYap(birinciSayi,ikinciSayi); 
        }

        double DoubleIslemYap()
        {
            Console.WriteLine("{0} işlemi yapılıyor.", islemTuru.ToString());

            birinciSayi = SayiAl(1);
            ikinciSayi = SayiAl(2);
            return islem.IslemYap(birinciSayi, ikinciSayi);
        }

        void IslemOlustur()
        {
            if (islemDoubleMi)
            {
                switch (islemTuru)
                {
                    case IslemlerEnum.Bolme:
                        doubleIslem = new Bolme();
                        break;
                    case IslemlerEnum.Kapatma:
                        islem = null;
                        Console.WriteLine("Hesap makinesi kapanıyor !!");
                        break;
                    default:
                        islem = null;
                        Console.WriteLine("İşlem bulunamadı !!");
                        break;
                }
            }
            else
            {
                switch (islemTuru)
                {
                    case IslemlerEnum.Toplama:
                        islem = new Toplama();
                        break;
                    case IslemlerEnum.Cikarma:
                        islem = new Cikarma();
                        break;
                    case IslemlerEnum.Carpma:
                        islem = new Carpma();
                        break;
                    case IslemlerEnum.Bolme:
                        islem = new Bolme();
                        break;
                    case IslemlerEnum.Kapatma:
                        islem = null;
                        Console.WriteLine("Hesap makinesi kapanıyor !!");
                        break;
                    default:
                        islem = null;
                        Console.WriteLine("İşlem bulunamadı !!");
                        break;
                }
            }  
        }

        void IslemSec()
        {
            Console.WriteLine("Ne işlem yapmak istersin  Toplama : 1, Çıkarma : 2, Çarpma : 3, Bölme : 4, Kapatmak için : 0");

            islemTuru = (IslemlerEnum)SayiAl();

            Console.WriteLine("Double olsun mu ? Evet : E , Hayır : H");
            var secim = Console.ReadLine();
            if(secim == "E")
            {
                islemDoubleMi= true;
            }
            else
            {
                islemDoubleMi = false;
            }
        }

        int SayiAl(int sira)
        {
            Console.WriteLine("{0}. sayıyı giriniz", sira);
            return SayiAl();
        }

        int SayiAl()
        {
            int girilenSayi = 0;
            var sayi = Console.ReadLine();
            if(!String.IsNullOrEmpty(sayi) && !IsAlpha(sayi)) 
            {
                girilenSayi = Convert.ToInt32(sayi);
            }
            else
            {
                Console.WriteLine("Lütfen geçerli bir sayı giriniz !!");
            }
            return girilenSayi;
        }

        bool IsAlpha(string input) 
        {
            return Regex.IsMatch(input, "^[a-zA-Z]+$");
        }
    }
}
