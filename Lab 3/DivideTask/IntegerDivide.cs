using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3.DivideTask
{
    delegate bool IsIntDivideByDelegate(int num);

    class IntegerDivide
    {
        public static bool IsDivisible(int num,IsIntDivideByDelegate delgate1, IsIntDivideByDelegate delgate2)
        {
            return delgate1(num) && delgate2(num);
        }

        public static bool IsDivisibleBy3(int num) => num % 3 == 0;
        public static bool IsDivisibleBy7(int num) => num % 7 == 0;
    }
}
