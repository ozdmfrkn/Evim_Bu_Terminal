# Evim Bu - Dijital Kiralık Portföy Yönetimi

**Evim Bu**, gayrimenkul sektöründeki kiralık mülk süreçlerini dijitalleştirmek, portföy takibini kolaylaştırmak ve rezervasyon/kiralama işlemlerini merkezi bir sistemden yönetmek için C# ile geliştirilmiş bir yönetim uygulamasıdır. 

Bu repo, projenin terminal ve form tabanlı çekirdek (backend) yönetim mekanizmalarını içermektedir.

---

## 🚀 Özellikler

*   **Detaylı Kiralık Portföy Yönetimi:** Kiralık ilanların kategorilendirilmesi, özelliklerinin ve durumlarının takibi.
*   **Rezervasyon ve Kiralama Sistemi (`Booking`):** Mülklerin kiralama süreçlerinin, tarih aralıklarının ve müşteri eşleşmelerinin dinamik yönetimi.
*   **Kategori Tabanlı Listeleme:** Mülk türlerine göre (daire, iş yeri vb.) hızlı filtreleme ve erişim.
*   **Gelişmiş Form ve Terminal Entegrasyonu:** Hem kullanıcı dostu arayüz formları (`Booking_Form`) hem de veri tutarlılığını sağlayan nesne yönelimli mimari.

---

## 🛠️ Kullanılan Teknolojiler

*   **Dil:** C# (.NET Framework)
*   **Mimari:** Nesne Yönelimli Programlama (OOP), Entity Framework / Veritabanı Modelleri
*   **Arayüz:** Windows Forms & Terminal / Konsol Altyapısı

---

## 📁 Proje Yapısı

Görselde yer alan temel dosyaların işlevleri:

*   `Booking.cs` / `Booking_Form.cs`: Kiralama ve rezervasyon işlemlerinin iş mantığı ile kullanıcı arayüzü tasarımları.
*   `Category.cs`: Kiralık mülklerin kategorilendirilmesini sağlayan model sınıfı.
*   `App.config`: Uygulamanın veritabanı bağlantı dizesi (Connection String) ve sistem konfigürasyonları.

---

## 💻 Kurulum ve Çalıştırma

Projeyi yerel bilgisayarınızda çalıştırmak için aşağıdaki adımları takip edebilirsiniz:

1.  **Depoyu Klonlayın:**
```bash
    git clone [https://github.com/ozdmfrkn/Evim_Bu_Terminal.git](https://github.com/ozdmfrkn/Evim_Bu_Terminal.git)
    ```
2.  **Projeyi Açın:**
    `Evim_Bu_Terminal.sln` (veya ilgili proje dosyasını) **Visual Studio** ile açın.
3.  **Veritabanı Yapılandırması:**
    `App.config` dosyası içerisindeki veri tabanı bağlantı adreslerini kendi yerel SQL Server ayarlarınıza göre güncelleyin.
4.  **Çalıştırın:**
    `Build` edin ve projeyi `Start` butonuna basarak çalıştırın.

---

## 👨‍💻 Geliştirici

*   **Furkan Özdemir** - [ozdmfrkn](https://github.com/ozdmfrkn)
