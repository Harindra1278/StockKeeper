using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using StockKeeper.ViewModels;
using System;
using System.Data;
using System.Numerics;
using System.Text.RegularExpressions;
using ReactiveUI.Validation.Extensions;
using Avalonia.ReactiveUI;
using ReactiveUI;
using System.Reactive.Disposables;
using Avalonia.Markup.Xaml;
using StockKeeper.Models;

namespace StockKeeper.Views
{
    public partial class AddStockView : ReactiveWindow<AddStockViewModel>
    {
        AddStockViewModel viewModel;
        public AddStockView(Stock stock)
        {
            this.DataContext = viewModel = new AddStockViewModel(this, stock);
            
            //AvaloniaXamlLoader.Load(this);
            InitializeComponent();
           this.WhenActivated(disposables =>
            {
               this.BindValidation(ViewModel, x => x.CurrentStock.ItemName, x => x.UserNameValidation.Text)
                   .DisposeWith(disposables);
                this.BindValidation(ViewModel, x => x.CurrentStock.Description, x => x.UserDescriptionValidation.Text)
                   .DisposeWith(disposables);
                this.BindValidation(ViewModel, x => x.CurrentStock.InvoiceDate, x => x.UserInvoiceValidation.Text)
                  .DisposeWith(disposables);
                this.BindValidation(ViewModel, x => x.CurrentStock.Quantity, x => x.UserQuantityValidation.Text)
                  .DisposeWith(disposables);
                this.BindValidation(ViewModel, x => x.CurrentStock.Price, x => x.UserPriceValidation.Text)
                  .DisposeWith(disposables);
                this.BindValidation(ViewModel, x => x.CurrentStock.Used, x => x.UserUsedValidation.Text)
                   .DisposeWith(disposables);
                this.BindValidation(ViewModel, x => x.CurrentStock.Balance, x => x.UserBalanceValidation.Text)
                  .DisposeWith(disposables);
                this.BindValidation(ViewModel, x => x.CurrentStock.Total, x => x.UserTotalValidation.Text)
                  .DisposeWith(disposables);
                this.BindValidation(ViewModel, x => x.CurrentStock.IssedTo, x => x.UserIssedValidation.Text)
                  .DisposeWith(disposables);
            });
        }
        
       

        public void Actionclose()
        {

            this.Close(viewModel.CurrentStock);
        }
        


    }

   
}


