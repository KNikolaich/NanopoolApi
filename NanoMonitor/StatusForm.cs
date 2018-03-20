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

        public Balance Value
        {
            set
            {
                _lBalabce.Text = value.Volume.ToString("n5");
                _bPicture.ImageIndex = GetIndex(value.Status);
            }
        }

        private int GetIndex(bool status)
        {
            if (status)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }
    }
}
