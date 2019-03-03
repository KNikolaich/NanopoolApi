using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRates
{
    public class Statics
    {
        public static readonly string CurrencyTypeeHolder = "<<CurrencyType>>/";
        private static readonly string BaseCoinMarketApiUrl = $"https://api.coinmarketcap.com/v1/";
        public static readonly string TickersFromCoinMarket = BaseCoinMarketApiUrl + $"ticker/{CurrencyTypeeHolder}"; //address

        public static readonly string MinerGateHost = "https://api.minergate.com/1.0";
        public static readonly string MinergateLoginUrl = $"{MinerGateHost}/auth/login";
        public static readonly string YourEmailAddress = "kirill.nikolaich@yandex.ru";
        public static readonly string YourPassword = "P@s$w0rD~!";
        
    }
}
