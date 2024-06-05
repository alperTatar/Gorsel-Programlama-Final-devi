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

namespace Flight_Reservation_system
{
    public partial class Sign_UP : Form
    {
        string conStr = Program.ConnStr; // Veritabanı bağlantı dizesi
        OracleConnection con; // Oracle veritabanı bağlantısı

        public Sign_UP()
        {
            InitializeComponent();
        }

        // Form yüklendiğinde yapılacak işlemler
        private void Sign_UP_Load(object sender, EventArgs e)
        {
            // İşlevsiz, bu kısımda herhangi bir kod yok
        }

        // İsim metni kutusunda metin değiştiğinde yapılacak işlemler
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // İşlevsiz, bu kısımda herhangi bir kod yok
        }

        // Soyisim metni kutusunda metin değiştiğinde yapılacak işlemler
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // İşlevsiz, bu kısımda herhangi bir kod yok
        }

        // Kayıt butonuna tıklandığında yapılacak işlemler
        private void button1_Click(object sender, EventArgs e)
        {
            // Kullanıcı bilgileri kontrol edilir
            if (textBox3.Text.Equals("First Name") || textBox4.Text.Equals("Second Name") ||
                textBox1.Text.Equals("E-Mail") || textBox2.Text.Equals("PASSWORD") || textBox5.Text.Equals("Phone Number1")
                || textBox3.Text.Equals("") || textBox4.Text.Equals("") || textBox1.Text.Equals("") || textBox2.Text.Equals("") || textBox5.Text.Equals(""))
            {
                MessageBox.Show(Program.MessageAlert); // Kullanıcıya uyarı mesajı gösterilir
            }
            else
            {
                try
                {
                    // Veritabanına bağlanılır
                    con = new OracleConnection(conStr);
                    con.Open();

                    // Kullanıcı bilgileri veritabanına eklenir
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "insert into PRO_CUSTOMER (email, first_name, last_name, password) Values(:email, :first, :last, :password)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("email", textBox1.Text);
                    cmd.Parameters.Add("first", textBox3.Text);
                    cmd.Parameters.Add("last", textBox4.Text);
                    cmd.Parameters.Add("password", textBox2.Text);
                    int ret = cmd.ExecuteNonQuery();
                    if (ret == -1) MessageBox.Show("Invalid problem1");

                    // Kullanıcı telefon numaraları veritabanına eklenir
                    OracleCommand cmd2 = new OracleCommand();
                    cmd2.Connection = con;
                    cmd2.CommandText = "insert into PRO_CUSTOMER_PHONES (CUSTOMER_PHONE, EMAIL_CPN) Values(:phone, :emailFK)";
                    cmd2.CommandType = CommandType.Text;
                    cmd2.Parameters.Add("phone", textBox5.Text);
                    cmd2.Parameters.Add("emailFK", textBox1.Text);
                    ret = cmd2.ExecuteNonQuery();
                    if (ret == -1) MessageBox.Show("Invalid problem2");

                    OracleCommand cmd3 = new OracleCommand();
                    cmd3.Connection = con;
                    cmd3.CommandText = "insert into PRO_CUSTOMER_PHONES (CUSTOMER_PHONE, EMAIL_CPN) Values(:phone, :emailFK)";
                    cmd3.CommandType = CommandType.Text;
                    cmd3.Parameters.Add("phone", textBox6.Text);
                    cmd3.Parameters.Add("emailFK", textBox1.Text);
                    ret = cmd3.ExecuteNonQuery();
                    if (ret == -1) MessageBox.Show("Invalid problem3");

                    // Kullanıcı bilgileri saklanır
                    Program.UserName = textBox3.Text;
                    Program.UserEmail = textBox1.Text;
                    Program.UserPassword = textBox2.Text;

                    // Kullanıcıya hoş geldin mesajı gösterilir
                    MessageBox.Show("Welcome\nSign Up Process Done Successfully");

                    // Ana ekrana kullanıcı adı görüntülenir
                    Home.UserNameLabel.Text = Program.UserName;
                    Home.UserNameLabel.Visible = true;
                    this.Close(); // Kayıt formu kapatılır
                }
                catch
                {
                    MessageBox.Show("Allready Registered Befor!!! please sign in"); // Hata durumunda kullanıcıya uyarı mesajı gösterilir
                }
            }
        }

        // Telefon numarası metni kutusunda metin değiştiğinde yapılacak işlemler
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            // İşlevsiz, bu kısımda herhangi bir kod yok
        }

        // Giriş yap etiketine tıklandığında yapılacak işlemler
        private void label3_Click(object sender, EventArgs e)
        {
            new Sign_In().Show(); // Giriş yap formu açılır
            this.Close(); // Kayıt formu kapatılır
        }

        // Soyisim metni kutusunda metin değiştiğinde yapılacak işlemler
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            // İşlevsiz, bu kısımda herhangi bir kod yok
        }

        // Kapatma butonuna tıklandığında yapılacak işlemler
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close(); // Kayıt formu kapatılır
        }
    }
}

