using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ricky_capg_sample_challenge_2.Sampler;

namespace ricky_capg_sample_challenge_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("result of RelativeToCommonBase : ");
            string result = Sampler.RelativeToCommonBase("/home/daniel/memes", "/home/daniel/work");
            Console.WriteLine(result);
            Console.WriteLine();

            Console.WriteLine("result of ClosestWord : ");
            result = Sampler.ClosestWord("ricky", new string[] { "raiki", "rambo", "riki", "ricki", "Rhandy" });
            Console.WriteLine(result);
            Console.WriteLine();

            Console.WriteLine("result of SpeedAtTime : ");
            Sampler.PointInTime start = new Sampler.PointInTime(10, 20, 1729502700);        // 1729502700 -> Mon Oct 21 2024 09:25:00 GMT+0000
            Sampler.PointInTime middle = new Sampler.PointInTime(20, 100, 1729505400);      // 1729505400 -> Mon Oct 21 2024 10:10:00 GMT+0000 (+45 minute)
            Sampler.PointInTime end = new Sampler.PointInTime(25, 120, 1729506000);         // 1729506000 -> Mon Oct 21 2024 10:20:00 GMT+0000 (+10 minute)
            PointInTime[] path = new PointInTime[3] {start, middle, end};
            var resultDouble = Sampler.SpeedAtTime(1729503000, path);
            Console.WriteLine(resultDouble);
            Console.WriteLine();

            // simple example
            // 2 points in 10 second travel time
            Console.WriteLine("result of SpeedAtTime with simple parameter data : ");
            start = new Sampler.PointInTime(1, 1, 1729502700);
            end = new Sampler.PointInTime(4, 5, 1729502710);
            path = new PointInTime[2] { start, end };
            resultDouble = Sampler.SpeedAtTime(1729502702, path);
            Console.WriteLine(resultDouble);

            var stopper = Console.ReadLine();
        }
    }
}
