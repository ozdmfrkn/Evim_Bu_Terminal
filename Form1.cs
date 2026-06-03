using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace Evim_Bu
{
    public partial class Form1 : Form
    {
        EvimBuDbContext db = new EvimBuDbContext();
        private int _aktifKullaniciId;

        public Form1(int kullaniciId)
        {
            InitializeComponent();
            _aktifKullaniciId = kullaniciId;
        }

        public Booking_Form Booking_Form
        {
            get => default;
            set
            {
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            EvleriListele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_category_name.SelectedIndex == -1 || string.IsNullOrEmpty(txt_category_name.Text))
                {
                    MessageBox.Show("Lütfen listeden bir Ev Tipi seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal girilenFiyat;
                if (!decimal.TryParse(txt_price.Text, out girilenFiyat))
                {
                    MessageBox.Show("Lütfen geçerli bir sayısal fiyat girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Property yeniEv = new Property()
                {
                    Title = txt_category_name.Text,
                    Price_Per_Night = girilenFiyat,
                    Category_id = 1,
                    Is_My_Property = true,
                    Host_id = _aktifKullaniciId
                };

                db.Properties.Add(yeniEv);
                db.SaveChanges();

                MessageBox.Show("Eviniz portföyünüze başarıyla eklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Temizle();
                EvleriListele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EvleriListele()
        {
            try
            {
                db = new EvimBuDbContext();

                var evler = db.Properties
                              .Where(p => p.Is_My_Property != null && p.Is_My_Property == true && p.Host_id == _aktifKullaniciId)
                              .Select(p => new
                              {
                                  p.Property_id,
                                  p.Title,
                                  p.Price_Per_Night
                              }).ToList();

                dgv_categories.DataSource = evler;
                dgv_categories.Columns["Property_id"].HeaderText = "Ev No";
                dgv_categories.Columns["Title"].HeaderText = "İlan Başlığı";
                dgv_categories.Columns["Price_Per_Night"].HeaderText = "Gecelik Fiyat";
                dgv_categories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception) { }
        }

        private void dgv_categories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_categories.CurrentRow != null)
            {
                txt_category_name.Text = dgv_categories.CurrentRow.Cells["Title"].Value.ToString();
                txt_price.Text = dgv_categories.CurrentRow.Cells["Price_Per_Night"].Value.ToString();
            }
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_categories.CurrentRow == null)
                {
                    MessageBox.Show("Lütfen güncellemek istediğiniz evi tablodan seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txt_category_name.SelectedIndex == -1 || string.IsNullOrEmpty(txt_price.Text))
                {
                    MessageBox.Show("Lütfen Ev Tipi ve Fiyat alanlarını doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal yeniFiyat;
                if (!decimal.TryParse(txt_price.Text, out yeniFiyat))
                {
                    MessageBox.Show("Lütfen geçerli bir sayısal fiyat girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int secilenEvId = Convert.ToInt32(dgv_categories.CurrentRow.Cells["Property_id"].Value);
                var guncellenecekEv = db.Properties.FirstOrDefault(p => p.Property_id == secilenEvId);

                if (guncellenecekEv != null)
                {
                    guncellenecekEv.Title = txt_category_name.Text;
                    guncellenecekEv.Price_Per_Night = yeniFiyat;

                    db.SaveChanges();
                    MessageBox.Show("Ev bilgileri başarıyla güncellendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Temizle();
                    EvleriListele();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme yapılırken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_categories.CurrentRow == null)
                {
                    MessageBox.Show("Lütfen silmek istediğiniz evi tablodan seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult secenek = MessageBox.Show(
                    "Bu ilanı portföyünüzden silmek istediğinize emin misiniz?",
                    "Silme Onayı",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (secenek == DialogResult.Yes)
                {
                    int secilenEvId = Convert.ToInt32(dgv_categories.CurrentRow.Cells["Property_id"].Value);
                    var silinecekEv = db.Properties.FirstOrDefault(p => p.Property_id == secilenEvId);

                    if (silinecekEv != null)
                    {
                        db.Properties.Remove(silinecekEv);
                        db.SaveChanges();

                        MessageBox.Show("İlan başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Temizle();
                        EvleriListele();
                    }
                }
                else
                {
                    MessageBox.Show("Silme işlemi iptal edildi.", "İptal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme işlemi sırasında bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Temizle()
        {
            txt_category_name.SelectedIndex = -1;
            txt_price.Clear();
        }

        private void btn_listele_Click(object sender, EventArgs e) { EvleriListele(); }

        private void button2_Click(object sender, EventArgs e)
        {
            Booking_Form rezervasyonFormu = new Booking_Form();
            rezervasyonFormu.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Login_Form girisFormu = new Login_Form();
            girisFormu.Show();
            this.Hide();
        }

        private void dgv_categories_CellClick_1(object sender, DataGridViewCellEventArgs e) { }

        private void txt_category_name_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}