using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Controls.Documents;
using LiteDB;
using Newtonsoft.Json;
using StockKeeper.ViewModels;

namespace StockKeeper.Models
{
    public class StockService
    {
        private const string StockDataCollection = "stock";
        private const string dbFile = @"E:\vayukah\Stock_Keeper\StockKeeper.db";
        private List<Stock> stocks;
        private LiteDatabase db;

        public StockService(MainViewModel mainViewModel)
        {
            stocks = new List<Stock>();
            db = new LiteDatabase(dbFile);

        }
        public async Task<List<Stock>>GetAll()
        {
            var collection = db.GetCollection<Stock>(StockDataCollection);
            var stocks = collection.Query().ToList();
            return stocks;
        }
        public async Task Save(List<Stock> stock)
        {
            var collection= db.GetCollection<Stock>(StockDataCollection);
             collection.Insert(stock);
        }

        public async void  add(Stock stock)
        {
            var collection = db.GetCollection<Stock>(StockDataCollection);
            collection.Insert(stock);
        }

        internal void Delete(long id)
        {
            var collection = db.GetCollection<Stock>(StockDataCollection);
            collection.Delete(id);
        }

        internal void Update(Stock stock)
        {
            var collection = db.GetCollection<Stock>(StockDataCollection);
            collection.Update(stock);
        }
    }
}
