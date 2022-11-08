using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstactClassesAndInterfaces2
{
    abstract class HotDrink
    {
        protected int sugar = 3;
        protected int milk = 3;

        public int Sugar
        {
            get
            {
                return sugar;
            }
            set
            {
                if ((value >= 0) & (value <= 10))
                {
                    sugar = value;
                }
                else sugar = 3;
            }
        }
        public int Milk
        {
            get
            {
                return milk;
            }
            set
            {
                if ((value >= 0) & (value <= 10))
                {
                    milk = value;
                }
                else milk = 3;
            }
        }

        string Drink()
        {
            return "Выпить";
        }
        string AddMilk(int count)
        {
            Milk = count;
            return $"В кофе добавлено молоко: {Milk}";
        }
        string AddSugar(int count)
        {
            Sugar = count;
            return $"В кофе добавлен сахар: {Sugar}";
        }
    }
}
