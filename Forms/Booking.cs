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

namespace Uçuş_Rezervasyon_Sistemi
{
    public partial class Rezervasyon : Form
    {
        string baglantiStr = Program.BaglantiStr;
        OracleConnection baglanti;
        public Rezervasyon()
        {
            InitializeComponent();
        }

        private void Rezervasyon_Yükle(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void pictureBox2_Tıkla(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label6_Tıkla(object sender, EventArgs e)
        {

        }

        private void button1_Tıkla(object sender, EventArgs e)
        {
            // kullanıcı bilgilerini kaydet (adres ve kredi kartı)
            // rezervasyon verilerini kullanıcıya kaydet 
            // mail tekrarlanabilir 
            // uçuş numarası tekrarlanırsa sadece diğer verileri kontrol edip eskiye ekleme yap
            // rezervasyon sonrası uçuş ve havalimanı verilerini göster 
            if (ucus_no.Text.Equals("") || bilet_sayisi.Text.Equals("") || adres.Text.Equals("") || kredi.Text.Equals("") || pasaport_no.Text.Equals(""))
            {
                MessageBox.Show(Program.UyariMesaji);
            }
            else
            {
                try
                {
                    baglanti = new OracleConnection(baglantiStr);
                    baglanti.Open();

                    OracleCommand cmd2 = new OracleCommand();
                    cmd2.Connection = baglanti;
                    cmd2.CommandText = "select FIYAT, KOLTUK_SAYISI from PRO_KOLTUK where UCUŞ_KOLTUK = :ukoltuk";
                    cmd2.CommandType = CommandType.Text;
                    cmd2.Parameters.Add("ukoltuk", int.Parse(ucus_no.Text));
                    string fiyatMesaji = "KOLTUK FIYATI : ", fiyat = "", koltukSayisi = "";
                    OracleDataReader dr = cmd2.ExecuteReader();
                    while (dr.Read())
                    {
                        fiyat = dr[0].ToString();
                        koltukSayisi = dr[1].ToString();
                    }

                    int toplamFiyat = int.Parse(fiyat);
                    toplamFiyat *= int.Parse(bilet_sayisi.Text);
                    fiyatMesaji = toplamFiyat.ToString();

                    /*  (kullanıcı adı)        
                     * uçuşunuz (havalimanından (kalkış) / havalimanına (varış)) 
                     * (tarih) tarihinde (saat) 
                     * uçağınız (tarih) tarihinde (saat) inecek
                     * toplam fiyat " "
                      * (koltuk fiyatı * bilet sayısı)
                     */
                    //----------------------------------
                    OracleCommand cmd3 = new OracleCommand();
                    cmd3.Connection = baglanti;
                    cmd3.CommandText = "select * from PRO_UCUS u, PRO_HAVALIMANI h where ((UCUŞ_NO =:ukoltuk) and (u.havalimani_kalkis = h.havalimani_no and u.havalimani_varis = h.sehir) )";
                    cmd3.CommandType = CommandType.Text;
                    cmd3.Parameters.Add("ukoltuk", int.Parse(ucus_no.Text));
                    string[] veriler = new string[20];
                    dr = cmd3.ExecuteReader();
                    while (dr.Read())
                    {
                        for (int i = 0; i < 13; i++)
                        {
                            veriler[i] = dr[i].ToString();
                        }
                    }

                    OracleCommand cmd4 = new OracleCommand();
                    cmd4.Connection = baglanti;
                    cmd4.CommandText = "select h.* from PRO_UCUS u, PRO_HAVALIMANI h where ((UCUŞ_NO =:ukoltuk) and (u.havalimani_kalkis = h.havalimani_no and u.havalimani_varis = h.sehir) )";
                    cmd4.CommandType = CommandType.Text;
                    cmd4.Parameters.Add("ukoltuk", int.Parse(ucus_no.Text));

                    dr = cmd4.ExecuteReader();
                    while (dr.Read())
                    {
                        veriler[13] = dr["SEHIR"].ToString();
                        veriler[14] = dr["HAVALIMANI_NO"].ToString();
                        veriler[15] = dr["ADI"].ToString();
                    }
                    String mesaj = "Uçuşunuz " + veriler[12] + "/" + veriler[10] + " den " + veriler[15] + "/" + veriler[13] + " ya\n" + veriler[1] + " tarihinde ve saatte\n iniş saati: " + veriler[2] + "\nBilet sayısı: " + bilet_sayisi.Text + "\nToplam Fiyat: " + fiyatMesaji + " TL";
                    string baslik = "Onay";
                    MessageBoxButtons butonlar = MessageBoxButtons.OKCancel;
                    DialogResult sonuc = MessageBox.Show(mesaj, baslik, butonlar);
                    if (sonuc == DialogResult.OK)
                    {
                        int kalanKoltukSayisi = int.Parse(koltukSayisi) - int.Parse(bilet_sayisi.Text);
                        if (kalanKoltukSayisi < 0)
                        {
                            MessageBox.Show("Yeterli bilet yok\nBilet sayısı rezervasyon için yetersiz");
                            return;
                        }
                        else
                        {
                            OracleCommand command = new OracleCommand();
                            command.Connection = baglanti;
                            command.CommandText = "update PRO_MUSTERI set PASAPORT_NO = :pasaport, KREDI_NO =:kredi, ADRES=:adres where EPOSTA= :eposta";
                            command.CommandType = CommandType.Text;
                            command.Parameters.Add("pasaport", pasaport_no.Text);
                            command.Parameters.Add("adres", adres.Text);
                            command.Parameters.Add("kredi", kredi.Text);
                            command.Parameters.Add("eposta", Program.KullaniciEposta);
                            int ret = command.ExecuteNonQuery();
                            if (ret == -1) MessageBox.Show("Hata: Güncelleme yapılamadı");

                            OracleCommand commandKontrol = new OracleCommand();
                            commandKontrol.Connection = baglanti;
                            commandKontrol.CommandText = "select UCUŞ_NO_FSSN, BILET_SAYISI, EPOSTA from PRO_MUSTERI_REZERVASYON where UCUŞ_NO_FSSN=:ukoltuk and EPOSTA=:eposta";
                            commandKontrol.CommandType = CommandType.Text;
                            commandKontrol.Parameters.Add("ukoltuk", int.Parse(ucus_no.Text));
                            commandKontrol.Parameters.Add("eposta", Program.KullaniciEposta);
                            dr = commandKontrol.ExecuteReader();
                            string rezervasyonKontrol = "", biletSayisiKontrol = "", epostaKontrol = "";
                            while (dr.Read())
                            {
                                rezervasyonKontrol = dr[0].ToString();
                                biletSayisiKontrol = dr[1].ToString();
                                epostaKontrol = dr[2].ToString();
                            }

                            if (rezervasyonKontrol == "")
                            {
                                OracleCommand cmd = new OracleCommand();
                                cmd.Connection = baglanti;
                                cmd.CommandText = "insert into PRO_MUSTERI_REZERVASYON (ucus_no_fssn, eposta, bilet_sayisi) values( :ukoltuk, :eposta, :bilet_sayisi)";
                                cmd.CommandType = CommandType.Text;
                                cmd.Parameters.Add("ukoltuk", int.Parse(ucus_no.Text));
                                cmd.Parameters.Add("eposta", Program.KullaniciEposta);
                                cmd.Parameters.Add("bilet_sayisi", int.Parse(bilet_sayisi.Text));
                                ret = cmd.ExecuteNonQuery();
                                if (ret == -1) MessageBox.Show("Hata: Rezervasyon yapılamadı");
                            }
                            else
                            {
                                int toplamBilet = int.Parse(bilet_sayisi.Text) + int.Parse(biletSayisiKontrol);
                                OracleCommand cmd = new OracleCommand();
                                cmd.Connection = baglanti;
                                cmd.CommandText = "update PRO_MUSTERI_REZERVASYON set BILET_SAYISI = :bilet_sayisi where  UCUŞ_NO_FSSN = :ukoltuk and EPOSTA=:eposta";
                                cmd.CommandType = CommandType.Text;
                                cmd.Parameters.Add("bilet_sayisi", toplamBilet);
                                cmd.Parameters.Add("ukoltuk", int.Parse(ucus_no.Text));
                                cmd.Parameters.Add("eposta", Program.KullaniciEposta);
                                ret = cmd.ExecuteNonQuery();
                                if (ret == -1) MessageBox.Show("Hata: Rezervasyon güncellenemedi");
                            }
                            if (kalanKoltukSayisi != 0)
                            {
                                OracleCommand command2 = new OracleCommand();
                                command2.Connection = baglanti;
                                command2.CommandText = "update PRO_KOLTUK set KOLTUK_SAYISI = :kalan where UCUŞ_KOLTUK= :ukoltuk";
                                command2.CommandType = CommandType.Text;
                                command2.Parameters.Add("kalan", kalanKoltukSayisi.ToString());
                                command2.Parameters.Add("ukoltuk", ucus_no.Text);

                                ret = command2.ExecuteNonQuery();
                                if (ret == -1) MessageBox.Show("Hata: Koltuk sayısı güncellenemedi");
                            }
                            else
                            {
                                OracleCommand command2 = new OracleCommand();
                                command2.Connection = baglanti;
                                command2.CommandText = "update PRO_KOLTUK set KOLTUK_SAYISI = :kalan, DURUM='y' where UCUŞ_KOLTUK= :ukoltuk";
                                command2.CommandType = CommandType.Text;
                                command2.Parameters.Add("kalan", kalanKoltukSayisi.ToString());
                                command2.Parameters.Add("ukoltuk", ucus_no.Text);

                                ret = command2.ExecuteNonQuery();
                                if (ret == -1) MessageBox.Show("Hata: Koltuk durumu güncellenemedi");
                            }
                            MessageBox.Show("Rezervasyon Tamamlandı");
                        }
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("İşlem İptal Edildi");
                        this.Close();
                    }
                    //-------------------------------------
                }
                catch
                {
                    MessageBox.Show("Bu Uçuş Şu Anda Mevcut Değil\nLütfen mevcut uçuşları arayın");
                }
            }
        }

        private void timer1_Tikla(object sender, EventArgs e)
        {
            DateTime zaman = DateTime.Now;
            this.label7.Text = zaman.ToString();
        }

        private void label9_Tikla(object sender, EventArgs e)
        {

        }

        private void label10_Tikla(object sender, EventArgs e)
        {

        }

        private void button2_Tikla(object sender, EventArgs e)
        {
            new Uçuş_Ara().Show();
        }

        private void button1_Tikla_1(object sender, EventArgs e)
        {
            ucus_no.Text = "";
            bilet_sayisi.Text = "";
            adres.Text = "";
            kredi.Text = "";
            pasaport_no.Text = "";
        }
    }
}
