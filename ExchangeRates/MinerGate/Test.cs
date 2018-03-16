using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRates.MinerGate
{
    public static class Test
    {
        private readonly static MinergateClient MgClient = new MinergateClient();

        //private static void Main(string[] args)
        public static void Main()
        {
            try
            {

                /* Public */

                var profitRating = MgClient.CheckProfitRating();
                var topHashRate = MgClient.CheckTopHashRate();
                var byteCoinBlockChainInfo = MgClient.CheckBlockChainInfo(Coins.ByteCoin);

                /* Requires Authorization */

                var balance = MgClient.CheckBalance();
                var workers = MgClient.CheckWorkers();
                var miningStats = MgClient.CheckMiningStats();
                var transfers = MgClient.CheckTransfers(Coins.ByteCoin);
                var withdrawals = MgClient.CheckWithdrawals(Coins.ByteCoin);
                var affiliateLinks = MgClient.CheckAffiliateLinks();
                var affiliates = MgClient.CheckAffiliates();
                var affiliateProfit = MgClient.CheckAffiliateProfit();
                var invoices = MgClient.CheckInvoices();
                var nickName = MgClient.ReturnNickname();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            //return "";
        }
    }
}
