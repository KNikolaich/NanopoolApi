using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NanopoolApi;

namespace NanoMonitor
{
    public partial class PropertyForm : Form
    {
        Nanopool nanopool = new Nanopool(Statics.PoolType.ETH);
        public PropertyForm()
        {
            InitializeComponent();
        }

        private void _bTest_Click(object sender, EventArgs e)
        {
            using (StatusForm statusForm = new StatusForm())
            {
                var balance = nanopool.GetAccountBalance(_tbAddress.Text);
                statusForm.Value = balance;
                if (statusForm.ShowDialog() == DialogResult.OK)
                {
                    if (balance.Status)
                    {
                        NanoDataBase.Domain.Save(balance);
                    }
                    //var charts = nanopool.GetWorkersAverageHashrate(_tbAddress.Text);

                }

            }
            
        }
    }
}
