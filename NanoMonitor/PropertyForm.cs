using System;
using System.Diagnostics.Eventing.Reader;
using System.Net;
using System.Threading.Tasks;
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
        Nanopool nanopool = new Nanopool(Statics.PoolType.ETH);
        private bool _bShow;
#if DEBUG
        private readonly TimeSpan DELAY = new TimeSpan(0, 15, 15); //задержка
#else
        private readonly TimeSpan DELAY = new TimeSpan(1, 0, 0); //задержка
#endif

        public PropertyForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            LoadTextNotify();


            _lAddressDb.Text = Domain.GetAddressDb();
            _timerRefreshData.Interval = (int) DELAY.TotalMilliseconds;
            _timerRefreshData.Start();
            LogHolder.MessageLogEventHandler += LogHolder_MessageLogEventHandler;
            base.OnLoad(e);
        }

        private void LoadTextNotify()
        {
            try
            {
                var balance = SaveBalance();

                if (balance.Status)
                {
                    LogHolder.MainLogInfo(_tbBalance.Text);
                }
                else
                {
                    LogHolder.MainLogWarning(_tbBalance.Text);
                
                }
                var volumeUsd = balance.VolumeUsd;
                if (volumeUsd != null)
                {
                    _notifyIcon1.Text = volumeUsd.Value.ToString("n3") + "$";
                }
                else
                {
                    _notifyIcon1.Text = "Подключенья нет";
                }
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
                    //var charts = nanopool.GetWorkersAverageHashrate(_tbAddress.Text);
                }
            }
        }
        
        private Balance SaveBalance()
        {
            var balance = nanopool.GetAccountBalance(_tbAddress.Text);
            
            string infoArray;
            var lastBalance = Domain.SaveBalance(balance, DELAY, CurrencyTypeEnum.ethereum, out infoArray);
            if (!string.IsNullOrEmpty(infoArray))
            {
                _tbBalance.Text = infoArray;
            }
            return lastBalance;
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

        private void testForm1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (EmptyForm emptyForm = new EmptyForm())
            {
                var page = DumpWebPage("https://minergate.com/");
                emptyForm.SetListBoxText(page);
                emptyForm.ShowDialog(this);
            }
        }

        private string DumpWebPage(string uri)
        {
            WebClient webclient = new WebClient();
            string page = webclient.DownloadString(uri);
            return page;
        }

        private void testForm2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (EmptyForm emptyForm = new EmptyForm())
            {
                WebClient webclient = new WebClient();
                Task<string> page = webclient.DownloadStringTaskAsync("https://yandex.ru/");
                
                emptyForm.SetListBoxText(page.Result);
                emptyForm.ShowDialog(this);
            }
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            switch (toolStripComboBox1.SelectedIndex)
            {
                case 0: break;
                case 1: break;
                case 2: break;
                case 3: break;
            }
            
        }
    }
}
