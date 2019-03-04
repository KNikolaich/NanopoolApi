using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.Metadata;
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
                objects = GetListObjects<TXpObj>(top, classInfoTxpObj);
                if (!objects.Any())
                {
                    var method = typeof(TXpObj).GetMethod("InitializeNewDb");
                    object[] param = { Session };
                    if (method != null)
                    {
                        method.Invoke(null, param);
                    }
                    objects = GetListObjects<TXpObj>(top, classInfoTxpObj);

                }
            }
            catch (Exception e)
            {
                LogHolder.LogError(e);
                throw;
            }
            return objects;
        }

        private static List<TXpObj> GetListObjects<TXpObj>(int top, XPClassInfo classInfoTxpObj) where TXpObj : XPLiteObject, IPersistentBase
        {
            return Session.GetObjects(classInfoTxpObj, null, new SortingCollection(new SortProperty("Id", SortingDirection.Descending)), top, false, false).Cast<TXpObj>().ToList();
        }

        /// <summary> Сохранить баланс </summary>
        /// <param name="balanceRaw">сырье</param>
        /// <param name="tsDelta">время перед следующим сохранением</param>
        /// <param name="currencyEnum">валюта</param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static Balance SaveBalance(FloatValue balanceRaw, TimeSpan tsDelta, CurrencyTypeEnum currencyEnum, ref string result)
        {
            Currency currency = GetCurrensyByEnum(currencyEnum);
            Balance balance = new Balance(Session);
            var lastBalance = GetLastBalance<Balance>(currency);
            balance.Map(balanceRaw, currency);
            balance.Status = balanceRaw.Status;

            if (balanceRaw.Status)
            {
                if (HasNeedingSave(tsDelta, lastBalance, balance))
                {
                    result += (Environment.NewLine + lastBalance);
                    result += AdditionInfoFromCriptonator(currency);
                    balance.Save();

                }
                else
                {
                    result += (Environment.NewLine + lastBalance);
                }
            }
            return balance;
        }

        private static string AdditionInfoFromCriptonator(Currency currency)
        {
            StringBuilder errors = new StringBuilder(Environment.NewLine);
            var collection = GetCollectionXpObj<CurrencyPair>();
            //RelationCurrency pairCurr = null;
            AddExchangeRate(currency, collection, errors);
            return errors.ToString();
        }

        private static void AddExchangeRate(Currency currency, ICollection<CurrencyPair> collection, StringBuilder errors)
        {
            foreach (var pairCurr in collection.Where(pair => Equals(pair.First, currency)))
            {
                // найдем, есть ли уже недавно запрошенный уровень с такими же 
                var firstExchangeRate = Session.GetObjects(Session.GetClassInfo(typeof(ExchangeRate)), 
                    CriteriaOperator.Parse("[CurrencyPair] = ?", pairCurr.Id), 
                    new SortingCollection(new SortProperty("Date", SortingDirection.Descending)), 1, false, false)
                    .Cast<ExchangeRate>().FirstOrDefault();

                if (firstExchangeRate == null || firstExchangeRate.Date.AddHours(1) < DateTime.Now)
                {
                    string error = "";
                    var tickerContayner =
                        new ExchangeRates.Croptonator.CryptonatorApi().TickerContayner(
                            $"{pairCurr.First.Symbol}-{pairCurr.Second.Symbol}", ref error);

                    if (!string.IsNullOrEmpty(error))
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
                }

                
                AddExchangeRate(pairCurr.Second, collection, errors);
            }
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
                if (lastBalance.Date.Add(tsDelta) <= DateTime.Now)
                {
                    //balance.Id = lastBalance.Id + 1;
                    needSave = true;
                }
            }
            else
            {
                //balance.Id = 0;
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

        private static TXpObj GetLastBalance<TXpObj>(Currency currency) where TXpObj : XPLiteObject, IPersistentBase
        {
            List<TXpObj> objects;
            try
            {
                var classInfoTxpObj = Session.GetClassInfo(typeof(TXpObj));
                objects = Session.GetObjects(classInfoTxpObj, CriteriaOperator.Parse("[Currency] = ?", currency.Id), new SortingCollection(new SortProperty("Id", SortingDirection.Descending)), 1, false, false).Cast<TXpObj>().ToList();
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
