using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using NanoDataBase.ORMDataModelNanopoolCode;

namespace NanoDataBase.Nanopool
{

    public partial class ExchangeRate : IPersistentBase
    {
        public ExchangeRate(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }



        public override string ToString()
        {
            return $"{CurrencyPair} на дату {Date} = {Rate:F2}";
        }


    }

}
