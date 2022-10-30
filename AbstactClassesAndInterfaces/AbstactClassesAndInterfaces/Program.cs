using System;

namespace AbstractClasses
{
    class Angle
    {
        int degrees;
        float mins;
        char way;

        public Angle ()
        {
            degrees = 0;
            mins = 0;
            way = 'S';
        }
        public Angle (int degrees, float mins, char way)
        {
            this.degrees = degrees;
            this.mins = mins;
            this.way = way;
        }

       
        public void SetValues (int degrees, float mins, char way)
        {
            this .degrees = degrees;
            this.mins = mins;
            this.way = way;
        }

        public void Print ()
        {
            Console.WriteLine($"{degrees} {mins} {way} ");

        }

        static void Main()
        {
            Angle a = new Angle (3, 5, 'N');
            a.Print();
            Angle b = new Angle();
            b.SetValues(4, 8, 'S');
            b.Print();
        }
    }
}
