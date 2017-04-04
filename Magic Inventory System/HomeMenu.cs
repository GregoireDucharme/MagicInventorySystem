using System;

namespace Magic_Inventory_System
{
    class HomeMenu : AMenu
    {
       

        private short ownerMenu()
        {
            try
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
            catch (Exception e)
            {
                Console.WriteLine("An error occured: " + e.ToString());
            }
            return 1;
        }
        string[] StoreName = { "CBD", "North", "South", "East", "West" };

        private short franchiseOwnerMenu()
        {
            Console.Clear();
            Console.WriteLine("Franchise holder id ?");
            Console.WriteLine("CBD.1 North.2 South.3 East.4 West.5");
            try
            {
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
            catch (Exception e)
            {
                Console.WriteLine("An error occured: " + e.ToString());
            }
            return 1;
        }

        private short customerMenu()
        {
            Console.Clear();
            Console.WriteLine("Shop id ?");
            Console.WriteLine("CBD.1 North.2 South.3 East.4 West.5");
            try
            {
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
            catch (Exception e)
            {
                Console.WriteLine("An error occured: " + e.ToString());
            }
            return 1;
        }
        public HomeMenu()
        {
            functions.Add(ownerMenu);
            functions.Add(franchiseOwnerMenu);
            functions.Add(customerMenu);
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
