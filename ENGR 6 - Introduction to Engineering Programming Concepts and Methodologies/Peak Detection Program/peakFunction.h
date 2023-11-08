#include <stdio.h>
#include <math.h>
#include <stdlib.h>

void peakDetect(int r, int c, int arry[][c]){
    //This function will detect the peak on the grid
    if(r <= 2 && c <=2)
    {
        printf("You does not have any peak, you have row and column less or equal to two\n");
    } 
    else if(r > 2 && c > 2)
    {
        //We can always ignore the value on the 0 and n-1
        bool boolArr[r][c];
        int peak,numOfPeak = 0;
        
        //setting up the boolean array into all 0
        //this boolean array will change into 1 (true) if a peak is detected
        for(int i = 0; i < r;i++){
            for(int j = 0; j < c; j++){
                boolArr[i][j] = 0; 
            }
        }
        
        for(int a = 1; a < r-1; a++){
            for(int b = 1; b < c-1; b++){
                if(arry[a][b] > arry[a-1][b] && arry[a][b] > arry[a][b-1] && arry[a][b] > arry[a][b+1] && arry[a][b] > arry[a+1][b])
                {
                    boolArr[a][b] = 1;
                    peak = arry[a][b];
                    numOfPeak++;
                
                printf("The peak is located at row %i column %i with the value of %i\n",a+1,b+1,peak);
                }
                else if(arry[a][b] <= arry[a-1][b] || arry[a][b] <= arry[a][b-1] || arry[a][b] <= arry[a][b+1] || arry[a][b] <= arry[a+1][b]){
                    boolArr[a][b] = 0;
                }
                
            }
        }
        
    //Printing out the total numbe of peak
    printf("You have a total of %i peak(s)",numOfPeak);
    }
        
}
