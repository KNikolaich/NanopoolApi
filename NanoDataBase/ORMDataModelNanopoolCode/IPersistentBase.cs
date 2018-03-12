using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoDataBase.ORMDataModelNanopoolCode
{
    public interface IPersistentBase
    {
        long Id { get; set; }
    }
}
