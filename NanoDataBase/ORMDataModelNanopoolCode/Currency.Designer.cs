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

    public partial class Currency : XPLiteObject
    {
        long fId;
        [Key(true)]
        public long Id
        {
            get { return fId; }
            set { SetPropertyValue<long>("Id", ref fId, value); }
        }
        string fName;
        [Size(50)]
        [DevExpress.Xpo.DisplayName(@"Наименование")]
        public string Name
        {
            get { return fName; }
            set { SetPropertyValue<string>("Name", ref fName, value); }
        }
        string fSymbol;
        [Size(15)]
        [DevExpress.Xpo.DisplayName(@"Код")]
        public string Symbol
        {
            get { return fSymbol; }
            set { SetPropertyValue<string>("Symbol", ref fSymbol, value); }
        }
        string fShort;
        [Size(5)]
        [DevExpress.Xpo.DisplayName(@"Кратко")]
        public string Short
        {
            get { return fShort; }
            set { SetPropertyValue<string>("Short", ref fShort, value); }
        }
        [Association(@"BalanceReferencesCurrency")]
        public XPCollection<Balance> Balances { get { return GetCollection<Balance>("Balances"); } }
        [Association(@"RelationCurrencyReferencesCurrency")]
        public XPCollection<CurrencyPair> RelationCurrenciesFirst { get { return GetCollection<CurrencyPair>("RelationCurrenciesFirst"); } }
        [Association(@"RelationCurrencyReferencesCurrency1")]
        public XPCollection<CurrencyPair> RelationCurrenciesSecond { get { return GetCollection<CurrencyPair>("RelationCurrenciesSecond"); } }
    }

}
