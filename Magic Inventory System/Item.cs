using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic_Inventory_System
{
    // Default class to read the inventory
    class Item
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public int CurrentStock { get; set; }
        public bool ReStock { get; set; }

        public Item(int id, string product, int currentStock, bool reStock = false)
        {
            Id = id;
            Product = product;
            CurrentStock = currentStock;
            ReStock = reStock;
        }
    }
}
