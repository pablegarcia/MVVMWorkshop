using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

using Microsoft.Extensions.Configuration;

using MVVMApp.Configuration;
using MVVMApp.View;

namespace MVVMApp
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            var customization = new CustomizationSettings();
            Program.Configuration.GetSection("Customization").Bind(customization);

            Bootstrapper.Run(customization);

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
                desktop.MainWindow = Bootstrapper.Resolve<IMainWindow>() as Window;

            base.OnFrameworkInitializationCompleted();
        }
    }
}