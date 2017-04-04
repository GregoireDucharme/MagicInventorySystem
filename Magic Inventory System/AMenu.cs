using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic_Inventory_System
{
    abstract class AMenu
    {
        protected int _choice;
        protected delegate short function();
        protected List<function> functions = new List<function>();

        /* Function for the delegate */
        protected short quit()
        {
            Console.WriteLine("quit");
            return 0;
        }
        protected short exit()
        {
            Console.WriteLine("exit");
            return -1;
        }
        /* End of delegate function */

        protected void read()
        {
            string inputUser;

            inputUser = Console.ReadLine();
            while (!int.TryParse(inputUser, out _choice))
            {
                Console.WriteLine("Invalid input");
                inputUser = Console.ReadLine();
            }
        }
        protected void waitForInput()
        {
            Console.ReadLine();
        }
        public short run()
        {
            read();
            /* Functions being the delegate of each children class and initialized in each default constructor */
            if (_choice > 0 && _choice <= functions.Count())
                return functions[_choice - 1](); // Typing 1 meaning accessing function index 0
            return -1;
        }
        abstract public void display();
    }
}
