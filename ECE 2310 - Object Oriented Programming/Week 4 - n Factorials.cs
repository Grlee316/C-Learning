/**
 * 3. The factorial of a nonnegative integer n is written n! (pronounced “n factorial”)
 * and is defined as follows:
 * n! = n · (n – 1) · (n – 2) · … · 1 (for values of n greater than 1) and
 * n! = 1 (for n = 0 or n = 1).
 * For example, 5! = 5 · 4 · 3 · 2 · 1, which is 120. Use while statements in each of the following:
 * Write a C# Windows Forms Application that reads n from a textbox and display 1! through n! in a list box. 
 * 
 * 
 * Also, estimates the value of the mathematical constant e by using the following formula (with accuracy of 6 decimal places)  :         
 *		e = 1 + 1/1! + 1/2! + 1/3! + ...
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

namespace HW04_3
{
    public partial class Form1 : Form
    {
        //initializing form 1
        public Form1()
        {
            InitializeComponent();
        }

        //form load function that will load the elements of the form
        private void Form1_Load(object sender,EventArgs e)
        {
            ListBox calcList = new ListBox();
        }

        //boolean function numValidator that will check string that being passed
        //since we're only accepting integer for our calculation, this function will only validate integer
        private bool numValidator(string str1)
        {
            //integer variable num
            int num;

            //tryParse string 1 with output as integer num, if it failed, then return false
            if (!int.TryParse(str1, out num))
            {
                return false;
            }
            else //else if its true, return true
            {
                return true;
            }
        }

        //private decimal addition function
        //this function will accept decimal n, and will add n with its previous number until it reach 0
        private decimal zeroToN(decimal n)
        {
            //initializa variable sum = 0
            decimal sum = 0;

            //for loop to add the numbers
            for(decimal i = n; i > 0; i--)
            {
                sum = sum + n;
            }
            return sum; //return total
        }

        //event when button 1 is being clicked
        private void button1_Click(object sender, EventArgs e)
        {
            string userStr = userInputBox.Text; //get the string from the textbox
            bool valid = numValidator(userStr); //bool valid is equal to the return of numValidator function
            calcList.Items.Clear(); //clear the item in the calcList to clear the list from previous calculation

            if (!valid) //if valid is false
            {
                MessageBox.Show("Please enter a right value", "warning"); //show the warning message
                userInputBox.Clear(); //clear the userInput textbox
                userInputBox.Focus(); //set the focus on the userInput textbox}
            } 
            else
            {
                //variable declaration
                int userNum = int.Parse(userStr); //integer userNum is parsing the string
                int total = 1;
                string numStr;
                bool isneg = false; //boolean isneg for negative case


                if(userNum == 0) //if the user entered 0, then result of 0! is 1
                {
                    calcList.Items.Add(userNum.ToString() + "! = 1");
                }
                else if(userNum < 0) //if the user entered number less than 0, we will keep tract of the negative and convert the number to absolute
                {
                    isneg = true; //set isneg as true
                    userNum = Math.Abs(userNum); //convert userNum to positive (abs value)
                }
                else
                {
                    isneg = false; //else, the isneg is false
                }

                while (userNum > 0) //while the userNum is larger than 0, do this
                {   
                    //for loop to multiply the value with previous value (n*(n-1)) then store it in total
                    for (int i = userNum; i > 0; i--)
                    {
                        total = total * i;
                    }

                    //if the negative is false
                    if(isneg == false)
                    {
                        calcList.Items.Add(userNum.ToString() + "! = " + total); //print it normally
                    }
                    else
                    {
                        calcList.Items.Add("(-" + userNum.ToString() + ")! = (-" + total + ")");//print it with - sign and ()
                    }
                    total = 1; //reset the total
                    userNum--; //control
                }

            }
        }

        //this function will estimate the value of e
        private void button2_Click(object sender, EventArgs e)
        {
            //variables
            string userStr = userInputBox.Text; //string userStr to get the value entered from user
            bool valid = numValidator(userStr); //valid boolean to validate the userStr
            calcList.Items.Clear(); //clear the listbox

            //if not valid, then show the warning message
            if (!valid)
            {
                MessageBox.Show("Please enter whole integer value", "warning"); //show the warning message
                userInputBox.Clear(); //clear the userInput textbox
                userInputBox.Focus(); //set the focus on the userInput textbox}
            }
            else //else do calculation
            {
                //variables
                int userNum = int.Parse(userStr); //integer userNum to store the value entered from userStr
                decimal total = 1; //decimal total with initial value of 1, need to use decimal for a 6 point accuracy

                //if the user entered less than or equal to 0, then show warning message, since the e estimation will be really low and 1/0 is unknown (or infinity)
                if (userNum <= 0)
                {
                    MessageBox.Show("Please enter a bigger value to get a better estimation of e", "warning"); //show the warning message
                    userInputBox.Clear(); //clear the userInput textbox
                    userInputBox.Focus(); //set the focus on the userInput textbox}
                }
                else
                {
                    while(userNum > 0)
                    {
                        for (decimal i = userNum; i > 0; i--) //for loop to add the values
                        {
                            total = total + Convert.ToDecimal(1 / zeroToN(i)); //total is equal to total plus 1/i!
                        }

                        //show the result in the listbox
                        calcList.Items.Add("e with an accuracy of " + userNum.ToString() + "!  is = " + String.Format("{0,-10:F6}", total));

                        userNum--; //control
                        total = 1; //reset total to 1
                    }
                   
                }
            }
        }
    }
}

