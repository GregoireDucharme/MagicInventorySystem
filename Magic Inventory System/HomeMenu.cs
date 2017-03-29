using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic_Inventory_System
{
    class HomeMenu : AMenu
    {
        //Should it be in the abstract class ?
        //Quid of prototype
        

        private short ownerMenu()
        {
            Console.WriteLine("oM");
            OwnerMenu OM = new OwnerMenu();
            short result = 1;

            while (result == 1)
            {
                OM.display();
                result = OM.run();
            }
            return result;
        }
        private short franchiseOwnerMenu()
        {
            Console.WriteLine("fOM");
            Console.Clear();
            Console.WriteLine("Franchise holder id ?");
            read();
            FranchiseHolderMenu FHM = new FranchiseHolderMenu(_choice);
            short result = 1;

            while (result == 1)
            {
                FHM.display();
                result = FHM.run();
            }
            return result;
        }
        private short customerMenu()
        {
            Console.Clear();
            Console.WriteLine("Which shop id ?");
            read();
            CustomerMenu CM = new CustomerMenu(_choice);
            short result = 1;

            while (result == 1)
            {
                CM.display();
                result = CM.run();
            }
            Console.WriteLine("cM");
            return result;
        }
        public HomeMenu()
        {
            functions.Add(ownerMenu);
            functions.Add(franchiseOwnerMenu);
            functions.Add(customerMenu);
            // Should quit be on the delegate ?
            functions.Add(exit);
        }
        override public void display()
        {
            Console.Clear();
            Console.WriteLine("Welcome in wonderland - Home Menu");
            Console.WriteLine("==================");
            Console.WriteLine("1. Owner");
            Console.WriteLine("2. Franchise Owner");
            Console.WriteLine("3. Customer");
            Console.WriteLine("4. Quit");
    
        }
    }
}
