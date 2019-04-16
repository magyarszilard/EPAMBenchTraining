using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public abstract class Food : IFood
    {
        public abstract double CalculateHappiness(double happiness);
    }

    public class HotDog : Food
    {
        public override double CalculateHappiness(double happiness)
        {
            return happiness + 2;
        }
    }
}
