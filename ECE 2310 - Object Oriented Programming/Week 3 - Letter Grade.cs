/******************************************************************************************************************************************************
 * 2. Write a C# console application that reads a student’s grade and displays the letter grade. 
 * It should validate the input before processing it, i.e. if the input is negative or more than 100, 
 * output an error message and stop the program. If the input is not a number, output an error message and stop the program, too. 
 * There is one requirement: to determine the letter grade , use “ switch…case “ 
 * 
 * 100>=grade>=90     A
 * 90>grade>=80       B
 * 80>grade>=70 	  C
 * 70>grade>=60		  D
 * Grade<60			  F
 ******************************************************************************************************************************************************/

using System;

namespace Hw03_2
{
    class Program
    {
        private static void grader(int num) //this is the function called grader that will receive integer entered by the user
        {
            switch (num) //switch case with num as the cases
            {
                case  var expression when (num <= 100 && num >= 90): //if the num is more than equal to 90 and less than equal to 100,
                    Console.WriteLine("The score of {0} is A in letter grade", num); //then the letter grade is A
                    break;
                case var expression when (num < 90 && num >= 80): //if the num is more than equal to 80 and less than 90,
                    Console.WriteLine("The score of {0} is B in letter grade", num); //then the letter grade is B
                    break;
                case var expression when (num < 80 && num >= 70): //if the num is more than equal to 70, and less than 80,
                    Console.WriteLine("The score of {0} is C in letter grade", num); //then the letter grade is C
                    break;
                case var expression when (num < 70 && num >= 60): //if the num is more than equal to 60 and less than 70,
                    Console.WriteLine("The score of {0} is D in letter grade", num); //then the letter grade is D
                    break;
                case var expression when (num < 60): //if the num is less than 60,
                    Console.WriteLine("The score of {0} is F in letter grade", num); //then the letter grade is F
                    break;
                default:
                    break;

            }
        }
        static void Main(string[] args) //main function
        {
            Console.WriteLine("Grading System - Programmed by Jonathan Hanbali");
            Console.WriteLine("Please enter the numerical grade"); //asking the user to enter the grade in numerical value
            String userInput = Console.ReadLine(); //read the input and store it int userInput
            int num; //empty integer variable num

            if (!int.TryParse(userInput, out num)) //if the user entered values other than an integer
            {
                Console.WriteLine("Invalid value entered"); //show the error message
                Environment.Exit(0); //exit the program
            }
            else //if the user entered integer
            {
                num = Int32.Parse(userInput); //parsing the user input into integer 32
                if(num < 0 || num > 100) //if the num is less than 0 or more than 100
                {
                    Console.WriteLine("Invalid value entered"); //show the error message
                    Environment.Exit(0); //exit the program
                }
                else
                {
                    grader(num); //else it will call the grader function and will pass the numerical grade
                }
            }
        }
    }
}
