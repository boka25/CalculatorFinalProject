using System.Diagnostics.Metrics;

namespace CalcClass
{
    public class CalcClass
    {
        public double calcOperation(double op1, double op2, char operation)
        {
            switch (operation)
            {
                case '+':
                    return Add(op1, op2);
                    break;

                case '-':
                    return Minus(op1, op2);
                    break;

                case '*':
                    return Multipl(op1, op2);
                    break;
                case '/':
                    return Div(op1, op2);
                    break;

                default:
                    throw new InvalidOperationException();
                    break;
            }
        }


        private double Multipl(double a, double b) => a * b;
        private double Add(double a, double b) => a + b;
        private double Minus(double a, double b) => a - b;
        private double Div(double a, double b)
        { 
            if(b == 0)throw new DivideByZeroException();
          return  a / b; 
        }

    }
}
