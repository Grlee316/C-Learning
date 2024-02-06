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
using System.Text;

namespace Project_1
{
    class Program
    {
        
        private static int randomGen()                                                  //function randomGen that will return an integer random number
        {
            Random rand = new Random();                                                 //New Random variable
            int num = rand.Next(0, 100);                                                //creating new random between 0 to 100 and store it in num variable

            return num;                                                                 //return num
        }

        private static void userPrompt()
        {
            int numGen = randomGen();
            Console.WriteLine("Please enter your guess: ");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Random Number Guessing Game");
            Console.WriteLine("Programmed by Jonathan Hanbali");
            Console.WriteLine("==============================");
            Console.WriteLine("\n");
            

            userPrompt();



        }
    }
}
