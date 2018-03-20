using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using ExchangeRates;
using NanoDataBase.Nanopool;
using NanoDataBase.ORMDataModelNanopoolCode;
using NanopoolApi.Response;

namespace NanoDataBase
{
    public class Domain
    {

        public static ICollection<TXpObj> GetCollectionXpObj<TXpObj>() where TXpObj : XPLiteObject, IPersistentBase
        {
            List<TXpObj> objects;
            try
            {
                var classInfoTxpObj = Session.GetClassInfo(typeof(TXpObj));
                objects = Session.GetObjects(classInfoTxpObj, null, new SortingCollection(new SortProperty("Id", SortingDirection.Descending)), 100, false, false).Cast<TXpObj>().ToList();
            }
            catch (Exception e)
            {
                // LogHolder.LogError(e);
                throw;
            }
            return objects;
        }

        /// <summary> Сохранить баланс </summary>
        /// <param name="balanceRaw">сырье</param>
        /// <param name="tsDelta">время перед следующим сохранением</param>
        /// <param name="currency">валюта</param>
        /// <returns></returns>
        public static string SaveBalance(FloatValue balanceRaw, TimeSpan tsDelta, CurrencyTypeEnum currency)
        {
            string result = "";
            Balance balance = new Balance(Session);
            var lastBalance = GetNewId<Balance>();
            balance.Map(balanceRaw, currency);

            if (HasNeedingSave(tsDelta, lastBalance, balance))
            {
                result = AdditionInfoFromCoinMarketCap(balance, currency);

                balance.Save();
            }

            return result;
        }

        /// <summary> Имеется необходимость сохранения </summary>
        private static bool HasNeedingSave(TimeSpan tsDelta, Balance lastBalance, Balance balance)
        {
            bool needSave = false;
            if (lastBalance != null)
            {
                if (lastBalance.Date.Add(tsDelta) <= DateTime.Now)
                {
                    balance.Id = lastBalance.Id + 1;
                    needSave = true;
                }
            }
            else
            {
                balance.Id = 0;
                needSave = true;
            }
            return needSave;
        }

        private static string AdditionInfoFromCoinMarketCap(Balance balance, CurrencyTypeEnum currency)
        {
            var cmc = new CoinMarketCap(currency);
            var tickets = cmc.GetAllTickets();
            var ticketCurr = tickets.FirstOrDefault(t => t.id == currency.ToString());
            if (ticketCurr != null)
            {
                balance.VolumeUsd = ticketCurr.price_usd * balance.Volume;
            }
            var result = balance.Date.ToString("f");
            result += Environment.NewLine + balance;
            if (balance.VolumeUsd != null)
                result += $" ({balance.VolumeUsd.Value.ToString("N4")}$)"+ Environment.NewLine;
            foreach (var itemTicket in tickets.Select(t => Environment.NewLine + t.name + "\t" + t.price_usd))
            {
                result += itemTicket;
            }
            
            return result;
        }

        private static TXpObj GetNewId<TXpObj>() where TXpObj : XPLiteObject, IPersistentBase
        {
            List<TXpObj> objects;
            try
            {
                var classInfoTxpObj = Session.GetClassInfo(typeof(TXpObj));
                objects = Session.GetObjects(classInfoTxpObj, null, new SortingCollection(new SortProperty("Id", SortingDirection.Descending)), 1, false, false).Cast<TXpObj>().ToList();
            }
            catch (Exception e)
            {
                // LogHolder.LogError(e);
                throw;
            }
            return objects.FirstOrDefault();
        }


        private static readonly object LockObject = new object();

        static volatile IDataLayer _fDataLayer;

        static IDataLayer DataLayer
        {
            get
            {
                if (_fDataLayer == null)
                {
                    lock (LockObject)
                    {
                        if (_fDataLayer == null)
                        {
                            _fDataLayer = ConnectionHelper.GetDataLayer(AutoCreateOption.DatabaseAndSchema);
                        }
                    }
                }
                return _fDataLayer;
            }
        }



        internal static Session Session
        {
            get
            {
                var session = (Session.DefaultSession ?? XpoDefault.Session) ?? new Session(DataLayer);
                if (string.IsNullOrEmpty(session.ConnectionString))
                {
                    session.ConnectionString = ConnectionHelper.ConnectionString;
                }
                return session;
            }
        }

        public static string GetAddressDb()
        {
            //"data source ="
            return $"{Session.Connection.Database} на сервере {((System.Data.SqlClient.SqlConnection)Session.Connection).DataSource}";
        }
    }
}
