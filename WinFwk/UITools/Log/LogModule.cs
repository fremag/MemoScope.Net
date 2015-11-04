using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using BrightIdeasSoftware;
using NLog;
using NLog.Targets;
using WinFwk.UIMessages;
using WinFwk.UIModules;

namespace WinFwk.UITools.Log
{
    public partial class LogModule : UIModule
        , IMessageListener<LogMessage>
    {
        private readonly LogModel model = new LogModel();

        public LogModule()
        {
            InitializeComponent();
            colTimeStamp.AspectGetter = model.GetTimeStamp;
            colLogLevel.AspectGetter = model.GetLogLevel;
            colText.AspectGetter = model.GetText;
            colException.AspectGetter = model.GetException;
            dlvLogMessages.CellClick += OnCellClick;

            Icon = Properties.Resources.small_file_extension_log;
            Summary = "Logs";
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
                case LogLevelType.Notify:
                    logger.Info(message.Text);
                    notifyIcon.BalloonTipTitle = notifyIcon.Text;
                    notifyIcon.BalloonTipText = string.IsNullOrEmpty(message.Text) ? "Hello !" : message.Text; ; 
                    notifyIcon.ShowBalloonTip(1000);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            model.Add(message);
            dlvLogMessages.SetObjects(model);
        }

        private void OnCellClick(object sender, CellClickEventArgs e)
        {
            if (e.ClickCount != 2)
            {
                return;
            }

            var logMessage = model.GetObject(e.Item.RowObject);
            if (logMessage == null)
            {
                return;
            }
            LogMessageViewerModule viewerModule = new LogMessageViewerModule {UIModuleParent = this};
            viewerModule.Init(logMessage);
            RequestDockModule(viewerModule);
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
                case LogLevelType.Notify:
                    return Color.Chartreuse;
                default:
                    throw new ArgumentOutOfRangeException(nameof(logLevel), logLevel, null);
            }
        }

        private void LogModule_Load(object sender, EventArgs e)
        {
            var appIcon = System.Drawing.Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);
            notifyIcon.Icon = appIcon;
            notifyIcon.Text = $"{Application.ProductName} ({Application.ProductVersion})";
            notifyIcon.Visible = true;
        }

        private void btnOpenLogFile_Click(object sender, EventArgs e)
        {
            foreach (var fileTarget in LogManager.Configuration.AllTargets.OfType<FileTarget>())
            {
                var logEventInfo = new LogEventInfo { TimeStamp = DateTime.Now };
                string fileName = fileTarget.FileName.Render(logEventInfo);
                Process.Start(fileName);
            }
        }
    }
}