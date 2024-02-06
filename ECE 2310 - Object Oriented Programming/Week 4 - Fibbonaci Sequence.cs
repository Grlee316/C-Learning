/******************************************************************************************************************************************************
 * 1.	Write a C# console application that finds the first 30 numbers of Fibonacci series and displays all of them in 6 rows, with 5 numbers in each row. 
 * Use a formated string to make the output numbers aligned neatly, such as:
 *
 * 
 * 1	  1	    2	      3	        5
 * 8	  13	    21	      34	        55
 * 89	  144	    233	         …         …
 * …                    …	                     …
 * …                         …	                     …
 * …                           …	                     …
 * 
 ******************************************************************************************************************************************************/


using System;

namespace hw04_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //integer userInput to store the amount of fib series the user wanted
            int userInput;

            Console.WriteLine("Fibonacci Series - Programmed By Jonathan Hanbali");
            Console.WriteLine("*************************************************\n");

            Console.WriteLine("Please enter how many fibbonaci series you want to calculate"); //asking the user of how many fib series they wanted to calculate
            string input = Console.ReadLine();

            if (!int.TryParse(input, out userInput)) //if the user entered a wrong input other than numbers
            {
                Console.WriteLine("Invalid value entered");
            }
            else
            {
                //Integer array to hold the value
                int[] fibArr = new int[userInput];

                //since the first two number of the fibbonaci series will always be 1 and 1, we can hardcoded it into the array
                fibArr[0] = 1;
                fibArr[1] = 1;

                //for loop to calculate the fibbonaci series
                //i will start from 2 since we already filled the fib sequence up to pos 1
                //fib sequnce works by adding the previous 2 number, so then you need to add the two previous number to get your current number
                for (int i = 2; i < userInput; i++)
                {
                    fibArr[i] = fibArr[i - 1] + fibArr[i - 2];
                }

                Console.WriteLine("\nYour fibbonaci sequences are:");

                //while loop to show the output
                int count = 0, fiveCounter = 0; //integer counter and fivecounter to count the steps
                while (userInput > count) //if the userinput is bigger than count
                {
                    if (fiveCounter < 5) //if the fivecounter is less than 5
                    {
                        string a = String.Format("{0,-10}", (Convert.ToString(fibArr[count]) + " ")); //setting up the string to be printed
                        Console.Write(a); //write string a into the console
                        fiveCounter++; //add one to five counter 
                        count++; //add one to counter
                    }
                    else
                    {
                        Console.Write("\n"); //if the fivecounter equals to 5, then it will do a single return carriage 
                        fiveCounter = 0; //reset fivecounter to 0
                    }

                }


                /** in this previous version, i have to differentiate on how I do the writing (i.e. if the user entered something that's divisible with 5 (some%5=0)
                 * else it will print using the while loop, but then the while loop also works for number divisible by 5, so then I just use the while loop
                if(userInput % 5 == 0) //if the user input is divisible by 5
                {
                    for (int i = 0; i < userInput / 5; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            string a = String.Format("{0,-10}", (Convert.ToString(fibArr[(5 * i) + j]) + " "));
                            Console.Write(a);
                        }
                        Console.Write("\n");
                    }
                }
                else
                {
                    int count = 0, fiveCounter = 0;
                    while(userInput > count)
                    {
                        if(fiveCounter < 5)
                        {
                            string a = String.Format("{0,-10}", (Convert.ToString(fibArr[count]) + " "));
                            Console.Write(a);
                            fiveCounter++;
                            count++;
                        }
                        else
                        {
                            Console.Write("\n");
                            fiveCounter = 0;
                        }
                        
                    }

                }**/
            }

            Console.Read(); //wait until the user press enter to close the program
        }
    }
}
