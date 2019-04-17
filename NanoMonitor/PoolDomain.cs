using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExchangeRates;
using NanoDataBase;
using NanoDataBase.Logging;
using NanoDataBase.Nanopool;
using NanopoolApi;
using NanopoolApi.Response;

using Statics = NanopoolApi.Statics;

namespace NanoMonitor
{
    internal class PoolDomain
    {

        readonly Nanopool _nanopoolEth = new Nanopool(Statics.PoolType.ETH);
        readonly Nanopool _nanopoolXmr = new Nanopool(Statics.PoolType.XMR);

        private const string XmrAccount = "4APMf9wHWok1ZmShRWJB8yWvF8ragKFnmUYSVaqzBFGVemgBsos3Lau6XwFEB1vekqKkvn977so1oP8akzNhY93u48wH2kV";
        private const string EthAccount = "0x13c90C011E0524793561dE63F2809Eb6723eb195";

#if DEBUG
        private static readonly TimeSpan Delay = new TimeSpan(0, 1, 0);
#else
        private static readonly TimeSpan Delay = new TimeSpan(1, 0, 0); //задержка
#endif
        private System.Windows.Forms.Timer _timerRefreshData;

        public void StartThread(IContainer components)
        {

            _timerRefreshData = new System.Windows.Forms.Timer(components)
            {
                Enabled = true,
                Interval = (int) Delay.TotalMilliseconds,
            };
            _timerRefreshData.Tick += _timerRefreshData_Tick;
            _timerRefreshData.Start();
        }

        private void _timerRefreshData_Tick(object sender, EventArgs e)
        {
            TrySaveBalance();
        }

        internal List<Balance> TrySaveBalance()
        {
            List<Balance> balance = null;
            try
            {
                balance = SaveBalance();

                //if (balance.All(b => b.Status))
                //{
                //    LogHolder.MainLogWarning(_tbBalance.Text);
                //}
                var volumeUsd = balance.Aggregate("",
                    (current, b) => current + $"{b.Currency.Short}:{b.Volume:F5}{Environment.NewLine}");
                LogHolder.MainLogWarning(!string.IsNullOrEmpty(volumeUsd) ? volumeUsd : "Подключенья нет");
            }
            catch (Exception ex)
            {
                LogHolder.LogError(ex);
            }
            return balance;
        }


        private List<Balance> SaveBalance()
        {
            var balanceEth = _nanopoolEth.GetAccountBalance(EthAccount);

            var result = new List<Balance>();
            string infoArray = "";
            result.Add(Domain.SaveBalance(balanceEth, Delay, CurrencyTypeEnum.ethereum, ref infoArray));
            var balanceXmr = _nanopoolXmr.GetAccountBalance(XmrAccount);

            result.Add(Domain.SaveBalance(balanceXmr, Delay, CurrencyTypeEnum.monero, ref infoArray));
            if (!string.IsNullOrEmpty(infoArray))
            {
                LogHolder.MainLogInfo(infoArray);
            }
            return result;
        }
    }
}
