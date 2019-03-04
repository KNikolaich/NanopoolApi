using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using NanoDataBase.ORMDataModelNanopoolCode;

namespace NanoDataBase.Nanopool
{

    public partial class CurrencyPair : IPersistentBase
    {
        public CurrencyPair(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        public override string ToString()
        {
            return $"Отношение {Second?.Name} к {First?.Name}";
        }

        public static void InitializeNewDb(Session session)
        {
            var listCurr = Domain.GetCollectionXpObj<Currency>();

            var usdCurr = listCurr.FirstOrDefault(curr => curr.Symbol == "USD");
            new CurrencyPair(session)
            {
                First = listCurr.FirstOrDefault(curr => curr.Symbol == "BTC"),
                Second = usdCurr,
            }.Save();
            new CurrencyPair(session)
            {
                First = listCurr.FirstOrDefault(curr => curr.Symbol == "XMR"),
                Second = usdCurr,
            }.Save();
            new CurrencyPair(session)
            {
                First = listCurr.FirstOrDefault(curr => curr.Symbol == "ETH"),
                Second = usdCurr,
            }.Save();
            new CurrencyPair(session)
            {
                First = usdCurr,
                Second = listCurr.FirstOrDefault(curr => curr.Symbol == "RUB"),
            }.Save();
        }
    }

}
