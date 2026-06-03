using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity; 
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evim_Bu
{
    public partial class Booking_Form : Form
    {
        EvimBuDbContext db = new EvimBuDbContext();

        private decimal secilenEvFiyati = 0;
        private int secilenEvId = 0;

        public static int AktifKullaniciId { get; set; } = 1;

        public Booking_Form()
        {
            InitializeComponent();
        }

        private void Booking_Form_Load(object sender, EventArgs e)
        {
            EvleriListele();
            dtp_giris.Value = DateTime.Now;
            dtp_cikis.Value = DateTime.Now.AddDays(1);

            lbl_en_cok_kategori.Text = "";
            lbl_en_cok_kisi.Text = "";
        }

        private void EvleriListele()
        {
            try
            {
                var evler = db.Properties.Select(p => new
                {
                    p.Property_id,
                    p.Title,
                    p.Price_Per_Night
                }).ToList();

                dataGridView_evler.DataSource = evler;

                dataGridView_evler.Columns["Property_id"].HeaderText = "Ev No";
                dataGridView_evler.Columns["Title"].HeaderText = "İlan Başlığı";
                dataGridView_evler.Columns["Price_Per_Night"].HeaderText = "Gecelik Fiyat";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Evler listelenirken hata oluştu: " + ex.Message);
            }
        }

        private void dataGridView_evler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView_evler.Rows[e.RowIndex];

                secilenEvId = Convert.ToInt32(row.Cells["Property_id"].Value);
                string evBasligi = row.Cells["Title"].Value.ToString();
                secilenEvFiyati = Convert.ToDecimal(row.Cells["Price_Per_Night"].Value);

                lbl_secilen_ev.Text = evBasligi;
                TutarHesapla();
            }
        }

        private void dtp_giris_ValueChanged(object sender, EventArgs e)
        {
            TutarHesapla();
        }

        private void dtp_cikis_ValueChanged(object sender, EventArgs e)
        {
            TutarHesapla();
        }

        private void TutarHesapla()
        {
            if (secilenEvId == 0) return;

            DateTime girisTarihi = dtp_giris.Value.Date;
            DateTime cikisTarihi = dtp_cikis.Value.Date;

            if (cikisTarihi <= girisTarihi)
            {
                lbl_toplam_fiyat.Text = "Geçersiz Tarih!";
                return;
            }

            int toplamGun = (cikisTarihi - girisTarihi).Days;
            decimal toplamTutar = toplamGun * secilenEvFiyati;

            lbl_gunluk_fiyat.Text = secilenEvFiyati.ToString("C2");
            lbl_toplam_fiyat.Text = toplamTutar.ToString("C2");
        }

        private void rb_kategori_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_kategori.Checked)
            {
                try
                {
                    
                    var enCokKiralanan = db.Bookings.AsNoTracking()
                        .GroupBy(b => b.Property_id)
                        .Select(g => new { PropertyId = g.Key, Adet = g.Count() })
                        .OrderByDescending(x => x.Adet)
                        .FirstOrDefault();

                    if (enCokKiralanan != null)
                    {
                        var evBilgisi = db.Properties.AsNoTracking().FirstOrDefault(p => p.Property_id == enCokKiralanan.PropertyId);
                        if (evBilgisi != null)
                        {
                            lbl_en_cok_kategori.Text = evBilgisi.Title;
                        }
                    }
                    else
                    {
                        lbl_en_cok_kategori.Text = "Kayıt Yok";
                    }
                    lbl_en_cok_kisi.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void rb_kisi_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_kisi.Checked)
            {
                try
                {
                    
                    var enCokRezervasyonYapan = db.Bookings.AsNoTracking()
                        .GroupBy(b => b.Guest_id)
                        .Select(g => new { UserId = g.Key, Adet = g.Count() })
                        .OrderByDescending(x => x.Adet)
                        .FirstOrDefault();

                    if (enCokRezervasyonYapan != null)
                    {
                        var kullaniciBilgisi = db.Users.AsNoTracking().FirstOrDefault(u => u.User_id == enCokRezervasyonYapan.UserId);

                        if (kullaniciBilgisi != null)
                        {
                            string[] mailParcalari = kullaniciBilgisi.E_Mail.Split('@');
                            lbl_en_cok_kisi.Text = mailParcalari[0];
                        }
                    }
                    else
                    {
                        lbl_en_cok_kisi.Text = "Kayıt Yok";
                    }
                    lbl_en_cok_kategori.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (secilenEvId == 0)
            {
                MessageBox.Show("Lütfen listeden bir ev seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime girisTarihi = dtp_giris.Value.Date;
            DateTime cikisTarihi = dtp_cikis.Value.Date;

            if (cikisTarihi <= girisTarihi)
            {
                MessageBox.Show("Çıkış tarihi giriş tarihinden sonra olmalıdır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int toplamGun = (cikisTarihi - girisTarihi).Days;
                decimal toplamTutar = toplamGun * secilenEvFiyati;

                Booking yeniRezervasyon = new Booking
                {
                    Property_id = secilenEvId,
                    Guest_id = AktifKullaniciId,
                    CheckInDate = girisTarihi,
                    CheckOutDate = cikisTarihi,
                    TotalAmount = toplamTutar
                };

                db.Bookings.Add(yeniRezervasyon);
                db.SaveChanges();

                MessageBox.Show($"Rezervasyonunuz başarıyla alındı!\nGün Sayısı: {toplamGun}\nToplam Tutar: {toplamTutar.ToString("C2")}", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Rezervasyon kaydedilemedi!\n\n" + ex.Message, "SQL Hata Raporu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Login_Form girisFormu = new Login_Form();
            girisFormu.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 listelemeFormu = new Form1(AktifKullaniciId);
            listelemeFormu.Show();
            this.Close();
        }

        private void Booking_Form_Load_1(object sender, EventArgs e)
        {
            EvleriListele();
        }

        
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var liste = db.Bookings.AsNoTracking()
                    .GroupBy(b => b.Guest_id)
                    .Select(g => new
                    {
                        UserId = g.Key,
                        Adet = g.Count(),
                        Email = db.Users.Where(u => u.User_id == g.Key).Select(u => u.E_Mail).FirstOrDefault()
                    }).ToList();

                string raporMesaj = "=== REZERVASYON SAYILARI ===\n\n";
                foreach (var item in liste)
                {
                    raporMesaj += $"Kullanıcı: {item.Email} (ID: {item.UserId}) -> Toplam {item.Adet} adet kiralama yapmış.\n";
                }

                MessageBox.Show(raporMesaj, "Veritabanı Durum Raporu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Rapor alınırken hata oluştu: " + ex.Message);
            }
        }
    }
}