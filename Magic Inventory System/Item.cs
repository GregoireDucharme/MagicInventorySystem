using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic_Inventory_System
{
    class Item
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public int CurrentStock { get; set; }
        public bool ReStock { get; set; }
    }
}
