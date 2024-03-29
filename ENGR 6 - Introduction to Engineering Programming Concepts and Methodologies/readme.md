# ENGR 6 - Introduction to Engineering Programming Concepts and Methodologies
This Part of the repository will show the program that I wrote or modify in the class. This class incorporate both C and C++. We also use Arduino as an integral part of this class. 

## Contains:
### 1. [Pacific Weather Program](https://github.com/Grlee316/C-Learning/tree/main/ENGR%206%20-%20Introduction%20to%20Engineering%20Programming%20Concepts%20and%20Methodologies/Pacific%20Weather%20Program#pacific-weather-program)
Objective:
- reads a data file (Oceandata.txt) that contains the year, quarter, and ENSO index for that period of time. Use dynamic memory to set the size of the array at run-time.
- Determine and print to the screen the year and quarter with the strongest El Niño and La Niña conditions.
- Write to an output file named Elnino15.dat all the years and quarters and index value in which the El Nino conditions averaged stronger than 1.0 (greater than 1.0).
  The year, quarter and index are written on one line in aligned columns. Use csv standards so that the file can easily be imported into another application
- The program should read a file with monthly data. The months in the file are encoded with a number.

### 2. [Seismic Detection Program](https://github.com/Grlee316/C-Learning/blob/main/ENGR%206%20-%20Introduction%20to%20Engineering%20Programming%20Concepts%20and%20Methodologies/Seismic%20Detection%20Program/readme.md)
Objective:
- Accept the data from seismic text file, and then read the amount of data and the interval, and then create an appropriate array to store the data that's being read.
- Pass the data to seismFunct.h that will calculate the total of possible seismic events

### 3. [Peak Detection Program](https://github.com/Grlee316/C-Learning/blob/main/ENGR%206%20-%20Introduction%20to%20Engineering%20Programming%20Concepts%20and%20Methodologies/Peak%20Detection%20Program/readme.md)
Objective:
- This program will read the data provided by user in a form of text file, and then will read the amount of rows and column provided.
- It will create a two dimensional array with the size given. Then another function will be used to gather the grid data and then store it inside of the array.
- After storing the array, we then will read the value inside the array and then determine whether the value is the peak of the grid or not.
  The criteria that will be used for this function is if the value on the 4 sides of the value is lower than the selected walue itself.

### 4. [Random Number and Statistics](https://github.com/Grlee316/C-Learning/blob/main/ENGR%206%20-%20Introduction%20to%20Engineering%20Programming%20Concepts%20and%20Methodologies/Random%20Numbers%20and%20Statistics/readme.md)
Objective:
- Allow the user to enter the size of the dice, the number of dice to roll in a single throw, the number of throws to make.
- Save the results of the dice rolls to a file (to allow for verification of the program).
- The file should have an opening header line that indicates size (number of sides) of the dice rolled.
- Then calculate the mean roll, the median roll, the standard deviation for the total number of rolls made

### 5. [DNA Strings](https://github.com/Grlee316/C-Learning/blob/main/ENGR%206%20-%20Introduction%20to%20Engineering%20Programming%20Concepts%20and%20Methodologies/DNA/readme.md)
Objective:
- use either the index or pointer version as a starting point
- Modify the program so that it will work with either lowercase or uppercase characters.
- Modify the program so that it checks to be sure that the length of the short string is less than the length of the long string.
- Store the results of the search to a file as well as to the screen.
- Run the program on the provided DNA sequence file. Search for the short string AACAT
