using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManhattanSkyline
{
    class Program
    {
        const int BuildingCount = 100000;
        const int MinBuildingHeight = 1;
        const int MaxBuildingHeight = 100;
        static void Main(string[] args)
        {
            var input = RandomSkylineGenerator.GenerateSkyline(BuildingCount, MinBuildingHeight, MaxBuildingHeight);
            Stopwatch watch = new Stopwatch();
            foreach (var item in input)
            {
                var implementation = new FirstImplementation(input);
                watch.Start();
                var result = implementation.CalculateWater();
                watch.Stop();
                Console.WriteLine(result);
                Console.WriteLine(watch.Elapsed);

                var implementation2 = new SecondImplementation(input);
                watch.Reset();
                watch.Start();
                var result2 = implementation2.CalculateWater();
                watch.Stop();
                Console.WriteLine(implementation2.CalculateWater());
                Console.WriteLine(watch.Elapsed);
                Console.ReadLine();
            }
        }
    }
}
