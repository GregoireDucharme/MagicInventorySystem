using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Magic_Inventory_System
{
    class CustomerMenu : AMenu
    {
        private string bookingReferenceMorning;
        private string bookingReferenceAfternoon;
        private string _storeName;
        private int registeredForWorkshop = 0;
        List<Tuple<string, int>> pickedItems = new List<Tuple<string, int>>();

        private short displayWorkshop()
        {
            Console.Clear();
            Console.WriteLine("Workshop available");
            Console.WriteLine("1. Morning" + (registeredForWorkshop == 1 ? " - Registered" : ""));
            Console.WriteLine("2. Afternoon" + (registeredForWorkshop == 2 ? " - Registered" : ""));
            Console.WriteLine("3. Quit");
            read();
            switch (_choice)
            {
                case 1:
                    Console.WriteLine("Booking reference: " + bookingReferenceMorning);
                    registeredForWorkshop = 1;
                    waitForInput();
                    break;
                case 2:
                    Console.WriteLine("Booking reference: " + bookingReferenceAfternoon);
                    registeredForWorkshop = 2;
                    waitForInput();
                    break;
                case 3:
                    registeredForWorkshop = 3;
                    break;
                default:
                    Console.WriteLine("Unvalid command");
                    displayWorkshop();
                    break;

            }
            return 1;
        }
        private short displayProduct()
        {
            List<int> IdArray = new List<int>();
            string storeInventoryFileName = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\json\\" + _storeName + "_inventory.json";
            string lines = File.ReadAllText(storeInventoryFileName);
            List <Item> products = JsonConvert.DeserializeObject<List<Item>>(lines);
            int i = 0, id = 0, quantity = 0, toDisplay = 5;
            string userInput;
            while (true)
            {
                while (i < products.Count() && i < toDisplay)
                {
                    IdArray.Add(products[i].Id);
                    Console.WriteLine($"Id = {products[i].Id} Product = {products[i].Product} CurrentStock = {products[i].CurrentStock} Re-Stock = {products[i].ReStock}");
                    i++;
                }
                Console.WriteLine("[Legend: 'P' Next Page | 'R' Return to Menu | 'C' Complete Transaction]");
                Console.WriteLine("Enter Item Number to purchase or Function: ");
                userInput = Console.ReadLine();
                bool check = false;
                if (int.TryParse(userInput, out id))
                {
                    /* handleInt */
                    id = _choice;
                    for (int j = 0; j < products.Count(); j++)
                    {
                        if (products[j].Id == id)
                        {
                            Console.WriteLine("How many ?");
                            read();
                            quantity = _choice;
                            if (quantity <= products[j].CurrentStock)
                            {
                                pickedItems.Add(new Tuple<string, int>(products[j].Product, quantity));
                                products[j].CurrentStock -= quantity;
                                check = true;
                            }
                        }
                    }
                    if (check == false)
                    {
                        Console.WriteLine("Unvalid id");
                        check = false;
                    }
                }
                else
                {
                    switch (userInput.ToLower())
                    {
                        case "p":
                            toDisplay += 5;
                            Console.Clear();
                            break;
                        case "r":
                            return 1;
                        case "c":
                            if (pickedItems.Count() > 0)
                            {
                                string customerInventoryFileName = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\json\\customer_inventory.json";
                                lines = File.ReadAllText(customerInventoryFileName);
                                List<Item> customerProducts = JsonConvert.DeserializeObject<List<Item>>(lines);
                                if (customerProducts == null)
                                    customerProducts = new List<Item>();
                                for (int j = 0; j < customerProducts.Count(); j++)
                                {
                                    for (int k = 0; k < pickedItems.Count(); k++)
                                    {
                                        Console.WriteLine("You bought :");
                                        if (string.Compare(customerProducts[j].Product, pickedItems[k].Item1) == 0)
                                        {
                                            customerProducts[j].CurrentStock += pickedItems[k].Item2;
                                            Console.WriteLine($"{pickedItems[k].Item2} {pickedItems[k].Item1}");
                                            pickedItems.Remove(pickedItems[k]);
                                            k--;
                                        }
                                    }
                                }
                                for (int j = 0; j < pickedItems.Count(); j++)
                                {
                                    customerProducts.Add(new Item((customerProducts.Count() > 0 ? customerProducts.Last().Id + 1 : 1), pickedItems[j].Item1, pickedItems[j].Item2));
                                    Console.WriteLine($"{pickedItems[j].Item2} {pickedItems[j].Item1}");
                                }
                                if (registeredForWorkshop > 0)
                                {
                                    Console.WriteLine("You are book in " + (registeredForWorkshop == 1 ? "morning" : "afternoon") + " workshop, therefore you get a 10% discount");
                                }
                                File.WriteAllText(customerInventoryFileName, JsonConvert.SerializeObject(customerProducts));
                                File.WriteAllText(storeInventoryFileName, JsonConvert.SerializeObject(products));
                                pickedItems = new List<Tuple<string, int>>();
                                waitForInput();
                            }
                            return 1;
                    }
                }
            }
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
        public CustomerMenu(string storeName)
        {
            functions.Add(displayProduct);
            functions.Add(displayWorkshop);
            // Should quit be on the delegate ?
            functions.Add(quit);
            functions.Add(exit);
            _storeName = storeName;
            bookingReferenceAfternoon = "afternoon_" + storeName;
            bookingReferenceMorning = "morning_" + storeName;
        }
    }
}
