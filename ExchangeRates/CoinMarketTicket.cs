using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRates
{
    public class CoinMarketTicket
    {
        public string id { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public int rank { get; set; }
        public double price_usd { get; set; }
        public double price_btc { get; set; }
        //public double 24h_volume_usd { get; set; }
        //market_cap_usd	"155326299442"
        //available_supply	"16916925.0"
        //total_supply	"16916925.0"
        //max_supply	"21000000.0"
        //percent_change_1h	"1.59"
        //percent_change_24h	"-5.25"
        //percent_change_7d	"-16.76"
        public long last_updated { get; set; }
    }
}
