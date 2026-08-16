<div align="center">

# 🌍 Traversal

### ASP.NET Core 6 ile geliştirilmiş çok katmanlı seyahat & tur rezervasyon platformu

[![.NET](https://img.shields.io/badge/.NET-6.0-512BD4?style=for-the-badge\&logo=dotnet)](https://dotnet.microsoft.com/)
[![EF Core](https://img.shields.io/badge/EF%20Core-6.0-512BD4?style=for-the-badge\&logo=dotnet)](https://docs.microsoft.com/ef/)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge\&logo=microsoftsqlserver\&logoColor=white)](https://www.microsoft.com/sql-server)
[![Identity](https://img.shields.io/badge/ASP.NET%20Identity-512BD4?style=for-the-badge\&logo=dotnet)](https://docs.microsoft.com/aspnet/core/security/authentication/identity)
[![SignalR](https://img.shields.io/badge/SignalR-512BD4?style=for-the-badge\&logo=dotnet)](https://dotnet.microsoft.com/apps/aspnet/signalr)
[![MediatR](https://img.shields.io/badge/MediatR-CQRS-orange?style=for-the-badge)](https://github.com/jbogard/MediatR)
[![AutoMapper](https://img.shields.io/badge/AutoMapper-B33B9E?style=for-the-badge)](https://automapper.org/)
[![FluentValidation](https://img.shields.io/badge/FluentValidation-2E8B57?style=for-the-badge)](https://fluentvalidation.net/)
[![ClosedXML](https://img.shields.io/badge/ClosedXML-Excel-217346?style=for-the-badge\&logo=microsoftexcel\&logoColor=white)](https://github.com/ClosedXML/ClosedXML)
[![MailKit](https://img.shields.io/badge/MailKit-SMTP-blue?style=for-the-badge)](https://github.com/jstedfast/MailKit)

</div>

---

## 📖 İçindekiler

* [📌 Proje Hakkında](#-proje-hakkında)
* [📸 Ekran Görüntüleri](#-ekran-görüntüleri)
* [🛠️ Kullanılan Teknolojiler](#️-kullanılan-teknolojiler)
* [🏗️ Mimari](#-mimari)
* [✨ Özellikler](#-özellikler)
* [📦 Kurulum](#-kurulum)
* [📁 Proje Yapısı](#-proje-yapısı)
* [🎯 Öne Çıkan Özellikler](#-öne-çıkan-özellikler)

---

## 📌 Proje Hakkında

**Traversal**, seyahat acenteleri ve bireysel kullanıcılar için geliştirilmiş, **N-katmanlı mimari** üzerine kurulu full-stack bir web uygulamasıdır. SQL Server tabanlı ilişkisel veritabanı ile dinamik içerik yönetimi sunar; hem kullanıcı arayüzü hem de admin paneli tarafında eksiksiz çalışan işlevsel bir sistem sağlar.

> 🎯 Kullanıcılar tur listesini görüntüleyip rezervasyon yapabilir, admin panelinden tüm içerikler yönetilebilir, rezervasyon sonrası otomatik onay maili gönderilir ve admin paneli SignalR ile anlık istatistiklerle beslenir.

---

## 📸 Ekran Görüntüleri

### 🌍 Kullanıcı Arayüzü

<table>
<tr>
<td width="50%">

**Ana Sayfa**

![Ana Sayfa](Traversal/Traversal.WebUI/wwwroot/images/Ana%20Sayfa.png)

</td>
<td width="50%">

**Ana Sayfa — Öne Çıkanlar**

![Ana Sayfa 2](Traversal/Traversal.WebUI/wwwroot/images/Ana%20Sayfa%202.png)

</td>
</tr>

<tr>
<td width="50%">

**Ana Sayfa — Referanslar**

![Ana Sayfa 3](Traversal/Traversal.WebUI/wwwroot/images/Ana%20Sayfa%203.png)

</td>
<td width="50%">

**Destinasyon Listesi**

![Destinasyonlar](Traversal/Traversal.WebUI/wwwroot/images/Destinasyonlar.png)

</td>
</tr>

<tr>
<td width="50%">

**Destinasyon Detay**

![Destinasyon Detay](Traversal/Traversal.WebUI/wwwroot/images/Destinasyon%20Detay.png)

</td>
<td width="50%">

**Destinasyon Detay — Devamı**

![Destinasyon Detay 2](Traversal/Traversal.WebUI/wwwroot/images/Destinasyon%20Detay%202.png)

</td>
</tr>

<tr>
<td width="50%">

**Hakkımızda**

![Hakkımızda](Traversal/Traversal.WebUI/wwwroot/images/Hakk%C4%B1m%C4%B1zda.png)

</td>
<td width="50%">

**Hakkımızda — Devamı**

![Hakkımızda 2](Traversal/Traversal.WebUI/wwwroot/images/Hakk%C4%B1m%C4%B1zda%202.png)

</td>
</tr>

<tr>
<td width="50%">

**İletişim**

![İletişim](Traversal/Traversal.WebUI/wwwroot/images/%C4%B0leti%C5%9Fim.png)

</td>
<td width="50%"></td>
</tr>
</table>

---

### 👤 Üye Paneli

<table>
<tr>
<td width="50%">

**Üye Dashboard**

![Member Dashboard](Traversal/Traversal.WebUI/wwwroot/images/Member%20Dashboard.png)

</td>
<td width="50%">

**Profil Ekranı**

![Üye Profil Ekranı](Traversal/Traversal.WebUI/wwwroot/images/%C3%9Cye%20Profil%20Ekran%C4%B1.png)

</td>
</tr>

<tr>
<td width="50%">

**Rezervasyon İşlemleri**

![Üye Rezervasyon](Traversal/Traversal.WebUI/wwwroot/images/%C3%9Cye%20Rezervasyon.png)

</td>
<td width="50%">

**Aktif Tur Listesi**

![Üye Aktif Tur Liste](Traversal/Traversal.WebUI/wwwroot/images/%C3%9Cye%20Aktif%20Tur%20Liste.png)

</td>
</tr>

<tr>
<td width="50%">

**Favori Destinasyonlar**

![Üye Favori Destinasyon](Traversal/Traversal.WebUI/wwwroot/images/%C3%9Cye%20Favori%20Destinasyon.png)

</td>
<td width="50%">

**Yorum Listesi**

![Üye Yorum Listesi](Traversal/Traversal.WebUI/wwwroot/images/%C3%9Cye%20Yorum%20Listesi.png)

</td>
</tr>
</table>

---

### 🛠️ Admin Paneli

<table>
<tr>
<td width="50%">

**Dashboard**

![Admin Dashboard](Traversal/Traversal.WebUI/wwwroot/images/Admin%20Dashboard.png)

</td>
<td width="50%">

**SignalR — Anlık Veriler**

![Admin SignalR Anlık Veri](Traversal/Traversal.WebUI/wwwroot/images/Admin%20SignalR%20Anl%C4%B1k%20Veri.png)

</td>
</tr>

<tr>
<td width="50%">

**Destinasyon Yönetimi**

![Admin Destinasyon Liste](Traversal/Traversal.WebUI/wwwroot/images/Admin%20Destinasyon%20Liste.png)

</td>
<td width="50%">

**Rezervasyon Yönetimi**

![Admin Rezervasyon Liste](Traversal/Traversal.WebUI/wwwroot/images/Admin%20Rezervasyon%20Liste.png)

</td>
</tr>

<tr>
<td width="50%">

**Kullanıcı Yönetimi**

![Admin Kullanıcılar](Traversal/Traversal.WebUI/wwwroot/images/Admin%20Kullan%C4%B1c%C4%B1lar.png)

</td>
<td width="50%">

**Rol Yönetimi**

![Admin Roller](Traversal/Traversal.WebUI/wwwroot/images/Admin%20Roller.png)

</td>
</tr>
</table>

---

### ⚠️ Hata Sayfaları

<table>
<tr>
<td width="33%">

**401 - Yetkisiz**

![401](Traversal/Traversal.WebUI/wwwroot/images/401%20Sayfas%C4%B1.png)

</td>
<td width="33%">

**403 - Erişim Engellendi**

![403](Traversal/Traversal.WebUI/wwwroot/images/403%20Sayfas%C4%B1.png)

</td>
<td width="33%">

**404 - Sayfa Bulunamadı**

![404](Traversal/Traversal.WebUI/wwwroot/images/404%20Sayfas%C4%B1.png)

</td>
</tr>
</table>

---

## 🛠️ Kullanılan Teknolojiler

| Kategori                    | Teknoloji                                                              |
| --------------------------- | ---------------------------------------------------------------------- |
| **Backend**                 | ASP.NET Core MVC (.NET 6)                                              |
| **Veritabanı**              | SQL Server, Entity Framework Core                                      |
| **Kimlik Doğrulama**        | ASP.NET Core Identity, Cookie Authentication, Role-Based Authorization |
| **Nesne Eşleme**            | AutoMapper                                                             |
| **Doğrulama**               | FluentValidation                                                       |
| **Gerçek Zamanlı İletişim** | SignalR                                                                |
| **CQRS**                    | MediatR (Destinasyon modülünde uygulanmıştır)                          |
| **Mail Gönderimi**          | MailKit / MimeKit (SMTP)                                               |
| **Excel Raporlama**         | ClosedXML                                                              |
| **PDF İşlemleri**           | QuestPDF                                                               |
| **Frontend**                | HTML5, CSS3, JavaScript, jQuery                                        |
| **Dış API Entegrasyonu**    | RapidAPI (Döviz Kuru, Altın, Hava Durumu)                              |

---

## 🏗️ Mimari

Proje, **Generic Repository Pattern** temelli N-katmanlı mimari üzerine kurulmuştur:

```text
Traversal.EntityLayer      → Veritabanı varlıkları (Entities)

Traversal.DataAccessLayer  → Generic Repository Pattern, EF Core sorguları

Traversal.BusinessLayer    → Servisler, FluentValidation kuralları

Traversal.DtoLayer         → Data Transfer Object'ler

Traversal.WebUI            → MVC Controller'lar, View'lar, Area yapısı, CQRS/MediatR
```

### Mimari Prensipler

* 🧩 **N-Katmanlı Mimari** — Generic Repository Pattern ile DAL/Service ayrımı
* 🔐 **Area Yapısı** — Admin ve Member panelleri birbirinden bağımsız, izole modüller
* 🔄 **AutoMapper** — Entity ↔ DTO dönüşümlerinde tutarlı ve merkezi mapping yönetimi
* ✅ **FluentValidation** — İş kurallarının Business Layer'da, DTO'lardan bağımsız yönetimi
* 🧱 **ViewComponent Kullanımı** — Yeniden kullanılabilir, veri odaklı UI parçaları
* ⚡ **CQRS & MediatR** — Destinasyon modülü, Command/Query ayrımı ve MediatR pipeline'ı ile ayrıca geliştirilmiştir

### 🔀 CQRS / MediatR Kullanımı

Projede genel CRUD işlemleri klasik **Service Layer** yaklaşımıyla yönetilirken, **Destinasyon modülü** bilinçli olarak **CQRS (Command Query Responsibility Segregation)** prensibiyle, **MediatR** kütüphanesi kullanılarak ayrıca geliştirilmiştir.

```text
Traversal.WebUI/CQRS/

├── Command/      → Create/Update işlemlerini temsil eden komut nesneleri
├── Handler/      → Command/Query'leri işleyen handler sınıfları
└── Result/       → Query sonuçlarını taşıyan result nesneleri
```

* `IRequestHandler<TRequest, TResponse>` implementasyonları ile okuma (Query) ve yazma (Command) sorumlulukları ayrıştırılmıştır.
* Controller katmanı, `IMediator.Send(...)` üzerinden ilgili handler'a yönlendirme yapar.
* Bu yapı, aynı proje içinde hem klasik N-katmanlı mimarinin hem de CQRS yaklaşımının karşılaştırmalı olarak uygulanması amacıyla tercih edilmiştir.

---

## ✨ Özellikler

### 🌍 Kullanıcı Tarafı

* Dinamik ana sayfa: slider, öne çıkan destinasyonlar, istatistikler, referanslar
* Destinasyon detay sayfası: tur bilgisi, gün gün program, yorumlar, görsel galerisi
* Kullanıcı girişi zorunlu rezervasyon akışı
* Rezervasyon durumları: **Beklemede / Onaylandı / İptal**
* Rezervasyon sonrası otomatik SMTP onay maili
* Benzersiz `VIT-XXXXXXXX` rezervasyon kodu
* Favori destinasyon ekleme/listeleme
* Kullanıcı yorumu bırakma
* Admin onayı sonrası yorumların yayınlanması

### 🛠️ Admin Paneli

| Modül                         | İşlemler                                                      |
| ----------------------------- | ------------------------------------------------------------- |
| 🏖️ **Destinasyonlar**        | Listeleme, Ekleme, Güncelleme, Silme, **Excel'e Aktarma**     |
| 🖼️ **Vitrin İçerikleri**     | Öne Çıkan (Ana/Izgara), Bilgi Kartları                        |
| 🧑‍💼 **Rehberler**           | Listeleme, Ekleme, Güncelleme, Silme, **Excel'e Aktarma**     |
| ℹ️ **Hakkımızda / Neden Biz** | İçerik yönetimi                                               |
| ⭐ **Yorumlar**                | Listeleme, Onaylama, Silme                                    |
| 💬 **Referanslar**            | Listeleme, Ekleme, Güncelleme, Silme                          |
| ✉️ **Mesajlar**               | Okunan / Okunmayan mesaj yönetimi, otomatik okundu işaretleme |
| 📅 **Rezervasyonlar**         | Onaylama, İptal Etme, **Excel'e Aktarma**                     |
| 👥 **Kullanıcılar**           | Listeleme, Detay Görüntüleme, Silme, **Excel'e Aktarma**      |
| 🛡️ **Roller**                | Rol tanımlama, kullanıcıya rol atama                          |
| 📞 **İletişim Bilgileri**     | Site geneli iletişim bilgisi yönetimi                         |
| 📰 **Bülten Aboneleri**       | Abone listesi görüntüleme                                     |

---

## 📊 Anlık Veriler (SignalR)

Admin panelinde, **SignalR** ile gerçek zamanlı güncellenen istatistik paneli bulunur:

* Toplam destinasyon sayısı
* Toplam rezervasyon sayısı
* Toplam kullanıcı sayısı
* Toplam yorum sayısı
* Toplam favori sayısı
* Toplam referans sayısı
* Onaylanan rezervasyonlar
* Bekleyen rezervasyonlar
* İptal edilen rezervasyonlar
* Her 5 saniyede bir otomatik güncellenen canlı veri akışı

---

## 💱 Piyasa Verileri

**RapidAPI** entegrasyonu ile admin dashboard üzerinde:

* 💵 USD güncel döviz kuru
* 💶 EUR güncel döviz kuru
* 💷 GBP güncel döviz kuru
* 🪙 Gram altın fiyatı
* 🌤️ İstanbul hava durumu bilgisi

---

## 🔐 Kimlik Doğrulama & Yetkilendirme

* ASP.NET Core Identity ile kullanıcı kayıt/giriş sistemi
* Cookie tabanlı authentication
* Rol bazlı yetkilendirme (**Admin / Member**)
* Özelleştirilmiş Identity hata mesajları
* Türkçe hata mesajları
* Kullanıcıya özel profil yönetimi
* Profil fotoğrafı değiştirme
* Ad-soyad değiştirme
* Şifre değiştirme

---

## 📦 Kurulum

### 1. Projeyi Klonlayın

```bash
git clone https://github.com/EmreHaci03/Traversal.git
cd Traversal
```

### 2. Connection String'i Düzenleyin

`Traversal/Traversal.WebUI/appsettings.json` içerisindeki bağlantı dizesini kendi SQL Server ortamınıza göre düzenleyin:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=TraversalDb;Trusted_Connection=True;"
}
```

### 3. Migration'ları Uygulayın

Visual Studio Package Manager Console üzerinden:

```powershell
Update-Database
```

> **Default Project:** `Traversal.WebUI`

### 4. Mail Ayarlarını Tanımlayın

`appsettings.json` içerisinde:

```json
"MailSettings": {
  "SenderName": "TraversalAdmin",
  "SenderEmail": "your@email.com",
  "SenderPassword": "your-app-password",
  "SmtpServer": "smtp.gmail.com",
  "Port": 587
}
```

> ⚠️ Gmail SMTP kullanıyorsanız normal hesap şifreniz yerine **Google Uygulama Şifresi (App Password)** kullanmanız gerekir.

### 5. RapidAPI Ayarlarını Tanımlayın

```json
"RapidApi": {
  "CurrencyKey": "your-currency-api-key",
  "GoldKey": "your-gold-api-key"
}
```

### 6. Projeyi Çalıştırın

```bash
dotnet run --project Traversal.WebUI
```

---

## 📁 Proje Yapısı

```text
Traversal/

├── Traversal.EntityLayer/
│   └── Entities/

├── Traversal.DataAccessLayer/
│   ├── Abstract/
│   ├── Concrete/
│   ├── EntityFramework/
│   └── Repository/

├── Traversal.BusinessLayer/
│   ├── Abstract/
│   ├── Concrete/
│   └── ValidationRules/

├── Traversal.DtoLayer/
│   └── DTOS/

└── Traversal.WebUI/
    ├── Areas/
    │   ├── Admin/
    │   └── Member/
    │
    ├── Controllers/
    ├── ViewComponents/
    ├── SignalRHub/
    │
    ├── CQRS/
    │   ├── Command/
    │   ├── Handler/
    │   └── Result/
    │
    ├── Extensions/
    └── Views/
```

---

## 🎯 Öne Çıkan Özellikler

* ✅ Tam fonksiyonel N-katmanlı mimari + CQRS/MediatR karşılaştırması
* ✅ Admin & Member panel ayrımı (Area Pattern)
* ✅ Gerçek zamanlı veri akışı (SignalR)
* ✅ Otomatik email bildirimi (rezervasyon onayı)
* ✅ FluentValidation ile merkezi doğrulama yönetimi
* ✅ Excel raporlama
* ✅ Destinasyon, Rezervasyon, Kullanıcı ve Rehber Excel çıktıları
* ✅ Dış API entegrasyonu
* ✅ Döviz, altın ve hava durumu verileri
* ✅ Responsive, modern arayüz tasarımı
* ✅ Rol bazlı erişim kontrolü
* ✅ ASP.NET Core Identity
* ✅ AutoMapper
* ✅ Generic Repository Pattern
* ✅ ViewComponent yapısı
* ✅ CQRS / MediatR
* ✅ SMTP / MailKit
* ✅ Özel tasarlanmış 401 / 403 / 404 hata sayfaları

---

<div align="center">

### 👤 Geliştirici

Bu proje, ASP.NET Core ile N-katmanlı mimari, Identity, AutoMapper, SignalR, CQRS/MediatR ve modern web teknolojilerini uygulamalı olarak öğrenmek amacıyla geliştirilmiştir.

</div>
