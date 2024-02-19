using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using StockKeeper.Models;
using StockKeeper.ViewModels;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace StockKeeper.Views
{
    public partial class MainView : UserControl
    {
        private MainViewModel viewModel;
        public MainView()
        {
            InitializeComponent();

            viewModel = new MainViewModel(this);    
            this.DataContext = viewModel;   
        }
       public async Task<Stock> Add(Stock? stockToUpdate = null)
        {
            AddStockView add = new AddStockView(stockToUpdate);
            return await add.ShowDialog<Stock>(FindParentWindow(this));
            
        }

        public async Task<Stock> Update(Stock? stockToUpdate = null)
        {
            AddStockView add = new AddStockView(stockToUpdate);
            return await add.ShowDialog<Stock>(FindParentWindow(this));
        }

        private Window FindParentWindow(Control element)
        {
            if (element == null) return null;
            var parent = element.Parent;
            if (parent == null) return null;
            if (parent is Window topWindow) return topWindow;
            return FindParentWindow(parent as Control);
        }

        public void OnMainWindowClosing()
        {
            viewModel.Save();
        }

    }
}