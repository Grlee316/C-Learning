/**
 * Design a C# Windows Forms Application that simulates a simple calculator, 
 * which reads two numbers and displays the sum, difference, product and average of the two numbers when a specific button is clicked.  
 * There should be 6 buttons : "Add", "Subtract",  "Multiply", "Average", "Clear", and "Exit".
 * 
 * For example, if the user enters 3.5 and  -2 , and clicks the "Add" button, the following message should be displayed in a textbox or a label : 
 * 3.5 + (-2) = 1.5
 * 
 * **/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week2_formapp
{
    public partial class Form1 : Form
    {
        public Form1() 
        {
            InitializeComponent();

        }

        //this function is a void function that will spit out the output to the textbox
        //this function will accept three double variables and one integer that will tell us the calculation that's being done
        private void negChecker(double num1, double num2, double result, int calcmethod)
        {
            //creating string variables to hold the modified value if the number is below 0
            string num1mod, num2mod, resultmod;

            //if the first number is below 0, then put () around it, if not, then leave it as is
            if(num1 < 0)
            {
                num1mod = "(" + Convert.ToString(num1) + ")";
            }else
            {
                num1mod = Convert.ToString(num1);
            }

            //if the second number is below 0, then put () around it, if not, then leave it as is
            if (num2 < 0)
            {
                num2mod = "(" + Convert.ToString(num2) + ")";
            }
            else
            {
                num2mod = Convert.ToString(num2);
            }

            //if the result is below 0, then put () around it, if not, then leave it as is
            if (result < 0)
            {
                resultmod = "(" + Convert.ToString(result) + ")";
            }
            else
            {
                resultmod = Convert.ToString(result);
            }

            //switch case that use the calc method as the switch cases
            switch (calcmethod)
            {
                case var expression when (calcmethod == 1): //as stated below, 1 is addition, so the result will be shown as belo
                    textresult.Text = num1mod + " + " + num2mod + " = " + resultmod;
                    break;
                case var expression when (calcmethod == 2): //2 is deduction
                    textresult.Text = num1mod + " - " + num2mod + " = " + resultmod;
                    break;
                case var expression when (calcmethod == 3): //3 is multiplication
                    textresult.Text = num1mod + " x " + num2mod + " = " + resultmod;
                    break;
                case var expression when (calcmethod == 4): //4 is division
                    textresult.Text = num1mod + " / " + num2mod + " = " + resultmod;
                    break;
                case var expression when (calcmethod == 5): //5 is modulus
                    textresult.Text = num1mod + " % " + num2mod + " = " + resultmod;
                    break;
                case var expression when (calcmethod == 6): //6 is average
                    textresult.Text = "( " + num1mod + " + " + num2mod + " ) " + ": 2 " + "= " + resultmod;
                    break;
                default:
                    break;
            }

            }

        //Calculation Method:
        //if the user use + , int = 1;
        //if the user use - , int = 2;
        //if the user use * , int = 3;
        //if the user use / , int = 4;
        //if the user use % , int = 5;
        //if the user use avg, int = 6;

        //below is the the code for + button
        private void add_Click(object sender, EventArgs e)
        {
            double num1, num2, result; //creating double variables to hold the values
            num1 = Convert.ToDouble(textnum1.Text); //converting the string into double
            num2 = Convert.ToDouble(textnum2.Text); //converting the string into double
            result = num1 + num2; //adding the two number
            //textresult.Text = Convert.ToString(result); //showing the text result
            negChecker(num1, num2, result, 1); //calling the negChecker function and passing the variables
        }

        //below is the code for - button
        private void deduct_Click(object sender, EventArgs e)
        {
            double num1, num2, result; //creating double variables to hold the values
            num1 = Convert.ToDouble(textnum1.Text); //convert the string into double
            num2 = Convert.ToDouble(textnum2.Text); //convert the string into double
            result = num1 - num2; //result is equal to num1 - num2
            //textresult.Text = Convert.ToString(result); //showing the text result
            negChecker(num1, num2, result, 2);//calling the negChecker function and passing the variables
        }

        //below is the code for x button
        private void multi_Click(object sender, EventArgs e)
        {
            double num1, num2, result; //creating double variables to hold the values
            num1 = Convert.ToDouble(textnum1.Text); //convert the string into double
            num2 = Convert.ToDouble(textnum2.Text); //convert the string into double
            result = num1 * num2; //multiply num1 with num2
            //textresult.Text = Convert.ToString(result); //showing the text result
            negChecker(num1, num2, result, 3);//calling the negChecker function and passing the variables
        }

        //below is the code for : button
        private void divide_Click(object sender, EventArgs e)
        {
            double num1, num2, result; //creating double variables to hold the values
            num1 = Convert.ToDouble(textnum1.Text); //convert the string into double
            num2 = Convert.ToDouble(textnum2.Text); //convert the string into doubles
            result = num1 / num2; //dividing number 1 with number 2, then show it on result
            //textresult.Text = Convert.ToString(result); //showing the text result
            negChecker(num1, num2, result, 4);//calling the negChecker function and passing the variables
        }

        //below is the code for clear button
        private void button1_Click(object sender, EventArgs e)
        {
            textnum1.Clear(); //clearing the value inside textnum1 textbox
            textnum2.Clear(); //clearing the value inside textnum2 textbox
            textresult.Clear(); //clearing the value inside textresult textbox
        }

        //below is the code for mod button
        private void modulus_Click(object sender, EventArgs e)
        {
            double num1, num2, result; //creating double variables to hold the values
            num1 = Convert.ToDouble(textnum1.Text); //converting the string into doubles
            num2 = Convert.ToDouble(textnum2.Text); //converting the string into doubles
            result = num1 % num2; //calculate num1 modulo num2, and store it in result
            //textresult.Text = Convert.ToString(result); //show the text result
            negChecker(num1, num2, result, 5);//calling the negChecker function and passing the variables
        }

        //below is the code for close button
        private void close_Click(object sender, EventArgs e)
        {
            Close(); //close the form app
        }

        //below is the code for avg button
        //this will calculate the average between two number
        private void avg_Click(object sender, EventArgs e)
        {
            double num1, num2, result; //creating double variables to hold the values
            num1 = Convert.ToDouble(textnum1.Text); //converting the string into doubles
            num2 = Convert.ToDouble(textnum2.Text); //converting the string into doubles
            result = (num1 + num2) / 2; //result is equal to the average of the two numbers
            //textresult.Text = Convert.ToString(result); //show the text result
            negChecker(num1, num2, result, 6);//calling the negChecker function and passing the variables
        }
    }
}
