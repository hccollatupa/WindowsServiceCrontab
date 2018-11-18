using log4net;
using NCron;

namespace WindowsServiceCrontab.Core
{
    public class DumClientJob : CronJob
    {
        private static readonly ILog logger = LogManager.GetLogger("WindowsServiceLogger");

        public override void Execute()
        {
            logger.Debug("Existe una instancia aun corriendo. Se esperará a la finalización de la misma.");
        }
    }
}
