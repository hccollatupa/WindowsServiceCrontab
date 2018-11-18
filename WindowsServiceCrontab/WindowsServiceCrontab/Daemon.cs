using WindowsServiceCrontab.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsServiceCrontab
{
    partial class Daemon : ServiceBase
    {
        public Daemon()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            ServiceCore.Start();
        }

        protected override void OnStop()
        {
            ServiceCore.Stop();
        }
    }
}
