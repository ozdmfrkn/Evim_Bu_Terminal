using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evim_Bu
{
    public partial class Login_Form : Form
    {
        public Login_Form()
        {
            InitializeComponent();
        }

        public Form1 Form1
        {
            get => default;
            set
            {
            }
        }

        private void btn_giris_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_email.Text) || string.IsNullOrEmpty(txt_sifre.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (EvimBuDbContext db = new EvimBuDbContext())
            {
                string girilenEmail = txt_email.Text.Trim();
                string girilenSifre = txt_sifre.Text.Trim();

                var kullanici = db.Users.FirstOrDefault(u => u.E_Mail == girilenEmail && u.Password_Hash == girilenSifre);

                if (kullanici != null)
                {
                    
                    string[] mailParcalari = girilenEmail.Split('@');
                    string mailIsmi = mailParcalari[0];

                    MessageBox.Show($"Giriş Başarılı! Hoş geldiniz, {mailIsmi}", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    
                    Booking_Form.AktifKullaniciId = kullanici.User_id;

                    Form1 anaForm = new Form1(kullanici.User_id);
                    anaForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("E-posta veya şifre hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_kayit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_email.Text) || string.IsNullOrEmpty(txt_sifre.Text))
            {
                MessageBox.Show("Lütfen kayıt olmak için e-posta ve şifre giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (EvimBuDbContext db = new EvimBuDbContext())
            {
                string girilenEmail = txt_email.Text.Trim();

                var varMi = db.Users.Any(u => u.E_Mail == girilenEmail);
                if (varMi)
                {
                    MessageBox.Show("Bu e-posta adresi zaten kayıtlı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                User yeniKullanici = new User
                {
                    E_Mail = girilenEmail,
                    Password_Hash = txt_sifre.Text.Trim(),
                    First_Name = "Yeni",
                    Last_Name = "Kullanıcı",
                    User_Role = "Customer"
                };

                db.Users.Add(yeniKullanici);
                db.SaveChanges();
                MessageBox.Show("Kayıt başarılı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Login_Form_Load(object sender, EventArgs e) { }
    }
}