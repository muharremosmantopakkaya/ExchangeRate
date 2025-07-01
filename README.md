# ExchangeRate

## English

ExchangeRate is a .NET 6 application that retrieves daily currency rates from the Central Bank of the Republic of Turkey. The data is stored in SQL Server and can be accessed through a REST API. An optional MVC web interface allows you to view the rates in a browser.

### Features
- Fetch exchange rate data from the official XML feed
- Persist rates to SQL Server using Entity Framework Core
- Expose endpoints to query stored rates
- Optional MVC front end with WebSocket support
- Background jobs and logging for regular processing

### Quick Start
1. Install the .NET 6 SDK and SQL Server
2. Update the `DefaultConnection` string in `ExchangeRate.API/appsettings.json` and `ExchangeRate.Web/appsettings.json`
3. Restore dependencies and apply migrations:
   ```bash
   dotnet restore
   dotnet ef database update --project ExchangeRate/ExchangeRate.Repository
   ```
4. Run the API:
   ```bash
   dotnet run --project ExchangeRate/ExchangeRate.API
   ```
5. (Optional) Run the web application:
   ```bash
   dotnet run --project ExchangeRate/ExchangeRate.Web
   ```

## Türkçe

ExchangeRate, Türkiye Cumhuriyet Merkez Bankası'ndan günlük döviz kurlarını alıp SQL Server veritabanına kaydeden bir .NET 6 uygulamasıdır. Kayıtlı veriler REST API üzerinden erişilebilir. İsteğe bağlı MVC web arayüzü ile kurları tarayıcıdan görüntüleyebilirsiniz.

### Özellikler
- Resmî XML kaynağından döviz kurları çekme
- Entity Framework Core ile kurları SQL Server'a kaydetme
- Kayıtlı kurlara API uç noktalarıyla erişme
- WebSocket destekli isteğe bağlı MVC arayüzü
- Düzenli işlemler ve loglama için arka plan görevleri

### Hızlı Başlangıç
1. .NET 6 SDK ve SQL Server kurun
2. `ExchangeRate.API/appsettings.json` ve `ExchangeRate.Web/appsettings.json` içindeki `DefaultConnection` değerini düzenleyin
3. Bağımlılıkları yükleyip veritabanı şemasını oluşturun:
   ```bash
   dotnet restore
   dotnet ef database update --project ExchangeRate/ExchangeRate.Repository
   ```
4. API'yi çalıştırın:
   ```bash
   dotnet run --project ExchangeRate/ExchangeRate.API
   ```
5. (Opsiyonel) Web arayüzünü başlatın:
   ```bash
   dotnet run --project ExchangeRate/ExchangeRate.Web
   ```
