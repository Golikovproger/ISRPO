using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstactClassesAndInterfaces2
{
    class CupOfCoffee : HotDrink, ICup
    {
        public string type = "пластик";
        public double capacity = 0.2;
        public string beantype = "робуста";
        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                if ((value == "пластик") || (value == "бумага"))
                {
                    type = value;
                }
            }
        }
        public double Capacity
        {
            get
            {
                return capacity;
            }
            set
            {
                if ((value == 0.2) || (value == 0.4) || (value == 0.6))
                {
                    capacity = value;
                }
            }
        }
        public string BeanType
        {
            get
            {
                return beantype;
            }
            set
            {
                if ((value == "робуста") || (value == "арабика"))
                {
                    type = value;
                }
            }
        }
        public void Refil()
        {
            throw new NotImplementedException();
        }

        public void Wash()
        {
            throw new NotImplementedException();
        }
    }
}
