using System.Drawing;
using System.Drawing.Drawing2D;

namespace WinFwk.UITools.Settings.Skins
{
    public class DarkSkin : AbstractSkin
    {
        public override string Name => "Dark";

        public override void Apply(UISettings settings)
        {
            settings.AlternateRowColor = Color.Gray;
            settings.BackgroundColor = Color.DarkSlateGray;
            settings.ForegroundColor= Color.LightGray;

            settings.HeaderBackColor = SystemColors.Menu;
            settings.HeaderForeColor= SystemColors.MenuText;

            settings.DockStripGradient.StartColor = Color.DarkSlateGray;
            settings.DockStripGradient.EndColor = Color.DarkSlateGray;
            settings.DockStripGradient.LinearGradientMode = LinearGradientMode.Vertical;

            settings.ActiveTabGradient.StartColor = Color.LightGray;
            settings.ActiveTabGradient.EndColor = Color.LightGray;
            settings.ActiveTabGradient.LinearGradientMode = LinearGradientMode.Vertical;

            settings.InactiveTabGradient.StartColor = Color.DarkSlateGray;
            settings.InactiveTabGradient.EndColor = Color.DarkSlateGray;
            settings.InactiveTabGradient.LinearGradientMode = LinearGradientMode.Vertical;

            settings.ActiveCaptionGradient.StartColor = Color.LightGray;
            settings.ActiveCaptionGradient.EndColor = Color.LightGray;
            settings.ActiveCaptionGradient.LinearGradientMode = LinearGradientMode.Vertical;

            settings.InactiveCaptionGradient.StartColor = Color.DarkSlateGray;
            settings.InactiveCaptionGradient.EndColor = Color.DarkSlateGray;
            settings.InactiveCaptionGradient.LinearGradientMode = LinearGradientMode.Vertical;
        }
    }
}
