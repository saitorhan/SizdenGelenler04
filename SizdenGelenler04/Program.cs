using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SizdenGelenler04
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ayGunSayilari = new[] {31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
            string[] aylar = new[] {"Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran", "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık"};
            int girilecekAy, enKucukGun = 0, enBuyukGun = 0;
            string okunan;
            double[] sicaklikDegerleri;
            double temp;
            double toplam = 0, enKucuk = 0, enBuyuk = 0, ortalama;

            ayDegeriAlma:
            Console.WriteLine("Değeri Girilecek Ay Numarası Giriniz");
            okunan = Console.ReadLine();

            // string sayi dönüşüm işlemleri için https://youtu.be/IjuDU5AMTOI linkinden ilgili videomu izleyebilirsiniz. 
            if (!Int32.TryParse(okunan, out girilecekAy) || girilecekAy < 1 || girilecekAy > 12)
            {
                Console.WriteLine("Girilen ay numarası doğru formatta değil");
                goto ayDegeriAlma;
            }

            sicaklikDegerleri = new Double[ayGunSayilari[girilecekAy - 1]];

            for (int i = 0; i < ayGunSayilari[girilecekAy-1]; )
            {
                Console.WriteLine("{0} gününün sıcaklık değerini giriniz", i +1);
                okunan = Console.ReadLine();

                // string sayi dönüşüm işlemleri için https://youtu.be/IjuDU5AMTOI linkinden ilgili videomu izleyebilirsiniz. 
                if (!Double.TryParse(okunan, out temp))
                {
                    Console.WriteLine("Girilen sıcaklık değeri doğru formatta değil");
                    continue;
                }

                sicaklikDegerleri[i] = temp;
                toplam += temp;
                i++;

                if (temp < enKucuk)
                {
                    enKucuk = temp;
                    enKucukGun = i;
                }

                if (temp> enBuyuk)
                {
                    enBuyuk = temp;
                    enBuyukGun = i;
                }
            }

            ortalama = toplam / ayGunSayilari[girilecekAy - 1];
            Console.WriteLine("{0} Ayına ait\nOrtalama Sıcaklık: {1:F2}\nEn Düşük Sıcaklık {2}. Günde: {3:F2}\nEn Yüksek Sıcaklık {4}. Günde: {5:F2}", aylar[girilecekAy -1], ortalama, enKucukGun, enKucuk, enBuyukGun, enBuyuk);

            Console.ReadLine();
        }
    }
}
