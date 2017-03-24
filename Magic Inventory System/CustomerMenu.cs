using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic_Inventory_System
{
    class CustomerMenu : AMenu
    {
        private short displayWorkshop()
        {
            Console.WriteLine("dW");
            return 1;
        }
        private short displayProduct()
        {
            Console.WriteLine("dP");
            return 1;
        }

        override public void display()
        {
            Console.Clear();
            Console.WriteLine("Welcome in wonderland - Customer Menu");
            Console.WriteLine("==================");
            Console.WriteLine("1. Display products");
            Console.WriteLine("2. Display Workshops");
            Console.WriteLine("3. Return to main menu");
            Console.WriteLine("4. Exit");
        }
        public CustomerMenu()
        {
            functions.Add(displayProduct);
            functions.Add(displayWorkshop);
            // Should quit be on the delegate ?
            functions.Add(quit);
            // NOT WORKING FOR NOW, SAME AS QUIT
            functions.Add(exit);
        }
    }
}
