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
namespace Flight_Reservation_system
{
    public partial class Sign_In : Form
    {
        string conStr = Program.ConnStr; // Veritabanı bağlantı dizesi
        OracleConnection con; // Oracle veritabanı bağlantısı

        public Sign_In()
        {
            InitializeComponent();
        }

        // Form yüklendiğinde gerçekleşen olay
        private void Sign_In_Load(object sender, EventArgs e)
        {

        }

        // Giriş butonuna tıklandığında gerçekleşen olay
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("E-Mail") || textBox2.Text.Equals("PASSWORD") || textBox1.Text.Equals("") || textBox2.Text.Equals(""))
            {
                MessageBox.Show(Program.MessageAlert); // Eksik giriş bilgisi uyarısı
            }
            else
            {
                con = new OracleConnection(conStr); // Veritabanı bağlantısını oluştur
                con.Open(); // Bağlantıyı aç
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;

                cmd.CommandText = "SELECT EMAIL from PRO_CUSTOMER WHERE EMAIL= :email and PASSWORD= :password"; // Kullanıcı giriş bilgilerini kontrol et
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("email", textBox1.Text);
                cmd.Parameters.Add("password", textBox2.Text);
                OracleDataReader dr = cmd.ExecuteReader();
                string x = "";
                while (dr.Read())
                {
                    x = dr[0].ToString();
                }

                if (x.Equals(""))
                {
                    MessageBox.Show("Invalid Email or password"); // Geçersiz e-posta veya şifre uyarısı
                }
                else
                {
                    Program.UserName = gat_userName(); // Kullanıcı adını al
                    Program.UserEmail = textBox1.Text; // Kullanıcı e-posta adresini sakla
                    Program.UserPassword = textBox2.Text; // Kullanıcı şifresini sakla
                    MessageBox.Show("Welcome Back\nLogin Successfully"); // Başarılı giriş mesajı

                    Home.UserNameLabel.Text = Program.UserName; // Ana formda kullanıcı adını göster
                    Home.UserNameLabel.Visible = true;
                    this.Close(); // Giriş formunu kapat
                }
            }
        }

        // Kayıt olma etiketine tıklanıldığında gerçekleşen olay
        private void label3_Click(object sender, EventArgs e)
        {
            new Sign_UP().Show(); // Kayıt formunu aç
            this.Close(); // Giriş formunu kapat
        }

        // Kullanıcının adını veritabanından alarak döndüren metot
        private string gat_userName()
        {
            string name = "";

            con = new OracleConnection(conStr); // Veritabanı bağlantısını oluştur
            con.Open(); // Bağlantıyı aç
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;

            cmd.CommandText = "SELECT FIRST_NAME from PRO_CUSTOMER WHERE EMAIL= :email"; // Kullanıcı adını sorgula
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("email", textBox1.Text);
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                name = dr["FIRST_NAME"].ToString(); // Kullanıcı adını al
            }

            return name;
        }

        // Formu kapatmak için PictureBox tıklama olayı
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
```
