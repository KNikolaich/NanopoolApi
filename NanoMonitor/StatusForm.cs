using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NanoDataBase.Nanopool;
using NanopoolApi.Response;

namespace NanoMonitor
{
    public partial class StatusForm : Form
    {
        public StatusForm()
        {
            InitializeComponent();
        }

        public List<Balance> Value
        {
            set
            {
                _lBalabce.Text = value.Aggregate("", (current, b) => current + $"{b.Currency.Short}:{b.Volume:F5}{Environment.NewLine}");
                _bPicture.ImageIndex = GetIndex(value.Select(b=>b.Status).ToList());
            }
        }

        private int GetIndex(List<bool> statuses)
        {
            if (statuses.All(s => s)) // все ок
            {
                return 1;
            }
            if(statuses.All(s => !s)) // все не ок
            {
                return 2;
            }
            return 0; // смешанные статусы
        }

    }
}
