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
    public partial class AnaSayfa : Form // Form adı
    {
        static public Label KullaniciAdiEtiketi = new Label(); 
        public AnaSayfa() // Constructor 
        {
            InitializeComponent();
        }

        private void AnaSayfa_Yüklendi(object sender, EventArgs e) // Event handler 
        {
            KullaniciAdiEtiketi = etiket2; // Label 
            if (!Program.KullaniciAdi.Equals("")) // Kullanıcı adı kontrolü
            {
                KullaniciAdiEtiketi.Visible = true;
                KullaniciAdiEtiketi.Text = Program.KullaniciAdi; // Kullanıcı adını göster
            }
            else
            {
                KullaniciAdiEtiketi.Visible = false;
            }
        }

        private void buton1_Click(object sender, EventArgs e) // Event handler 
        {
        }

        private void etiket1_Click(object sender, EventArgs e) // Event handler 
        {

        }

        private void buton2_Click(object sender, EventArgs e) // Event handler a
        {
            if (!Program.KullaniciEmail.Equals("")) // Kullanıcı email kontrolü
            {
                MessageBox.Show("Zaten Giriş Yaptınız"); // Kullanıcıya mesaj göster
            }
            else
            {
                // Kayıt ol sayfasına git
                new Kayit_Ol().Show(); // Form adı 
            }
        }

        private void buton5_Click(object sender, EventArgs e) // Event handler 
        {
            if (!Program.KullaniciEmail.Equals("")) // Kullanıcı email kontrolü
            {
                MessageBox.Show("Zaten Giriş Yaptınız"); // Kullanıcıya mesaj göster
            }
            else
            {
                // Giriş yap sayfasına git
                new Giris_Yap().Show(); // Form adı 
            }
        }

        private void buton3_Click(object sender, EventArgs e) // Event handler 
        {
            if (!Program.KullaniciEmail.Equals("")) // Kullanıcı email kontrolü
            {
                // Uçuş rezervasyonu sayfasına git
                new Rezervasyon().Show(); // Form 
            }
            else
            {
                MessageBox.Show("Lütfen Önce Giriş Yapınız"); // Kullanıcıya mesaj göster
            }
        }

        private void buton4_Click(object sender, EventArgs e) // Event 
        {

        }

        private void buton6_Click(object sender, EventArgs e) // Event handler 
        {
            if (!Program.KullaniciEmail.Equals("")) // Kullanıcı email kontrolü
            {
                // Uçuş arama sayfasına git
                new Uçuş_Ara().Show(); // Form adı 
            }
            else
            {
                MessageBox.Show("Lütfen Önce Giriş Yapınız"); // Kullanıcıya mesaj göster
            }
        }

        private void buton7_Click(object sender, EventArgs e) // Event handler 
        {
            if (!Program.KullaniciEmail.Equals("")) // Kullanıcı email kontrolü
            {
                // Profil sayfasına git
                new Profil().Show(); // Form 
            }
            else
            {
                MessageBox.Show("Lütfen Önce Giriş Yapınız"); // Kullanıcıya mesaj göster
            }
        }

        private void buton4_Click_1(object sender, EventArgs e) 
        {
            if (!Program.KullaniciEmail.Equals("")) // Kullanıcı email kontrolü
            {
                // Rezervasyon yönetimi sayfasına git
                new Rezervasyon_Yönet().Show(); // Form 
            }
            else
            {
                MessageBox.Show("Lütfen Önce Giriş Yapınız"); // Kullanıcıya mesaj göster
            }
        }

        private void resimKutu2_Click(object sender, EventArgs e) // Event handler 
        {
            this.Close(); // Formu kapat
        }

        private void resimKutu3_Click(object sender, EventArgs e) // Event handler 
        {
            if (!Program.KullaniciEmail.Equals("")) // Kullanıcı email kontrolü
            {
                // Uçuşlar rapor sayfasına git
                new UçuşlarRapor().Show(); // Form 
            }
            else
            {
                MessageBox.Show("Lütfen Önce Giriş Yapınız"); // Kullanıcıya mesaj göster
            }
        }

        private void etiket3_Click(object sender, EventArgs e) // Event handler 
        {

        }

        private void resimKutu4_Click(object sender, EventArgs e) // Event handler 
        {
            if (!Program.KullaniciEmail.Equals("")) // Kullanıcı email kontrolü
            {
                // Şehirler rapor sayfasına git
                new SehirlerRapor().Show(); // Form 
            }
            else
            {
                MessageBox.Show("Lütfen Önce Giriş Yapınız"); // Kullanıcıya mesaj göster
            }
        }
    }
}