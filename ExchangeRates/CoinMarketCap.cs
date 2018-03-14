using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace ExchangeRates
{
    public class CoinMarketCap
    {

        public CoinMarketCap() : this(CurrencyTypeEnum.undefine)
        {
        }

        public CoinMarketCap(CurrencyTypeEnum type)
        {
            CurrencyType = type;
        }

        public CurrencyTypeEnum CurrencyType { get; set; }

        public List<CoinMarketTicket> GetAllTickets()
        {
            var error = string.Empty;
            CurrencyType = CurrencyTypeEnum.undefine;
            var result = LoadResponse<List<CoinMarketTicket>>(Statics.Tickers, ref error);

            if (!string.IsNullOrWhiteSpace(error) && result == null)
            {
                result = CastToChild<List<CoinMarketTicket>>(GetErrorResponse(error));
            }
            var valuesEnum = Enum.GetNames(typeof(CurrencyTypeEnum)).ToList();

            return result.Where(ticket => valuesEnum.Contains(ticket.id)).ToList();
        }

        public CoinMarketTicket GetTicket(CurrencyTypeEnum type)
        {

            var error = string.Empty;
            CurrencyType = type;
            var result = LoadResponse<List<CoinMarketTicket>>(Statics.Tickers, ref error);

            if (!string.IsNullOrWhiteSpace(error) && result == null)
            {
                result = CastToChild<List<CoinMarketTicket>>(GetErrorResponse(error));
            }

            return result.FirstOrDefault();
        }

        private T LoadResponse<T>(string url, ref string error)
        {
            error = null;

            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentNullException(nameof(url));
            }

            url = url.Replace(Statics.CurrencyTypeeHolder, CurrencyType != CurrencyTypeEnum.undefine? CurrencyType + "/" : "");

            try
            {
                using (var client = new WebClient())
                {
//                    if (Proxy != null)
//                    {
//                        WebRequest.DefaultWebProxy = Proxy;
//                        client.Proxy = Proxy;
//                    }

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

        private static T CastToChild<T>(Response response)
        {
            var serializedParent = JsonConvert.SerializeObject(response);
            return JsonConvert.DeserializeObject<T>(serializedParent);
        }

        private static Response GetErrorResponse(string error)
        {
            return new Response
            {
                Status = false,
                Error = error
            };
        }
    }
}
