﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic_Inventory_System
{
    class FranchiseHolderMenu : AMenu
    {
        private int _id;
        private short displayInventory()
        {
            Console.WriteLine("dI");
            return 1;
        }
        private short displayInventoryThreshold()
        {
            Console.WriteLine("dIT");
            return 1;
        }
        private short addNewItem()
        {
            Console.WriteLine("aNI");
            return 1;
        }

        override public void display()
        {
            Console.Clear();
            Console.WriteLine("Welcome in wonderland - Franchise Holder Menu");
            Console.WriteLine("==================");
            Console.WriteLine("1. Display inventory");
            Console.WriteLine("2. Display inventory (Threshold)");
            Console.WriteLine("3. Add new inventory item");
            Console.WriteLine("4. Return to main menu");
            Console.WriteLine("5. Exit");
        }
        public FranchiseHolderMenu(int id)
        {
            functions.Add(displayInventory);
            functions.Add(displayInventoryThreshold);
            functions.Add(addNewItem);
            functions.Add(quit);
            functions.Add(exit);
            _id = id;
        }
    }
}
