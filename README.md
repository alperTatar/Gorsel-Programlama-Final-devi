```markdown
# Uçuş Rezervasyon Sistemi (FRMS)
ODP.Net ve C# Windows formları kullanılarak yapılmış Uçuş Rezervasyon Sistemi, Veritabanı Yönetimi ve Varlıklar Arasındaki İlişkiler üzerine bir uygulamadır.

# Açıklama
FRMS, müşterilerin sisteme kaydolmasına/giriş yapmasına ve mevcut uçuşları aramasına, belirlemesine ve (Kalkış yeri, Varış yeri, bilet sayısı) bilgilerini girerek uçuş rezervasyonu yapmasına olanak tanır.

FRMS Varlıkları (Customer, Airport, Flight, Seats) olarak bölünmüştür:
- **Customer** (Ad, E-posta, Şifre, Telefon Numarası, Adres, Pasaport Numarası, Kredi Kartı Numarası)
- **Airport** (Havaalanı Adı, Havaalanı Şehri, Havaalanı Numarası)
- **Flight** (Uçuş Numarası, Uçuş Tarihi, Kalkış Saati, Varış Saati, Kalkış Yeri, Varış Yeri)
- **Seat** (Koltuk Numarası, Koltuk Durumu, Koltuk Fiyatı, Koltuk Sayısı)

# Gereksinimler
1. Visual Studio Kurulumu
2. Visual Studio ile aynı sürümde Crystal Reports kurulumu
3. Herhangi bir Oracle Veritabanı

# Eklemeler
Bu proje, kullanıcı dostu bir arayüz ile uçuş rezervasyon işlemlerini kolaylaştırmayı hedefler. Kullanıcıların kayıt ve giriş işlemlerini güvenli hale getirmek için şifreleme yöntemleri kullanılacaktır. Ayrıca, uçuş ve koltuk bilgilerinin güncel ve doğru bir şekilde gösterilmesi için veritabanı ile gerçek zamanlı entegrasyon sağlanacaktır.
```