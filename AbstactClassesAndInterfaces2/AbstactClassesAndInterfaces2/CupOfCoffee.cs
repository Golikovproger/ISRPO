using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstactClassesAndInterfaces2
{
    class CupOfCoffee : HotDrink, ICup
    {
        public string Type { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Refil()
        {
            throw new NotImplementedException();
        }

        public void Wash()
        {
            throw new NotImplementedException();
        }
        string BeanType
        {
            get;
            set;
        }
        double ICup.Capacity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
