using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Windows.Forms;
using ExchangeRates;
using NanoDataBase;
using NanoDataBase.Logging;
using NanoDataBase.Nanopool;
using NanopoolApi;
using NanopoolApi.Response;
using NLog;
using Statics = NanopoolApi.Statics;

namespace NanoMonitor
{
    public partial class PropertyForm : Form
    {
        readonly Nanopool _nanopoolEth = new Nanopool(Statics.PoolType.ETH);

        readonly Nanopool _nanopoolXmr = new Nanopool(Statics.PoolType.XMR);
        private const string XmrAccount = "4APMf9wHWok1ZmShRWJB8yWvF8ragKFnmUYSVaqzBFGVemgBsos3Lau6XwFEB1vekqKkvn977so1oP8akzNhY93u48wH2kV";

        private bool _bShow;
#if DEBUG
        private static readonly TimeSpan Delay = new TimeSpan(0, 1, 0);
#else
        private static readonly TimeSpan Delay = new TimeSpan(1, 0, 0); //задержка
#endif

        public PropertyForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            LoadTextNotify();


            _lAddressDb.Text = Domain.GetAddressDb();
            _timerRefreshData.Interval = (int) Delay.TotalMilliseconds;
            _timerRefreshData.Start();
            LogHolder.MessageLogEventHandler += LogHolder_MessageLogEventHandler;
            base.OnLoad(e);
        }

        private void LoadTextNotify()
        {
            try
            {
                var balance = SaveBalance();

                if (balance.All(b => b.Status))
                {
                    LogHolder.MainLogInfo(_tbBalance.Text);
                }
                else
                {
                    LogHolder.MainLogWarning(_tbBalance.Text);
                
                }
                var volumeUsd = balance.Aggregate("", (current, b) => current + $"{b.Currency.Short}:{b.Volume:F5}{Environment.NewLine}");
                _notifyIcon1.Text = !string.IsNullOrEmpty(volumeUsd) ? volumeUsd : "Подключенья нет";
            }
            catch (Exception ex)
            {
                LogHolder.LogError(ex);
            }
        }


        private void LogHolder_MessageLogEventHandler(object sender, LogEventInfo e)
        {
            _notifyIcon1.BalloonTipIcon = GetToolTipIcon(e.Level);
            _notifyIcon1.BalloonTipText = e.Message;
            _notifyIcon1.BalloonTipTitle = e.LoggerName;
            _notifyIcon1.ShowBalloonTip(3);
        }

        private ToolTipIcon GetToolTipIcon(LogLevel logLevel)
        {
            if (logLevel == LogLevel.Error)
                return ToolTipIcon.Error;
            else if (logLevel == LogLevel.Info)
                return ToolTipIcon.Info;
            else if (logLevel == LogLevel.Warn)
                return ToolTipIcon.Warning;
            return ToolTipIcon.None;
        }

        private void _bTest_Click(object sender, EventArgs e)
        {
            using (StatusForm statusForm = new StatusForm())
            {
                statusForm.Value = SaveBalance();
                if (statusForm.ShowDialog() == DialogResult.OK)
                {
                    //var charts = nanopoolEth.GetWorkersAverageHashrate(_tbAddress.Text);
                }
            }
        }
        
        private List<Balance> SaveBalance()
        {
            var balanceEth = _nanopoolEth.GetAccountBalance(_tbAddress.Text);

            var result = new List<Balance>();
            string infoArray = "";
            result.Add(Domain.SaveBalance(balanceEth, Delay, CurrencyTypeEnum.ethereum, ref infoArray));
            var balanceXmr = _nanopoolXmr.GetAccountBalance(XmrAccount);

            result.Add(Domain.SaveBalance(balanceXmr, Delay, CurrencyTypeEnum.monero, ref infoArray));
            if (!string.IsNullOrEmpty(infoArray))
            {
                _tbBalance.Text = infoArray;
            }
            return result;
        }

        private void _settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowOrHide();
        }

        private void ShowOrHide()
        {
            if (_bShow)
            {
                Hide();
                _bShow = false;
            }
            else
            {
                Show();
                _bShow = true;
            }
        }

        protected override void OnShown(EventArgs e)
        {
            _bShow = true;
            base.OnShown(e);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void _bSave_Click(object sender, EventArgs e)
        {
            //Hide();
            ShowOrHide();
        }

        private void _timerRefreshData_Tick(object sender, EventArgs e)
        {
            LoadTextNotify();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            ShowOrHide();
        }
    }
}
