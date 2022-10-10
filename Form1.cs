using System;
using System.Windows.Forms;

namespace MyCalc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "0";
        }

        private void button_Click(object sender, EventArgs e)
        {
            var value = (sender as Button).Text;

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void dot_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = "0";

            if (textBox1.Text == "0")
                textBox1.Text = string.Empty;
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
