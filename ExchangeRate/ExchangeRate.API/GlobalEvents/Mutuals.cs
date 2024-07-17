using ExchangeRate.Helpers.Models.CustomModels;
using ExchangeRate.Logging.Methods;

namespace ExchangeRate.API.GlobalEvents
{
    public static class Mutuals
    {
        public static Setting settings { get; set; } = new Setting();
    }
}
