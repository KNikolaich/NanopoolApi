using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using NanoDataBase.ORMDataModelNanopoolCode;

namespace NanoDataBase.Nanopool
{

    public partial class Currency : IPersistentBase
    {
        public Currency(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        public override string ToString()
        {
            return $"{Name} ({Symbol})";
        }

        public static void InitializeNewDb(Session session)
        {
            new Currency(session)
            {
                Name = "Доллан",
                Symbol = "USD",
                Short = "$"
            }.Save();
            new Currency(session)
            {
                Name = "Bitcoin",
                Symbol = "BTC",
                Short = "B"
            }.Save();
            new Currency(session)
            {
                Name = "Monero",
                Symbol = "XMR",
                Short = "M"
            }.Save();

            new Currency(session)
            {
                Name = "Рубли",
                Symbol = "RUB",
                Short = "р."
            }.Save();
        }
    }

}
