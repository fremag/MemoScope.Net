using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using BrightIdeasSoftware;
using NLog;
using WinFwk.UIMessages;
using WinFwk.UIModules;

namespace WinFwk.UITools
{
    public partial class LogModule : UIModule
        , IMessageListener<LogMessage>
    {
        private readonly LogModel model = new LogModel();

        public LogModule()
        {
            InitializeComponent();
            colTimeStamp.AspectGetter = o => model.GetTimeStamp(o);
            colLogLevel.AspectGetter = o => model.GetLogLevel(o);
            colText.AspectGetter = o => model.GetText(o);
            colException.AspectGetter = o => model.GetException(o);
            dlvLogMessages.CellClick += OnCellClick;
        }

        private void OnCellClick(object sender, CellClickEventArgs e)
        {
            if (e.ClickCount != 2)
            {
                return;
            }

            var logMessage = e.Item.RowObject as LogMessage ;
            if (logMessage == null)
            {
                return;
            }
            LogMessageViewer viewer = new LogMessageViewer();
            viewer.Init(logMessage);
            RequestDockModule(viewer);
        }

        public void HandleMessage(LogMessage message)
        {
            var logger = LogManager.GetLogger(message.LoggerName);
            switch (message.LogLevel)
            {
                case LogLevelType.Debug:
                    logger.Debug(message.Text);
                    break;
                case LogLevelType.Info:
                    logger.Info(message.Text);
                    break;
                case LogLevelType.Warn:
                    logger.Warn(message.Text);
                    break;
                case LogLevelType.Error:
                    logger.Error(message.Text);
                    break;
                case LogLevelType.Exception:
                    logger.Error(message.Exception, message.Text);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            model.Add(message);
            dlvLogMessages.SetObjects(model);
        }

        private void fdlvLogMessages_FormatCell(object sender, BrightIdeasSoftware.FormatCellEventArgs e)
        {
            if (e.Column != colLogLevel)
                return;

           e.SubItem.BackColor = GetLogLevelColor((LogLevelType) e.SubItem.ModelValue);
        }

        private static Color GetLogLevelColor(LogLevelType logLevel)
        {
            switch (logLevel)
            {
                case LogLevelType.Debug:
                    return Color.LightSkyBlue;
                case LogLevelType.Info:
                    return Color.PaleGreen;
                case LogLevelType.Warn:
                    return Color.Yellow;
                case LogLevelType.Error:
                    return Color.Red;
                case LogLevelType.Exception:
                    return Color.MediumPurple;
                default:
                    throw new ArgumentOutOfRangeException(nameof(logLevel), logLevel, null);
            }
        }
    }

    public class LogModel : IEnumerable
    {
        private readonly List<LogMessage> logMessages = new List<LogMessage>();

        public IEnumerator GetEnumerator()
        {
            return logMessages.GetEnumerator();
        }

        public void Add(LogMessage logMessage)
        {
            logMessages.Add(logMessage);
        }

        public DateTime GetTimeStamp(object o)
        {
            return ((LogMessage) o).TimeStamp;
        }

        public LogLevelType GetLogLevel(object o)
        {
            return ((LogMessage) o).LogLevel;
        }

        public object GetText(object o)
        {
            return ((LogMessage) o).Text;
        }

        public object GetException(object o)
        {
            return ((LogMessage) o).Exception;
        }
    }
}