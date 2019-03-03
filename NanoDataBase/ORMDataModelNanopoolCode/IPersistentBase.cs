using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpo;
using ExchangeRates;

namespace NanoDataBase.ORMDataModelNanopoolCode
{
    public interface IPersistentBase
    {
        long Id { get; set; }

        //void InitializeNewDb(Session session);
    }
}
