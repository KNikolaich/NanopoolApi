using System;
using System.Collections.Generic;
using System.IO;
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
            var ticker = TickerContayner(symbol, out var error);
            return string.IsNullOrEmpty(error) ? ticker.ticker : null;
        }

        public TickerContayner TickerContayner(string symbol, out string error)
        {
            error = null;
            string url = $"{EndPoint}{Ticker}/{symbol}";
            Console.WriteLine(url);
            try
            {
                HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);
                request.AutomaticDecompression = DecompressionMethods.GZip;

                string html;
                using (HttpWebResponse response = (HttpWebResponse) request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        html = reader.ReadToEnd();
                    }
                }
                Console.WriteLine(html);
                
                return JsonConvert.DeserializeObject<TickerContayner>(html);
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return null;
        }
    }
}
