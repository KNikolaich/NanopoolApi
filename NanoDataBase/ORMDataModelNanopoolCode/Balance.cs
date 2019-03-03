using System;
using DevExpress.Xpo;
using NanoDataBase.ORMDataModelNanopoolCode;
using NanopoolApi.Response;

namespace NanoDataBase.Nanopool
{

    public partial class Balance : IPersistentBase
    {
        public Balance(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        public void Map(FloatValue balanceRaw, Currency currency)
        {
            Volume = balanceRaw.Data;
            Date = DateTime.Now;
            Currency = currency;
        }

        public override string ToString()
        {
            return $"({Id}) {Volume.ToString("N8")} {Currency}";
        }

        [NonPersistent]
        public bool Status { get; set; }
        
    }

}
