using Avalonia;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StockKeeper.Models
{
    [DataContract]

    public class Stock : ReactiveObject
    {

       

        [DataMember]
        public int Price
        {
            get => price;
            set => this.RaiseAndSetIfChanged(ref price, value);
        }
        [DataMember]
        public int Used
        {
            get => used;
            set
            {
                this.RaiseAndSetIfChanged(ref used, value);
                var remaining = quantity - used;
                if(remaining >=0)
                {
                    balance = remaining;
                    this.RaisePropertyChanged(nameof(Balance));
                }
            }
        }

        [DataMember]
        public int Balance
        {

            get => balance;
            set => this.RaiseAndSetIfChanged(ref balance, value);
        }


        [DataMember]
        public int Total
        {
            get => total;
            set => this.RaiseAndSetIfChanged(ref total, value);
        }
        [DataMember]
        public String ItemName
        {
            get => itemName;
            set => this.RaiseAndSetIfChanged(ref itemName, value);
    }

        [DataMember]
        public String Description
        {
            get => description;
            set => this.RaiseAndSetIfChanged(ref description, value);
        }
        [DataMember]
        public String InvoiceDate
        {
            get => invoiceDate;
            set => this.RaiseAndSetIfChanged(ref invoiceDate, value);
        }

        [DataMember]
        public int Quantity
        {
            get => quantity;
            set => this.RaiseAndSetIfChanged(ref quantity, value);
        }
        [DataMember]
        public String IssedTo
        {
            get => issedTo;
            set => this.RaiseAndSetIfChanged(ref issedTo, value);
        }
        [DataMember]

        public long Id{
            get => id;
          set => this.RaiseAndSetIfChanged(ref id, value);  

        }

        private String itemName = String.Empty;
        private String description = String.Empty;
        private String invoiceDate = String.Empty;
        private int quantity ;
        private int price;
        private int used;
        private int balance;
        private int total;
        private long id;
        private String issedTo = String.Empty;
    }
}

