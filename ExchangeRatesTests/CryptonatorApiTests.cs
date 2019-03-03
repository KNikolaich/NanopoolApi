using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExchangeRates;
using ExchangeRates.Croptonator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExchangeRatesTests
{
    [TestClass]
    public class CryptonatorApiTests
    {
        [TestMethod]
        public void CryptonatorApi_OneTicket_BitCoin_Usd()
        {
            var cmc = new CryptonatorApi();
            var ticket = cmc.GetTicker($"{Coins.BitCoin}-USD");
            Assert.AreEqual(ticket.Base.ToLower(), Coins.BitCoin);
        }

        [TestMethod]
        public void CryptonatorApi_OneTicket_Usd_Rub()
        {
            var cmc = new CryptonatorApi();
            var ticket = cmc.GetTicker($"USD-Rub");
            Assert.AreEqual(ticket.Base, "USD");
        }

        [TestMethod]
        public void CryptonatorApi_OneTicket_XMR_Usd()
        {
            var cmc = new CryptonatorApi();
            var ticket = cmc.GetTicker($"{Coins.Monero}-Rub");
            Assert.AreEqual(ticket.Base.ToLower(), Coins.Monero);
        }
    }
}
