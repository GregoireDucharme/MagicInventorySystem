using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic_Inventory_System
{
    // Is it A ?
    abstract class AMenu
    {
        protected int _choice;
        protected delegate short function();
        protected List<function> functions = new List<function>();
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
        protected void read()
        {
            _choice = Convert.ToInt32(Console.ReadLine());
        }
        //Usefull in every child class ? 
        protected void waitForInput()
        {
            Console.ReadLine();
        }
        public short run()
        {
            read();
            if (_choice > 0 && _choice <= functions.Count())
                return functions[_choice - 1](); // Typing 1 meaning accessing function index 0
            return -1;
        }
        abstract public void display();
    }
}
