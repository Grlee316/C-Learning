/******************************************************************************
HW#22 DNA STRING
Modification to the program discussed in class

YOU can use either the index or pointer version as a starting point
•	Modify the program so that it will work with either lowercase or uppercase characters.
•	Modify the program so that it checks to be sure that the length of the short string is 
less than the length of the long string.
•	Store the results of the search to a file as well as to the screen.
•	Run the program on the provided DNA sequence file.  Search for the short string AACAT

LongDNAseq.dat string is shown below. 
*******************************************************************************/
//Including all appropriate header file needed for this program
#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include "functions.h"
#include <stdbool.h>
#include <ctype.h>
#include <conio.h>

#define f_O "fileOut.dat"
#define f_I "LongDNAseq.dat" //testing purposes

int main()
{
    
    printf("                     DNA STRING CHECKER                     ");
    printf("\n               Programmed By: Jonathan Hanbali               ");
    printf("\n/////////////////////////////////////////////////////////////");
    
    
    char tFN[21];
    printf("\nPlease enter the file name that contains the long string: (max 20 char)\n");
    scanf("%s",tFN);
    
    
    /***********************************************************************************
    // This section of the code will test if the name of the text file contains
    // .txt to prevent error, and then rename the file so it will have the extensions
    // of .txt this function will rename both input and output file
    ***********************************************************************************/
    //boolean variable containsDotTxt that will be true if the user entered the
    // name of the text file that contain .txt
    
    bool containsDotDat = false; 
    //character array dotTxt that hold .txt
    char dotDat[5] = ".dat";
        containsDotDat = true;
    //size of theFileName (length)
    int tFNL = (int)strlen(tFN);
    
    //If the fileName entered need to have .dat, then containsDotdat equals true
    if(tFN[tFNL-1] == 't' && tFN[tFNL-2] == 'a' && tFN[tFNL-3] == 'd' && tFN[tFNL-4] == '.'){
        containsDotDat = true;
    }//else if theFileName does not contain .dat, then 
    else if(tFN[tFNL-1] != 't' && tFN[tFNL-2] != 'a' && tFN[tFNL-3] != 'd' && tFN[tFNL-4] != '.'){
        //strncat theFileName with dotdat
        strncat(tFN,dotDat,4);
        //containsDotTxt equals true
        containsDotDat = true;
        //printf("\n%s",tFN); //test section
    }
    
    
    if(containsDotDat == true){
        FILE * tIN; //create new file pointer tIN
        FILE * tOUT; // create new file pointer tOUT
        
        tIN = fopen(tFN,"r"); //open tIN, set to read
        if(tIN == NULL){ //if tIN is NULL
            printf("Error opening input file\n"); //Show an error message
            //return (1);
        }
        tOUT = fopen(f_O,"w+");
        if(tOUT == NULL){
            printf("Error opening output file\n");
            //return(2);
        }
        
        printf("\nReading Input file"); 
        
        flushstdin();
        /**************************************************************************
         * This section of the code is the loop that will read the text file, and then
         * will do an appropriate step either to encode or decode the message
        **************************************************************************/
        int curchar; //integer variable curchar
        char * textIn = malloc(2500 * sizeof(char)); //char array textIn with the size of 2500
        int count = 0; //integer variable count with the initial value 0
        curchar = fgetc(tIN); //curchar equals get character on tIN file
        
        //while it does not reach the end of file
        while (curchar != EOF)
        {
            if(curchar >= 97 && curchar <= 122){
               textIn[count] = (char)(curchar - 32);
            }else if(isupper(curchar) == true){
                textIn[count] = (char)curchar;
            }
            count++;
            //get character again from file tIN
            curchar = getc(tIN);
        }
        //this part will make the array behave like a string (when we printf we Can
        //just use %s instead of having to do it one by one)
        textIn[count+1] = '\0';
        
        // -------------------- TEST CODE -------------------- 
        // showing the user what their input text is
        printf("\nYour Text is: \n");
        printf("%s\n",textIn);
        
        //showing the user what their input text is in the file out.dat
        fprintf(tOUT,"Your long text is: \n");
        fprintf(tOUT,"%s\n",textIn);
        
        int longStrLt = strlen(textIn);
        //printf("\nYour string has: %d characters", longStrLt); //Test sequence
        
        //flush the buffer
        flushstdin();
        
        //Creating character array to hold the string that you want to search
        char * strInput = malloc(longStrLt * sizeof(char));
        
        //Asking the user what string that they want to search
        printf("Please enter the short string that you're trying to find:\n");
        
        //scan for user input
        scanf("%s",strInput);
        
        //set the last character to null
        strInput[strlen(strInput)] = '\0';
        
        //showing the string that the user try to find on file out
        fprintf(tOUT,"\nYou want to find: %s",strInput);
        
        //calculating the length of the short string 
        int shortLt = strlen(strInput);
        //printf("\nYou entered a string with %i characters",shortLt);
        
        //convert user input to uppercase
        up(strInput);
        
        //find the number of occurance of the short string on the long string
        int numOC = countF(textIn,strInput);
        
        //integer variable to do the countdown
        int countdw = numOC;
        
        //integer variable to do the countup
        int countup = 0;
        
        //Showing the number of total occurance of the short string inside the long string
        printf("Total Occurance: %i",numOC);
        
        //Character pointer firstloc that will hold the pointer to the first occrance of the short string inside the long string
        char * firstLoc = strstr(textIn,strInput);
        
        //dynamically allocated integer loc array that hold the location of the appearance of the short string inside of the long string
        int * loc = malloc(longStrLt * sizeof(int));
        
        //getting the first occurance of the string, and store it inside the location array
        loc[countup] = longStrLt - strlen(firstLoc) + 1;
        
        //letting the user know when the occurance happen (at what numberth of character)
        printf("\nOccurance #%i of %s is at %ith character",(countup+1),strInput,loc[countup]);
        fprintf(tOUT,"\nOccurance #%i of %s is at %ith character",(countup+1),strInput,loc[countup]);
        
        //reduce 1 to countdown
        countdw = countdw - 1;
        
        //do while loop
        do{
            //search the next occurance with the pointer as the new first parameter
            firstLoc = strstr(firstLoc + 1 ,strInput);
            
            //if the pointer is not null
            if(firstLoc != NULL){
                //then add 1 to countup
                countup++;
                //location array at countoup equals to the location number th of the character
                loc[countup] = longStrLt - strlen(firstLoc) + 1;
                //printing the result to the command prompt
                printf("\nOccurance #%i of %s is at %ith character",(countup+1),strInput,loc[countup]);
                //printing the result to the text file
                fprintf(tOUT,"\nOccurance #%i of %s is at %ith character",(countup+1),strInput,loc[countup]);
                //reduce 1 to countdown
                countdw--;
            }
            
        }while(countdw != 0); //while countdown is not equal to 0
    
    //freeing the dynamic memory location
    free(loc);
    free(textIn);
    free(strInput);
    
    //closing the input file
    fclose(tOUT);
    fclose(tIN);
    
    return 0;
    }
}
