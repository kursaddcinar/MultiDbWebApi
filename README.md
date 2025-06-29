# MultiDbWebApi

Bu proje, çoklu veritabanı desteği olan bir ASP.NET Core Web API projesidir. JWT (JSON Web Token) tabanlı kimlik doğrulama sistemi içerir ve farklı veritabanlarından veri çekmek için stored procedure'lar kullanır.

## 🚀 Özellikler

- **Çoklu Veritabanı Desteği**: TestDB ve FERPEX veritabanları
- **JWT Authentication**: Güvenli token tabanlı kimlik doğrulama
- **Stored Procedure Desteği**: Veritabanı işlemleri için stored procedure kullanımı
- **Repository Pattern**: Temiz kod yapısı için repository pattern implementasyonu
- **Swagger/OpenAPI**: API dokümantasyonu için Swagger entegrasyonu

## 📋 Gereksinimler

- .NET 8.0
- SQL Server
- Visual Studio 2022 veya Visual Studio Code

## 🛠️ Kurulum

### 1. Projeyi Klonlayın
```bash
git clone [repository-url]
cd MultiDbWebApi
```

### 2. Bağımlılıkları Yükleyin
```bash
dotnet restore
```

### 3. Veritabanı Bağlantısını Yapılandırın
`appsettings.json` dosyasını oluşturun ve veritabanı bağlantı stringlerini ekleyin:

```json
{
  "ConnectionStrings": {
    "TestDBConnection": "Server=your-server;Database=TESTDB;User Id=your-user;Password=your-password;Trusted_Connection=False;MultipleActiveResultSets=true;TrustServerCertificate=True",
    "FERPEXConnection": "Server=your-server;Database=FERPEX;User Id=your-user;Password=your-password;Trusted_Connection=False;MultipleActiveResultSets=true;TrustServerCertificate=True"
  },
  "JwtSettings": {
    "SecretKey": "your-super-secret-key-at-least-32-characters-long",
    "Issuer": "your-issuer",
    "Audience": "your-audience",
    "ExpirationHours": 1
  }
}
```

### 4. Projeyi Çalıştırın
```bash
dotnet run
```

API varsayılan olarak `https://localhost:7001` ve `http://localhost:5001` adreslerinde çalışacaktır.

## 🔐 Kimlik Doğrulama

### JWT Token Alma
```http
POST /api/auth/login
Content-Type: application/json

{
  "kulAdi": "test1",
  "kulSifre": "1234",
  "extraParam": "admin"
}
```

**Başarılı Yanıt:**
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
}
```

### Korumalı Endpoint'lere Erişim
Token'ı Authorization header'ında Bearer token olarak gönderin:

```http
GET /api/TBLDEPOSAYIMREHBER/protected-example
Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...
```

## 📚 API Endpoint'leri

### Kimlik Doğrulama
- `POST /api/auth/login` - Kullanıcı girişi ve JWT token alma

### Veritabanı İşlemleri
- `GET /api/TBLUSERS` - Kullanıcı listesi
- `GET /api/TBLCARISB` - Cari hesap listesi
- `GET /api/TBLSTOKSB` - Stok listesi
- `GET /api/TBLBANKASB` - Banka listesi
- `GET /api/TBLKASASB` - Kasa listesi
- `GET /api/TBLCEKSENET` - Çek/Senet listesi
- `GET /api/TBLRECETESB` - Reçete listesi
- `GET /api/TBLISEMRISB` - İş emri listesi
- `GET /api/TBLURETIM` - Üretim listesi
- `GET /api/TBLDEPOSB` - Depo listesi

### Detay Endpoint'leri
- `GET /api/TBLCARIHR/{cariKod}` - Cari hesap detayları
- `GET /api/TBLSTOKHR/{stokKod}` - Stok detayları
- `GET /api/TBLBANKAHR/{bankaKod}` - Banka detayları
- `GET /api/TBLKASAHR/{kasaKod}` - Kasa detayları
- `GET /api/TBLRECETEHR/{receteKod}` - Reçete detayları
- `GET /api/TBLISEMRIHR/{isEmriKod}` - İş emri detayları
- `GET /api/TBLURETIM2/{uretimKod}` - Üretim detayları

### Rehber Endpoint'leri
- `GET /api/TBLSTOKREHBER` - Stok rehberi
- `GET /api/TBLCARIREHBER` - Cari rehberi
- `GET /api/TBLDEPOSAYIMREHBER` - Depo sayım rehberi

## 🧪 Test Kullanıcıları

Proje içinde test amaçlı fake kullanıcılar bulunmaktadır:

| Kullanıcı Adı | Şifre | Rol |
|---------------|-------|-----|
| test1 | 1234 | admin |
| test2 | 5678 | user |

## 📖 Swagger Dokümantasyonu

Proje çalıştığında Swagger UI'a şu adresten erişebilirsiniz:
- `https://localhost:7001/swagger`
- `http://localhost:5001/swagger`

## 🏗️ Proje Yapısı

```
MultiDbWebApi/
├── Controllers/          # API Controller'ları
├── Data/                # DbContext sınıfları
├── Models/              # Veri modelleri
├── Repositories/        # Repository pattern implementasyonu
├── Program.cs           # Uygulama konfigürasyonu
└── README.md           # Bu dosya
```

## 🔧 Konfigürasyon

### JWT Ayarları
JWT token ayarları `Program.cs` dosyasında yapılandırılır:

```csharp
var key = Encoding.ASCII.GetBytes("your-secret-key");
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero
    };
});
```

## 🚨 Güvenlik Notları

1. **Production ortamında**:
   - Güçlü bir secret key kullanın (en az 32 karakter)
   - HTTPS kullanın
   - Veritabanı bağlantı stringlerini güvenli şekilde saklayın
   - Token sürelerini uygun şekilde ayarlayın

2. **Hassas bilgiler**:
   - `appsettings.json` dosyasını git'e commit etmeyin
   - Gerçek veritabanı bilgilerini kod içinde saklamayın
   - Environment variables veya Azure Key Vault kullanın
   
3. **Stored Procedure İsimleri**:
   -  Bu projede bazı stored procedure isimleri (`FPROCBANKLIST`, `FPROCOPRSAVE` vb.) gösterilmiştir. Bunlar sadece örnek amaçlıdır ve iç yapıları veya içerikleri paylaşılmamaktadır. Gerçek veritabanı şeması veya prosedür içeriği açıklanmamıştır.

## 📄 Lisans

Bu proje [MIT License](LICENSE) altında lisanslanmıştır.

## 📞 İletişim

Proje ile ilgili sorularınız için issue açabilirsiniz. 