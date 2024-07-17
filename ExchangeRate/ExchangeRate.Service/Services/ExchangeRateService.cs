using ExchangeRate.Core.DbModels;
using ExchangeRate.Core.Repositories;
using ExchangeRate.Core.UnitOfWork;
using ExchangeRate.Core.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Globalization;

namespace ExchangeRate.Service.Services
{
    public class ExchangeRateService : IExchangeRateService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExchangeRateService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task FetchAndSaveExchangeRatesAsync()
        {
            string url = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var exchangeRates = await GetExchangeRatesAsync(url);

            if (exchangeRates == null || !exchangeRates.Any())
            {
                // Log an error message or throw an exception
                throw new Exception("No exchange rates were retrieved.");
            }

            foreach (var rate in exchangeRates)
            {
                await _unitOfWork.ExchangeRates.AddAsync(rate);
            }

            await _unitOfWork.CompleteAsync();
        }


        public async Task<IEnumerable<ExchangeRate.Core.DbModels.ExchangeRate>> GetAllExchangeRatesAsync()
        {
            return await _unitOfWork.ExchangeRates.GetAllAsync();
        }

        private async Task<List<ExchangeRate.Core.DbModels.ExchangeRate>> GetExchangeRatesAsync(string url)
        {
            using HttpClient client = new HttpClient();
            string response = await client.GetStringAsync(url);
            var xdoc = XDocument.Parse(response);

            var rates = xdoc.Descendants("Currency").Select(x =>
            {
                try
                {
                    var exchangeRate = new ExchangeRate.Core.DbModels.ExchangeRate
                    {
                        CurrencyCode = x.Attribute("CurrencyCode")?.Value,
                        Unit = x.Element("Unit") != null ? int.Parse(x.Element("Unit").Value) : 0,
                        Isim = x.Element("Isim")?.Value,
                        CurrencyName = x.Element("CurrencyName")?.Value,
                        ForexBuying = x.Element("ForexBuying") != null ? decimal.Parse(x.Element("ForexBuying").Value, System.Globalization.CultureInfo.InvariantCulture) : 0,
                        ForexSelling = x.Element("ForexSelling") != null ? decimal.Parse(x.Element("ForexSelling").Value, System.Globalization.CultureInfo.InvariantCulture) : 0,
                        BanknoteBuying = x.Element("BanknoteBuying") != null ? decimal.Parse(x.Element("BanknoteBuying").Value, System.Globalization.CultureInfo.InvariantCulture) : 0,
                        BanknoteSelling = x.Element("BanknoteSelling") != null ? decimal.Parse(x.Element("BanknoteSelling").Value, System.Globalization.CultureInfo.InvariantCulture) : 0,
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now
                    };
                    return exchangeRate;
                }
                catch (Exception ex)
                {
                    // Log exception or handle it as needed
                    // For now, return null to skip this entry
                    return null;
                }
            }).Where(rate => rate != null).ToList();

            return rates;
        }

        private int ParseInt(string value)
        {
            if (int.TryParse(value, out int result))
            {
                return result;
            }
            return 0;
        }

        private decimal ParseDecimal(string value)
        {
            if (decimal.TryParse(value, out decimal result))
            {
                return result;
            }
            return 0;
        }

    }
}
