namespace WinFwk.UITools.Settings.Skins
{

    public abstract class AbstractSkin
    {
        public abstract string Name { get; }
        public abstract void Apply(UISettings settings);
    }
}
