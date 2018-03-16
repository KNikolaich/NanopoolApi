using Newtonsoft.Json.Linq;

namespace ExchangeRates.MinerGate
{
    public class MinergateClient
    {
        private static string _baseUrlApi = Statics.MinerGateHost;
        private static readonly WebRequests Wr = new WebRequests();
        private static string _token = string.Empty;

        public MinergateClient()
        {
            _token = Wr.Login(null)["token"].ToString();
        }

        public MinergateClient(int totp)
        {
            _token = Wr.Login(totp)["token"].ToString();
        }

        /* Requires Authorization */

        public JObject CheckBalance()
        {
            return Wr.GetObject(_token, _baseUrlApi, EndPoints.Balance);
        }

        public JObject CheckWorkers()
        {
            return Wr.GetObject(_token, _baseUrlApi, EndPoints.Workers);
        }

        public JObject CheckMiningStats()
        {
            return Wr.GetObject(_token, _baseUrlApi, EndPoints.MiningStats);
        }

        public JArray CheckTransfers(string coin)
        {
            return Wr.GetArray(_token, _baseUrlApi, EndPoints.Transfers(coin));
        }

        public JArray CheckWithdrawals(string coin)
        {
            return Wr.GetArray(_token, _baseUrlApi, EndPoints.Withdrawals(coin));
        }

        public JObject CheckAffiliateLinks()
        {
            return Wr.GetObject(_token, _baseUrlApi, EndPoints.AffiliateLinks);
        }

        public JObject CheckAffiliates()
        {
            return Wr.GetObject(_token, _baseUrlApi, EndPoints.Affiliates);
        }

        public JObject CheckAffiliateProfit()
        {
            return Wr.GetObject(_token, _baseUrlApi, EndPoints.AffiliateProfit);
        }

        public JArray CheckInvoices()
        {
            return Wr.GetArray(_token, _baseUrlApi, EndPoints.Invoices);
        }

        public string ReturnNickname()
        {
            return Wr.GetString(_token, _baseUrlApi, EndPoints.Nickname);
        }

        /* Public */

        public JArray CheckProfitRating()
        {
            return Wr.GetArray(string.Empty, _baseUrlApi, EndPoints.ProfitRating);
        }

        public JObject CheckTopHashRate()
        {
            return Wr.GetObject(string.Empty, _baseUrlApi, EndPoints.TopHashRate);
        }

        public JObject CheckBlockChainInfo(string coin)
        {
            return Wr.GetObject(string.Empty, _baseUrlApi, EndPoints.BlockChainInfo(coin));
        }
    }
}
