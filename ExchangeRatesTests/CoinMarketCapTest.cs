using System;
using ExchangeRates;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExchangeRatesTests
{
    [TestClass]
    public class CoinMarketCapTest
    {
        [TestMethod]
        public void BitcoinType_OneTicket()
        {
            var cmc = new CoinMarketCap();
            var ticket = cmc.GetTicket(Statics.CurrencyType.bitcoin);
            Assert.AreEqual(ticket.id, Statics.CurrencyType.bitcoin.ToString());
        }


        [TestMethod]
        public void BitcoinType_AllTickets()
        {
            var cmc = new CoinMarketCap();
            var tickets = cmc.GetAllTickets();
            Assert.AreNotSame(tickets.Count, 0);
        }
    }
}
