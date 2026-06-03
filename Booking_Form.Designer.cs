namespace Evim_Bu
{
    partial class Booking_Form
    {
        
        private System.ComponentModel.IContainer components = null;

        
        /// <param name="disposing"
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code


        private void InitializeComponent()
        {
            this.dtp_giris = new System.Windows.Forms.DateTimePicker();
            this.dtp_cikis = new System.Windows.Forms.DateTimePicker();
            this.btn_rezervasyon = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_secilen_ev = new System.Windows.Forms.Label();
            this.lbl_gunluk_fiyat = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView_evler = new System.Windows.Forms.DataGridView();
            this.lbl_toplam_fiyat = new System.Windows.Forms.Label();
            this.rb_kategori = new System.Windows.Forms.RadioButton();
            this.rb_kisi = new System.Windows.Forms.RadioButton();
            this.lbl_en_cok_kategori = new System.Windows.Forms.Label();
            this.lbl_en_cok_kisi = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_evler)).BeginInit();
            this.SuspendLayout();
            // 
            // dtp_giris
            // 
            this.dtp_giris.Location = new System.Drawing.Point(265, 335);
            this.dtp_giris.Name = "dtp_giris";
            this.dtp_giris.Size = new System.Drawing.Size(200, 22);
            this.dtp_giris.TabIndex = 1;
            this.dtp_giris.ValueChanged += new System.EventHandler(this.dtp_giris_ValueChanged);
            // 
            // dtp_cikis
            // 
            this.dtp_cikis.Location = new System.Drawing.Point(488, 335);
            this.dtp_cikis.Name = "dtp_cikis";
            this.dtp_cikis.Size = new System.Drawing.Size(200, 22);
            this.dtp_cikis.TabIndex = 2;
            this.dtp_cikis.ValueChanged += new System.EventHandler(this.dtp_cikis_ValueChanged);
            // 
            // btn_rezervasyon
            // 
            this.btn_rezervasyon.BackColor = System.Drawing.Color.Green;
            this.btn_rezervasyon.Location = new System.Drawing.Point(488, 386);
            this.btn_rezervasyon.Name = "btn_rezervasyon";
            this.btn_rezervasyon.Size = new System.Drawing.Size(167, 52);
            this.btn_rezervasyon.TabIndex = 3;
            this.btn_rezervasyon.Text = "Rezervasyon Yap";
            this.btn_rezervasyon.UseVisualStyleBackColor = false;
            this.btn_rezervasyon.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 267);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Seçilen Ev";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 339);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Günlük Fiyat";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Nirmala UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 404);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Toplam Tutar";
            // 
            // lbl_secilen_ev
            // 
            this.lbl_secilen_ev.AutoSize = true;
            this.lbl_secilen_ev.Location = new System.Drawing.Point(106, 268);
            this.lbl_secilen_ev.Name = "lbl_secilen_ev";
            this.lbl_secilen_ev.Size = new System.Drawing.Size(10, 16);
            this.lbl_secilen_ev.TabIndex = 7;
            this.lbl_secilen_ev.Text = ":";
            // 
            // lbl_gunluk_fiyat
            // 
            this.lbl_gunluk_fiyat.AutoSize = true;
            this.lbl_gunluk_fiyat.Location = new System.Drawing.Point(106, 339);
            this.lbl_gunluk_fiyat.Name = "lbl_gunluk_fiyat";
            this.lbl_gunluk_fiyat.Size = new System.Drawing.Size(33, 16);
            this.lbl_gunluk_fiyat.TabIndex = 8;
            this.lbl_gunluk_fiyat.Text = "0 TL";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button1.Location = new System.Drawing.Point(684, 386);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 52);
            this.button1.TabIndex = 9;
            this.button1.Text = "Çıkış Yap";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button2.Location = new System.Drawing.Point(255, 386);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(210, 52);
            this.button2.TabIndex = 10;
            this.button2.Text = "Listeleme Ekranına Dön";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView_evler
            // 
            this.dataGridView_evler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_evler.Location = new System.Drawing.Point(-1, -1);
            this.dataGridView_evler.Name = "dataGridView_evler";
            this.dataGridView_evler.RowHeadersWidth = 51;
            this.dataGridView_evler.RowTemplate.Height = 24;
            this.dataGridView_evler.Size = new System.Drawing.Size(803, 220);
            this.dataGridView_evler.TabIndex = 11;
            this.dataGridView_evler.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_evler_CellClick);
            // 
            // lbl_toplam_fiyat
            // 
            this.lbl_toplam_fiyat.AutoSize = true;
            this.lbl_toplam_fiyat.Location = new System.Drawing.Point(106, 404);
            this.lbl_toplam_fiyat.Name = "lbl_toplam_fiyat";
            this.lbl_toplam_fiyat.Size = new System.Drawing.Size(33, 16);
            this.lbl_toplam_fiyat.TabIndex = 12;
            this.lbl_toplam_fiyat.Text = "0 TL";
            // 
            // rb_kategori
            // 
            this.rb_kategori.AutoSize = true;
            this.rb_kategori.Location = new System.Drawing.Point(473, 236);
            this.rb_kategori.Name = "rb_kategori";
            this.rb_kategori.Size = new System.Drawing.Size(130, 20);
            this.rb_kategori.TabIndex = 13;
            this.rb_kategori.TabStop = true;
            this.rb_kategori.Text = "En Çok Kiralanan";
            this.rb_kategori.UseVisualStyleBackColor = true;
            this.rb_kategori.CheckedChanged += new System.EventHandler(this.rb_kategori_CheckedChanged);
            // 
            // rb_kisi
            // 
            this.rb_kisi.AutoSize = true;
            this.rb_kisi.Location = new System.Drawing.Point(473, 262);
            this.rb_kisi.Name = "rb_kisi";
            this.rb_kisi.Size = new System.Drawing.Size(130, 20);
            this.rb_kisi.TabIndex = 14;
            this.rb_kisi.TabStop = true;
            this.rb_kisi.Text = "En Çok Kiralayan";
            this.rb_kisi.UseVisualStyleBackColor = true;
            this.rb_kisi.CheckedChanged += new System.EventHandler(this.rb_kisi_CheckedChanged);
            // 
            // lbl_en_cok_kategori
            // 
            this.lbl_en_cok_kategori.AutoSize = true;
            this.lbl_en_cok_kategori.Location = new System.Drawing.Point(613, 239);
            this.lbl_en_cok_kategori.Name = "lbl_en_cok_kategori";
            this.lbl_en_cok_kategori.Size = new System.Drawing.Size(10, 16);
            this.lbl_en_cok_kategori.TabIndex = 15;
            this.lbl_en_cok_kategori.Text = ":";
            // 
            // lbl_en_cok_kisi
            // 
            this.lbl_en_cok_kisi.AutoSize = true;
            this.lbl_en_cok_kisi.Location = new System.Drawing.Point(613, 267);
            this.lbl_en_cok_kisi.Name = "lbl_en_cok_kisi";
            this.lbl_en_cok_kisi.Size = new System.Drawing.Size(10, 16);
            this.lbl_en_cok_kisi.TabIndex = 16;
            this.lbl_en_cok_kisi.Text = ":";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(473, 288);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(150, 23);
            this.button3.TabIndex = 17;
            this.button3.Text = "Kullanıcı İstatistikleri";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Booking_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.lbl_en_cok_kisi);
            this.Controls.Add(this.lbl_en_cok_kategori);
            this.Controls.Add(this.rb_kisi);
            this.Controls.Add(this.rb_kategori);
            this.Controls.Add(this.lbl_toplam_fiyat);
            this.Controls.Add(this.dataGridView_evler);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbl_gunluk_fiyat);
            this.Controls.Add(this.lbl_secilen_ev);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_rezervasyon);
            this.Controls.Add(this.dtp_cikis);
            this.Controls.Add(this.dtp_giris);
            this.Name = "Booking_Form";
            this.Text = "Evim_Bu_Rezervasyon";
            this.Load += new System.EventHandler(this.Booking_Form_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_evler)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dtp_giris;
        private System.Windows.Forms.DateTimePicker dtp_cikis;
        private System.Windows.Forms.Button btn_rezervasyon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_secilen_ev;
        private System.Windows.Forms.Label lbl_gunluk_fiyat;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView_evler;
        private System.Windows.Forms.Label lbl_toplam_fiyat;
        private System.Windows.Forms.RadioButton rb_kategori;
        private System.Windows.Forms.RadioButton rb_kisi;
        private System.Windows.Forms.Label lbl_en_cok_kategori;
        private System.Windows.Forms.Label lbl_en_cok_kisi;
        private System.Windows.Forms.Button button3;
    }
}