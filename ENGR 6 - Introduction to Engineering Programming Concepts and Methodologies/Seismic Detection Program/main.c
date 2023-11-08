/******************************************************************
 * This program will accept the data from seismic text file, and then
 * read the amount of data and the interval, and then create an appropriate
 * array to store the data that's being read.
 * 
 * then it will pass the data to seismFunct.h that will calculate the total /
 * possible seismic events
******************************************************************/
#include <stdio.h>
#include <math.h>
#include <stdlib.h>
#include "seismFunct.h"

//constant filename for file input
#define f_I "seismic1.txt"

int main(){
    //This main function will call every other function
    
    //Read the file
    //Declare and initialize variables
    FILE *sesFile;
    
    //Open file and read the first data point
    sesFile = fopen(f_I,"r");
    
    //Integer array size
    int arrSize;
    //Float variable time Interval
    float timeInt;
    
    
    //Reading input files
    if(sesFile == NULL)
        printf("Error opening input file. \n");
    else
    {   
        //scanning the text file as the input files
            // printf("File reading is successful\n");
        
        //getting the value of the column provided on the first row 
        //of the text file and the time Interval
        fscanf(sesFile,"%i %f", &arrSize, &timeInt);
        
        //creating the array with the size of the row and column
        float seis[2][arrSize];
        
        //read the data and store it inside the appropriate row and column of the grid array
        //i is the row, and j is the column
        for(int i = 0; i < arrSize; i++){
                //scanning the file and store it inside the array
                fscanf(sesFile, "%f", &seis[0][i]);
                //storing the time interval at i
                seis[1][i] = timeInt * i;
                
                //test function
                //printf("%2.2f time %2.2f size\n",seis[1][i],seis[0][i]);
        }
        
        //calling the seisDetect function
        seisDetect(arrSize,timeInt,seis);
    }
}
