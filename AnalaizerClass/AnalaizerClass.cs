namespace AnalaizerClass
{
    public class AnalaizerClass
    {
        public string InputString { get; set; }
        public List<CalcObjects> CalcObjects = new List<CalcObjects>();
        public Stack<CalcObjects> Stack = new Stack<CalcObjects>();
        public List<CalcObjects> CurrentString = new List<CalcObjects>();
        public int erposition = 0;
        public bool ShowMessage = false;
        public string errorCode = "";
        private Stack<Char> bracketsStack = new Stack<Char>();

        public AnalaizerClass(string inputString)
        {
            InputString = inputString;
        }

        public void Calc()
        {
            InputString = Format(InputString);
            CheckCurrency();
            stringToCalcObj();
            ExpToRPN();
        }

        private bool CheckCurrency()
        {
            if(InputString.Length > 65536)
            {
                errorCode = "Error 07";
                ShowMessage = true;
                throw new Exception(errorCode);
            }
            char[] arrayOfDigitChars = new[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0'};
            char[] arrayOfOperationChars = new[] {'+', '-', '*', '/'};
            char[] arrayOfBrackets = new[] { '(', ')' };

            if(arrayOfOperationChars.Contains(InputString[InputString.Length-1] ))
            {
                errorCode = "Error 05";
                ShowMessage = true;
                throw new Exception(errorCode);
            }
            for (int i = 0; i < InputString.Length; i++)
            {
                if (!arrayOfDigitChars.Contains(InputString[i]) && !arrayOfOperationChars.Contains(InputString[i]) && !arrayOfBrackets.Contains(InputString[i]))
                {
                    errorCode = "Error 02";
                    erposition = i;
                    ShowMessage = true;
                    throw new Exception(errorCode);
                }
                if (arrayOfOperationChars.Contains(InputString[i]))
                {
                    if (i < InputString.Length - 1 && arrayOfOperationChars.Contains(InputString[i + 1]))
                    {
                        errorCode = "Error 04";
                        erposition = i;
                        ShowMessage = true;
                        throw new Exception(errorCode);
                    }
                }
                if (InputString[i] == ')')
                {
                    if(bracketsStack.Count == 0 )
                    {
                        errorCode = "Error 01";
                        erposition = i;
                        ShowMessage = true;
                        throw new Exception(errorCode);
                    }
                    else bracketsStack.Pop();
                }
                if(InputString[i] == '(')
                    bracketsStack.Push(InputString[i]);
            }
            if(bracketsStack.Count > 0)
            {
                errorCode = "Error 01";
                ShowMessage = true;
                throw new Exception(errorCode);
            }

            return false;
        }

        private string Format(string inputString)
        {
            string outputString = "";
            outputString = inputString.Replace(" ", "");
            return outputString;
        }

       

        private void ExpToRPN()
        {
            for (int i = 0; i < CalcObjects.Count; i++)
            {

                if (CalcObjects[i].Priority == 0) { CurrentString.Add(CalcObjects[i]); }
                else if (CalcObjects[i].Priority == 1) { Stack.Push(CalcObjects[i]); }
                else if (CalcObjects[i].Priority > 1)
                {
                    while (Stack.Count != 0)
                    {
                        if (Stack.Peek().Priority >= CalcObjects[i].Priority) CurrentString.Add(Stack.Pop());
                        else break;
                    }
                        Stack.Push(CalcObjects[i]);
                }
                else if (CalcObjects[i].Priority < 0)
                {
                    while(Stack.Peek().Priority != 1)CurrentString.Add(Stack.Pop());
                    Stack.Pop();
                }
            }
            while (Stack.Count != 0)CurrentString.Add(Stack.Pop());
        }


        private void stringToCalcObj()
        {
            for (int i = 0; i < InputString.Length; i++)
            {
                if (Char.IsDigit(InputString[i]))
                {
                    string output = "";
                    do
                    {
                        output += InputString[i].ToString();
                        i++;
                    } while ((i < InputString.Length) && Char.IsDigit(InputString[i]));
                    i--;
                    CalcObjects.Add(new CalcObjects(output, 0));
                }
                else
                {
                    if (InputString[i] == '/' || InputString[i] == '*') { CalcObjects.Add(new CalcObjects(InputString[i].ToString(), 3)); }
                    else if (InputString[i] == '+' || InputString[i] == '-'){ CalcObjects.Add(new CalcObjects(InputString[i].ToString(), 2));}
                    else if (InputString[i] == '(') CalcObjects.Add(new CalcObjects(InputString[i].ToString(), 1));
                    else if (InputString[i] == ')') CalcObjects.Add(new CalcObjects(InputString[i].ToString(), -1));
                }
            }
            if(CalcObjects.Count > 30)
            {
                errorCode = "Error 08";
                ShowMessage = true;
                throw new ArgumentException(errorCode);
            }
        }
    }
}
