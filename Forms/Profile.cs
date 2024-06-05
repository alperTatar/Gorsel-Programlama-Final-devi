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

```csharp
namespace Uçuş_Rezervasyon_Sistemi // Namespace 
{
    public partial class Profil : Form // Sınıf 
    {
        string veritabaniYolu; // Veritabanı bağlantı dizesi
        OracleConnection baglanti; // Oracle veritabanı bağlantısı
        string eposta; // Kullanıcı e-posta adresi
        string adi; // Kullanıcı adı
        string soyadi; // Kullanıcı soyadı
        string adres; // Kullanıcı adresi
        string pasaportNo; // Kullanıcı pasaport numarası
        string krediKartNo; // Kullanıcı kredi kartı numarası

        public Profil()
        {
            InitializeComponent();
        }

        private void Profil_Yüklenince(object sender, EventArgs e) // Form yüklendiğinde çalışır
        {
            veritabaniYolu = Program.ConnStr;
            baglanti = new OracleConnection(veritabaniYolu);
            baglanti.Open();
            eposta = Program.UserEmail;
            OracleCommand komut = new OracleCommand();
            komut.Connection = baglanti;
            komut.CommandText = "PRO_GET_USER_DATA";
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.Add("email_", eposta);

            // Kullanıcı verilerini almak için parametreler
            OracleParameter adiParametre = new OracleParameter("FIRST_NAME", OracleDbType.Varchar2, 50);
            adiParametre.Direction = ParameterDirection.Output;
            komut.Parameters.Add(adiParametre);

            OracleParameter soyadiParametre = new OracleParameter("LAST_NAME", OracleDbType.Varchar2, 50);
            soyadiParametre.Direction = ParameterDirection.Output;
            komut.Parameters.Add(soyadiParametre);

            OracleParameter adresParametre = new OracleParameter("ADDRESS", OracleDbType.Varchar2, 50);
            adresParametre.Direction = ParameterDirection.Output;
            komut.Parameters.Add(adresParametre);

            OracleParameter pasaportNoParametre = new OracleParameter("PASSPORT_NUM", OracleDbType.Int32, 2000);
            pasaportNoParametre.Direction = ParameterDirection.Output;
            komut.Parameters.Add(pasaportNoParametre);

            OracleParameter krediKartNoParametre = new OracleParameter("CREDIT_NUM", OracleDbType.Varchar2, 20);
            krediKartNoParametre.Direction = ParameterDirection.Output;
            komut.Parameters.Add(krediKartNoParametre);

            try
            {
                int sonuc = komut.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri alınamadı");
            }

            adi = adiParametre.Value.ToString();
            soyadi = soyadiParametre.Value.ToString();
            adres = adresParametre.Value.ToString();
            pasaportNo = pasaportNoParametre.Value.ToString();
            krediKartNo = krediKartNoParametre.Value.ToString();

            // Formdaki metin kutularına verileri doldurur
            textBox1.Text = adiParametre.Value.ToString();
            textBox2.Text = soyadiParametre.Value.ToString();
            label5.Text = textBox1.Text + " " + textBox2.Text;
            textBox3.Text = eposta;
            textBox4.Text = adresParametre.Value.ToString();
            textBox5.Text = pasaportNoParametre.Value.ToString();
            textBox6.Text = krediKartNoParametre.Value.ToString();

            OracleCommand komut2 = new OracleCommand();
            komut2.Connection = baglanti;
            komut2.CommandText = "PRO_GET_USER_PHONES";
            komut2.CommandType = CommandType.StoredProcedure;
            komut2.Parameters.Add("email", eposta);
            komut2.Parameters.Add("phones", OracleDbType.RefCursor, ParameterDirection.Output);
            try
            {
                OracleDataReader okuyucu = komut2.ExecuteReader();

                okuyucu.Read();
                label10.Text = okuyucu[0].ToString();
                okuyucu.Read();
                label11.Text = okuyucu[0].ToString();

                okuyucu.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Telefon verileri alınamadı");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) // Kullanıcı bilgilerini güncellemek için
        {
            try
            {
                OracleCommand komut = new OracleCommand();
                komut.Connection = baglanti;

                komut.CommandText = "PRO_UPDATE_CUSTOMER_DATA";
                komut.CommandType = CommandType.StoredProcedure;
                komut.Parameters.Add("email", eposta);
                komut.Parameters.Add("first", textBox1.Text);
                komut.Parameters.Add("last", textBox2.Text);
                komut.Parameters.Add("address", textBox4.Text);
                komut.Parameters.Add("passport", int.Parse(textBox5.Text));
                komut.Parameters.Add("credit", int.Parse(textBox6.Text));

                int sonuc = komut.ExecuteNonQuery();
                MessageBox.Show("Veriler başarıyla güncellendi");

                label5.Text = textBox1.Text.ToString() + " " + textBox2.Text.ToString();
                adi = textBox1.Text;
                soyadi = textBox2.Text;
                eposta = textBox3.Text;
                adres = textBox4.Text;
                pasaportNo = textBox5.Text;
                krediKartNo = textBox6.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme başarısız");
            }
        }

        private void button2_Click(object sender, EventArgs e) // Kullanıcı bilgilerini sıfırlamak için
        {
            textBox1.Text = adi;
            textBox2.Text = soyadi;
            textBox3.Text = eposta;
            textBox4.Text = adres;
            textBox5.Text = pasaportNo;
            textBox6.Text = krediKartNo;
        }

        private void pictureBox2_Click(object sender, EventArgs e) // Formu kapatmak için
        {
            this.Close();
        }
    }
}
```
