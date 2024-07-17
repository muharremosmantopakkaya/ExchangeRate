using ExchangeRate.Core.Services;
using ExchangeRate.Service.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ExchangeRate.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExchangeRatesController : ControllerBase
    {
        private readonly IExchangeRateService _exchangeRateService;

        public ExchangeRatesController(IExchangeRateService exchangeRateService)
        {
            _exchangeRateService = exchangeRateService;
        }

        [HttpPost("fetch")]
        public async Task<IActionResult> FetchAndSaveExchangeRates()
        {
            try
            {
                await _exchangeRateService.FetchAndSaveExchangeRatesAsync();
                return Ok("Exchange rates fetched and saved successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred during operations. Please try again later.", Error = ex.Message });
            }
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllExchangeRates()
        {
            try
            {
                var exchangeRates = await _exchangeRateService.GetAllExchangeRatesAsync();
                return Ok(exchangeRates);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred during operations. Please try again later.", Error = ex.Message });
            }
        }
    }
}
