using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml.Serialization;
using WeifenLuo.WinFormsUI.Docking;

namespace WinFwk.UITools.Settings
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class GradientConfig
    {
        [XmlIgnore]
        public Color StartColor { get; set; }
        [XmlIgnore]
        public Color EndColor { get; set; }
        [DefaultValue(LinearGradientMode.Horizontal)]
        public LinearGradientMode LinearGradientMode { get; set; }
        [Browsable(false)]
        public string StartColorStr
        {
            get
            {
                return WinFwkHelper.ToString(StartColor);
            }
            set
            {
                StartColor = WinFwkHelper.FromString(value);
            }
        }
        [Browsable(false)]
        public string EndColorStr
        {
            get
            {
                return WinFwkHelper.ToString(EndColor);
            }
            set
            {
                EndColor = WinFwkHelper.FromString(value);
            }
        }
        [XmlIgnore]
        [Browsable(false)]
        public TabGradient TabGradient => new TabGradient { StartColor = StartColor, EndColor = EndColor, LinearGradientMode = LinearGradientMode };
    }
}
