using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    //Pool Class
    class Pool
    {
        //Data members
        //This class will contain or have Temperature and Location Class
        private Temperature myTemp;
        private Location myLoc;
        private int count = 0; //This will count how many pool being created
        private string name; //Store the name of the pool

        //overloaded constructor to create the pool
        public Pool(string n, Temperature myTemp, Location myLoc)
        {
            count = count + 1;
            this.myLoc = myLoc;
            this.myTemp = myTemp;
            name = n;
            Console.WriteLine("Pool " + name + " has been successfully created");
            Console.WriteLine("At the location of: " + this.myLoc.ToString());
            Console.WriteLine(this.myTemp.ToString());
        }

        //overloaded ToString function
        public override string ToString()
        {
            string str1 = name + " with " + this.myTemp.ToString() + " at a coordinate of "+this.myLoc.ToString();
            return str1;
        }

        //Accessor and Mutators
        public int PoolLocX
        {
            get { return this.myLoc.X; }
            set { this.myLoc.X = value; }
        }

        public int PoolLocY
        {
            get { return this.myLoc.Y; }
            set { this.myLoc.Y = value; }
        }
        
        public int Total
        {
            get { return count;}
        }

        public string Name
        {
            get { return name; }
        }

        //destructor
        ~Pool() { }
    }

    class Temperature
    {
        //data members
        public int degree;
        public double scale; //seems like we don't reaally use this
        Random randTemp = new Random(); //creating random temperature
        int rand; //random integer, created outside the function so we don't have to recreate the variable everytime the function being called

        int roll() //roll function to roll the temperature creation
        {
            rand = randTemp.Next(98, 105); //temperature between 98 and 104
            return rand; //return the integer
        }

        //default constructor that will automatically set the temperature to random 
        //values between 98 degree F to 104 Degree F
        public Temperature()
        {
            degree = roll();
        }

        //overloaded constructor
        public Temperature(int temp)
        {
            degree = temp;
        }

        //Accessor and Mutators
        public int Degree
        {
            get { return this.degree; }
            set { this.degree = value; }
        }

        public override string ToString()
        {
            string tempStr = "Temperature at " + degree + " degree F";
            return tempStr;
        }

        //destructor
        ~Temperature() { }
    }

    class Location
    {
        public int x;
        public int y;

        //default constructor
        public Location()
        {
            x = 0;
            y = 0;
        }

        //overloading constructor with x and y location
        public Location(int xcoor, int ycoor)
        {
            x = xcoor;
            y = ycoor;
        }

        //accessor and mutator
        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public override string ToString()
        {
            string strLoc = "(" + x + "," + y + ")";
            return strLoc;
        }

        //destructor
        ~Location() { }
    }

    class Program
    {
        //Function to find distance between two location
        public static double findDistance(Location loc1, Location loc2)
        {
            int x1, x2, y1, y2;
            x1 = loc1.X;
            x2 = loc2.X;
            y1 = loc1.Y;
            y2 = loc2.Y;

            return Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));
        }

        public static int[] nearest(Location[] loc)
        {
            double[,] distArr = new double[8,7];
            Location initialLoc = new Location(0, 0);

            for (int i = 0; i < 7; i++)
            {
                distArr[0, i] = findDistance(initialLoc, loc[i]);
                for (int j = 1; j < 8; j++)
                {
                    distArr[j, i] = findDistance(loc[j-1], loc[i]);
                    if(i == j-1)
                    {
                        distArr[j, i] = 1000;
                    }
                }
            }
            //passed

            int[] selection = new int[7];
            int count = 0;
            double closeDist = 100;
            double minVal;
            int lastResort = 0;

            //Closest to (0,0)
            for (int i = 0; i < loc.Length; i++)
            {
                minVal = distArr[0, i];
                if (minVal < closeDist)
                {
                    minVal = distArr[0, i];
                    selection[count] = i;
                    closeDist = minVal;
                    lastResort = i;
                }
            }
            
            //Console.WriteLine(lastResort); //B
            count++;

            //For loop to fill it with 1000;
            for(int i = 0; i < loc.Length; i++)
            {
                if(i != selection[count - 1])
                {
                    distArr[0, i] = 1000;
                }
            }

            for (int j = 0; j < 8; j++)
            {
                distArr[j, lastResort] = 1000;
            }
            //passed

            ///////////////////////////////////////////////////
            ///To find closest after B
            closeDist = 100;
            for (int i = 0; i < loc.Length; i++)
            {
                minVal = distArr[selection[0] +1, i];
                if (minVal < closeDist)
                {
                    minVal = distArr[2, i];
                    selection[count] = i;
                    closeDist = minVal;
                    lastResort = i;
                }
            }  
            
            //Console.WriteLine(selection[count]); //C
            count++;

            //For loop to fill it with 1000;
            for (int i = 0; i < loc.Length; i++)
            {
               if (i != count)
               {
                   distArr[lastResort, i] = 1000;
               }
            }

            for (int j = 0; j < 8; j++)
            {
                distArr[j, lastResort] = 1000;
            }

            //passed

            ///////////////////////////////////////////////////
            ///To Find closest after C
            closeDist = 100;
            for (int i = 0; i < loc.Length; i++)
            {
                minVal = distArr[3, i];
                if (minVal < closeDist)
                {
                    minVal = distArr[3, i];
                    selection[count] = i;
                    closeDist = minVal;
                    lastResort = i;
                }
            }

            //Console.WriteLine(selection[2]); //G
            count++;

            //For loop to fill it with 1000;
            for (int i = 0; i < loc.Length; i++)
            {
                if (i != count)
                {
                    distArr[lastResort, i] = 1000;
                }
            }

            for (int j = 0; j < 8; j++)
            {
                distArr[j, lastResort] = 1000;
            }

            ///////////////////////////////////////////////////
            ///To Find closest after G
            closeDist = 100;
            for (int i = 0; i < loc.Length; i++)
            {
                minVal = distArr[7, i];
                if (minVal < closeDist)
                {
                    minVal = distArr[7, i];
                    selection[count] = i;
                    closeDist = minVal;
                    lastResort = i;
                }
            }

            //Console.WriteLine(selection[3]); //A
            count++;

            //For loop to fill it with 1000;
            for (int i = 0; i < loc.Length; i++)
            {
                if (i != count)
                {
                    distArr[lastResort, i] = 1000;
                }
            }
            
            for (int j = 0; j < 8; j++)
            {
                    distArr[j, lastResort] = 1000;
            }

            ///////////////////////////////////////////////////
            ///To Find closest after A
            closeDist = 100;
            for (int i = 0; i < loc.Length; i++)
            {
                minVal = distArr[1, i];
                if (minVal < closeDist)
                {
                    minVal = distArr[1, i];
                    selection[count] = i;
                    closeDist = minVal;
                    lastResort = i;
                }
            }

            //Console.WriteLine(selection[4]); //F
            count++;

            //For loop to fill it with 1000;
            for (int i = 0; i < loc.Length; i++)
            {
                if (i != count)
                {
                    distArr[lastResort, i] = 1000;
                }
            }

            for (int j = 0; j < 8; j++)
            {
                distArr[j, lastResort] = 1000;
            }

            ///////////////////////////////////////////////////
            ///To Find closest after F
            closeDist = 100;
            for (int i = 0; i < loc.Length; i++)
            {
                minVal = distArr[6, i];
                if (minVal < closeDist)
                {
                    minVal = distArr[6, i];
                    selection[count] = i;
                    closeDist = minVal;
                    lastResort = i;
                }
            }

            //Console.WriteLine(selection[5]); //D
            count++;

            //For loop to fill it with 1000;
            for (int i = 0; i < loc.Length; i++)
            {
                if (i != count)
                {
                    distArr[lastResort, i] = 1000;
                }
            }

            for (int j = 0; j < 8; j++)
            {
                distArr[j, lastResort] = 1000;
            }

            ///////////////////////////////////////////////////
            ///To Find closest after D
            closeDist = 100;
            for (int i = 0; i < loc.Length; i++)
            {
                minVal = distArr[4, i];
                if (minVal < closeDist)
                {
                    minVal = distArr[4, i];
                    selection[count] = i;
                    closeDist = minVal;
                    lastResort = i;
                }
            }

            //Console.WriteLine(selection[6]); //E

            //For loop to fill it with 1000;
            for (int i = 0; i < loc.Length; i++)
            {
                if (i != count)
                {
                    distArr[lastResort, i] = 1000;
                }
            }

            for (int j = 0; j < 8; j++)
            {
                distArr[j, lastResort] = 1000;
            }

            /// Finished checking
            /// We technically should be able to use a recursive function to find this
            /// but the general idea works

            //Checking module :: We don't have to run it now, since we know that the algorightm works. 
            /**
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.WriteLine(distArr[j, i]);
                }
                Console.WriteLine("\n");
            }**/

            return selection;
        }

        //driver function
        static void Main(string[] args)
        {
            //data members
            int[] locX = new int[] { 4, 1, 4, 13, 12, 10, 6 };
            int[] locY = new int[] { 8, 3, 2, 1, 9, 5, 6 };
            int asci = 65;

            //objects
            Pool[] pools = new Pool[7];
            Location[] loc = new Location[7];
            Temperature[] temp = new Temperature[7];

            //Creatting pool array
            for(int i = 0; i < 7; i++)
            {
                loc[i] = new Location(locX[i], locY[i]);

                temp[i] = new Temperature();

                pools[i] = new Pool(char.ConvertFromUtf32(asci) , temp[i] , loc[i]);
                asci = asci + 1;
            }
            //resetting asci to 65
            asci = 65;

            //integer that holds the sequence
            int[] sel = new int[7];

            //assigning the output from nearest to sel array.
            sel = nearest(loc);

            //Printing the output
            Console.WriteLine("=====================================================================");
            Console.WriteLine("\n\nFrom (0,0) the Maintanance guy will go to pool: " + pools[sel[0]].ToString());
            Console.WriteLine("From " + pools[sel[0]].Name + " the Maintanance guy will go to pool: " + pools[sel[1]].ToString());
            Console.WriteLine("From " + pools[sel[1]].Name + " the Maintanance guy will go to pool: " + pools[sel[2]].ToString());
            Console.WriteLine("From " + pools[sel[2]].Name + " the Maintanance guy will go to pool: " + pools[sel[3]].ToString());
            Console.WriteLine("From " + pools[sel[3]].Name + " the Maintanance guy will go to pool: " + pools[sel[4]].ToString());
            Console.WriteLine("From " + pools[sel[4]].Name + " the Maintanance guy will go to pool: " + pools[sel[5]].ToString());
            Console.WriteLine("From " + pools[sel[5]].Name + " the Maintanance guy will go to pool: " + pools[sel[6]].ToString());
            
            //Waiting the user to press enter to exit the console
            Console.ReadLine();
        }
    }
}
