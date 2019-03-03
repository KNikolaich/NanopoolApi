
using Newtonsoft.Json;

namespace ExchangeRates.Croptonator
{
    public class TickerContayner
    {
        public Ticker ticker { get; set; }
        public string timestamp { get; set; }
        public bool success { get; set; }
        public string error { get; set; }
    }

    public class Ticker
    {
        [JsonProperty("base")]
        public string Base { get; set; }
        public string target { get; set; }
        public double price { get; set; }
        public double volume { get; set; }
        public double change { get; set; }
    }
}
