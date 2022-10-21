using MyCalc.MathOperations;
using System;
using System.Linq;
using System.Windows.Forms;

namespace MyCalc
{
    public partial class Form1 : Form
    {
        private string _firstNumber; 
        private string _secondNumber;
        private MathOperation _currentMathOperation = MathOperation.None;
        public int numberOfDots = 0;
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

            if (value == "." && textBox1.Text == "0")
                textBox1.Text = "0.";
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
            var mathOperation = (sender as Button).Text;

            var firstNumber = double.Parse(_firstNumber);


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
                numberOfDots = 1;
            }

            if (mathOperation == "√")
            {
                _currentMathOperation = MathOperation.ExtractionOfRoot;
               
                var result = MathCalc(firstNumber, 0);
                textBox1.Text = result.ToString();
                _firstNumber = result.ToString();
                numberOfDots = 1;
            }

            if (mathOperation == "x")
            {
                _currentMathOperation = MathOperation.Multiplication;
                textBox1.Text += mathOperation;
            }

        }

        private void dot_Click(object sender, EventArgs e)
        {
            string isFirstDot = _firstNumber.ToString();

            var dotChar = (sender as Button).Text;
            if (_currentMathOperation == MathOperation.None && textBox1.Text.Contains("."))
            {
                string textBox;
                textBox = textBox1.Text.Trim();
                textBox1.Text = textBox;
            }

            else if (_currentMathOperation != MathOperation.None)
            {
                char dot = '.';
                char[] textBoxArray = textBox1.Text.ToArray();
                for(int i = 0; i < textBoxArray.Length; i++)
                {
                    if (textBoxArray[i] == dot)
                        numberOfDots += 1;
                    else
                        continue;
                }

                if (numberOfDots > 1)
                {
                    string textBox;
                    textBox = textBox1.Text.Trim();
                    textBox1.Text = textBox;
                }
                else
                    textBox1.Text += dotChar;
            }
            
            else
                textBox1.Text += dotChar;
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
            if (_currentMathOperation == MathOperation.None)
                return;

            var firstNumber = double.Parse(_firstNumber);
            double secondNumber;

            if (_secondNumber == null)
            {
                secondNumber = 0;
            }
            else
                secondNumber = double.Parse(_secondNumber);

            var result = MathCalc(firstNumber, secondNumber);

            textBox1.Text = result.ToString();
            _firstNumber = result.ToString();
            _currentMathOperation = MathOperation.None;
            _secondNumber = null;
            
            numberOfDots = 1;

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

           
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

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
                        return firstNumber;
                    }
                    return firstNumber - secondNumber;
                case MathOperation.Exponentation:
                    return Math.Exp(firstNumber);
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
