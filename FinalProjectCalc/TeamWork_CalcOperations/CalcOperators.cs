using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamWork_CalcOperations
{
    public class CalcOperators
    {
        public static double Add(double a, double b)
        {
            double result = a + b;
            if (double.IsInfinity(result))
                throw new OverflowException();
            return result;
        }

        public static double Sub(double a, double b)
        {
            double result = a - b;
            if (double.IsInfinity(result))
                throw new OverflowException();
            return result;
        }

        public static double Mult(double a, double b)
        {
            double result = a * b;
            if (double.IsInfinity(result))
                throw new OverflowException();
            return result;
        }

        public static double Div(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException();
            return a / b;
        }

        public static double Mod(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException();
            return a % b;
        }
    }
}
