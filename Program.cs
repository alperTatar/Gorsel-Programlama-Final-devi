using System; // Temel sistem işlevlerine erişim sağlar.
using System.Collections.Generic; // Genel koleksiyonlar için sınıfları içerir.
using System.Linq; // Veri sorgulama işlevleri için sınıfları içerir.
using System.Threading.Tasks; // Zaman uyumsuz görevler için sınıfları içerir.
using System.Windows.Forms; // Grafiksel kullanıcı arayüzü bileşenleri için sınıfları içerir.

// Uçuş rezervasyon sistemi için isim alanı tanımı.
namespace Uçuş_Rezervasyon_Sistemi
{
    // Program sınıfı statik olarak tanımlanmıştır, bu da onun nesnesinin oluşturulamayacağı anlamına gelir.
    static class Program
    {
        // Kullanıcı adını saklamak için genel bir değişken.
        public static string KullaniciAdi = "";
        // Kullanıcı e-postasını saklamak için genel bir değişken.
        public static string KullaniciEmail = "";
        // Kullanıcı şifresini saklamak için genel bir değişken.
        public static string KullaniciSifre = "";
        // Kullanıcıya gösterilecek genel uyarı mesajı.
        public static string MesajUyarisi = "lütfen işlemi tamamlamak için gerekli tüm verileri doldurun";
        // Raporlama sırasında yanlış veri varsa gösterilecek genel uyarı mesajı.
        public static string RaporMesajUyarisi = "Yanlış Veri Görüntüleniyor";
        // Veritabanı bağlantı dizesi, sabit bir değer olarak tanımlanmıştır ve değiştirilemez.
        public const string BaglantiDizesi = "veri kaynağı = orcl; kullanıcı id = scott; şifre = kaplan;";

        // Uygulamanın ana giriş noktası.
        [STAThread] // Tek iş parçacıklı apartman modelini belirtir.
        static void Main()
        {
            // Uygulamanın görsel stillerini etkinleştirir.
            Application.GörselStilleriEtkinleştir();
            // Uygulamanın metin gösterimini ayarlar.
            Application.UyumluMetinGösteriminiAyarla(false);
            // Ana form olarak 'AnaSayfa' sınıfının bir örneğini çalıştırır.
            Application.Run(new AnaSayfa());
        }
    }
}
