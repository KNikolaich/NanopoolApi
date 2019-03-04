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
                    var URL = new UriBuilder(url);
                    var API_KEY =
                        "v1551691809768%2Fv3394bd9fdd620f60a9c678163aeca6afa04ab3%2F5seg8oRKkJfvGxyJHpu4MQ%3d%3d&fa821dba_ipp_uid=1551691643283%2frOqD8su5kmRivQ8k%2fW1dwddfnMPOhhv4dC7Qfpw%3d%3d&fa821dba_ipp_uid2=rOqD8su5kmRivQ8k%2fW1dwddfnMPOhhv4dC7Qfpw%3d%3d&fa821dba_ipp_uid1=1551691643283";
                    
                    var queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);
                    queryString["fa821dba_ipp_key"] = API_KEY;
                    URL.Query = queryString.ToString();

                    client.Headers.Add("fa821dba_ipp_key", API_KEY);
                    client.Headers.Add("Accepts", "application/json");
                    
                    var response = client.DownloadString(URL.ToString());
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
