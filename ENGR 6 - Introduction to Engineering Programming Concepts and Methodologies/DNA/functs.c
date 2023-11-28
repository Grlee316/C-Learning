#include<stdbool.h>

/******************************************************************************
 * UP function that will accept a pointer to character array.
 * this function will change all lowercase character into an uppercase characters
******************************************************************************/
void up(char *st){
    //This part of the code will change the lowercase letter into an uppercase letter
    for(int i = 0; i < strlen(st); i++){
         if(st[i] >= 97 && st[i] <= 122)
         {
            st[i] = st[i] - 32;
         }
    }
}

//void function to clean the buffer after reading
void flushstdin()
/* Clear the stdin buffer through the next \n character */
{
    int charin=getchar();
    while (charin != (int)'\n' && charin != EOF)
      charin=getchar();
    return;
}

/**
bool isEqual(char A,char B){
    if(A == B)
        return 1;
    else
        return 0;
}**/

//integer function count Function that will show the number of occurance of the short string on the long string
int countF(char *LongS, char *ShortS){
    //integer variable to hold the length of the short strings and the long strings
    int aL = strlen(LongS);
    int bL = strlen(ShortS);
    //integer variable result 
    int res = 0;
    
    // Loop to go thru the long string
    for(int i = 0; i < aL - bL; i++){
        int j;
        for(j = 0; j < bL; j++){
            //if any of them is not equal
            if(LongS[i+j] != ShortS[j]){
                //break the j loop
                break;
            }
        }
        //if j reach the end of the short string
        if (j == bL){
            //add res
            res++;
            //reset j
            j = 0;
        }
    }
    //return res
    return res;
}
