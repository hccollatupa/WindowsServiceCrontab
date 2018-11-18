using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using NCron;
using Repositories.Contracts;
using Entities;

namespace WindowsServiceCrontab.Core
{
    public class ClientJob : CronJob
    {
        #region Declarations

        private static readonly ILog logger = LogManager.GetLogger("WindowsServiceLogger");
        private IClientRepository _clientRepository;
        private Action _completionCallback;

        #endregion

        public ClientJob(IClientRepository _clientRepository, Action completionCallback)
        {
            try
            {
                this._clientRepository = _clientRepository;
                this._completionCallback = completionCallback;
            }
            catch (Exception ex)
            {
                logger.Error("Se produjo un error inesperado.", ex);
                _completionCallback();
            }
        }

        public override void Execute()
        {
            var counter = 0;
            try
            {
                logger.Info("Obteniendo nuevos avisos para procesar...");

                var clients = _clientRepository.GetAll();

                if (clients.Count > 0)
                {
                    logger.InfoFormat("Se encontraron {0} nuevos avisos por procesar.", clients.Count);

                    foreach (var client in clients)
                    {
                        Process(client);
                        counter++;
                    }

                    logger.InfoFormat("Fin del procesamiento. Se procesaron {0} registros en total.", counter);
                }
                else
                {
                    logger.Info("No hay nuevos avisos por procesar.");
                }
            }
            catch (Exception ex)
            {
                logger.Error("Se produjo un error inesperado.", ex);
            }
            finally {
                _completionCallback();
            }
        }

        public void Process(Client client)
        {
            logger.Info("Ejecutar lógica.");
        }
    }
}