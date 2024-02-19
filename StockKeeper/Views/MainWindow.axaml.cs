using Avalonia.Controls;

namespace StockKeeper.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    protected override void OnClosing(WindowClosingEventArgs e)
    {
        stockListUI.OnMainWindowClosing();
        base.OnClosing(e);
    }

}
