using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace DemoService
{
    [RunInstaller(true)]
    public partial class Service1 : ServiceBase
    {
        private Timer timer = null;

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Logger.logger("****** -- Event: onStart -- ******");
            Logger.logger("Attempting to start service");

            timer = new Timer();
            //1000 -> one second
            this.timer.Interval = 10000;
            this.timer.Elapsed += new ElapsedEventHandler(this.todoTask);
            this.timer.Enabled = true;

            Logger.logger("Demo service started !");
            Logger.logger("****** -- service action will repeated after every "+this.timer.Interval+" seconds !-- ******");
        }

        private void todoTask(object sender, ElapsedEventArgs e)
        {
            //todo
            Logger.logger("in todo task method");
            Logger.logger("task completed");
        }

        protected override void OnStop()
        {
            Logger.logger("****** -- Event: OnStop -- ******");
            Logger.logger("Attempting to shutdown service");

            timer.Stop();
            timer = null;

            Logger.logger("Demo service shut down");
        }
    }
}
