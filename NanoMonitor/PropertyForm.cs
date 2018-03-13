using System;
using System.Windows.Forms;
using NanopoolApi;
using NanopoolApi.Response;

namespace NanoMonitor
{
    public partial class PropertyForm : Form
    {
        Nanopool nanopool = new Nanopool(Statics.PoolType.ETH);
        private bool _bShow;
#if DEBUG
        private readonly TimeSpan DELAY = new TimeSpan(0, 0, 15); //задержка
#else
        private readonly TimeSpan DELAY = new TimeSpan(1, 0, 0); //задержка
#endif

        public PropertyForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            _timerRefreshData.Interval = (int) DELAY.TotalMilliseconds;
            _timerRefreshData.Start();
            
            base.OnLoad(e);
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

        private FloatValue SaveBalance()
        {
            var balance = nanopool.GetAccountBalance(_tbAddress.Text);
            
            if (balance.Status)
            {
                string infoArray = NanoDataBase.Domain.Save(balance, DELAY);
                if (!string.IsNullOrEmpty(infoArray))
                {
                    _tbBalance.Text = Environment.NewLine + infoArray;
                }
            }
            return balance;
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
            SaveBalance();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            ShowOrHide();
        }
    }
}
