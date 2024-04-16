using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using TeamWork_CalcOperations;

namespace TeamWork_1
{
    public class RPNConverter
    {
        public static string ConvertToRPN(string expression)
        {
            StringBuilder output = new StringBuilder();
            Stack<char> stack = new Stack<char>();

            expression = Regex.Replace(expression, @"([+\-*/%()])", " $1 ");

            string[] tokens = expression.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string token in tokens)
            {
                if (IsNumeric(token))
                {
                    output.Append(token).Append(" ");
                }
                else if (token == "(")
                {
                    stack.Push('(');
                }
                else if (token == ")")
                {
                    while (stack.Count > 0 && stack.Peek() != '(')
                    {
                        output.Append(stack.Pop()).Append(" ");
                    }
                    stack.Pop();
                }
                else
                {
                    while (stack.Count > 0 && Operator(stack.Peek()) >= Operator(token[0]))
                    {
                        output.Append(stack.Pop()).Append(" ");
                    }
                    stack.Push(token[0]);
                }
            }

            while (stack.Count > 0)
            {
                output.Append(stack.Pop()).Append(" ");
            }

            return output.ToString().Trim();
        }

        private static bool IsNumeric(string str)
        {
            return double.TryParse(str, out _);
        }

        private static int Operator(char o)
        {
            switch (o)
            {
                case '+':
                case '-':
                    return 1;
                case '*':
                case '/':
                case '%':
                    return 2;
                default:
                    return 0;
            }
        }
    }

    public class RPNCalculator
    {
        public static double CalculateRPN(string expression)
        {
            Stack<double> stack = new Stack<double>();

            string[] tokens = expression.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string token in tokens)
            {
                if (IsNumeric(token))
                {
                    stack.Push(double.Parse(token));
                }
                else if (IsOperator(token))
                {
                    double operand2 = stack.Pop();
                    double operand1 = stack.Pop();

                    double result = PerformOperation(token[0], operand1, operand2);
                    stack.Push(result);
                }
            }

            return stack.Pop();
        }

        private static bool IsNumeric(string str)
        {
            return double.TryParse(str, out _);
        }

        private static bool IsOperator(string token)
        {
            return token == "+" || token == "-" || token == "*" || token == "/" || token == "%";
        }

        private static double PerformOperation(char o, double operand1, double operand2)
        {
            switch (o)
            {
                case '+':
                    //return operand1 + operand2;
                    return CalcOperators.Add(operand1, operand2);
                case '-':
                    return CalcOperators.Sub(operand1, operand2);
                case '*':
                    return CalcOperators.Mult(operand1, operand2);
                case '/':
                    return CalcOperators.Div(operand1, operand2);
                case '%':
                    return CalcOperators.Mod(operand1, operand2);
                default:
                    throw new ArgumentException("Invalid operator: " + o);
            }
        }
    }
}
