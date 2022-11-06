using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstactClassesAndInterfaces2
{
    class CupOfTea : HotDrink, ICup
    {
        public string Type { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double Capacity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Refil()
        {
            throw new NotImplementedException();
        }

        public void Wash()
        {
            throw new NotImplementedException();
        }
        string LeafType
        {
            get;
            set;
        }
    }
}
