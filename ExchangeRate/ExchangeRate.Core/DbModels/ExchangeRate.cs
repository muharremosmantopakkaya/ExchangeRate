﻿using System;

namespace ExchangeRate.Core.DbModels
{
    [Serializable]
    public class ExchangeRate : BaseEntity
    {
        public string CurrencyCode { get; set; }
        public int Unit { get; set; }
        public string Isim { get; set; }
        public string CurrencyName { get; set; }
        public decimal ForexBuying { get; set; }
        public decimal ForexSelling { get; set; }
        public decimal BanknoteBuying { get; set; }
        public decimal BanknoteSelling { get; set; }
    }
}
