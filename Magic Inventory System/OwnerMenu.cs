using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic_Inventory_System
{
    class OwnerMenu : AMenu
    {
        private short displayAllStock()
        {
            Console.WriteLine("dAS");
            return 1;
        }
        private short displayStock()
        {
            Console.WriteLine("dS");
            return 1;
        }
        private short displayAllProduct()
        {
            Console.WriteLine("dAP");
            return 1;
        }

        override public void display()
        {
            Console.Clear();
            Console.WriteLine("Welcome in wonderland - Owner Menu");
            Console.WriteLine("==================");
            Console.WriteLine("1. Display all stock requests");
            Console.WriteLine("2. Display stock requests");
            Console.WriteLine("3. Display all product lines");
            Console.WriteLine("4. Return to main menu");
            Console.WriteLine("5. Exit");
        }
        public OwnerMenu()
        {
            functions.Add(displayAllStock);
            functions.Add(displayStock);
            functions.Add(displayAllProduct);
            // Should quit be on the delegate ?
            functions.Add(quit);
            // NOT WORKING FOR NOW, SAME AS QUIT
            functions.Add(exit);
        }
    }
}
