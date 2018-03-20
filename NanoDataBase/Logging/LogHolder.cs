using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace NanoDataBase.Logging
{
    public static class LogHolder
    {
        private static EventHandler<LogEventInfo> _messageLogEventHandler;


        public static event EventHandler<LogEventInfo> MessageLogEventHandler
        {
            add
            {
                _messageLogEventHandler += value;
            }
            remove
            {
                if (_messageLogEventHandler != null)
                    _messageLogEventHandler -= value;
            }
        }

        //private readonly static Logger _mainLog = LogManager.GetCurrentClassLogger();
        private readonly static Logger _mainLog = LogManager.GetLogger("MainLog");
        private readonly static Logger _errorLog = LogManager.GetLogger("ErrorLog");
        private readonly static Logger _traceLog = LogManager.GetLogger("TraceLog");
        private readonly static Logger _debugLog = LogManager.GetLogger("DebugLog");


        public static Logger MainLog
        {
            get { return _mainLog; }
        }

        public static Logger ErrorLog
        {
            get { return _errorLog; }
        }

        public static void MainLogInfo(string messageLog)
        {
            _mainLog.Log(LogLevel.Info, messageLog);
            if (_messageLogEventHandler != null)
                _messageLogEventHandler(messageLog, new LogEventInfo(LogLevel.Info, _mainLog.Name, messageLog));
        }

        public static void MainLogWarning(string messageLog)
        {
            _mainLog.Warn(messageLog);
            if (_messageLogEventHandler != null)
                _messageLogEventHandler(messageLog, new LogEventInfo(LogLevel.Warn, _mainLog.Name, messageLog));
        }

        public static void LogTrace(string messageLog)
        {
            _traceLog.Trace(messageLog);
            if (_messageLogEventHandler != null)
                _messageLogEventHandler(messageLog, new LogEventInfo(LogLevel.Trace, _mainLog.Name, messageLog));
        }

        public static void LogDebug(string messageLog)
        {
#if DEBUG
            _debugLog.Debug(messageLog);
            if (_messageLogEventHandler != null)
                _messageLogEventHandler(messageLog, new LogEventInfo(LogLevel.Debug, _mainLog.Name, messageLog));
#endif
        }

        public static void LogError(Exception exception)
        {
            _errorLog.Log(LogLevel.Error, exception);
            if (_messageLogEventHandler != null)
                _messageLogEventHandler(exception.Message, new LogEventInfo(LogLevel.Error, _mainLog.Name, exception.Message));
        }
    }

}
