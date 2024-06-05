//------------------------------------------------------------------------------
// <otomatik-üretilmiş>
//     Bu kod bir araç tarafından üretildi.
//     Çalışma Zamanı Sürümü:4.0.30319.42000
//
//     Bu dosyadaki değişiklikler yanlış davranışlara neden olabilir ve eğer
//     kod yeniden üretilirse kaybolacaktır.
// </otomatik-üretilmiş>
//------------------------------------------------------------------------------

// Uçuş Rezervasyon Sistemi isim alanı.
namespace Flight_Reservation_system
{
    using System; // Temel .NET sınıflarına erişim sağlar.
    using System.ComponentModel; // Bileşen modeli sınıflarını içerir.
    using CrystalDecisions.Shared; // Crystal Reports'un paylaşılan nesnelerine erişim sağlar.
    using CrystalDecisions.ReportSource; // Rapor kaynakları için sınıfları içerir.
    using CrystalDecisions.CrystalReports.Engine; // Crystal Reports rapor motoru sınıflarını içerir.

    // 'TownsCrystalReport2' adında bir rapor sınıfı tanımlanır.
    public class TownsCrystalReport2 : ReportClass
    {

        // Yapıcı metot.
        public TownsCrystalReport2()
        {
        }

        // Raporun kaynak adını döndürür.
        public override string ResourceName
        {
            get
            {
                return "TownsCrystalReport2.rpt";
            }
            set
            {
                // Hiçbir şey yapma
            }
        }

        // Yeni bir rapor üretecinin kullanılıp kullanılmadığını belirtir.
        public override bool NewGenerator
        {
            get
            {
                return true;
            }
            set
            {
                // Hiçbir şey yapma
            }
        }

        // Raporun tam kaynak adını döndürür.
        public override string FullResourceName
        {
            get
            {
                return "Flight_Reservation_system.TownsCrystalReport2.rpt";
            }
            set
            {
                // Hiçbir şey yapma
            }
        }

        // Raporun bölümlerine erişim sağlar.
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.CrystalReports.Engine.Section Section1
        {
            get
            {
                return this.ReportDefinition.Sections[0];
            }
        }

        // Diğer rapor bölümlerine erişim sağlar.
        // 'Section2', 'Section3', 'Section4', 'Section5' benzer şekilde tanımlanmıştır.

        // Rapor parametrelerine erişim sağlar.
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_Source_Place_parm
        {
            get
            {
                return this.DataDefinition.ParameterFields[0];
            }
        }

        // Diğer rapor parametrelerine erişim sağlar.
        // 'Parameter_Des_Place_pram' benzer şekilde tanımlanmıştır.
    }

    // 'CachedTownsCrystalReport2' adında bir önbelleğe alınmış rapor sınıfı tanımlanır.
    [System.Drawing.ToolboxBitmapAttribute(typeof(CrystalDecisions.Shared.ExportOptions), "report.bmp")]
    public class CachedTownsCrystalReport2 : Component, ICachedReport
    {

        // Yapıcı metot.
        public CachedTownsCrystalReport2()
        {
        }

        // Raporun önbelleğe alınıp alınamayacağını belirtir.
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public virtual bool IsCacheable
        {
            get
            {
                return true;
            }
            set
            {
                // 
            }
        }

        // Veritabanı giriş bilgilerinin paylaşılıp paylaşılmayacağını belirtir.
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public virtual bool ShareDBLogonInfo
        {
            get
            {
                return false;
            }
            set
            {
                // 
            }
        }

        // Önbelleğin zaman aşımı süresini belirtir.
        [Browsable(false)]
        [DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public virtual System.TimeSpan CacheTimeOut
        {
            get
            {
                return CachedReportConstants.DEFAULT_TIMEOUT;
            }
            set
            {
                // 
            }
        }

        // Rapor nesnesi oluşturur.
        public virtual CrystalDecisions.CrystalReports.Engine.ReportDocument CreateReport()
        {
            TownsCrystalReport2 rpt = new TownsCrystalReport2();
            rpt.Site = this.Site;
            return rpt;
        }

        // Özelleştirilmiş önbellek anahtarını döndürür.
        public virtual string GetCustomizedCacheKey(RequestContext request)
        {
            String key = null;
            // Aşağıdaki kod, ASP.NET Önbelleğinde rapor işlerini önbelleğe almak için varsayılan
            // önbellek anahtarını oluşturmak için kullanılan koddur.
            // İhtiyaçlarınıza göre bu kodu değiştirmekte özgürsünüz.
            // key == null döndürmek varsayılan önbellek anahtarının
            // oluşturulmasına neden olur.
            return key;
        }
    }
}
