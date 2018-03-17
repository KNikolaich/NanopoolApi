using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using NanoDataBase;
using System.Web.Mvc;
using NanoDataBase.Nanopool;

namespace Nanopool.DXWebApp.Controllers
{
    public class BalancesController : Controller
    {
        // GET: Balances
        public ActionResult Index()
        {
            return View(GetBalanceCollection());
        }

        public ActionResult ChartBalancesPartial()
        {
            return PartialView("_ChartBalancesPartial", GetBalanceCollection());
        }

        private static ICollection<Balance> GetBalanceCollection()
        {
            var filtredData = new Dictionary<DateTime, Balance>();
            var balanceCollection = Domain.GetCollectionXpObj<Balance>().OrderByDescending(b=> b.Date);
            foreach (var balance in balanceCollection)
            {
                var date = balance.Date.Date;
                if (!filtredData.ContainsKey(date))
                {
                    filtredData.Add(date, balance);
                }
            }
            return filtredData.Values.OrderBy(b=>b.Date).ToList();
        }

    }
}