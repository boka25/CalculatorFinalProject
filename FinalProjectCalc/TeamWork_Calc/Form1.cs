using System.Linq.Expressions;
using TeamWork_CalcOperations;

namespace TeamWork_Calc
{
    public partial class Form1 : Form
    {
        private int count_l = 0;
        private int count_r = 0;
        private string expression = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            expression += button1.Text;
            textBox1.Text = expression;
            count_l++;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            expression += button2.Text;
            textBox1.Text = expression;
            count_r++;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // del last char
            textBox1.Text = expression;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            expression = "";
            textBox1.Text = expression;
            textBox2.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            expression += button5.Text;
            textBox1.Text = expression;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            expression += button6.Text;
            textBox1.Text = expression;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            expression += button7.Text;
            textBox1.Text = expression;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            expression += button12.Text;
            textBox1.Text = expression;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            expression += button11.Text;
            textBox1.Text = expression;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            expression += button10.Text;
            textBox1.Text = expression;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            expression += button16.Text;
            textBox1.Text = expression;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            expression += button15.Text;
            textBox1.Text = expression;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            expression += button14.Text;
            textBox1.Text = expression;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            expression += button19.Text;
            textBox1.Text = expression;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            expression += button8.Text;
            textBox1.Text = expression;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            expression += button9.Text;
            textBox1.Text = expression;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            expression += button13.Text;
            textBox1.Text = expression;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            expression += button17.Text;
            textBox1.Text = expression;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (count_l == count_r)
            {
                string rpnExpression = CalcOperation.RPNConverter.ConvertToRPN(expression);
                double result = CalcOperation.RPNCalculator.CalculateRPN(rpnExpression);
                textBox2.Text = result.ToString();
            }
            else
            {
                throw new Exception("Error 03");
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            expression += "%";
            textBox1.Text = expression;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (expression.Length > 30)
            {
                throw new Exception("Error 08");
            }

            double res = double.Parse(textBox2.Text);
            if (res >= int.MaxValue || res <= int.MinValue)
            {
                throw new Exception("Error 06");
            }
            if (res != 0)
            {
                res *= -1;
                textBox2.Text = res.ToString();
            }

        }
    }
}
