using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace Uçuş_Rezervasyon_Sistemi // Namespace 
{
    public partial class Rezervasyon_Yonetimi : Form // Form a
    {
        string baglantiDizesi = Program.BaglantiDizesi; // Veritabanı bağlantı dizesi
        string komutDizesi = ""; // SQL komut dizesi
        OracleDataAdapter adaptör; // Veritabanı veri adaptörü
        OracleCommandBuilder komutOlusturucu; // SQL komut oluşturucu
        DataSet veriKumesi; // Veri kümesi
        int sonUcusSayisi = 0, ucusNumarasi = 0; // Uçuş numaraları

        public Rezervasyon_Yonetimi() // Yapıcı metot
        {
            InitializeComponent();
        }

        private void Rezervasyon_Yonetimi_Yuklendi(object sender, EventArgs e) // Form yüklendiğinde
        {
            try
            {
                komutDizesi = "select * from pro_cust_book_flight where email_cssn = '" + Program.KullaniciEmail + "'";
                adaptör = new OracleDataAdapter(komutDizesi, baglantiDizesi);
                veriKumesi = new DataSet();
                adaptör.Fill(veriKumesi);
                dataGridView1.DataSource = veriKumesi.Tables[0]; // Veritabanı verilerini DataGridView'a yükler

                dataGridView1.Columns[0].HeaderText = "Kullanıcı Email";
                dataGridView1.Columns[1].HeaderText = "Uçuş Numarası";
                dataGridView1.Columns[2].HeaderText = "Uçuş Sayısı";
                dataGridView1.Columns[0].ReadOnly = true; // Kullanıcı Email kolonunu sadece okunabilir yapar
                dataGridView1.Columns[1].ReadOnly = true; // Uçuş Numarası kolonunu sadece okunabilir yapar
            }
            catch
            {
                MessageBox.Show("Veri Gösteriminde Hata"); // Hata mesajı gösterir
            }
        }

        private void butonGuncelle_Click(object sender, EventArgs e) // Güncelleme butonuna tıklanıldığında
        {
            try
            {
                int öncekiUcusSayisi = 0, yeniUcusSayisi = 0;

                DataGridViewRow satir = dataGridView1.SelectedRows[0];
                ucusNumarasi = Convert.ToInt32(satir.Cells[1].Value.ToString());
                öncekiUcusSayisi = get_UcusSayisi_Kitaptan();
                yeniUcusSayisi = Convert.ToInt32(satir.Cells[2].Value.ToString());
                sonUcusSayisi = öncekiUcusSayisi - yeniUcusSayisi;

                if (yeniUcusSayisi <= 0) // 0 bilet durumu
                {
                    MessageBox.Show("Uçuş Sayısı 0'dan büyük olmalıdır\nYoksa rezervasyonu silin");
                    return;
                }
                if (get_KoltukSayisi_Koltuktan() + sonUcusSayisi < 0) // Bilet sayısından fazla olma durumu
                {
                    MessageBox.Show("Biletler tükenmiş\nBilet sayınızdan az bilet var");
                    return;
                }

                komutOlusturucu = new OracleCommandBuilder(adaptör);
                adaptör.Update(veriKumesi.Tables[0]); // Veritabanında güncelleme yapar

                koltukSayisini_Ayarla();
                MessageBox.Show("Rezervasyon Başarıyla Güncellendi"); // Başarı mesajı gösterir
            }
            catch
            {
                MessageBox.Show("Lütfen Güncellenen Satırı Seçin"); // Hata mesajı gösterir
            }
        }

        private void butonSil_Click(object sender, EventArgs e) // Silme butonuna tıklanıldığında
        {
            try
            {
                DataGridViewRow satir = this.dataGridView1.SelectedRows[0];
                ucusNumarasi = Convert.ToInt32(satir.Cells[1].Value.ToString());
                sonUcusSayisi = Convert.ToInt32(satir.Cells[2].Value.ToString());

                int satirIndeksi = dataGridView1.CurrentCell.RowIndex;
                veriKumesi.Tables[0].Rows[satirIndeksi].Delete(); // Seçilen satırı siler

                komutOlusturucu = new OracleCommandBuilder(adaptör);
                adaptör.Update(veriKumesi.Tables[0]); // Veritabanında güncelleme yapar

                dataGridView1.Refresh();
                koltukSayisini_Ayarla();
                MessageBox.Show("Rezervasyon Başarıyla Silindi"); // Başarı mesajı gösterir
            }
            catch
            {
                MessageBox.Show("Lütfen Satırı Seçin"); // Hata mesajı gösterir
            }
        }

        private void koltukSayisini_Ayarla() // Koltuk sayısını ayarlar
        {
            int koltukSayisi = get_KoltukSayisi_Koltuktan();

            koltukSayisi += sonUcusSayisi;

            OracleConnection baglanti = new OracleConnection(baglantiDizesi);
            baglanti.Open();
            OracleCommand komut = new OracleCommand();
            komut.Connection = baglanti;

            komut.CommandText = "Update PRO_SEAT set NUM_OF_SEATS = " + koltukSayisi + " Where F_SEAT= '" + ucusNumarasi + "'";
            komut.CommandType = CommandType.Text;
            int sonuc = komut.ExecuteNonQuery();
            if (sonuc == -1) MessageBox.Show("Geçersiz Problem1");

            // Durumu Yönet
            if (koltukSayisi == 0)
            {
                OracleConnection baglanti1 = new OracleConnection(baglantiDizesi);
                baglanti1.Open();
                OracleCommand komut1 = new OracleCommand();
                komut1.Connection = baglanti1;

                komut1.CommandText = "Update PRO_SEAT set STATUS = 'y' Where F_SEAT= '" + ucusNumarasi + "'";
                komut1.CommandType = CommandType.Text;
                sonuc = komut1.ExecuteNonQuery();
                if (sonuc == -1) MessageBox.Show("Geçersiz Problem1");
            }
            else
            {
                OracleConnection baglanti2 = new OracleConnection(baglantiDizesi);
                baglanti2.Open();
                OracleCommand komut2 = new OracleCommand();
                komut2.Connection = baglanti2;

                komut2.CommandText = "Update PRO_SEAT set STATUS = 'n' Where F_SEAT= '" + ucusNumarasi + "'";
                komut2.CommandType = CommandType.Text;
                sonuc = komut2.ExecuteNonQuery();
                if (sonuc == -1) MessageBox.Show("Geçersiz Problem1");
            }
        }

        private void resimKutusuKapat_Click(object sender, EventArgs e) // Resim kutusuna tıklanıldığında
        {
            this.Close(); // Formu kapatır
        }

        private int get_UcusSayisi_Kitaptan() // Rezervasyon tablosundan uçuş sayısını alır
        {
            int ucusSayisi = 0;
            OracleConnection baglanti = new OracleConnection(baglantiDizesi);
            baglanti.Open();
            OracleCommand komut = new OracleCommand();
            komut.Connection = baglanti;

            komut.CommandText = "SELECT NUM_OF_FLIGHTS from PRO_CUST_BOOK_FLIGHT WHERE EMAIL_CSSN= '" + Program.KullaniciEmail + "' and FLIGHT_NUM_FSSN = '" + ucusNumarasi + "'";
            komut.CommandType = CommandType.Text;
            OracleDataReader veriOkuyucu = komut.ExecuteReader();

            while (veriOkuyucu.Read())
            {
                ucusSayisi = Convert.ToInt32(veriOkuyucu[0]);
            }
            return ucusSayisi;
        }

        private int get_KoltukSayisi_Koltuktan() // Koltuk tablosundan koltuk sayısını alır
        {
            int koltukSayisi = 0;

            OracleConnection baglanti = new OracleConnection(baglantiDizesi);
            baglanti.Open();
            OracleCommand komut = new OracleCommand();
            komut.Connection = baglanti;

            komut.CommandText = "SELECT NUM_OF_SEATS from PRO_SEAT WHERE F_SEAT= '" + ucusNumarasi + "'";
            komut.CommandType = CommandType.Text;
            OracleDataReader veriOkuyucu = komut.ExecuteReader();

            while (veriOkuyucu.Read())
            {
                koltukSayisi = Convert.ToInt32(veriOkuyucu[0]);
            }

            return koltukSayisi;
        }
    }
}