﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace NanoDataBase.Nanopool
{

    public partial class CurrencyPair : XPLiteObject
    {
        long fId;
        [Key(true)]
        public long Id
        {
            get { return fId; }
            set { SetPropertyValue<long>("Id", ref fId, value); }
        }
        Currency fFirst;
        [Persistent(@"FirstId")]
        [Association(@"RelationCurrencyReferencesCurrency")]
        [DevExpress.Xpo.DisplayName(@"Первая валюта")]
        public Currency First
        {
            get { return fFirst; }
            set { SetPropertyValue<Currency>("First", ref fFirst, value); }
        }
        Currency fSecond;
        [Persistent(@"SecondId")]
        [Association(@"RelationCurrencyReferencesCurrency1")]
        [DevExpress.Xpo.DisplayName(@"Вторая валюта")]
        public Currency Second
        {
            get { return fSecond; }
            set { SetPropertyValue<Currency>("Second", ref fSecond, value); }
        }
        [Association(@"ExchangeRateReferencesRelationCurrency")]
        public XPCollection<ExchangeRate> ExchangeRates { get { return GetCollection<ExchangeRate>("ExchangeRates"); } }
    }

}
