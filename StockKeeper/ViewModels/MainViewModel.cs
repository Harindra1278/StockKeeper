using DynamicData;
using LiteDB;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ReactiveUI;
using StockKeeper.Models;
using StockKeeper.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reactive;

namespace StockKeeper.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        StockService stockService;
        
        public ReactiveCommand<Unit, Unit> DeleteCommand { get; set; }
        public ReactiveCommand<Unit, Unit> AddsCommand { get; set; }
        public ReactiveCommand<Unit,Unit> UpdateCommand { get; set; }
        
        public MainViewModel(MainView mainView)
        {
            
            var  execute = () =>
            {
                if (Selecteditem == null) return;
                stockService.Delete(Selecteditem.Id);
                StockList.Remove(Selecteditem);
            };
            var addExecute = async () =>
            {
               // stockService.add(CurrentStock);
                var opReturn = await mainView.Add();
                if(opReturn != null)
                {
                    stockService.add(opReturn);
                    StockList.Add(opReturn);
                }
            };
            var updateexecute = async () =>
            {
                if (selecteditem == null) return;
                await mainView.Update(selecteditem);
                stockService.Update(selecteditem);
            };

            
            DeleteCommand = ReactiveCommand.Create(execute);//,canDelete);
            AddsCommand = ReactiveCommand.CreateFromTask(addExecute);  
            UpdateCommand = ReactiveCommand.CreateFromTask(updateexecute);
            stockService = new StockService(this);
            Loadall();
        }

        private ObservableCollection<Stock> stockList = new ObservableCollection<Stock>();
        public ObservableCollection<Stock> StockList => stockList;
       
        private async void Loadall()
        {
            var stocks = await stockService.GetAll();
            stockList.AddRange(stocks);
        }

        public void Save()
        {
            stockService.Save(StockList.ToList());
        }

        private Stock selecteditem ;

        public Stock Selecteditem 
        
        {
            
            get=>selecteditem;
            set
            {
                if(selecteditem != value)
                {
                    selecteditem = value;
                    SendPropertyChanged(nameof(selecteditem));
                }
            }
                
                
                
        } 


    }

}

