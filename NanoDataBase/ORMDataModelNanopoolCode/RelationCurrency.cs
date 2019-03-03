using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using NanoDataBase.ORMDataModelNanopoolCode;

namespace NanoDataBase.Nanopool
{

    public partial class RelationCurrency : IPersistentBase
    {
        public RelationCurrency(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        public override string ToString()
        {
            return $"Отношение {Second?.Name} к {First?.Name}";
        }

        public static void InitializeNewDb(Session session)
        {
            var listCurr = Domain.GetCollectionXpObj<Currency>();

            var usdCurr = listCurr.FirstOrDefault(curr => curr.Name == "USD");
            new RelationCurrency(session)
            {
                First = listCurr.FirstOrDefault(curr => curr.Name == "BTC"),
                Second = usdCurr,
            }.Save();
            new RelationCurrency(session)
            {
                First = listCurr.FirstOrDefault(curr => curr.Name == "XMR"),
                Second = usdCurr,
            }.Save();
            new RelationCurrency(session)
            {
                First = usdCurr,
                Second = listCurr.FirstOrDefault(curr => curr.Name == "RUB"),
            }.Save();
        }
    }

}
