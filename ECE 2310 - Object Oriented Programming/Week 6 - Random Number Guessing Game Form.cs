/**
 * PROJECT 1 - PROGRAMMED BY JONATHAN HANBALI
 * GUESS NUMBER GAME
 * 
 * deliverable:
 * 1. Flowchart or pseudocode
 * 2. execution sc, and code
 * 
 * Rules:
 * •	Computer proposes an integer number in range 1..100 and a player should guess it.
 * •	At every step of the game, player tells the computer his assumption about a number and computer tells if player guessed it right.
 *      Otherwise, computer tells the player if his number is less or more than the proposed number and player tries again until he/she guesses it right.
 * •	The player could type invalid inputs, such as: 3.24 (real number ), or sdf (string). 
 *      The program should validate the input by displaying an invalid input message and allowing the player to re-enter , until the input is valid.
 * •	After the player guesses the number right, the program should ask the user if he/she wants to play another game. 
 *      If the answer is yes, repeat the whole process; if it is no, then stop the program.
**/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1_Form
{
    public partial class Form1 : Form
    {
        private int randomNum;                                                                  //integer randomNumber that will be accessible by multiple functions within this class
        private int count = 0;                                                                  //private integer count that will be accessible by multiple function within this class

        private static int randomGen()                                                          //function randomGen that will return an integer random number
        {
            Random rand = new Random();                                                         //New Random variable
            int num = rand.Next(0, 100);                                                        //creating new random between 0 to 100 and store it in num variable

            return num;                                                                         //return num
        }

        
        private bool numValidator(string str1)                                                  //boolean function numValidator that will validate userEntered string
        {
            int num;                                                                            //integer variable num

            if (!int.TryParse(str1, out num))                                                   //tryParse string 1 with output as integer num, if it failed, then return false
            {
                return false;
            }
            else                                                                                //else if its true, return true only and if only number is bigger than 0 and less than 100
            {
                if (int.Parse(str1) < 0 || int.Parse(str1) > 100)
                {
                    return false;                                                               //if its bigger than 100 or less than 0, then return false
                }
                else
                {
                    return true;                                                                //else return true
                }
            }
        }

        private void game()                                                                     //game function that can be recalled by enter keypress or clicking button
        {
            string userInput = userBox.Text;                                                    //get the value from the userBox textbox
            bool valid = numValidator(userInput);                                               //boolean valid to check if the user entered the right values

            if (!valid)                                                                         //if its not valid, then show a warning message, clear and focus the textbox
            {
                MessageBox.Show("Please enter a valid number between 0 to 100", "Error Message");
                userBox.Clear();
                userBox.Focus();
            }
            else
            {
                int userNum = int.Parse(userInput);                                              //since we validate the user input, then we can just convert the input into numbers

                if (userNum < randomNum)                                                          //if userInput is less than the random number, show message that the input is less
                {
                    MessageBox.Show("Your number is lower than the random number", "Almost There");
                    userBox.Focus();
                    count++;
                }
                else if (userNum > randomNum)                                                    //if userInput is more than the random number, show message that the input is more
                {
                    MessageBox.Show("Your number is higher than the random number", "Almost There");
                    userBox.Focus();
                    count++;
                }
                else
                {                                                                                //else congratulate the user
                    MessageBox.Show("You guessed the right number! it took you: " + count + " tries", "Congratulations!");
                    count = 0;
                    randomNum = randomGen();
                    userBox.Clear();
                }
            }
        }

            public Form1()
        {
            InitializeComponent();
            MessageBox.Show("Welcome to Random Number Guessing Game, \nprogrammed by Jonathan Hanbali. \n\n" +
                "To play this game, press the create button, \nthen the system will generate a random number between 0 to 100\n\n" +
                "After that, then you can enter your guess for the random number, \nthen press guess button \n\n" +
                "= if your guess is right, then the computer will let you know that your number is right \n" +
                "< if your guess is too low, then the computer will let you know that your number is lower \n" +
                "> if your guess is too high, then the computer will let you know that your number is to high", "How to Play:");
        }

        private void createBtn_Click(object sender, EventArgs e)                                //CreateButton click is when you press the create button to generate random numbers
        {
            randomNum = randomGen();                                                            //set randomGen output into randomNum variable
        }

        private void guessBtn_Click(object sender, EventArgs e)                                 //event that will happen when you press the guess button
        {
            game();
        }

        private void userBox_KeyDown(object sender, KeyEventArgs e)                             //event that will happen when you press enter button on your keyboard.
        {
            if (e.KeyCode == Keys.Enter)
            {
                game();
            }
        }
    }
}


