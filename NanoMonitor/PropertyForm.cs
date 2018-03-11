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
        public PropertyForm()
        {
            InitializeComponent();
        }

        private void _bTest_Click(object sender, EventArgs e)
        {
            using (StatusForm statusForm = new StatusForm())
            {
            var balance = new Nanopool(Statics.PoolType.ETH).GetAccountBalance(_tbAddress.Text);
                statusForm.Value = balance;
                statusForm.ShowDialog();
            }
            
        }
    }
}
