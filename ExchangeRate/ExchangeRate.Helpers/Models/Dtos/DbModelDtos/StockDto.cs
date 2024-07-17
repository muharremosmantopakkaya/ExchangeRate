using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ExchangeRate.Core.DbModels
{
    public class StockDto
    {
        public string Symbol { get; set; } = "";
        public string Name { get; set; } = "";
        public double Price { get; set; }
        public double Change { get; set; }
    }
}

