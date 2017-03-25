﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Magic_Inventory_System
{
    class OwnerMenu : AMenu
    {
        private short displayAllStock()
        {
            //Use IEnmerable also for stocks ? 
            /*using (JsonTextReader reader = new JsonTextReader(File.OpenRead())
            {
                reader.SupportMultipleContent = true;

                var serializer = new JsonSerializer();
                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.StartObject)
                    {
                        Contact c = serializer.Deserialize<Contact>(reader);
                        Console.WriteLine(c.FirstName + " " + c.LastName);
                    }
                }
            }*/
            List<Stock> stocks = new List<Stock>();
            string lines = File.ReadAllText(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName +  "\\json\\stockrequests.txt");
            /*            foreach (var line in lines)
                        {*/
            //stocks.Add(JsonConvert.DeserializeObject<Stock>(lines));
            //}
            stocks = JsonConvert.DeserializeObject<List<Stock>>(lines);            
            Console.WriteLine("dAS");
            for (int i = 0; i < stocks.Count(); i++)
            {
                Console.Write($"Id = {stocks[i].Id} Product = {stocks[i].Product} Quantity = {stocks[i].Quantity}");
                Console.WriteLine($"Current Stock = {stocks[i].CurrentStock} Stock Available = {stocks[i].StockAvailability}");
            }
            waitForInput();
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
