using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using NanoDataBase.ORMDataModelNanopoolCode;
using NanopoolApi.Response;

namespace NanoDataBase.Nanopool
{

    public partial class Balance : IPersistentBase
    {
        public Balance(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        public void Map(FloatValue balanceRaw)
        {
            Volume = balanceRaw.Data;
            Date = DateTime.Now;
        }

        public override string ToString()
        {
            return $"({Id}) {Volume.ToString("N12")} [{Date.ToString("f")}] ";
        }
    }

}
