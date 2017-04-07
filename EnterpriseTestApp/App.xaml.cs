using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
using System.Windows;
using System.Windows.Media;

namespace EnterpriseTestApp
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var helper = new PaletteHelper();

            var blueLight = (Color)ColorConverter.ConvertFromString("#58a3ef");
            var blueMid = (Color)ColorConverter.ConvertFromString("#0075BC");
            var blueDark = (Color)ColorConverter.ConvertFromString("#004a8b");

            var dark = (Color)ColorConverter.ConvertFromString("#333333");
            var light = (Color)ColorConverter.ConvertFromString("#f5f5f5");

            var accentLight = (Color)ColorConverter.ConvertFromString("#b7b7b7");
            var accentMid = (Color)ColorConverter.ConvertFromString("#878787");
            var accentDark = (Color)ColorConverter.ConvertFromString("#5a5a5a");

            var primary = new Swatch(
                "primary",
                new[]
                {
                                new Hue("blueLight2", Colors.Red,dark),
                                new Hue("blueMid2", blueMid,light),
                                new Hue("blueDark2", Colors.Red,dark),
                },
                new[]
                {
                                new Hue("blueLight2", Colors.Red,dark),
                                new Hue("blueMid2", Colors.Red,dark),
                                new Hue("blueDark2", Colors.Red,dark),
                }
            );

            var accent = new Swatch(
                "accent",
                new[]
                {
                                new Hue("blueLight2", Colors.Red,dark),
                                new Hue("blueMid2", Colors.Red,dark),
                                new Hue("blueDark2", Colors.Red,dark),
                },
                new[]
                {
                                new Hue("blueLight2", Colors.Red,dark),
                                new Hue("blueMid2", Colors.Red,dark),
                                new Hue("blueDark2", Colors.Red,dark),
                }
            );


            var palette = new Palette(primary, accent, 1, 1, 1, 1);

            helper.ReplacePalette(palette);
            helper.SetLightDark(false);
            base.OnStartup(e);
        }
    }
}
