using Agent_rest.Model;

namespace Agent_rest.Utils
{
    public class Time
    {
        public static class ResponseTimeCalculator
        {
            public static double CalculateResponseTime(int x1, int y1, int x2, int y2) =>
                Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));

        }
    }
}
