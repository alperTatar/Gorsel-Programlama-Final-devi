namespace Flight_Reservation_system
{
    partial class Booking
    {
        /// <summary>
        /// Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        /// <param name="disposing">Yönetilen kaynaklar atılmalıdır.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Tasarımcı desteği için gereken yöntem - kod düzenleyici ile içeriği değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox2 = new System.Windows.Forms.PictureBox(); // Pencereyi kapatmak için resim kutusu.
            this.label1 = new System.Windows.Forms.Label(); // "Uçuş Numarası" etiketi.
            this.label2 = new System.Windows.Forms.Label(); // "Bilet sayısı" etiketi.
            this.label3 = new System.Windows.Forms.Label(); // "Kredi Kartı Numarası" etiketi.
            this.label4 = new System.Windows.Forms.Label(); // "Kişisel Adres" etiketi.
            this.label5 = new System.Windows.Forms.Label(); // "Pasaport Numarası" etiketi.
            this.flight_num = new System.Windows.Forms.TextBox(); // Uçuş numarasını girmek için metin kutusu.
            this.nums = new System.Windows.Forms.TextBox(); // Bilet sayısını girmek için metin kutusu.
            this.credit = new System.Windows.Forms.TextBox(); // Kredi kartı numarasını girmek için metin kutusu.
            this.add = new System.Windows.Forms.TextBox(); // Kişisel adresi girmek için metin kutusu.
            this.pass_num = new System.Windows.Forms.TextBox(); // Pasaport numarasını girmek için metin kutusu.
            this.finish = new System.Windows.Forms.Button(); // Rezervasyon işlemini tamamlamak için düğme.
            this.timer1 = new System.Windows.Forms.Timer(this.components); // Zamanlayıcı bileşeni.
            this.label7 = new System.Windows.Forms.Label(); // "Zamanlayıcı" etiketi.
            this.panel1 = new System.Windows.Forms.Panel(); // Formdaki bileşenleri içeren panel.
            this.label12 = new System.Windows.Forms.Label(); // "Güncel Zaman" etiketi.
            this.label6 = new System.Windows.Forms.Label(); // "Kişisel Bilgiler" etiketi.
            this.label11 = new System.Windows.Forms.Label(); // "______________" çizgi etiketi.
            this.button2 = new System.Windows.Forms.Button(); // Uçuş aramak için düğme.
            this.label10 = new System.Windows.Forms.Label(); // "Rezervasyon Detayları" etiketi.
            this.label9 = new System.Windows.Forms.Label(); // "______________" çizgi etiketi.
            this.button1 = new System.Windows.Forms.Button(); // Formu temizlemek için düğme.
            this.label8 = new System.Windows.Forms.Label(); // "Havayolu Rezervasyon Formu" başlığı.
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::Flight_Reservation_system.Properties.Resources.index1; // Resim kaynağı.
            this.pictureBox2.Location = new System.Drawing.Point(1028, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(48, 52);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click); // Tıklama olayı.
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 19);
            this.label1.TabIndex = 12;
            this.label1.Text = "Uçuş Numarası"; // Uçuş Numarası
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(311, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 19);
            this.label2.TabIndex = 13;
            this.label2.Text = "Bilet Sayısı"; // Bilet Sayısı
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(19, 288);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 19);
            this.label3.TabIndex = 14;
            this.label3.Text = "Kredi Kartı Numarası"; // Kredi Kartı Numarası
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(19, 245);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 19);
            this.label4.TabIndex = 15;
            this.label4.Text = "Kişisel Adres"; // Kişisel Adres
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(19, 328);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 19);
            this.label5.TabIndex = 16;
            this.label5.Text = "Pasaport Numarası"; // Pasaport Numarası
            // 
            // flight_num
            // 
            this.flight_num.BackColor = System.Drawing.Color.PeachPuff;
            this.flight_num.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flight_num.Cursor = System.Windows.Forms.Cursors.Default;
            this.flight_num.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.flight_num.ForeColor = System.Drawing.SystemColors.WindowText;
            this.flight_num.Location = new System.Drawing.Point(114, 73);
            this.flight_num.Name = "flight_num";
            this.flight_num.Size = new System.Drawing.Size(180, 26);
            this.flight_num.TabIndex = 17;
            this.flight_num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nums
            // 
            this.nums.BackColor = System.Drawing.Color.PeachPuff;
            this.nums.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.nums.ForeColor = System.Drawing.SystemColors.WindowText;
            this.nums.Location = new System.Drawing.Point(438, 73);
            this.nums.Name = "nums";
            this.nums.Size = new System.Drawing.Size(180, 26);
            this.nums.TabIndex = 18;
            this.nums.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // credit
            // 
            this.credit.BackColor = System.Drawing.Color.PeachPuff;
            this.credit.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.credit.Location = new System.Drawing.Point(192, 286);
            this.credit.Name = "credit";
            this.credit.Size = new System.Drawing.Size(180, 26);
            this.credit.TabIndex = 19;
            this.credit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // add
            // 
            this.add.BackColor = System.Drawing.Color.PeachPuff;
            this.add.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.add.Location = new System.Drawing.Point(192, 241);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(180, 26);
            this.add.TabIndex = 20;
            this.add.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pass_num
            // 
            this.pass_num.BackColor = System.Drawing.Color.PeachPuff;
            this.pass_num.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.pass_num.Location = new System.Drawing.Point(192, 326);
            this.pass_num.Name = "pass_num";
            this.pass_num.Size = new System.Drawing.Size(180, 26);
            this.pass_num.TabIndex = 21;
            this.pass_num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // finish
            // 
            this.finish.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.finish.Cursor = System.Windows.Forms.Cursors.Hand;
            this.finish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.finish.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.finish.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.finish.Location = new System.Drawing.Point(384, 381);
            this.finish.Name = "finish";
            this.finish.Size = new System.Drawing.Size(120, 34);
            this.finish.TabIndex = 22;
            this.finish.Text = "Rezerve Et";
            this.finish.UseVisualStyleBackColor = false;
            this.finish.Click += new System.EventHandler(this.finish_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Italic);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(64, 415);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 29);
            this.label7.TabIndex = 25;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(13, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1009, 466);
            this.panel1.TabIndex = 26;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(16, 409);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(0, 19);
            this.label12.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label6.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label6.Location = new System.Drawing.Point(15, 217);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 23);
            this.label6.TabIndex = 23;
            this.label6.Text = "Kişisel Bilgiler";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label11.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label11.Location = new System.Drawing.Point(134, 217);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(106, 23);
            this.label11.TabIndex = 22;
            this.label11.Text = "______________";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Location = new System.Drawing.Point(450, 187);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 34);
            this.button2.TabIndex = 21;
            this.button2.Text = "Uçuş Ara";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label10.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label10.Location = new System.Drawing.Point(15, 73);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(167, 23);
            this.label10.TabIndex = 20;
            this.label10.Text = "Rezervasyon Detayları";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label9.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label9.Location = new System.Drawing.Point(176, 73);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 23);
            this.label9.TabIndex = 19;
            this.label9.Text = "______________";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(450, 127);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 34);
            this.button1.TabIndex = 18;
            this.button1.Text = "Temizle";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Italic);
            this.label8.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label8.Location = new System.Drawing.Point(15, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(262, 29);
            this.label8.TabIndex = 0;
            this.label8.Text = "Havayolu Rezervasyon Formu";
            // 
            // Booking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Sienna;
            this.ClientSize = new System.Drawing.Size(1088, 478);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.finish);
            this.Controls.Add(this.pass_num);
            this.Controls.Add(this.add);
            this.Controls.Add(this.credit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.mail);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lname);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.fname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Booking";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox fname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox lname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox mail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox credit;
        private System.Windows.Forms.TextBox add;
        private System.Windows.Forms.TextBox pass_num;
        private System.Windows.Forms.Button finish;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
    }
}