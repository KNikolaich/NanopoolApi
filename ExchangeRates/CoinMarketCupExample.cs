using System;
using System.Net;
using System.Web;

namespace ExchangeRates
{
    public static class CSharpExample
    {
        private static string API_KEY = "c9b0d748-1e3c-494c-aeb2-8fcea169a6e5";//"b54bcf4d-1bca-4e8e-9a24-22ff2c3d462c";

        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine(makeAPICall("btc-usd"));
            }
            catch (WebException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }

        static string makeAPICall(string symbols)
        {
            var URL = new UriBuilder($"https://api.cryptonator.com/api/c/{symbols}");

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["symbol"] = "BTC,ETH,XMR";
            /*queryString["start"] = "1";
            queryString["limit"] = "12";
            queryString["cryptocurrency_type"] = "coins";
            queryString["convert"] = "RUB";
            */
            //URL.Query = queryString.ToString();

            var client = new WebClient();
            //client.Headers.Add("X-CMC_PRO_API_KEY", API_KEY);
            client.Headers.Add("Accepts", "application/json");
            return client.DownloadString(URL.ToString());
        }

        static string makeAPICall()
        {
            var URL = new UriBuilder("https://pro-api.coinmarketcap.com/v1/cryptocurrency/market-pairs/latest");

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["symbol"] = "BTC,ETH,XMR";
            /*queryString["start"] = "1";
            queryString["limit"] = "12";
            queryString["cryptocurrency_type"] = "coins";
            queryString["convert"] = "RUB";
            */
            URL.Query = queryString.ToString();

            var client = new WebClient();
            client.Headers.Add("X-CMC_PRO_API_KEY", API_KEY);
            client.Headers.Add("Accepts", "application/json");
            return client.DownloadString(URL.ToString());
        }
    }
}