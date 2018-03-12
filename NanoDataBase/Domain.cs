using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using NanoDataBase.Nanopool;
using NanoDataBase.ORMDataModelNanopoolCode;
using NanopoolApi.Response;

namespace NanoDataBase
{
    public class Domain
    {
        public static void Save(FloatValue balanceRaw, TimeSpan tsDelta)
        {
            Balance balance = new Balance(Session);
            var lastBalance = GetNewId<Balance>();
            balance.Map(balanceRaw);
            if (lastBalance != null)
            {
                if (lastBalance.Date.Add(tsDelta) <= DateTime.Now)
                {
                    balance.Id = lastBalance.Id + 1;
                    balance.Save();
                }
            }
            else
            {
                balance.Id = 0;
                balance.Save();
            }

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

    }
}
