using AnalaizerClass;

namespace FinalProject
{
    public partial class Form1 : Form
    {
        private string buffer = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            textBoxIn.Text += "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            textBoxIn.Text += "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            textBoxIn.Text += "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            textBoxIn.Text += "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            textBoxIn.Text += "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            textBoxIn.Text += "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            textBoxIn.Text += "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            textBoxIn.Text += "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            textBoxIn.Text += "9";
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            textBoxIn.Text += "0";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBoxIn.Text = "";
        }

        private void btnLeftBr_Click(object sender, EventArgs e)
        {
            textBoxIn.Text += "(";
        }

        private void btnRightBr_Click(object sender, EventArgs e)
        {
            textBoxIn.Text += ")";
        }

        private void btnBackSP_Click(object sender, EventArgs e)
        {
            textBoxIn.Text = textBoxIn.Text.Remove(textBoxIn.Text.Length - 1);
        }

        private void btnAddBuf_Click(object sender, EventArgs e)
        {
            buffer = textBoxOut.Text;
        }

        private void btnOutBuf_Click(object sender, EventArgs e)
        {
            textBoxIn.Text += buffer;
        }

        private void btnClearBuf_Click(object sender, EventArgs e)
        {
            buffer = "";
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            textBoxIn.Text += "/";
        }

        private void btnMultpl_Click(object sender, EventArgs e)
        {
            textBoxIn.Text += "*";
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            textBoxIn.Text += "-";
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            textBoxIn.Text += "+";
        }

        private void button21_Click(object sender, EventArgs e)
        {
            textBoxOut.Text = "";

            var ac = new AnalaizerClass.AnalaizerClass(textBoxIn.Text);
            try
            {
                ac.Calc();
            }
            catch (Exception ex)
            {
                textBoxOut.Text = ac.errorCode + " at position " + ac.erposition;
            }

            if (ac.ShowMessage)
                textBoxOut.Text = ac.errorCode + " at position " + ac.erposition;

            else
            {
                for (int i = 0; i < ac.CurrentString.Count; i++)
                {
                    if (ac.CurrentString[i].Priority < 2)
                        ac.Stack.Push(ac.CurrentString[i]);
                    else
                    {
                        try
                        {
                            double b = Double.Parse(ac.Stack.Pop().Token);
                            double a = Double.Parse(ac.Stack.Pop().Token);
                            char c = Char.Parse(ac.CurrentString[i].Token);
                            var cc = new CalcClass.CalcClass();
                            ac.Stack.Push(new CalcObjects(cc.calcOperation(a, b, c).ToString(), 0));
                        }
                        catch (DivideByZeroException)
                        {
                            textBoxOut.Text = "Error 09";
                        }
                    }
                }
                if (ac.Stack.Count > 0)
                    textBoxOut.Text = ac.Stack.Pop().Token.ToString();
                else { }
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBoxIn.Text += "%";
        }

        private void btnChangeSign_Click(object sender, EventArgs e)
        {
            //uMinus();
            textBoxIn.Text += "i";
        }

        public void uMinus()
        {
            string inputStr = textBoxIn.Text;
            string strResult = "";
            int i= inputStr.Length - 1;
            if (!Char.IsDigit(inputStr[i]))
                textBoxOut.Text = "Error 01";
            else {
                do
                {
                    strResult += inputStr[i];
                    i--;
                } while (i != 0 && Char.IsDigit(inputStr[i]));
                textBoxIn.Text = textBoxIn.Text.Insert(inputStr.Length-strResult.Length, "-");

            }
        }
    }
}
