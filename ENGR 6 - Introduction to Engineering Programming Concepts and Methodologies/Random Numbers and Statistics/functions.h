#include <math.h>
#include <stdlib.h>
#include <stdio.h>
#include <stdbool.h>

/******************************************************************************
**                          RANDOM NUMBER GENERATOR                          **
** This function will return a number generated by rand() % number of sides  **
** And add k-1                                                               **
******************************************************************************/
int roll(int sides){
    return (rand()%sides + 1);
}

/******************************************************************************
**                  Statistical Functions source code                        **
******************************************************************************/
// MAX,MIN, MEAN, MEDIAN, VARIANCE, STD_DEV
/******************************************************************************
**                                 MAX                                       **
** This function will return the max value on the array x                    **
******************************************************************************/
float max(float x[],int npts){
    //creating float variable maxN to hold the value on x[0]
    float maxN = x[0];
    //for loop to check if the max value is indeed the highest
    for(int k = 0; k < npts; k++){
        if(x[k] > maxN){
            maxN = x[k];
        }
    }
    return maxN; //return max number
}
///////////////////////////////////////////////////////////////////////////////
/******************************************************************************
**                                 MIN                                       **
** This function will return the minimum value inside the array              **
******************************************************************************/
float min(float x[],int npts){
    //float variable minN to hold to lowest value on the array
    float minN = x[0];
    //for loop that will determine the lowest value on the array
    for(int k = 0; k < npts; k++){
        if(x[k] < minN){
            minN = x[k-1];
        }
    }
    return minN;
}
///////////////////////////////////////////////////////////////////////////////
/******************************************************************************
**                                MEAN                                       **
**  This function returns the average or mean value of an array x with n     **
**  elements.                                                                **
******************************************************************************/
float mean(float x[],int npts){
    /*  Declare and initialize variables.  */
    float sum = 0;
    
    /*  Determine mean value.  */
    for (int k = 0 ; k < npts ; k++){
        sum += x[k];
    }
    
    /*  Return mean value.  */
    return sum/npts;
}
///////////////////////////////////////////////////////////////////////////////
/******************************************************************************
**                                 MEDIAN                                    **
** This function returns the median value in the sorted array x with npts    **
** elements.                                                                 **
******************************************************************************/
float median(float x[],int npts){
    /*  Declare variables.  */
    int k;
    float median_x;
    
    /*  Determine median value.  */
    k = floor(npts/2);
    
    if (npts%2 != 0){
        median_x = x[k];
    }else{
        median_x = (x[k-1] + x[k])/2;
    }
    
    /*  Return median value.  */
    return median_x;
}
///////////////////////////////////////////////////////////////////////////////
/******************************************************************************
**                               VARIANCE                                    **
**  This function returns the variance of an array x with npts elements.     **
******************************************************************************/
float variance(float x[],int npts){
    /*  Declare variables and function prototypes.  */
    float sum = 0, mu;
    
    /*  Determine variance.  */
    mu = mean(x,npts);
    
    for (int k = 0; k < npts-1 ; k++){
        sum += (x[k] - mu)*(x[k] - mu);
    }
    
    /*  Return variance.  */
    return sum/(npts-1);
}
/////////////////////////////////////////////////////////////////////////////// 
/******************************************************************************   
**                          STANDARD DEVIATION (STD)                         **
**  This function returns the standard deviation of an array x with npts     **
**  elements.                                                                **
******************************************************************************/
float std_dev(float x[],int npts){
    /*  Return standard deviation.  */
    return (sqrt(variance(x,npts)));
}


/******************************************************************************
**                         Sorting Functions source code                     **
******************************************************************************/
//swapping elements 
void swap(float* x, float* y){
	float temp = *x;
	*x = *y;
	*y = temp;
}

//int partition function
int partition(float * a, int p, int r) 
{
    /*  everything to the right is larger.*/
	float pivot = a[p];
	//integer variables for the position (p is the lowest and r is the max size)
	int i = p - 1, j = r + 1;

	while (true){ //while the condition is true
		// Find leftmost element greater than or equal to pivot 
		do{
			i++; //increase i while a at point i is lower that pivot point
		}while (a[i] < pivot);

		// Find rightmost element smaller than or equal to pivot 
		do{
			j--; //reduce j, while a at point j is bigger than the pivot
		} while (a[j] > pivot);

		// If the two is equal or bigger than ( i is bigger or equal with)
		if (i >= j)
			return j;
        
        //calling function swap to swap the value
		swap(&a[i],&a[j]);
	}
}

void quicksort(float * a, int p, int r)
{
    //if p is smaller than r
	if (p < r)
	{   
	    //declare an integer variable q
		int q;
		//q is equal to the result from the partition
		q = partition(a, p, r);
		quicksort(a, p, q);
		quicksort(a, q + 1, r);
	}
}