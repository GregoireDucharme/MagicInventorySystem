using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic_Inventory_System
{
    class Driver
    {

        static void Main(string[] args)
        {
            HomeMenu HM = new HomeMenu();
            short result = 1;

            while (result >= 0) {
                HM.display();
                result = HM.run();
            }
        }
    }
}
