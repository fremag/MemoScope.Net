
using System.ComponentModel;
using System.Drawing;
using System.Xml.Serialization;

namespace WinFwk.UITools.Settings
{
    public class UISettings
    {
        public static UISettings Instance { get; private set; }

        internal static void InitSettings(UISettings uiSettings)
        {
            Instance = uiSettings;
        }

        [XmlIgnore]
        [Category("GUI - Main")]
        public Color BackgroundColor { get; set; }
        [Browsable(false)]
        public string BackgroundColorStr
        {
            get
            {
                return WinFwkHelper.ToString(BackgroundColor);
            }
            set
            {
                BackgroundColor = WinFwkHelper.FromString(value);
            }
        }

        [XmlIgnore]
        [Category("GUI - Main")]
        public Color ForegroundColor { get; set; }
        [Browsable(false)]
        public string ForegroundColorStr
        {
            get
            {
                return WinFwkHelper.ToString(ForegroundColor);
            }
            set
            {
                ForegroundColor = WinFwkHelper.FromString(value);
            }
        }

        [Category("GUI - Tables")]
        public bool UseAlternateRowColor { get; set; }
        [XmlIgnore]
        [Category("GUI - Tables")]
        public Color AlternateRowColor { get; set; }
        [Browsable(false)]
        public string AlternateRowColorStr
        {
            get
            {
                return WinFwkHelper.ToString(AlternateRowColor);
            }
            set
            {
                AlternateRowColor = WinFwkHelper.FromString(value);
            }
        }
        [XmlIgnore]
        [Category("GUI - Tables")]
        public Color HeaderBackColor { get; set; }
        [Browsable(false)]
        public string HeaderBackColorStr
        {
            get
            {
                return WinFwkHelper.ToString(HeaderBackColor);
            }
            set
            {
                HeaderBackColor = WinFwkHelper.FromString(value);
            }
        }
        [XmlIgnore]
        [Category("GUI - Tables")]
        public Color HeaderForeColor { get; set; }
        [Browsable(false)]
        public string HeaderForeColorStr
        {
            get
            {
                return WinFwkHelper.ToString(HeaderForeColor);
            }
            set
            {
                HeaderForeColor = WinFwkHelper.FromString(value);
            }
        }
        [XmlIgnore]
        [Category("GUI - Tables")]
        public Color SelectedRowBackgroundColor { get; set; }
        [Browsable(false)]
        public string SelectedRowBackgroundColorStr
        {
            get
            {
                return WinFwkHelper.ToString(SelectedRowBackgroundColor);
            }
            set
            {
                SelectedRowBackgroundColor = WinFwkHelper.FromString(value);
            }
        }
        [XmlIgnore]
        [Category("GUI - Tables")]
        public Color SelectedRowForegroundColor { get; set; }
        [Browsable(false)]
        public string SelectedRowForeColorStr
        {
            get
            {
                return WinFwkHelper.ToString(SelectedRowForegroundColor);
            }
            set
            {
                SelectedRowForegroundColor = WinFwkHelper.FromString(value);
            }
        }
    }
}