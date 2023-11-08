#include <stdio.h>
#include <math.h>
#include <stdlib.h>

//constant filename for file output
#define f_O "result.txt" //for the ease of compile result, we will use this 

//declaring the seisDetect function that accepts int variable arrSize,
//float variable timeInt, float variable seis array

void seisDetect(int arrSize,float timeInt,float seis[][arrSize]){
    
    //declare a result file
    FILE *resFile;
    
    //Open file and read the first data point
    resFile = fopen(f_O,"w");
    
    //variable to count how many total events occured
    int counter = 0;
    
    //variable float to store max and min ratios
    float max = 0, min = 0;
    
    //the treshold of the seismic events
    printf("Please enter the threshold point above 1: ");
    //create a treshold variable
    float tresholdPts;
    scanf("%f",&tresholdPts);
    
    while(tresholdPts < 1){
        printf("Wrong value entered, please enter a threshold higher than 1: ");
        scanf("%f",&tresholdPts);
    }
    
    /***************************************************
     * If the short-time power measurement is made using two samples, and the 
     * long-time power measurement is made using five measurements, 
     * then we can compute power ratios
    ****************************************************/
    //If it's started from the 5th, we can ignore/start from the 4-5 for the short time measurements
    
    //float variable of ratio that holds the ratio calculation
    //since the power function use the 1-5, so we ignore the first 4 (0,1,2,3)
    float rat[arrSize - 4];
    
    //for loop that calculate the ratio
    //4 is the 5th
    for(int i = 4; i < arrSize;i++){
        //calculating the short power
        float short_T_Pow = (pow(seis[0][i-1],2) + pow(seis[0][i],2))/2 ;
        
        //calculating the long power
        float long_T_Pow = (pow(seis[0][i-4],2) + pow(seis[0][i-3],2) + pow(seis[0][i-2],2) + pow(seis[0][i-1],2) + pow(seis[0][i],2))/5;
        
        //store the ratio inside rat array
        rat[i-4] = short_T_Pow / long_T_Pow;
        
        //code to test if this code section is working properly
        //printf("Short power: %2.2f, Long power: %2.2f, ratio: %2.2f\n",short_T_Pow,long_T_Pow,rat[i-4]);
    }
    
    //for loop that will tell us when the seismic event happening
    for(int j = 0; j < arrSize - 4;j++){
        //if j is 0, j-1 is not make sense, so we can ignore 
        if(j == 0 && rat[j] > tresholdPts){
            //printing to prompt
            printf("Possible seismic event is detected between the time %2.2f s and %2.2f s with the ratio of %2.2f\n",(seis[1][j+4]),(seis[1][j+5]),rat[j]);
            //printing to result file
            fprintf(resFile,"Possible seismic event is detected between the time %2.2f s and %2.2f s with the ratio of %2.2f\n",(seis[1][j+4]),(seis[1][j+5]),rat[j]);
            //add 1 to counter
            counter++;
        }
        if(j >= 1 && rat[j] > tresholdPts && rat[j-1] < tresholdPts){
            //printing to prompt
            printf("Possible seismic event is detected between the time %2.2f s and %2.2f s with the ratio of %2.2f\n",(seis[1][j+4]),(seis[1][j+5]),rat[j]);
            //printing to result file
            fprintf(resFile,"Possible seismic event is detected between the time %2.2f s and %2.2f s with the ratio of %2.2f\n",(seis[1][j+4]),(seis[1][j+5]),rat[j]);
            //add 1 to counter
            counter++;
        }
    }
    
    //the min variable will be set to the value at rat[0]
    min = rat[0];
    
    //for loop that will tell you max and min ratio
    for(int a = 0 ; a < arrSize - 4 ; a++){
        //calculating the max
        if(rat[a] > max){
            max = rat[a];
        }
        //calculating the min
        if(min > rat[a]){
            min = rat[a];
        }
        
    }
   
   //printing it to the prompt and the result.txt
   printf("Total possible seismic event: %i",counter);
   fprintf(resFile,"Total possible seismic event: %i",counter);
   printf("\nMax ratio: %2.2f",max);
   fprintf(resFile,"\nMax ratio: %2.2f",max);
   printf("\nMin ratio: %2.2f",min);
   fprintf(resFile,"\nMin ratio: %2.2f",min);
}
