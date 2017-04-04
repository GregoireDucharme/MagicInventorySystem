using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic_Inventory_System
{
    // Default class to use the owner stock
    class Stock
    {
        public int Id {get; set;}
        public string Store { get; set;}
        public string Product { get; set; }
        public int Quantity { get; set; }
        public int CurrentStock { get; set; }
        public bool StockAvailability { get; set; }

        public Stock(int id, string store, string product, int quantity, int currentStock, bool stockAvailability)
        {
            Id = id;
            Store = store;
            Product = product;
            Quantity = quantity;
            CurrentStock = currentStock;
            StockAvailability = stockAvailability;
        }
    }
}
