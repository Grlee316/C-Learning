/** 
1.	
a) Write a method Search that takes input of an numerical array A of size n and a specific value key. 
   It returns the index of the first element in A that equals to key, or, returns -1 if none of the elements of A is equal to key.
b) Write a C# console application that reads the scores of 26 students. 
   It then calls the method Search and displays if there is anyone gets 100%. The display message should look like this:

Students #5 earns 100%.
Students #19 earns 100%.
Students #21 earns 100%.

Or this:
            
None of the students earn 100%.

Programmed by Jonathan Hanbali


 * **/

using System;

namespace hw6_1
{
    class Program
    {
        private static int sizeControl = 0;                                                                                                        //since the array will be passed every time we need a counter of where is the last checked position

        private static bool numValidator(string str1)                                                                                              //boolean function numValidator that will validate userEntered string
        {
            int num;                                                                                                                               //integer variable num

            if (!int.TryParse(str1, out num))                                                                                                      //tryParse string 1 with output as integer num, if it failed, then return false
            {
                return false;
            }
            else                                                                                                                                   //else if its true, return true only and if only number is bigger than 0 and less than equal to 100
            {
                if (int.Parse(str1) <= 0 || int.Parse(str1) > 100)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        private static int findThisThing(int[] arr, int num)                                                                                        //function that will accept array and find a value that we want to find in the array
        {
            for(int i = sizeControl; i < arr.Length; i++)                                                                                           //since we always get the array, i need to be equal to a sizeControl so it can resize it search into a smaller
            {                                                                                                                                       //section after the previous search (iteration 0 > iteration 1 > iteration 2) so i need to be the last search position
                if (arr[i] == num)                                                                                                                  //if the value in the array is equal to the one that we're trying to search
                {
                    sizeControl = i + 1;                                                                                                            //increase the sizeControl
                    return i;                                                                                                                       //return i;
                }
                else if(arr[i] != num)                                                                                                              //if the value of the array is not equal to the value that we're searching for
                {
                    sizeControl = i + 1;                                                                                                            //still shrink the searchable array size
                    return -1;                                                                                                                      //return -1
                }
            }

            return -2;                                                                                                                              //this will function as an error chacher, if neither of the value works, then it will show this error (-2)
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the amount of students in the class");                                                                 //Asking the user how many students is in this class
            string counter = Console.ReadLine();                                                                                                   //Read the user input
            bool valid = numValidator(counter);                                                                                                    //Check if the user entered the right number

            if (!valid)                                                                                                                            //if the user entered a wrong integer value
            {
                Console.WriteLine("Invalid value entered, please try again");                                                                      //show the error message
            }
            else                                                                                                                                   //if the user entered the right integer values
            {
                //Create integer variables
                int count = int.Parse(counter);
                int i = 0;
                int[] studentScore = new int[count];

                //Create string variables
                string stScore;

                Console.WriteLine("Please enter the score of the students\n");                                                                    //Asking the user to write each entry

                while (i < count)                                                                                                                 //while loop to input the student scores
                {
                    Console.WriteLine("The student #{0} have a score of: ", i + 1);                                                               //asking the score of the students
                    stScore = Console.ReadLine();                                                                                                 //Get the score and store it in string variable to check
                    bool validScore = numValidator(stScore);                                                                                      //Check the validity of the score

                    while (!validScore)                                                                                                           //If the student entered a invalid score, let them stay on the loop until they entered the right value
                    {
                        Console.WriteLine("Please enter the right score below for student #{0}", i+1);                                            //Ask the user to enter the right score
                        stScore = Console.ReadLine();                                                                                             //read the user input again
                        validScore = numValidator(stScore);                                                                                       //check the validity of user entered information
                    }

                    if (validScore == true)                                                                                                       //if the score is valid then start data entry
                    {
                        studentScore[i] = int.Parse(stScore);                                                                                     //store it in the array at index i
                    }

                    i = i + 1;                                                                                                                    //move index
                }

                //this is the search section
                int co = 0;                                                                                                                       //another counter variable called co
                int[] shadowCounter = new int[count];                                                                                             //a new array to store the location of "found" values
                bool theresVal = false;                                                                                                           //a boolean to note if value has been found
                while(co < studentScore.Length)                                                                                                   //while co is less than the length of the array
                {
                    shadowCounter[co] = findThisThing(studentScore, 100);                                                                         //check the array to make sure there's no 100, and store it in location array called the shadowCounter
                    if(shadowCounter[co] >= 0)                                                                                                    //if we found the value
                    {
                        theresVal = true;                                                                                                         //then we will note that we do find the value in the array
                    }
                    co++;                                                                                                                         //increase the counter
                }


                for(int a = 0; a < count; a++)                                                                                                    //for loop to show the output
                {
                    if(shadowCounter[a] >= 0)                                                                                                     //if there's an index location
                    {   
                        Console.WriteLine("Student #{0} earns 100%", shadowCounter[a] + 1);                                                       //print the index location + 1
                    }
                }

                if (theresVal != true)                                                                                                            //if there's no values
                {
                    Console.WriteLine("There's no student with 100% score");                                                                      //then show that there's no student with 100% score
                }
            }
        }
    }
}
