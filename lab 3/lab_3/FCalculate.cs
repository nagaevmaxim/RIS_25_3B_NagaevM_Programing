using System;
using System.Collections.Generic;
using System.Text;

namespace lab_3
{
    internal class FCalculate
    {
        public static double FAccurate(double x)
        {
            double lnInside = 1 - 2 * x * Math.Cos(Math.PI / 3) + Math.Pow(x, 2);
            return -0.5 * Math.Log(lnInside);
        }

        public static double FN(double x, int n)
        {
            double y = 0;

            for (var i = 1; i <= n; i++)
            {
                double angle = i * (Math.PI / 3);
                double divisible = Math.Pow(x, i) * Math.Cos(angle);
                y += divisible / i;
            }

            return y;
        }

        public static double FE(double x, double eps)
        {
            double y = 0;
            double oldValue;
            double newValue = y;
            var i = 1;
            
            do
            {
                oldValue = newValue;
                
                double angle = i * (Math.PI / 3);
                double divisible = Math.Pow(x, i) * Math.Cos(angle);
                newValue = divisible / i;

                y += newValue;
                i++;
            } while (Math.Abs(newValue-oldValue) >= eps);

            return y;
        }
    }
}
