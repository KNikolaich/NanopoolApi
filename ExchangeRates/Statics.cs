using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRates
{
    public class Statics
    {

        public static readonly string CurrencyTypeeHolder = "<<CurrencyType>>/";
        private static readonly string BaseApiUrl = $"https://api.coinmarketcap.com/v1/";
        public static readonly string Tickers = BaseApiUrl + $"ticker/{CurrencyTypeeHolder}"; //address

    }
}
