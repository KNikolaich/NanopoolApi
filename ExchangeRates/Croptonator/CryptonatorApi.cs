using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;

namespace ExchangeRates.Croptonator
{
    public class CryptonatorApi
    {
        private const string EndPoint = "https://api.cryptonator.com/api/";
        private const string Ticker = "ticker";

        public Ticker GetTicker(string symbol)
        {
            string error = "";
            var ticker = TickerContayner(symbol, ref error);
            if (string.IsNullOrEmpty(error))
                return ticker.ticker;
            return null;
        }

        public TickerContayner TickerContayner(string symbol, ref string error)
        {
            return LoadResponse<TickerContayner>(symbol, ref error);
        }



        private T LoadResponse<T>(string symbol, ref string error)
        {
            error = null;

            string url = $"{EndPoint}{Ticker}/{symbol}";

            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentNullException(nameof(url));
            }

            try
            {
                using (var client = new WebClient())
                {
                    var response = client.DownloadString(new Uri(url));

                    if (!string.IsNullOrWhiteSpace(response))
                    {
                        return JsonConvert.DeserializeObject<T>(response);
                    }
                }
            }
            catch (Exception e)
            {
                error = e.Message;
            }

            return default(T);
        }
    }
}
