/******************************************************************************
Pacific Weather Program

**
that reads a data file (Oceandata.txt) that contains the year, quarter, 
and ENSO index for that period of time. Use dynamic memory to set the size
of the array at run-time.

**
The program should determine and print to the screen the year and quarter 
with the strongest El Niño and La Niña conditions.

**
Write to an output file named Elnino15.dat all the years and quarters and 
index value in which the El Nino conditions averaged stronger than 1.0 
(greater than 1.0). The year, quarter and index are written on one line 
in aligned columns. Use csv standards so that the file can easily be 
imported into another application

**
The program should read a file with monthly data.  You will need to read 
the file and then create the quarterly averages (Jan-Mar, Apr-Jun, July-Sept,
and Oct-Dec are the four quarters named Q1, Q2, Q3, Q4 respectively).  
The months in the file are encoded with a number so that 1 is January and 
12 is December.

**
Programmed by: Jonathan Hanbali
*******************************************************************************/
//Including all the necesarry header file
#include <stdio.h>
#include <math.h>
#include <stdlib.h>
//#include "OcFunct.h"

//constant filename for file input
#define f_I "Oceandata.txt"
#define f_O "Elnino15.dat"

//Creating the structures.
//typedef will allows us to write OCD only without having to type struct OCD
//OCD struct will contains year, months, total, climajust, and anomalies
typedef struct OCD{
   int year, mon;
   float total,climajust,anom;
} OCD;

///QDT contains years, quarters, and average
typedef struct QDT{
    int years, quarters;
    float ave;
} QDT;

////////////////////////////////////////////////////////////////
// Max function that will return the max value from the struct//
////////////////////////////////////////////////////////////////
//this is a void function, it will shows the max value from the 
//structure. This function will accept the struct and size variables
void max(QDT *OcDat, int size){
    //creating float maxVal
    float maxVal = 0.0;
    //creating integer position 
    int pos;
    
    //for loop that will calculate the max value
    for(int a = 0; a < size; a++){
        if(maxVal < OcDat[a].ave){
            maxVal = OcDat[a].ave;
            pos = a;
        }
    }
    
    //printing the result to the console
    printf("\nMaximum El Niño Conditions in Data file\n");
    printf("Year: %i",OcDat[pos].years);
    printf(", quarter: %i",OcDat[pos].quarters);
    printf(", with a value of: %2.2f\n", maxVal);
}

////////////////////////////////////////////////////////////////
// Max function that will return the max value from the struct//
////////////////////////////////////////////////////////////////
//This function will calculate the lowest value.
//min function will accept the structure and the size of the data
void min(QDT *OcDat, int size){
    //float minVal  that will hold the minimum value
    float minVal = 0.0;
    //integer position that will hold the position
    int pos;
    
    //for loop that will calculate the minimum value on the average
    for(int a = 0; a < size; a++){
        if(minVal > OcDat[a].ave){
            minVal = OcDat[a].ave;
            pos = a;
        }
    }
    
    //printing up the result
    printf("\nMaximum La Niña Conditions in Data file\n");
    printf("Year: %i",OcDat[pos].years);
    printf(", quarter: %i",OcDat[pos].quarters);
    printf(", with a value of: %2.2f\n", minVal);
}

////////////////////////////////////////////////////////////////
//                 Above the Treshold function                //
////////////////////////////////////////////////////////////////
//this function will show the user the amount/ list of the averages
//that's above the treshold. this abT function will accept the structure
//and the size integer. it will also accept the treshold. I do it this way
//so then if we want to change the treshold, we can change it easily.
//this function will also write to Elnino15.dat file the result of the calculation
void abT(QDT *OcDat, int size, float treshold){
    //Read the file
    //Declare and initialize variables
    FILE *OcOUT;
    
    //Open file and ready to write
    OcOUT = fopen(f_O,"w");
    
    //integer count to keep track of the total 
    int count = 0;
    
    //printing the output and storing some output to a file
    printf("\nEl Niño Conditions stronger than %2.2f\n",treshold);
    printf("Year,    Quarter,    Index\n");
    fprintf(OcOUT,"El Niño Conditions stronger than %2.2f\n",treshold);
    fprintf(OcOUT,"Year,    Quarter,    Index\n");
    
    //loop to find the data that's above the treshold, and then show the output
    //and also store it onto the output file.
    for(int a = 0; a < size; a++){
        if(OcDat[a].ave > treshold){
            printf("%4i",OcDat[a].years);
            printf("%15i",OcDat[a].quarters);
            printf("%13.2f\n",OcDat[a].ave);
            
            fprintf(OcOUT,"%4i,",OcDat[a].years);
            fprintf(OcOUT,"%12i,",OcDat[a].quarters);
            fprintf(OcOUT,"%10.2f\n",OcDat[a].ave);
            count++;
        }
    }
    
    //printing the total occurents
    printf("Total Event : %i",count);
    fprintf(OcOUT,"Total Event : %i",count);
   
}

////////////////////////////////////////////////////////////////
//                         Main Function                      //
////////////////////////////////////////////////////////////////
//The main function will call the every other functions. it will
//also read the file, use the data and store it into struct array
//and then do necesarry calculation or computation to met the criteria
int main()
{
    //This main function will call every other function
    
    //Read the file
    //Declare and initialize variables
    FILE *OcFile;
    
    //Open file and read the first data point
    OcFile = fopen(f_I,"r");
    
    //Integer array size
    int arrSize = 0;
    
    //Dummy strings to store unused variable that we don't need
    char dumpMem[10];
    
    //DUmmy float
    float dumpF1, dumpF2;
    
    //Reading input files
    if(OcFile == NULL)
        printf("Error opening input file. \n");
    else
    {   
        //scanning the text file as the input files
        printf("File reading is successful\n");
        
        //getting the value of the column provided on the first row 
        //of the text file and the time Interval
        fscanf(OcFile,"%i %s", &arrSize, dumpMem);
        
        //new file OcDat
        OCD *OcDat;
        
        //Allocate the memory for an array with the size of arrSize
        OcDat = malloc(arrSize * sizeof(OCD));
        
        //Ignoring the header 
        fscanf(OcFile,"%s", dumpMem);
        fscanf(OcFile,"%s", dumpMem);
        fscanf(OcFile,"%s", dumpMem);
        fscanf(OcFile,"%s", dumpMem);
        fscanf(OcFile,"%s", dumpMem);
        
        //storing the rest of the data into the structures using for loop
        for(int i = 0; i < arrSize; i++){
            fscanf(OcFile,"%i",&OcDat[i].year);
            fscanf(OcFile,"%i",&OcDat[i].mon);
            fscanf(OcFile,"%f",&OcDat[i].total);
            fscanf(OcFile,"%f",&OcDat[i].climajust);
            fscanf(OcFile,"%f",&OcDat[i].anom);
        }
        
        //Dividing the data by quarters, and get the average of anom
        int quartSize = arrSize / 3;
        
        //new QDT struct, QuartDat
        QDT * QuartDat;
        
        //Allocate the memory for the array with the size of the QuartDat
        QuartDat = malloc(quartSize * sizeof(QDT));
        
        //for loop that will assign quarter value and also calculate the average
        //of the  anomalies for that quarter
        for(int j = 0; j < quartSize; j++){
            //Copy the year data to the quarterly structs
            QuartDat[j].years = OcDat[(j*3)+2].year;
            
            //Assigned the quarter value to the quarterly struct
            if(OcDat[(j*3)].mon >=1 && OcDat[(j*3)].mon <=3) {
                QuartDat[j].quarters = 1;
            }else if(OcDat[(j*3)].mon >=4 && OcDat[(j*3)].mon <=6) {
                QuartDat[j].quarters = 2;
            }else if(OcDat[(j*3)].mon >=7 && OcDat[(j*3)].mon <=9) {
                QuartDat[j].quarters = 3;
            }else if(OcDat[(j*3)].mon >=10 && OcDat[(j*3)].mon <=12) {
                QuartDat[j].quarters = 4;
            }
            
            //calculating the average
            QuartDat[j].ave = (OcDat[(j*3)].anom + OcDat[(j*3)+1].anom + OcDat[(j*3)+2].anom)/3;
        }
        
        /** testing
        for(int b = 0; b < quartSize; b++){
            printf("%2.2f\n",QuartDat[b].ave);
        }**/
        
        //calling max, min, and above the treshold function
        max(QuartDat,quartSize);
        min(QuartDat,quartSize);
        abT(QuartDat,quartSize,1.0);
        
        //freeing the memory allocation
        free(OcDat);
        free(QuartDat);
    }
}
