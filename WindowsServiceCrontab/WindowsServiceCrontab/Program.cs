using log4net;
using WindowsServiceCrontab.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsServiceCrontab
{
    class Program
    {
        private static readonly ILog logger = LogManager.GetLogger("WindowsServiceLogger");

        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();

            if (Environment.UserInteractive)
            {
                logger.Info("Iniciando programa en modo consola...");

                Console.CancelKeyPress += Console_CancelKeyPress;

                ServiceCore.Start();

                Thread.Sleep(Timeout.Infinite);
            }
            else
            {
                logger.Info("Iniciando programa en modo servicio...");

                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] 
                { 
                    new Daemon() 
                };
                ServiceBase.Run(ServicesToRun);
            }
        }

        static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            ServiceCore.Stop();
        }
    }
}
