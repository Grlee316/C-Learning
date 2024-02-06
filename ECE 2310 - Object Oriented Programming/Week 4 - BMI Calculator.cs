/**
 * Develop a BMI calculator using C# Windows Forms Application. The form should look 
something like the following figure, with 3 inputs( height in feet, height in inches and weight in 
lbs) and 1 output (BMI). 

Round the output to 1 decimal place.  (Hint: It could happen that one 
or more of the inputs is either a negative number or non-numeric)
In addition, display in a message box which one of the following categories the BMI is in :

Programmed By Jonathan Hanbali
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

namespace QUIZ_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //boolean function numValidator that will validate userEntered string
        private bool numValidator(string str1)
        {
            //integer variable num
            int num;

            //tryParse string 1 with output as integer num, if it failed, then return false
            if (!int.TryParse(str1, out num))
            {
                return false;
            }
            else //else if its true, return true only and if only number is bigger than 0
            {
                if (int.Parse(str1) <= 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        //boolean function inchValidator that will check the value of inch.
        //if the inch is bigger than 12, then return false
        //else if the inch is less than 12, then return true
        private bool inchValidator(string inchStr)
        {
            if (numValidator(inchStr) == true)
            {
                int num = int.Parse(inchStr);
                if(num >= 12)
                {
                    return false;
                }
                else 
                { 
                    return true; 
                }
                    
            } 
            else
            {
                return false;
            }
        }

        //compute bmi button on click
        private void button1_Click(object sender, EventArgs e)
        {
            //String variables to get all the user entered values
            string feetStr, inchStr, lbStr;

            //assigning appropriate strings
            feetStr = feetBox.Text;
            inchStr = inchBox.Text;
            lbStr = lbBox.Text;

            //boolean variables to get the status if user entered input are all valid
            bool ftValid = numValidator(feetStr);
            bool inchValid = numValidator(inchStr);
            bool lbValid = numValidator(lbStr);
            bool inValid = inchValidator(inchStr);

            //if the user entered input are not numbers
            if (!ftValid || !inchValid || !lbValid) //if valid is false
            {
                MessageBox.Show("Please enter a whole number only", "warning"); //show the warning message

                //clear everything
                //can be improved with an error code, so it only clear one part instead of all
                feetBox.Clear();
                inchBox.Clear();
                lbBox.Clear();
                bmiOut.Clear();
                feetBox.Focus(); //set the focus on the feet textbox
            }
            else //else if user entered input are all valid
            {
                if (inValid == true) //if the user entered a right inches
                {
                    int feetVal, inchVal, lbVal; //integer variables to hold values
                    decimal bmiRes, heightInInches; //decimal variables to hold decimal values

                    //parsing appropriate integer string into its container
                    feetVal = int.Parse(feetStr);
                    inchVal = int.Parse(inchStr);
                    lbVal = int.Parse(lbStr);

                    //multipying feet by 12 and added it with inches to inches total
                    heightInInches = (feetVal * 12) + inchVal;

                    //Formula: weight (lb) / [height (in)]2 x 703
                    //bmi res calculation
                    bmiRes = (lbVal / (heightInInches * heightInInches)) * 703;

                    string bmiString = String.Format("{0,4:f1}", bmiRes); //string formatting and 1 decimal value
                    bmiOut.Text = bmiString; //show the output to the textbox

                    /**BMI Categories:
                       Underweight = <18.5
                       Normal weight = 18.5–24.9
                       Overweight = 25–29.9
                       Obesity = BMI of 30 or greater

                       since switch operands does not work good with decimal, multiply by 10 to get hunderds
                    **/

                    //decimal bmix to store bmiRes * 10
                    decimal bmiX = bmiRes * 10;

                    //convert bmiX to integer
                    int bmiInt = Convert.ToInt16(bmiX);

                    switch (bmiInt) //switch case with bmiInt as the cases
                    {
                        case var expression when (bmiInt < 185): //when it is less than 18.5 (185)
                            MessageBox.Show("Your BMI says that you're underweight","Your BMI Result"); //showing that the user is underweight
                            break;
                        case var expression when (bmiInt >= 185 && bmiInt < 250): //when it is in between 18.5 and 24.9 (185, 260)
                            MessageBox.Show("Your BMI says that you're normal weight", "Your BMI Result"); //show that the user has normal weight
                            break;
                        case var expression when (bmiInt >= 250 && bmiInt < 300): //if its in between 25 and 30 (250,300)
                            MessageBox.Show("Your BMI says that you're overweight", "Your BMI Result"); //show that the user is overweight
                            break;
                        default:
                            MessageBox.Show("Your BMI says that you're obese", "Your BMI Result"); //else show that the user is obese
                            break;
                    }
                }
                else //if inches is higher than 12
                {
                    MessageBox.Show("Your inches is higher than 12, please enter the right inches \n(1 feet = 12 inches)", "Warning", MessageBoxButtons.OK); //show the warning message
                    inchBox.Clear(); //clear the inchbox
                    inchBox.Focus(); //set the inchbox on focus
                }
            }
        }

            //clear button on click function
            private void button2_Click(object sender, EventArgs e)
        {
            feetBox.Clear();
            inchBox.Clear();
            lbBox.Clear();
            bmiOut.Clear();
        }
    }
}
