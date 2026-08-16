# 🌍 Traversal — Seyahat & Tur Rezervasyon Platformu

.NET Core • SQL Server • Entity Framework Core • Identity • AutoMapper • SignalR • FluentValidation • MediatR

Modern, dinamik ve kullanıcı dostu bir seyahat & tur rezervasyon platformu.

---

## 📸 Ekran Görüntüleri

### 🌍 Kullanıcı Arayüzü

**Ana Sayfa**
![Ana Sayfa](wwwroot/images/Ana%20Sayfa.png)
![Ana Sayfa 2](wwwroot/images/Ana%20Sayfa%202.png)
![Ana Sayfa 3](wwwroot/images/Ana%20Sayfa%203.png)

**Destinasyonlar**
![Destinasyonlar](wwwroot/images/Destinasyonlar.png)

**Destinasyon Detay**
![Destinasyon Detay](wwwroot/images/Destinasyon%20Detay.png)
![Destinasyon Detay 2](wwwroot/images/Destinasyon%20Detay%202.png)

**Hakkımızda**
![Hakkımızda](wwwroot/images/Hakkımızda.png)
![Hakkımızda 2](wwwroot/images/Hakkımızda%202.png)

**İletişim**
![İletişim](wwwroot/images/İletişim.png)

### 👤 Üye Paneli

**Üye Dashboard**
![Member Dashboard](wwwroot/images/Member%20Dashboard.png)

**Profil Ekranı**
![Üye Profil Ekranı](wwwroot/images/Üye%20Profil%20Ekranı.png)

**Rezervasyon**
![Üye Rezervasyon](wwwroot/images/Üye%20Rezervasyon.png)

**Aktif Tur Listesi**
![Üye Aktif Tur Liste](wwwroot/images/Üye%20Aktif%20Tur%20Liste.png)

**Favori Destinasyonlar**
![Üye Favori Destinasyon](wwwroot/images/Üye%20Favori%20Destinasyon.png)

**Yorum Listesi**
![Üye Yorum Listesi](wwwroot/images/Üye%20Yorum%20Listesi.png)

### 🛠️ Admin Paneli

**Dashboard**
![Admin Dashboard](wwwroot/images/Admin%20Dashboard.png)

**SignalR Anlık Veriler**
![Admin SignalR Anlık Veri](wwwroot/images/Admin%20SignalR%20Anlık%20Veri.png)

**Destinasyon Listesi**
![Admin Destinasyon Liste](wwwroot/images/Admin%20Destinasyon%20Liste.png)

**Rezervasyon Listesi**
![Admin Rezervasyon Liste](wwwroot/images/Admin%20Rezervasyon%20Liste.png)

**Kullanıcılar**
![Admin Kullanıcılar](wwwroot/images/Admin%20Kullanıcılar.png)

**Roller**
![Admin Roller](wwwroot/images/Admin%20Roller.png)

### ⚠️ Hata Sayfaları

| 401 | 403 | 404 |
|---|---|---|
| ![401](wwwroot/images/401%20Sayfası.png) | ![403](wwwroot/images/403%20Sayfası.png) | ![404](wwwroot/images/404%20Sayfası.png) |

---

## 📌 Proje Hakkında

**Traversal**, seyahat acenteleri ve bireysel kullanıcılar için geliştirilmiş, N-katmanlı mimari üzerine kurulu full-stack bir web uygulamasıdır. SQL Server tabanlı ilişkisel veritabanı ile dinamik içerik yönetimi sunar; hem kullanıcı arayüzü hem de admin paneli tarafında eksiksiz çalışan işlevsel bir sistem sağlar.

### Temel Hedefler

- 🧳 Kullanıcıların tur listesini görüntüleyip rezervasyon yapabilmesi
- 🛠️ Admin panel üzerinden tüm içeriklerin yönetilebilmesi
- 📧 Rezervasyon sonrası otomatik onay maili gönderimi
- 📊 Anlık istatistiklerin SignalR ile canlı takibi
- 💱 Güncel döviz kuru ve hava durumu entegrasyonu

---

## 🖥️ Kullanıcı Arayüzü

### 🗺️ Ana Sayfa & Tur Vitrini

- Dinamik ana slider, öne çıkan destinasyonlar, istatistik alanı
- Tüm tur verileri, kategori ve fiyat bilgileri veritabanından dinamik olarak çekilir
- "Neden Biz", "Hakkımızda", referanslar ve bilgi kartları dinamik içerik olarak yönetilir

### 📄 Destinasyon Detay Sayfası

| Bölüm | İçerik |
|---|---|
| 📋 Tur Bilgileri | Kapasite, süre, fiyat ve genel açıklama |
| 🗓️ Tur Planı | Gün gün program (Details1 / Details2) |
| ⭐ Yorumlar | Kullanıcı yorumları, admin onayından geçmiş içerikler |
| 🖼️ Galeri | Tura özel fotoğraf görselleri (Image / CoverImage / Image2) |

### 🎟️ Rezervasyon Akışı

- Kullanıcı girişi zorunlu, kişi sayısına göre rezervasyon oluşturma
- Rezervasyon durumu takibi: **Beklemede / Onaylandı / İptal**
- Rezervasyon oluşturulduğunda kullanıcıya otomatik onay maili (SMTP - MailKit)
- Benzersiz rezervasyon kodu üretimi (`VIT-XXXXXXXX`)

### ❤️ Favoriler

- Kullanıcılar beğendikleri destinasyonları favorilere ekleyip listeleyebilir
- Aynı destinasyonun tekrar favoriye eklenmesini önleyen kontrol mekanizması

---

## 🛠️ Admin Paneli

Sıfırdan tasarlanmış, modern ve responsive bir yönetim arayüzü.

### CRUD Yönetimi

| Modül | İşlemler |
|---|---|
| 🏖️ Destinasyonlar | Listeleme, Ekleme, Güncelleme, Silme, Excel'e Aktarma |
| 🖼️ Vitrin İçerikleri | Öne Çıkan (Ana/Izgara), Bilgi Kartları |
| 🧑‍💼 Rehberler | Listeleme, Ekleme, Güncelleme, Silme, Excel'e Aktarma |
| ℹ️ Hakkımızda / Neden Biz | İçerik yönetimi |
| ⭐ Yorumlar | Listeleme, Onaylama, Silme |
| 💬 Referanslar | Listeleme, Ekleme, Güncelleme, Silme |
| ✉️ Mesajlar | Okunan / Okunmayan mesaj yönetimi, otomatik okundu işaretleme |
| 📅 Rezervasyonlar | Onaylama, İptal Etme, Excel'e Aktarma |
| 👥 Kullanıcılar | Listeleme, Detay Görüntüleme, Silme, Excel'e Aktarma |
| 🛡️ Roller | Rol tanımlama, kullanıcıya rol atama |
| 📞 İletişim Bilgileri | Site geneli iletişim bilgisi yönetimi |
| 📰 Bülten Aboneleri | Abone listesi görüntüleme |

### 📊 Anlık Veriler (SignalR)

Admin panelinde, **SignalR** ile gerçek zamanlı güncellenen istatistik paneli:

- Toplam destinasyon, rezervasyon, kullanıcı, yorum, favori ve referans sayıları
- Onaylanan / Bekleyen / İptal edilen rezervasyon dağılımı
- Her 5 saniyede bir otomatik güncellenen canlı veri akışı

### 💱 Piyasa Verileri

RapidAPI entegrasyonu ile dashboard üzerinde:

- USD, EUR, GBP güncel döviz kurları
- Gram altın fiyatı
- İstanbul hava durumu bilgisi

### 📈 Raporlama

- **ClosedXML** ile Excel raporu indirme (Destinasyonlar, Rezervasyonlar, Kullanıcılar)
- Her liste sayfasında özet istatistik kartları

---

## ⚙️ Teknik Altyapı

### Mimari

```
Traversal.EntityLayer      → Veritabanı varlıkları (Entities)
Traversal.DataAccessLayer  → Generic Repository Pattern, EF Core
Traversal.BusinessLayer    → Servisler, FluentValidation kuralları
Traversal.DtoLayer         → Data Transfer Object'ler
Traversal.WebUI            → MVC Controller'lar, View'lar, Area yapısı
```

### Kullanılan Teknolojiler

| Katman | Teknoloji |
|---|---|
| Backend | ASP.NET Core MVC (.NET 6) |
| Veritabanı | SQL Server, Entity Framework Core |
| Kimlik Doğrulama | ASP.NET Core Identity (Custom Error Describer ile) |
| Nesne Eşleme | AutoMapper |
| Doğrulama | FluentValidation |
| Gerçek Zamanlı İletişim | SignalR |
| Mail Gönderimi | MailKit / MimeKit (SMTP) |
| Excel İşlemleri | ClosedXML |
| PDF İşlemleri | QuestPDF |
| Frontend | HTML5, CSS3, JavaScript, jQuery |
| Dış API Entegrasyonu | RapidAPI (Döviz, Altın, Hava Durumu) |

### Mimari Prensipler

- **N-Katmanlı Mimari** — Generic Repository Pattern ile DAL/Service ayrımı
- **Area Yapısı** — Admin ve Member panelleri birbirinden bağımsız, izole modüller
- **AutoMapper** — Entity ↔ DTO dönüşümlerinde tutarlı ve merkezi mapping yönetimi
- **FluentValidation** — İş kurallarının Business Layer'da, DTO'lardan bağımsız yönetimi
- **ViewComponent Kullanımı** — Yeniden kullanılabilir, veri odaklı UI parçaları (yorum listesi, öne çıkan içerikler)
- **CQRS & MediatR** — Destinasyon modülü, Command/Query ayrımı ve MediatR pipeline'ı ile geliştirilmiştir; klasik Service katmanına alternatif bir yaklaşımın uygulamalı denemesi olarak projeye entegre edilmiştir

### CQRS / MediatR Kullanımı

Projede genel CRUD işlemleri klasik **Service Layer** yaklaşımıyla yönetilirken, **Destinasyon** modülü bilinçli olarak **CQRS (Command Query Responsibility Segregation)** prensibiyle, **MediatR** kütüphanesi kullanılarak ayrıca geliştirilmiştir:

```
Traversal.WebUI/CQRS/
├── Command/      → Create/Update işlemlerini temsil eden komut nesneleri
├── Handler/      → Command/Query'leri işleyen handler sınıfları
└── Result/       → Query sonuçlarını taşıyan result nesneleri
```

- `IRequestHandler<TRequest, TResponse>` implementasyonları ile okuma (Query) ve yazma (Command) sorumlulukları ayrıştırılmıştır
- Controller katmanı, `IMediator.Send(...)` üzerinden ilgili handler'a yönlendirme yapar
- Bu yapı, aynı proje içinde **hem klasik N-katmanlı mimarinin hem de CQRS yaklaşımının karşılaştırmalı olarak uygulanması** amacıyla tercih edilmiştir

---

## 🔐 Kimlik Doğrulama & Yetkilendirme

- ASP.NET Core Identity ile kullanıcı kayıt/giriş sistemi
- Cookie tabanlı authentication
- Rol bazlı yetkilendirme (Admin / Member)
- Özelleştirilmiş Identity hata mesajları (Türkçe)
- Kullanıcıya özel profil yönetimi (fotoğraf, ad-soyad, şifre değişikliği)

---

## 📦 Kurulum

```bash
# Depoyu klonlayın
git clone https://github.com/kullaniciadi/traversal.git

# Proje dizinine gidin
cd traversal

# appsettings.json içindeki bağlantı dizesini kendi SQL Server'ınıza göre düzenleyin
"ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=TraversalDb;Trusted_Connection=True;"
}

# Migration'ları uygulayın (Package Manager Console, Default Project: Traversal.WebUI)
Update-Database

# Mail ayarlarını appsettings.json içinde tanımlayın
"MailSettings": {
    "SenderName": "TraversalAdmin",
    "SenderEmail": "your@email.com",
    "SenderPassword": "your-app-password",
    "SmtpServer": "smtp.gmail.com",
    "Port": 587
}

# Projeyi çalıştırın
dotnet run --project Traversal.WebUI
```

> **Not:** Gmail SMTP kullanıyorsanız, normal hesap şifreniz yerine [Google Uygulama Şifresi](https://myaccount.google.com/apppasswords) oluşturmanız gerekmektedir.

---

## 📁 Proje Yapısı

```
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
    ├── Controllers/
    ├── ViewComponents/
    ├── SignalRHub/
    ├── Extensions/
    └── Views/
```

---

## 🎯 Öne Çıkan Özellikler

- ✅ Tam fonksiyonel N-katmanlı mimari
- ✅ Admin & Member panel ayrımı (Area Pattern)
- ✅ Gerçek zamanlı veri akışı (SignalR)
- ✅ Otomatik email bildirimi (rezervasyon onayı)
- ✅ FluentValidation ile merkezi doğrulama yönetimi
- ✅ Excel raporlama
- ✅ Dış API entegrasyonu (döviz, altın, hava durumu)
- ✅ Responsive, modern arayüz tasarımı
- ✅ Rol bazlı erişim kontrolü

---

## 👤 Geliştirici

Bu proje, ASP.NET Core ile N-katmanlı mimari, Identity, AutoMapper ve modern web teknolojilerini uygulamalı olarak öğrenmek amacıyla geliştirilmiştir.

---

## 📄 Lisans

Bu proje eğitim amaçlı geliştirilmiştir.
