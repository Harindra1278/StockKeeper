using Avalonia;
using Avalonia.Interactivity;
using Avalonia.Media;
using ReactiveUI;
using ReactiveUI.Validation.Abstractions;
using ReactiveUI.Validation.Contexts;
using ReactiveUI.Validation.Extensions;
using ReactiveUI.Validation.Helpers;
using StockKeeper.Models;
using StockKeeper.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows.Input;
namespace StockKeeper.ViewModels
{
    public class AddStockViewModel : ReactiveValidationObject 
    {


        private Stock currentStock;
        public Stock CurrentStock
        {
            get => currentStock;
            set => this.RaiseAndSetIfChanged(ref currentStock, value);
        }
                
        public ReactiveCommand<Unit, Unit> AddCommand { get; }
        
        public AddStockViewModel(AddStockView adv, Stock stockToUpdate)
        {
            currentStock = stockToUpdate ?? new Stock();
            
            Func<string?, bool> check_invoice = (strValue) => DateTime.TryParse(strValue, out DateTime _ );

            this.ValidationRule(
                viewModel => viewModel.CurrentStock.ItemName,
                name => !string.IsNullOrWhiteSpace(name),
                "You must specify a valid name");
            this.ValidationRule(
                viewModel => viewModel.CurrentStock.Description,
                _description => !string.IsNullOrWhiteSpace(_description),
                "You must specify a valid Descrition");
            this.ValidationRule(
               viewModel => viewModel.CurrentStock.InvoiceDate,
               check_invoice,
               "You must specify a valid Invoice");
            this.ValidationRule(
               viewModel => viewModel.CurrentStock.Quantity,
              _quantity => _quantity >= 0,
               "You must specify a valid Quantity");
            this.ValidationRule(
               viewModel => viewModel.CurrentStock.Price,
              _price => _price >= 0,
               "You must specify a valid Price");
            this.ValidationRule(
              viewModel => viewModel.CurrentStock.Price,
             _price => _price >= 0,
              "You must specify a valid Price");
            this.ValidationRule(
              viewModel => viewModel.CurrentStock.Used,
             _used => _used >= 0,
              "You must specify a valid used");
            this.ValidationRule(
              viewModel => viewModel.CurrentStock.Balance,
             _balance => _balance >= 0,
              "You must specify a valid Balance");
            this.ValidationRule(
             viewModel => viewModel.CurrentStock.Total,
           _total => _total >= 0,
             "You must specify a valid Re-order");
            this.ValidationRule(
             viewModel => viewModel.CurrentStock.IssedTo,
           _issed => !string.IsNullOrWhiteSpace(_issed),
             "You must specify a valid Issed");



            var execute = () => {
                adv.Actionclose();
            };
            
            AddCommand = ReactiveCommand.Create(execute);
            
        }
    }
}

