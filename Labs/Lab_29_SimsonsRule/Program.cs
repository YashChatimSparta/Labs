using System;

namespace Lab_29_SimsonsRule
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    public class SimsonsRule
    {
        // Graph of y = x*x
        // Points on x : 0,1,2,3,4,5,6
        // So, values of y : 0,1,4,9,16,25,36
        // Goal : Approx area under graph

        // Simpsons rule
        // Area = ((Max x - max y)/n) * [y(zeroth item) + y(last item) + 4(odd-indexed items N=1,3,5) + 2(even-indexed items N=2,4]

        public static double GetAreaUnderGraphUsingSimpsonsRule(int n, int min, int max)
        {
            // n = 6, min = 0, max = 6
            double area;
            int oddSum = 0;
            int evenSum = 0;
            int oddArea;
            int evenArea;

            double[] xValue = {0,1,2,3,4,5,6};

            double deltaX = (max - min) / n;

            for (int i = 1; i < n; i++) //looping 10 times, from 0 to 10, incrementing i for 1 every time
            {
                if (i % 2 == 0)
                {
                    evenSum += i * i;
                }

                if (i % 2 != 0)
                {
                    oddSum += i*i;
                }  
            }
            oddArea = 4 * oddSum;
            evenArea = 2 * evenSum;

            double bracketArea = (min * min) + oddArea + evenArea + (max * max);
            area = bracketArea/3;

            return area;
        }

        public static double GetAreaUnderGraphUsingSimpsonsRuleCubic(int n, int min, int max)
        {
            // n = 6, min = 0, max = 6
            double area;
            int oddSum = 0;
            int evenSum = 0;
            int oddArea;
            int evenArea;

            double deltaX = (max - min) / n;

            for (int i = 1; i < n; i++)
            {
                if (i % 2 == 0)
                {
                    evenSum += i * i * i;
                }

                if (i % 2 != 0)
                {
                    oddSum += i * i * i;
                }
            }
            oddArea = 4 * oddSum;
            evenArea = 2 * evenSum;

            double bracketArea = (min * min * min) + oddArea + evenArea + (max * max * max);
            area = bracketArea / 3;

            return area;
        }
    }
}
