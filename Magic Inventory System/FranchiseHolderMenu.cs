using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Magic_Inventory_System
{
    class FranchiseHolderMenu : AMenu
    {
        private bool useCondition = false;
        private int condition = 0;
        private string _storeName;
        private void handleRequestInventory(Item product)
        {
            Console.WriteLine("How many ?");
            read();
            if (product.ReStock == true)
            {
                List<Stock> stocks = new List<Stock>();
                string ownerInventoryFileName = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\json\\owners_inventory.json";
                string lines = File.ReadAllText(ownerInventoryFileName);
                List<Item> ownerProducts = JsonConvert.DeserializeObject<List<Item>>(lines);
                bool availability = false;
                for (int i = 0; i < ownerProducts.Count(); i++)
                {
                    if (string.Compare(ownerProducts[i].Product, product.Product) == 0)
                    {
                        if (ownerProducts[i].CurrentStock >= _choice)
                        {
                            availability = true;
                            break;
                        }
                    }
                }
                string stockRequestFileName = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\json\\stockrequests.json";
                lines = File.ReadAllText(stockRequestFileName);
                stocks = JsonConvert.DeserializeObject<List<Stock>>(lines);
                stocks.Add(new Stock(stocks.Last().Id + 1, _storeName, product.Product, _choice, product.CurrentStock, availability));
                File.WriteAllText(stockRequestFileName, JsonConvert.SerializeObject(stocks));
                Console.WriteLine("Request will be processed, press any key to exit");
                waitForInput();
            }
            else
            {
                Console.WriteLine("Impossible to request as much, press any key to exit");
                waitForInput();
            }
        }
        private short displayInventory()
        {
            Console.WriteLine("dI");
            List<int> IdArray = new List<int>();
            string storeInventoryFileName = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\json\\" + _storeName + "_inventory.json";
            string lines = File.ReadAllText(storeInventoryFileName);
            List <Item> products = JsonConvert.DeserializeObject<List<Item>>(lines);
            Console.WriteLine("dAS");
            for (int i = 0; i < products.Count(); i++)
            {
                if (useCondition == false || useCondition == true && products[i].CurrentStock <= condition)
                {
                    IdArray.Add(products[i].Id);
                    Console.WriteLine($"Id = {products[i].Id} Product = {products[i].Product} CurrentStock = {products[i].CurrentStock} Re-Stock = {products[i].ReStock}");
                }
            }
            if (IdArray.Count() == 0)
            {
                return 1;
            }
            read();
            if (IdArray.Contains(_choice))
            {
                for (int i = 0; i < products.Count(); i++)
                {
                    if (products[i].Id == _choice)
                    {
                        handleRequestInventory(products[i]);
                        break;
                    }
                }
            }
            return 1;
        }
        private short displayInventoryThreshold()
        {
            Console.WriteLine("dIT");
            Console.WriteLine("Define threshold");
            read();
            useCondition = true;
            condition = _choice;
            displayInventory();
            return 1;
        }
        private short addNewItem()
        {
            Console.WriteLine("aNI");
            List<int> IdArray = new List<int>();
            string storeInventoryFileName = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\json\\" + _storeName + "_inventory.json";
            string lines = File.ReadAllText(storeInventoryFileName);
            List<Item> products = JsonConvert.DeserializeObject<List<Item>>(lines);

            string ownerInventoryFileName = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\json\\owners_inventory.json";
            lines = File.ReadAllText(ownerInventoryFileName);
            List<Item> ownerProducts = JsonConvert.DeserializeObject<List<Item>>(lines);
            Console.WriteLine("dAS");
            Console.WriteLine("Your items");
            List<string> productArray = new List<string>();
            for (int i = 0; i < products.Count(); i++)
            {
                productArray.Add(products[i].Product);
                Console.WriteLine($"Id = {products[i].Id} Product = {products[i].Product} CurrentStock = {products[i].CurrentStock} ");
            }
            Console.WriteLine("Owner items");
            bool check = false;
            for (int i = 0; i < ownerProducts.Count(); i++)
            {
                if (!productArray.Contains(ownerProducts[i].Product))
                {
                    check = true;
                    Console.WriteLine($"Id = {ownerProducts[i].Id} Product = {ownerProducts[i].Product} CurrentStock = {ownerProducts[i].CurrentStock} ");
                }
            }
            if (!check)
            {
                Console.WriteLine("No item to add");
                return 1;
            }
            Console.WriteLine("Which one ?");
            read();
            int id = _choice;
            Console.WriteLine("How many?");
            read();
            for (int i = 0; i < ownerProducts.Count(); i++)
            {
                if (ownerProducts[i].Id == id)
                {
                    if (_choice <= ownerProducts[i].CurrentStock)
                    {
                        ownerProducts[i].CurrentStock -= _choice;
                        File.WriteAllText(ownerInventoryFileName, JsonConvert.SerializeObject(ownerProducts));
                        ownerProducts[i].Id = products.Last().Id;
                        ownerProducts[i].CurrentStock = _choice;
                        products.Add(ownerProducts[i]);
                        File.WriteAllText(storeInventoryFileName, JsonConvert.SerializeObject(products));
                        break;
                    }
                }
            }
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
        public FranchiseHolderMenu(string storeName)
        {
            functions.Add(displayInventory);
            functions.Add(displayInventoryThreshold);
            functions.Add(addNewItem);
            functions.Add(quit);
            functions.Add(exit);
            _storeName = storeName;
        }
    }
}
