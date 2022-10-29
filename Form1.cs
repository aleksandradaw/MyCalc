using MyCalc.MathOperations;
using System;
using System.Drawing.Imaging;
using System.Linq;
using System.Net.Http.Headers;
using System.Windows.Forms;

namespace MyCalc
{
    public partial class Form1 : Form
    {
        private string _firstNumber; 
        private string _secondNumber;
        private MathOperation _currentMathOperation = MathOperation.None;
        public int numberOfCommas = 0;
        public double firstNumber;
        string text;


        public char[] mathOper = new char[] { '/', '+', '-', 'x' };
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "0";
        }

        private void button_Click(object sender, EventArgs e)
        {
            var value = (sender as Button).Text;
            if (textBox1.Text == "0")
                textBox1.Text = string.Empty;

            if (value == "," && textBox1.Text == "0")
                textBox1.Text = "0,";
            else
                textBox1.Text += value;


            if (_currentMathOperation == MathOperation.None)
            {
                _firstNumber += value;
            }
            if (_currentMathOperation != MathOperation.None)
            {
                _secondNumber += value;
            }
        }


        private void mathOp_Click(object sender, EventArgs e)
        {
            string mathOperation = (sender as Button).Text;

            var charList = textBox1.Text.ToList();
            int numberOfChar = charList.Count();

            int numberOfCommas = 0;
            int numberOfOperators = 0;
            
            for (int i = 0; i < 4; i++)
            {
                foreach (char c in charList)
                {
                    if (c == mathOper[i] & _secondNumber != null)
                        numberOfOperators = 1;
                }
            }


            for (int i = 0; i < 4; i++)
            {
               
             
                if (charList[numberOfChar-1] == mathOper[i] & _secondNumber == null)
                {
                    textBox1.Text = textBox1.Text.Remove(charList.Count()-1);
                    break;
                }
            }

            foreach (char c in charList)
            {
                if (c == ',')
                    numberOfCommas++;
            }

            if (numberOfCommas == 2 | numberOfOperators ==1 )
            {
                result_Click(sender, e);
            }

            if (_firstNumber == null)
            {
                textBox1.Text = "0";
            }

            if (_firstNumber != null)
            {
                firstNumber = double.Parse(_firstNumber);

            if (mathOperation == "+")
            {
                _currentMathOperation = MathOperation.Addition;
                textBox1.Text += mathOperation;
            }

            if (mathOperation == "-")
            {
                _currentMathOperation = MathOperation.Subtraction;
                textBox1.Text += mathOperation;
            }

            if (mathOperation == "/")
            {
                _currentMathOperation = MathOperation.Division;
                textBox1.Text += mathOperation;
            }

            if (mathOperation == "x²")
            {
                _currentMathOperation = MathOperation.Exponentation;

                var result = MathCalc(firstNumber, 0);
                textBox1.Text = result.ToString();
                _firstNumber = result.ToString();
                    numberOfCommas = 1;
            }

            if (mathOperation == "√")
            {
                _currentMathOperation = MathOperation.ExtractionOfRoot;
               
                var result = MathCalc(firstNumber, 0);
                textBox1.Text = result.ToString();
                _firstNumber = result.ToString();
                    numberOfCommas = 1;
            }

            if (mathOperation == "x")
            {
                _currentMathOperation = MathOperation.Multiplication;
                textBox1.Text += mathOperation;
            }
            }
        }

        private void comma_Click(object sender, EventArgs e)
        {
            string isFirstDot = _firstNumber.ToString();

            var commaChar = (sender as Button).Text;
            if (_currentMathOperation == MathOperation.None && textBox1.Text.Contains(","))
            {
                string textBox;
                textBox = textBox1.Text.Trim();
                textBox1.Text = textBox;
            }

            else if (_currentMathOperation != MathOperation.None)
            {
                char comma = ',';
                char[] textBoxArray = textBox1.Text.ToArray();
                for (int i = 0; i < textBoxArray.Length; i++)
                {
                    if (textBoxArray[i] == comma)
                        numberOfCommas += 1;
                    else
                        continue;
                }

                if (numberOfCommas > 1)
                {
                    string textBox;
                    textBox = textBox1.Text.Trim();
                    textBox1.Text = textBox;
                }
                else
                {
                    if (_secondNumber != null)
                    {
                        textBox1.Text += commaChar;
                        _secondNumber += ",";
                    }
                    else
                    {
                        textBox1.Text += "0,";
                        _secondNumber += "0,";
                    }
                }
            }
            
            else
            {
                textBox1.Text += commaChar;
                _firstNumber += ",";
            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            _firstNumber = String.Empty;
            _secondNumber = String.Empty;
            _currentMathOperation = MathOperation.None;
        }

        private void result_Click(object sender, EventArgs e)
        {
            double result;

            if (_currentMathOperation == MathOperation.None)
                return;

            var firstNumber = double.Parse(_firstNumber);
            double secondNumber;

            if (_secondNumber == null)
            {
                secondNumber = 0;
                result = firstNumber;
            }
            else if (_secondNumber == "0,")
            {
                secondNumber = 0;
                result = MathCalc(firstNumber, secondNumber);
            }
            else
            {
                secondNumber = double.Parse(_secondNumber);
                result = MathCalc(firstNumber, secondNumber);
            }

            textBox1.Text = result.ToString();
            _firstNumber = result.ToString();
            _currentMathOperation = MathOperation.None;
            _secondNumber = null;
            
            numberOfCommas = 0;

        }

        private double MathCalc(double firstNumber, double secondNumber)
        {
            switch(_currentMathOperation)
            {
                case MathOperation.None:
                    return firstNumber;
                case MathOperation.Division:
                    if(secondNumber == 0)
                    {
                        textBox1.Text = "Nie można dzielić przez zero";
                        return 0;
                    }
                    return firstNumber / secondNumber;
                case MathOperation.Subtraction:
                    if(secondNumber == null)
                    {
                        return double.Parse(textBox1.Text);
                    }
                    return firstNumber - secondNumber;
                case MathOperation.Exponentation:
                    return firstNumber * firstNumber;
                case MathOperation.Addition:
                    return firstNumber + secondNumber;
                case MathOperation.Multiplication:
                    return firstNumber * secondNumber;
                case MathOperation.ExtractionOfRoot:
                    return Math.Sqrt(firstNumber);
            }

            return 0;
        }


    }
}
