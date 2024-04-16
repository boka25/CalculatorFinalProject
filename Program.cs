using System.Text;
using System.Text.RegularExpressions;
using TeamWork_CalcOperations;
//using TeamWork_1;


string infixExpression = "(5+3*8/4)%2";
string rpnExpression = CalcOperation.RPNConverter.ConvertToRPN(infixExpression);
Console.WriteLine("Infix Expression: " + infixExpression);
Console.WriteLine("RPN Expression: " + rpnExpression);


double result = CalcOperation.RPNCalculator.CalculateRPN(rpnExpression);
Console.WriteLine("Calculate Result: " + result);