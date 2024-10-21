using FuzzySharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ricky_capg_sample_challenge_2
{
    public class Sampler
    {

        // ---- 2.
        /*
          Write a function that accepts two Paths and returns the portion of the first Path that is not
          common with the second, which is to say portion of the first path starting from where the two
          paths diverged.

          For example, RelativeToCommonBase("/home/daniel/memes", "/home/daniel/work") should
          produce "/home/daniel".
        */
        public static String RelativeToCommonBase(String path1, String path2)
        {
            StringBuilder result = new StringBuilder();

            var path1chunk = path1.Split('/');
            var path2chunk = path2.Split('/');

            for (int i = 0; i < path1chunk.Length; i++)
            {
                //check if path2 has different number of path
                if(i >= path2chunk.Length)
                    break;

                if (path1chunk[i] != path2chunk[i])
                    break;

                result.Append(path1chunk[i]+"/");
            }

            // remove trailling slash
            if (result.Length > 0)
                result.Length = result.Length - 1;

            return result.ToString();
        }

        // ---- 2.
        /*
          Write a function that accepts a string as the first parameter, and a
          list of strings as the second parameter, and returns a string from the
          list that is "most like" the first string. The choice of algorithm 
          is yours.
        */
        public static String ClosestWord(String word, String[] possibilities)
        {
            //using fuzzySharp
            string mostSimiliar = string.Empty;
            int highScore = 0;

            for (int i = 0;i<possibilities.Length; i++)
            {
                int score = (Fuzz.Ratio(word, possibilities[i]));
                if (score > highScore)
                {
                    mostSimiliar = possibilities[i];
                    highScore = score;
                }
            }
            return mostSimiliar;
        }

        // ----3.
        /*
          Pretend there is a vehicle traveling along a path. The path is represented
          by a list of x, y points and a unix timestamp at that point 
          (the PointIntime struct).  The vehicle travels
          in straight lines between those points and passes through each point at
          the corresponding timestamp. Given this list of points and timestamps,
          and a time seconds (relative to the first timestamp), write a function
          that returns the instantaneous speed of the fake vehicle at that timestamp.
        */
        public struct PointInTime
        {
            public PointInTime(double x, double y, double timestamp)
            {
                X = x;
                Y = y;
                Timestamp = timestamp;
            }

            public double X { get; }
            public double Y { get; }
            public double Timestamp { get; }

            public override string ToString() => $"({X}, {Y}, {Timestamp})";
        }

        public static double SpeedAtTime(double atTime, PointInTime[] path)
        {
            double speedAtTime = 0;

            // assuming PointInTime[] path array is already sorted by Timestamp (because it describes a route of a vehicle)
            // if not, need additional sorting first here ...

            // validation
            if (path.Length<=1)
                throw new Exception($"PointInTime[] path need to be at least two(2) sized array");

            if (atTime < path[0].Timestamp)
                throw new Exception($"invalid atTime parameter, not enough data in array as the earliest timestamp found in path array is {path[0].Timestamp}");

            for (int i = 0; i < path.Length; i++)
            {
                // skip iteration of first element(because the start of the vehicle route)
                if (i == 0)
                    continue;

                // check which point to point need to be calculated based on atTime parameter
                if (atTime <= path[i].Timestamp)
                {
                    double distance = CalculateDistance(path[i - 1], path[i]);
                    double timeLapse = path[i].Timestamp - path[i-1].Timestamp;

                    // assuming instantaneous speed formula
                    // Instantaneous speed (v) = distance/ time
                    // a.k.a average speed in epoch unit
                    speedAtTime = distance / timeLapse;

                    return speedAtTime;
                }
            }

            // in case the requested atTime is too future, not enough route data on PointInTime[] path parameter
            throw new Exception($"invalid atTime parameter, not enough data in array as the latest timestamp found in path array is {path[path.Length-1].Timestamp}");
        }

        public static double CalculateDistance(PointInTime startPoint, PointInTime endPoint)
        {
            // formula
            // OP = √((x2 – x1)² + (y2 – y1)²)
            double distance = 0;
            var beforesquareroot = Math.Pow((endPoint.X - startPoint.X), 2) + Math.Pow((endPoint.Y - startPoint.Y), 2);
            distance = Math.Sqrt(beforesquareroot);

            return distance;
        }
    }
}
