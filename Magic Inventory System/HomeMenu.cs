using System;

namespace Magic_Inventory_System
{
    class HomeMenu : AMenu
    {
        //Should it be in the abstract class ?
        //Quid of prototype
        

        private short ownerMenu()
        {
            OwnerMenu OM = new OwnerMenu();
            short result = 1;

            while (result == 1)
            {
                OM.display();
                result = OM.run();
            }
            return result;
        }
        string[] StoreName = { "CBD", "North", "South", "East", "West" };

        private short franchiseOwnerMenu()
        {
            Console.Clear();
            Console.WriteLine("Franchise holder id ?");
            Console.WriteLine("CBD.1 North.2 South.3 East.4 West.5");
            read();
            short result = 1;
            if (_choice >= 1 && _choice <= 4)
            {
                FranchiseHolderMenu FHM = new FranchiseHolderMenu(StoreName[_choice - 1]);
                while (result == 1)
                {
                    FHM.display();
                    result = FHM.run();
                }
            }
            else
                Console.WriteLine("Wrong franchise holder id");
            return result;
        }

        private short customerMenu()
        {
            Console.Clear();
            Console.WriteLine("Shop id ?");
            Console.WriteLine("CBD.1 North.2 South.3 East.4 West.5");
            read();
            short result = 1;

            if (_choice >= 1 && _choice <= 4)
            {
                CustomerMenu CM = new CustomerMenu(StoreName[_choice - 1]);

                while (result == 1)
                {
                    CM.display();
                    result = CM.run();
                }
            }
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
