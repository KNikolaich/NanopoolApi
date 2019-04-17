using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Windows.Forms;
using ExchangeRates;
using NanoDataBase;
using NanoDataBase.Logging;
using NanoDataBase.Nanopool;
using NLog;

namespace NanoMonitor
{
    public partial class PropertyForm : Form
    {
        PoolDomain _pd = new PoolDomain();
        
        private bool _bShow;


        public PropertyForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            _pd.TrySaveBalance();
            _pd.StartThread(components);

            _lAddressDb.Text = Domain.GetAddressDb();
            
            LogHolder.MessageLogEventHandler += LogHolder_MessageLogEventHandler;
            base.OnLoad(e);
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
            if (logLevel == LogLevel.Info)
                return ToolTipIcon.Info;
            if (logLevel == LogLevel.Warn)
                return ToolTipIcon.Warning;
            return ToolTipIcon.None;
        }

        private void _bTest_Click(object sender, EventArgs e)
        {
            using (StatusForm statusForm = new StatusForm())
            {
                statusForm.Value = _pd.TrySaveBalance();
                if (statusForm.ShowDialog() == DialogResult.OK)
                {
                    //var charts = nanopoolEth.GetWorkersAverageHashrate(_tbAddress.Text);
                }
            }
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
        
        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            ShowOrHide();
        }
    }
}
