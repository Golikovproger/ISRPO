using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstactClassesAndInterfaces2
{
    interface ICup
    {
        void Refil();
        void Wash();
        string Type 
        {
            get;
            set;
        }
        double Capacity
        {
            get;
            set;
        }
    }
}
