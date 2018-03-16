using System;
using System.Collections.Generic;

using ExchangeRates.MinerGate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;

namespace ExchangeRatesTests
{
    [TestClass]
    public class MinerGateTest
    {
        [TestMethod]
        public void BitcoinType_OneTicket()
        {
            var testMinergate = new MinergateClient(088828);
            //Test.Main();
            JObject strError = testMinergate.CheckBalance();
            Assert.AreEqual(strError, String.Empty);
        }

    }
}
