using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
using System.Windows;
using System.Windows.Media;

namespace TestApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var helper = new PaletteHelper();

            var primary = new Swatch(
                "ITB primary",
                new[]
                {
                    new Hue("a", Colors.White,Colors.Black),
                    new Hue("a", Colors.White,Colors.Black),
                    new Hue("a", Colors.White,Colors.Black),
                },
                new[]
                {
                    new Hue("a", Colors.White,Colors.Black),
                    new Hue("a", Colors.White,Colors.Black),
                    new Hue("a", Colors.White,Colors.Black),
                }
            );

            var accent = new Swatch(
                "ITB accent",
                new[]
                {
                    new Hue("a", Colors.White,Colors.Black),
                    new Hue("a", Colors.White,Colors.Black),
                    new Hue("a", Colors.White,Colors.Black),
                },
                new[]
                {
                    new Hue("a", Colors.White,Colors.Black),
                    new Hue("a", Colors.White,Colors.Black),
                    new Hue("a", Colors.White,Colors.Black),
                }
            );

            var palette = new Palette(primary, accent, 1, 1, 1, 1);

            helper.ReplacePalette(palette);

            base.OnStartup(e);
        }
    }
}
