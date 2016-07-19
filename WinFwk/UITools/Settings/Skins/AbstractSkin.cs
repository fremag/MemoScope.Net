using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFwk.UITools.Settings.Skins
{

    public abstract class AbstractSkin
    {
        public abstract string Name { get; }
        public abstract void Apply(UISettings settings);
    }
}
