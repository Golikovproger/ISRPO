using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstactClassesAndInterfaces2
{
    abstract class HotDrink
    {
       string Drink()
        {
            return "You drunk all milk";
        }
        string AddMilk()
        {
            return "Milk was added";
        }
        string AddSugar()
        {
            return "Sugar was added";
        }
    }
}
