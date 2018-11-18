using log4net;
using NCron;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsServiceCrontab.Infraestructure
{
    internal class LogFactory : NCron.Logging.ILogFactory
    {
        public NCron.Logging.ILog GetLogForJob(ICronJob job)
        {
            var internalLogger = LogManager.GetLogger(job.GetType());
            return new LogAdapter(internalLogger);
        }

        internal class LogAdapter : NCron.Logging.ILog
        {
            private readonly ILog _log;

            public LogAdapter(ILog log)
            {
                _log = log;
            }

            public void Debug(Func<string> msgCallback)
            {
                if (_log.IsDebugEnabled)
                    _log.Debug(msgCallback());
            }

            public void Debug(Func<string> msgCallback, Func<Exception> exCallback)
            {
                if (_log.IsDebugEnabled)
                    _log.Debug(msgCallback(), exCallback());
            }

            public void Info(Func<string> msgCallback)
            {
                if (_log.IsInfoEnabled)
                    _log.Info(msgCallback());
            }

            public void Info(Func<string> msgCallback, Func<Exception> exCallback)
            {
                if (_log.IsInfoEnabled)
                    _log.Info(msgCallback(), exCallback());
            }

            public void Warn(Func<string> msgCallback)
            {
                if (_log.IsWarnEnabled)
                    _log.Warn(msgCallback());
            }

            public void Warn(Func<string> msgCallback, Func<Exception> exCallback)
            {
                if (_log.IsWarnEnabled)
                    _log.Warn(msgCallback(), exCallback());
            }

            public void Error(Func<string> msgCallback)
            {
                if (_log.IsErrorEnabled)
                    _log.Error(msgCallback());
            }

            public void Error(Func<string> msgCallback, Func<Exception> exCallback)
            {
                if (_log.IsErrorEnabled)
                    _log.Error(msgCallback(), exCallback());
            }

            public void Dispose()
            {
            }
        }
    }
}
