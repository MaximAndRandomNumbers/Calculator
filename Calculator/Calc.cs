using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calc : Form
    {
        private const int MAX_LENGTH = 9;
        private double operand1, operand2, result = 0;
        private bool appendFlag = true, dotFlag = false;
        private char currentOperation = ' ';
        public Calc()
        {
            InitializeComponent();
        }

        private void appendNumber(String number)
        {
            if (display.Text.Length > MAX_LENGTH && appendFlag) return;
            display.Text = display.Text != "0" && appendFlag ? display.Text + number : number;
            appendFlag = true;
        }
        private void makeOperation(char operation)
        {
            operand1 = Double.Parse(display.Text);
            appendFlag = false;
            dotFlag = false;
            currentOperation = operation;
        }
        private void getResult()
        {
            if (currentOperation == ' ') return;
            operand2 = Double.Parse(display.Text);
            switch (currentOperation)
            {
                case '+':
                    result = operand1 + operand2;
                    break;
                case '-':
                    result = operand1 - operand2;
                    break;
                case '*':
                    result = operand1 * operand2;
                    break;
                case '/':
                    result = operand1 / operand2;
                    break;

            }
            currentOperation = ' ';
            display.Text = result.ToString().Length > MAX_LENGTH ?
                string.Format("{0,10:E4}", result) : result.ToString();
            Clipboard.SetDataObject(result);
            appendFlag = false;
            dotFlag = false;
        }
        
        private void btnNumber1_Click(object sender, EventArgs e)
        {
            appendNumber("1"); 
        }

        private void btnNumber2_Click(object sender, EventArgs e)
        {
            appendNumber("2");
        }

        private void btnNumber3_Click(object sender, EventArgs e)
        {
            appendNumber("3");
        }

        private void btnNumber4_Click(object sender, EventArgs e)
        {
            appendNumber("4");
        }

        private void btnNumber5_Click(object sender, EventArgs e)
        {
            appendNumber("5");
        }

        private void btnNumber6_Click(object sender, EventArgs e)
        {
            appendNumber("6");
        }

        private void btnNumber7_Click(object sender, EventArgs e)
        {
            appendNumber("7");
        }

        private void btnNumber8_Click(object sender, EventArgs e)
        {
            appendNumber("8");
        }

        private void btnNumber9_Click(object sender, EventArgs e)
        {
            appendNumber("9");
        }

        private void btnNumber0_Click(object sender, EventArgs e)
        {
            appendNumber("0");
        }

        private void btnSignPlus_Click(object sender, EventArgs e)
        {
            makeOperation('+');
        }

        private void btnSignMinus_Click(object sender, EventArgs e)
        {
            makeOperation('-');
        }

        private void btnSignMult_Click(object sender, EventArgs e)
        {
            makeOperation('*');
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            display.Text = "0";
            dotFlag = false;
            currentOperation = ' ';
        }

        private void Calc_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue >= (char)Keys.D0 && e.KeyValue <= (char)Keys.D9)
            {
                appendNumber((e.KeyValue - (char)Keys.D0).ToString());
                return;
            }
            if (e.KeyValue >= (char)Keys.NumPad0 && e.KeyValue <= (char)Keys.NumPad9)
            {
                appendNumber((e.KeyValue - (char)Keys.NumPad0).ToString());
            }
            
        }

        private void display_Click(object sender, EventArgs e)
        {

        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (dotFlag) return;
            if (!appendFlag)
            {
                display.Text = "0";
                appendFlag = true;
            }
            display.Text += ",";
            dotFlag = true; 
        }

        private void btnSignDiv_Click(object sender, EventArgs e)
        {
            makeOperation('/');
        }

        private void btnGetResult_Click(object sender, EventArgs e)
        {
            getResult();
        }
    }
}
