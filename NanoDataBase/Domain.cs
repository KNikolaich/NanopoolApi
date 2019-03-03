using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using ExchangeRates;
using NanoDataBase.Logging;
using NanoDataBase.Nanopool;
using NanoDataBase.ORMDataModelNanopoolCode;
using NanopoolApi.Response;

namespace NanoDataBase
{
    public class Domain
    {

        public static ICollection<TXpObj> GetCollectionXpObj<TXpObj>(int top = 100) where TXpObj : XPLiteObject, IPersistentBase
        {
            List<TXpObj> objects;
            try
            {
                var classInfoTxpObj = Session.GetClassInfo(typeof(TXpObj));
                objects = Session.GetObjects(classInfoTxpObj, null, new SortingCollection(new SortProperty("Id", SortingDirection.Descending)), top, false, false).Cast<TXpObj>().ToList();
                if (!objects.Any())
                {
                    var method = typeof(TXpObj).GetMethod("InitializeNewDb");
                    object[] param = new object[] { Session };
                    if (method != null)
                    {
                        method.Invoke(null, param);
                    }
                }
            }
            catch (Exception e)
            {
                LogHolder.LogError(e);
                throw;
            }
            return objects;
        }

        /// <summary> Сохранить баланс </summary>
        /// <param name="balanceRaw">сырье</param>
        /// <param name="tsDelta">время перед следующим сохранением</param>
        /// <param name="currencyEnum">валюта</param>
        /// <returns></returns>
        public static Balance SaveBalance(FloatValue balanceRaw, TimeSpan tsDelta, CurrencyTypeEnum currencyEnum, out String result)
        {

            result = "";

            Currency currency = GetCurrensyByEnum(currencyEnum);

            Balance balance = new Balance(Session);
            var lastBalance = GetNewId<Balance>();
            balance.Map(balanceRaw, currency);

            if (balanceRaw.Status)
            {
                if (HasNeedingSave(tsDelta, lastBalance, balance))
                {
                    result = AdditionInfoFromCriptonator(currency);

                    balance.Save();
                }
            }
            lastBalance.Status = balanceRaw.Status;
            return lastBalance;
        }

        private static string AdditionInfoFromCriptonator(Currency currency)
        {
            StringBuilder errors = new StringBuilder();
            var collection = GetCollectionXpObj<RelationCurrency>();
            RelationCurrency pairCurr = null;
            do
            {
                pairCurr = collection.FirstOrDefault(pair => Equals(pair.First, currency));
                if (pairCurr != null)
                {
                    string error = "";
                    var tickerContayner = new ExchangeRates.Croptonator.CryptonatorApi().TickerContayner($"{pairCurr.First.Name}-{pairCurr.Second.Name}", ref error);
                    if (string.IsNullOrEmpty(error))
                    {
                        errors.AppendLine(error);
                    }
                    var ticker = tickerContayner?.ticker;
                    
                    if (ticker != null)
                    {
                        var exRate = new ExchangeRate(Session)
                        {
                            CurrencyPair = pairCurr,
                            Date = DateTime.Now,
                            Rate = ticker.price
                        };
                        exRate.Save();
                    }
                    currency = pairCurr.Second;
                }

            } while (pairCurr != null);

            return errors.ToString();
        }

        private static Currency GetCurrensyByEnum(CurrencyTypeEnum currencyEnum)
        {
            var listCurr = GetCollectionXpObj<Currency>();
            return listCurr.FirstOrDefault(curr => curr.Name.ToLower() == currencyEnum.ToString());
        }

        /// <summary> Имеется необходимость сохранения </summary>
        private static bool HasNeedingSave(TimeSpan tsDelta, Balance lastBalance, Balance balance)
        {
            bool needSave = false;
            if (lastBalance != null)
            {
                if (lastBalance.Date.Add(tsDelta) <= DateTime.Now.AddHours(-1))
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
            foreach (var itemTicket in tickets.Select(t => Environment.NewLine + t.name + "\t\t" + t.price_usd))
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
                LogHolder.LogError(e);
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
