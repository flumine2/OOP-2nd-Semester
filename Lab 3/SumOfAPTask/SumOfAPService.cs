using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3_Part_1.SumOfAPTask
{
    delegate double Operation(double num, int iteration);

    class SumOfAPService
    {
        public static double GetSumOfProgression(double startpoint, Operation operation, double accuracy)
        {
            double sum = 0;
            for (int i = 0; sum % accuracy <= 0; i++)
            {
                sum += operation(startpoint, i);
            }
            return sum;
        }

        public static double DivideByTwo(double startpoint, int iteration)
        {
            return startpoint / (2 ^ iteration);
        }

        public static double DivideByMinusTwo(double startpoint, int iteration)
        {
            if (iteration % 2 == 1)
            {
                return startpoint / (2 ^ iteration);
            }
            else
            {
                return startpoint / (-2 ^ iteration);
            }
        }

        public static double DivideBySamePLUS(double startpoint, int iteration)
        {
            return startpoint / Factorial(iteration + 1);
        }

        private static double Factorial(int num)
        {
            int factorial = 1;
            while (num != 0)
            {
                factorial *= num;
                num--;
            }
            return factorial;
        }

    }
}
