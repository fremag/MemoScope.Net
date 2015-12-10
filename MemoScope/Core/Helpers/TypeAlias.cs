using System.ComponentModel;
using System.Drawing;
using System.Xml.Serialization;

namespace MemoScope.Core.Helpers
{
    public class TypeAlias
    {
        public bool Active { get; set; } = true;
        public string OldTypeName { get; set; }
        public string NewTypeName { get; set; }

        [XmlIgnore]
        public Color BackColor
        {
            get;set;
        }

        [Browsable(false)]
        public string BackColorRGB
        {
            get
            {
                return BackColor.R +","+BackColor.G+","+BackColor.B;
            }
            set
            {
                string[] c = value.Split(',');
                BackColor = Color.FromArgb(int.Parse(c[0]), int.Parse(c[1]), int.Parse(c[2]));
            }
        }
        [XmlIgnore]
        public Color ForeColor
        {
            get; set;
        }

        [Browsable(false)]
        public string ForeColorRGB
        {
            get
            {
                return ForeColor.R + "," + ForeColor.G + "," + ForeColor.B;
            }
            set
            {
                string[] c = value.Split(',');
                ForeColor = Color.FromArgb(int.Parse(c[0]), int.Parse(c[1]), int.Parse(c[2]));
            }
        }

        public override int GetHashCode()
        {
            return (OldTypeName == null ? 0 : OldTypeName.GetHashCode()) + 37 * (NewTypeName == null ? 0 : NewTypeName.GetHashCode());
        }
        public override bool Equals(object o)
        {
            var other = o as TypeAlias;
            if (other == null)
            {
                return false;
            }
            bool b1 = other.NewTypeName == NewTypeName;
            bool b2 = other.OldTypeName == OldTypeName;
            return b1 && b2;
        }
        public override string ToString()
        {
            return "["+(Active ? "+": "-")+"] "+ OldTypeName + " => " + NewTypeName;
        }
    }
}
