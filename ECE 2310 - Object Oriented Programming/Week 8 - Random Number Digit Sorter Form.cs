/***
 * A) (20 Points)Write a function Seperate( number ) that separates an integer number 
 * (ranging from 0 to 999999) into its digits. For example, if the number is 412329, 
 * the function finds 4, 1, 2, 3, 2, 9.  If the number is 323, the function finds 
 * 0, 0, 0, 3, 2, 3. Nothing should be displayed in/by the function.
 * 
 * (30 Points) Use the function in A) in a C# Windows Forms application that analyzes 
 * a group of random numbers with no more than 6 digits. 
 * Your program should have the user to enter how many random numbers they want to 
 * analyze in a textbox. If the user’s entry is not valid, your program should display 
 * an error message. It should then generates the random numbers (ranging from 0 to 999999) 
 * accordingly.  Each time a random number is generated, the program should separate the 
 * integer into its digits and use a listbox to print all the 6 digits with one comma in 
 * between. Next, it should then sort the 6 digits into a descending order and display the 
 * re-arranged digits in another listbox. 

 * ***/


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidtermApp
{
    public partial class Form1 : Form
    {
        private static int[] separateThis(int num)                                                                   //This function will accept a number and will return an array in a size of 6 of the number separated
        {
            int[] sepNum = new int[6];                                                                               //creating new integer array
            int[] revNum = new int[6];
            int temp = num;                                                                                          //new temporary integer to hold the passed value
            for(int a = 0; a < 6; a++)                                                                               //for loop with arbitrary size to separate the number into individual elements of array
            {
                sepNum[a] = temp % 10;                                                                               //temp modulo 10 and store it in sepNum
                temp = temp / 10;                                                                                    //divide temp by 10, and store it in temp again
            }

            /**
             * We don't need an exception for this in case the digit is lower than 6, since any low digit / 10 is 0, and 0 modulo 10 is another 0
             * and after that, 0 / 10 is still 0, so any remaining digits will be 0, just by mathematical caltulation 
            **/

            for(int b = 0; b < 6; b++)                                                                               //this for loop will reverse the order of the digit in the array
            {
                revNum[b] = sepNum[5 - b];
            }

            return revNum;                                                                                           //return the temp array.
        }

        private static int[] sortThis(int[] num)                                                                     //this function will sort the array
        {
            int[] sorted = new int[6];                                                                               //create a temp array holder
            sorted = num;                                                                                            //sorted array equals to the passed array
            Array.Sort(sorted);                                                                                      //sort the array using Array.sort function
            Array.Reverse(sorted);                                                                                   //reverse the sorted array using Array.Reverse function (Array.sort sort the array from small to big)

            return sorted;                                                                                           //return the sorted array
        }

        private bool numValidator(string str1)                                                                       //boolean function numValidator that will validate userEntered string
        {
            decimal num;                                                                                             //integer variable num

            if (!decimal.TryParse(str1, out num))                                                                    //tryParse string 1 with output as integer num, if it failed, then return false
            { 
                return false;
            }
            else                                                                                                     //else if its true, return true only and if only number is bigger than 0 and less than 100
            {
                if (decimal.Parse(str1) < 0)
                {
                    return false;                                                                                    //if its less than 0, then it will return false
                }
                else
                {
                    return true;                                                                                     //else return true
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)                                                          //Creating new listbox objects when the form load
        {
            ListBox randList = new ListBox();
            ListBox digList = new ListBox();
            ListBox sortList = new ListBox();
        }

        private void method()                                                                                        //method function will be called to do tasks
        {
            randList.Items.Clear();                                                                                  //clearing all the listbox
            digList.Items.Clear();
            sortList.Items.Clear();

            string userVal;                                                                                          //string userVal that will store the user entered value
            string myStr, sortStr;                                                                                   //string myStr and sortStr will store the formatted string to put in the listbox           
            userVal = userInput.Text;                                                                                //assigning the userinput text to userVal

            int userValue = 0;                                                                                       //integer version of the userVal that will store the user entered value as an integer after validation
            bool valid = numValidator(userVal);                                                                      //bool valid that will tell if the user entered a valid number or not

            //int[] randHolder = new int[userValue];                                                                   //integer array randHolder that will hold the value of the random number (can be eliminated)
            //int[,] digHolder = new int[userValue, 6];                                                              //I decided that I won't store the values of the figits (can be eliminated)
            int[] mynum = new int[6];                                                                                //integer array myNum that will store the sorted num
            int[] sortNum = new int[6];                                                                              //integer array sortNum that will hold the sorted array
            Random rand = new Random();                                                                              //New Random variable


            if (!valid)                                                                                              //if not valid, show error message
            {
                string message = "Please enter a right value";
                string title = "Error";
                MessageBox.Show(message, title);
            }
            else                                                                                                      //else convert the value
            {
                userValue = Convert.ToInt32(userVal);
            }


            int count = 0;                                                                                           //integer count that will keep track of the while loop during listbox populating
            while (count < userValue)                                                                                 //while the count is lower than the user value
            {
                int num = rand.Next(0, 999999);                                                                       //create a new integer num and assign the random number
                //randHolder[count] = num;                                                                              //store the random number into randHolder array at count index (can be eliminated)
                randList.Items.Add(Convert.ToString(num));                                                            //add the random number to the listbox randList
                mynum = separateThis(num);                                                                            //call the function to separate the digits of the random number, and store it in mynum 
                /**
                for (int j = 0; j < 6; j++)                                                                           //this section should store the digits in two dimensional array, with i as the main index, and j as the digits position
                {                                                                                                     //i choose to eliminate this part since we don't need to recall the number
                    digHolder[count, j] = mynum[j];
                }**/

                myStr = Convert.ToString(mynum[0] + "," + mynum[1] + "," + mynum[2] + "," + mynum[3] + "," + mynum[4] + "," + mynum[5]);    //string formatting 
                digList.Items.Add(myStr);                                                                                                   //show the result at the listbox


                sortNum = sortThis(mynum);                                                                                                          //sorting the array 
                sortStr = Convert.ToString(sortNum[0] + "" + sortNum[1] + "" + sortNum[2] + "" + sortNum[3] + "" + sortNum[4] + "" + sortNum[5]);   //string formatting
                sortList.Items.Add(sortStr);                                                                                                        //add to the listbox

                count++;                                                                                                //increase the count
            }
        }

        private void createBtn_Click(object sender, EventArgs e)                                                        //when the user click the create button, do this
        {
            method();                                                                                                   //call the method function
        }

        private void userInput_KeyDown(object sender, KeyEventArgs e)                                                   //when user press the enter key after putting the number
        {
            if(e.KeyCode == Keys.Enter)
            {
                method();                                                                                               //call method function
            }
        }
    }
}
