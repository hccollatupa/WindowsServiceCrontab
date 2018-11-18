using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using NCron;
using System.Reflection;
using Ninject;
using NCron.Service;
using NCron.Fluent.Crontab;
using WindowsServiceCrontab.Infraestructure;
using System.Configuration;
using Repositories.Contracts;
using InversionControl;

namespace WindowsServiceCrontab.Core
{
    public class ServiceCore
    {
        #region Declarations

        private static readonly ILog logger = LogManager.GetLogger("WindowsServiceLogger");
        private static IClientRepository _clientRepository;
        private static ISchedulingService _schedulingService;
        private static volatile bool _isRunning = false;

        #endregion

        public static void Start()
        {
            logger.Info("Conectandose a las bases de datos...");

            CreateRepositories();

            var cronExpression = ConfigurationManager.AppSettings["scheduleConfig"];
            logger.InfoFormat("Configurando servicio con la expresión '{0}'...", cronExpression);

            _schedulingService = new SchedulingService();
            _schedulingService.LogFactory = new LogFactory();

            _schedulingService.At(cronExpression).Run(() =>
            {
                if (!_isRunning)
                {
                    _isRunning = true;

                    return new ClientJob(
                        _clientRepository,
                        () =>
                        {
                            _isRunning = false;
                        });
                }
                return new DumClientJob();
            });
            _schedulingService.Start();

            logger.Info("Servicio corriendo...");
        }

        public static void Stop()
        {
            logger.Info("Finalizando ejecución...");
            _schedulingService.Stop();
            logger.Info("Servicio detenido.");
        }

        private static void CreateRepositories() 
        {
            var Ioc = new IoC();
            IKernel _Kernal = Ioc.Kernel;
            _Kernal.Load(Assembly.GetExecutingAssembly());
            _clientRepository = _Kernal.Get<IClientRepository>();
        }
    }
}