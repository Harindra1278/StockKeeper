using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

using StockKeeper.ViewModels;
using StockKeeper.Views;

namespace StockKeeper;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            //var mainWindow = new MainWindow();
            //var mainViewModel = new MainViewModel(mainWindow.stockListUI);
            //mainWindow.DataContext = mainViewModel;
            desktop.MainWindow = new MainWindow();
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            //var view = new MainView();

            //view.DataContext = new MainViewModel(view);
            singleViewPlatform.MainView = new MainView();
            
        }

        base.OnFrameworkInitializationCompleted();
    }
}
