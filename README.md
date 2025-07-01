# ExchangeRate

ExchangeRate is a .NET Core solution that downloads daily currency rates from the Central Bank of the Republic of Turkey and stores them in a SQL Server database. The project exposes a REST API and an optional MVC web application for viewing the data.

## Project Overview
This solution consists of several projects including an API (`ExchangeRate.API`), a web application (`ExchangeRate.Web`), core library and repository layers. The `ExchangeRateService` retrieves the XML data, parses it and saves the results through Entity Framework Core.

## Features
- Fetch exchange rate data from the Central Bank XML feed
- Persist rates to the database via EF Core
- Retrieve saved data through a REST API
- Optional MVC UI with WebSocket support

## Technologies Used
- .NET 6
- ASP.NET Core
- Entity Framework Core
- SQL Server
- AutoMapper

## Getting Started
1. Install the .NET 6 SDK and a SQL Server instance.
2. Update the `DefaultConnection` string in `ExchangeRate.API/appsettings.json` and `ExchangeRate.Web/appsettings.json` to match your environment.
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

## API Endpoints
- `POST /api/exchangerates/fetch` - Fetch the latest rates and store them
- `GET /api/exchangerates/all` - List all stored rates

The project logs operations and includes background workers for regular processing.
