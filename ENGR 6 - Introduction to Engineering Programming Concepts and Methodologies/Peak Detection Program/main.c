/******************************************************************
 * This program will read the data provided by user in a form of 
 * text file, and then will read the amount of rows and column 
 * provided, then it will create a two dimensional array with the
 * size given. Then another function will be used to gather the grid data
 * and then store it inside of the array. After storing the array, we then
 * wull read the value inside the array and then determine whether the 
 * value is the peak of the grid or not. The criteria that will be used
 * for this function is if the value on the 4 sides of the value is lower
 * than the selected walue itself.

 **
 Programmed by Jonathan Hanbali
******************************************************************/
#include <stdio.h>
#include <math.h>
#include <stdlib.h>
#include <stdbool.h>
#include "peakFunct.h"


//constant filename for file input
#define f_I "grid.txt"
//constant filename for file output
#define f_O "peak.txt"

int main()
{
    //This main function will call every other function
    
    //Read the file
    //Declare and initialize variables
    FILE *peakFile;
    
    //Open file and read the first data point
    peakFile = fopen(f_I,"r");
    
    int row, col;
    
    printf("Peak Detection\n"); 
    printf("Programmed by Jonathan Hanbali\n");
    printf("**************************************************\n\n");
    
    //Reading input files
    if(peakFile == NULL)
        printf("Error opening input file. \n");
    else
    {   
        //scanning the text file as the input files
            // printf("File reading is successful\n");
        
        //getting the value of the row and column provided on the first row
        //of the text file
        fscanf(peakFile,"%i %i", &row, &col);
        
        //creating the array with the size of the row and column
        int grid[row][col];
        
        //read the data and store it inside the appropriate row and column of the grid array
        //i is the row, and j is the column
        for(int i = 0; i < row; i++){
            for(int j = 0; j < col; j++){
                fscanf(peakFile, "%i", &grid[i][j]);
            }
        }
        
        peakDetect(row,col,grid);
        
    }
    
}

