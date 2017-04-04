using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.IO;

namespace Magic_Inventory_System
{
    class OwnerMenu : AMenu
    {
        private bool handleStockRequest(Stock stock)
        {
            Console.Write($"Id = {stock.Id} Store = {stock.Store} Product = {stock.Product} Quantity = {stock.Quantity} ");
            Console.WriteLine($"Current Stock = {stock.CurrentStock} Stock Available = {stock.StockAvailability}");
            Console.WriteLine("How many ?");
            read();
            if (stock.StockAvailability == true && _choice + stock.Quantity <= stock.CurrentStock)
            {
                stock.Quantity += _choice;
                Console.WriteLine("Stock updated, press any key to exit");
                waitForInput();
                return true;
            }
            Console.WriteLine("Impossible to update stock, press any key to exit");
            waitForInput();
            return false;
        }
        private bool useCondition = false;
        private bool condition = false;
        private short displayAllStock()
        {
            List<int> IdArray = new List<int>();
            string stockRequestFileName = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\json\\stockrequests.json";
            string lines = File.ReadAllText(stockRequestFileName);
            List<Stock> stocks = JsonConvert.DeserializeObject<List<Stock>>(lines);
            if (stocks == null)
                stocks = new List<Stock>();

            for (int i = 0; i < stocks.Count(); i++)
            {
                if (useCondition == false || condition == stocks[i].StockAvailability)
                {
                    IdArray.Add(stocks[i].Id);
                    Console.Write($"Id = {stocks[i].Id} Store = {stocks[i].Store} Product = {stocks[i].Product} Quantity = {stocks[i].Quantity} ");
                    Console.WriteLine($"Current Stock = {stocks[i].CurrentStock} Stock Available = {stocks[i].StockAvailability}");
                }
            }
            if (IdArray.Count() == 0)
            {
                return 1;
            }
            read();
            if (IdArray.Contains(_choice))
            {
                for (int i = 0; i < stocks.Count(); i++)
                {
                    if (stocks[i].Id == _choice)
                    {
                        if (handleStockRequest(stocks[i]) == true)
                            File.WriteAllText(stockRequestFileName, JsonConvert.SerializeObject(stocks));
                        break;
                    }
                }
            }
            return 1;
        }
        private short displayStock()
        {
            string ConditionString = Console.ReadLine();
            useCondition = true;
            if (String.Compare(ConditionString, "true", true) == 0 || String.Compare(ConditionString, "t", true) == 0)
                condition = true;
            else if (String.Compare(ConditionString, "false", true) == 0 || String.Compare(ConditionString, "f", true) == 0)
                condition = false;
            else
            {
                Console.WriteLine("Invalid input, press any key to exit");
                waitForInput();
                return (1);
            }
            displayAllStock();
            return 1;
        }
        private short displayAllProduct()
        {
            string ownerInventoryFileName = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\json\\owners_inventory.json";
            string lines = File.ReadAllText(ownerInventoryFileName);
            List<Item> products = JsonConvert.DeserializeObject<List<Item>>(lines);
            if (products == null)
                products = new List<Item>();

            for (int i = 0; i < products.Count(); i++)
            {
                Console.WriteLine($"Id = {products[i].Id} Product = {products[i].Product} CurrentStock = {products[i].CurrentStock} ");
            }
            waitForInput();
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
            functions.Add(quit);
            functions.Add(exit);
        }
    }
}
