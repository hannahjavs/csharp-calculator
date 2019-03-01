using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{    
    public partial class Form1 : Form
    {
        private Calculator _calculator = new Calculator();
        private Calculator.Operations currentOperations;
        private bool _equalsWasClicked = false;

        public Form1()
        {
            InitializeComponent();
            _calculator.EnterNumber(0);
            textBox1.Text = "";
            textBox2.Text = "";
            history.Text = "";

            zero.Click += OnButtonClick;
            one.Click += OnButtonClick;
            two.Click += OnButtonClick;
            three.Click += OnButtonClick;
            four.Click += OnButtonClick;
            five.Click += OnButtonClick;
            six.Click += OnButtonClick;
            seven.Click += OnButtonClick;
            eight.Click += OnButtonClick;
            nine.Click += OnButtonClick;
        }

        private void Form1_Load(object sender, EventArgs e){}
        private void textBox1_Click(object sender, EventArgs e){}
        private void textBox2_Click(object sender, EventArgs e){}
        private void history_Click(object sender, EventArgs e){}

        // if you type 1 and then press the negative button it will say it is not allowed
        private void plusMinus_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.StartsWith("-"))
            {
                // It's negative now, so strip the '-' sign to make it positive
                textBox1.Text = textBox1.Text.Substring(1);
            }
            else if (!string.IsNullOrEmpty(textBox1.Text) && decimal.Parse(textBox1.Text) != 0)
            {
                // It's negative now so prefix the value with the '-' sign to make it negative
                textBox1.Text = "-" + textBox1.Text;
            }
        }

        private void fraction_Click(object sender, EventArgs e)
        {
            _calculator.EnterNumber(float.Parse(textBox1.Text));
            textBox1.Text = "";
            currentOperations = Calculator.Operations.Fraction;

            if (_calculator.Calculate(this.currentOperations) == Calculator.Status.Ok)
            {
                var result = _calculator.LastResult();
                textBox1.Text = result.ToString();
            }
        }

        private void equals_Click(object sender, EventArgs e)
        {
            _calculator.EnterNumber(float.Parse(textBox1.Text));
            _equalsWasClicked = true;

            // if no string do not do anything catch errors

            var status = _calculator.Calculate(this.currentOperations);

            switch (status)
            {
                case Calculator.Status.DivideByZero:
                {
                    MessageBox.Show("Cannot divide by zero");
                }
                break;

                case Calculator.Status.Ok:
                default:
                {
                    var result = _calculator.LastResult();
                    textBox1.Text = result.ToString();
                    history.Text += textBox2.Text + "=\n";
                    history.Text += textBox1.Text + "\n";
                }
                break;
            }
        }
        
        // Refactored button for numbers
        void OnButtonClick(object sender, EventArgs e)
        {
            textBox1.Text += (sender as Button).Text;
            textBox2.Text += (sender as Button).Text;
        }

        private void squareRoot_Click(object sender, EventArgs e)
        {
            _calculator.EnterNumber(float.Parse(textBox1.Text));
            textBox1.Text = "";
            currentOperations = Calculator.Operations.SquareRoot;

            if (_calculator.Calculate(this.currentOperations) == Calculator.Status.Ok)
            {
                var result = _calculator.LastResult();
                textBox1.Text = result.ToString();
            }
        }

        private void squared_Click(object sender, EventArgs e)
        {
            _calculator.EnterNumber(float.Parse(textBox1.Text));
            textBox1.Text = "";
            currentOperations = Calculator.Operations.Squared;

            if (_calculator.Calculate(this.currentOperations) == Calculator.Status.Ok)
            {
                var result = _calculator.LastResult();
                textBox1.Text = result.ToString();
            }
        }

        private void powerOf3_Click(object sender, EventArgs e)
        {
            _calculator.EnterNumber(float.Parse(textBox1.Text));
            textBox1.Text = "";
            currentOperations = Calculator.Operations.PowerOf3;

            if (_calculator.Calculate(this.currentOperations) == Calculator.Status.Ok)
            {
                var result = _calculator.LastResult();
                textBox1.Text = result.ToString();
            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "")
            {
                MessageBox.Show("Cannot clear empty space!");
                return;
            }
            else
            {
                _calculator.EnterNumber(float.Parse(textBox1.Text));
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length >= 1)
            {
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
            }
        }

        private void decimalpoint_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += ".";
            this.textBox2.Text += ".";
        }

        private void CE_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "")
            {
                MessageBox.Show("Cannot clear empty space!");
                return;
            }
            else
            {
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            _calculator.EnterNumber(float.Parse(textBox1.Text));
            textBox1.Text = "";
            currentOperations = Calculator.Operations.Add;
            textBox2.Text += "+";

            _equalsWasClicked = false;
        }

        private void divide_Click(object sender, EventArgs e)
        {
            _calculator.EnterNumber(float.Parse(textBox1.Text));
            textBox1.Text = "";
            currentOperations = Calculator.Operations.Divide;

            _equalsWasClicked = false;
        }

        private void multiply_Click(object sender, EventArgs e)
        {
            _calculator.EnterNumber(float.Parse(textBox1.Text));
            textBox1.Text = "";
            currentOperations = Calculator.Operations.Multiply;


        }

        private void subtract_Click(object sender, EventArgs e)
        {
            _calculator.EnterNumber(float.Parse(textBox1.Text));
            textBox1.Text = "";
            currentOperations = Calculator.Operations.Subtract;
        }

        private void modulus_Click(object sender, EventArgs e)
        {
        }
    }
}
