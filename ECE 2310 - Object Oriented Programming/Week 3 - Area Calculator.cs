/*************************************************************************************************************************************
 * Write a C# console application that computes the area of a circle, rectangle, and cylinder.
 * Display a menu showing the three options. Allow users to input which figure
 * they want to see calculated. Based on the value inputted, prompt for appropriate
 * dimensions and perform the calculations and display the result accordingly (Round the result to 3 decimal places).
 * 
 * Programmed by Jonathan Hanbali
 * I choose a double variables for everything, so the user can enter decimals and calculate the area still
 *************************************************************************************************************************************/

using System;

namespace Hw03_1
{
    class Program
    {
        //this function will calculate the area of circle, and accepts a double variable of r
        private static double CircArea(double r)
        {
            return Math.Round(((r * r) * Math.PI),3); //return the area of circle with rounding up to 3 digits
        }

        //this function will calculate the circumference of a circle, and accept a double variable r
        private static double CircCir(double r)
        {
            return Math.Round((2 * r * Math.PI),3); //returning the circumference of a circle with rounding up to 3 digits
        }

        //this function will caluclate the area of a rectangle, and accepts double variables length and width
        private static double RectArea(double len, double wid)
        {
            return Math.Round((len * wid),3); //returning the area of rectangle with rounding up to 3 digits
        }

        //this function will calculate the area of cylinder
        //since cylinder area is a addition of two base and one rectangular area, we will do it that way
        private static double CylArea(double rad, double h)
        {
            double baseArea, sleeveArea; //creating double variables that will hold the calculated value
            baseArea = CircArea(rad); //base area is equal to circular area of the radius
            sleeveArea = RectArea(CircCir(rad), h); //rectangular area is equal to the circumference of the circle multiplied by the height of the cylinder
            return (2 * baseArea) + sleeveArea; //returning the area of two base + one sleeve
        }
              
        static void Main(string[] args)
        {
            //prompts to the user
            Console.WriteLine("Area Calculator - Programmed by Jonathan Hanbali");
            Console.WriteLine("************************************************");
            Console.WriteLine("Please enter the number to calculate the area of:");
            Console.WriteLine("1) Circle");
            Console.WriteLine("2) Rectangle");
            Console.WriteLine("3) Cylinder");
            Console.WriteLine("************************************************");

            //switch cases
            switch (Console.ReadLine()) //read the user input
            {
                case "1": //if the user entered 1
                    Console.WriteLine("Please enter the radius of the circle"); //asking the user to enter the radius of the circle
                    double rad = Double.Parse(Console.ReadLine()); //creating double rad that will parse the user entered value
                    Console.WriteLine("The area of a circle with a radius of {0} is {1} unit squared", rad, CircArea(rad)); //writing the output and calculation result

                    Console.Read(); //waiting user to press enter to close the app
                    break;
                case "2": //if the user entered 2
                    Console.WriteLine("Please enter the length of the rectangle"); //asking the user to enter the length of the rectangle
                    double len = Double.Parse(Console.ReadLine()); //double variable len that will store parsed value from user entered input
                    Console.WriteLine("Please enter the width of the rectangle"); //asking the user to enter the width of the rectangle
                    double wid = Double.Parse(Console.ReadLine()); //double variable wid that will store parsed value from user entered input
                    Console.WriteLine("The area of a rectangle with a length of {0} and width of {1} is {2} unit squared", len, wid, RectArea(len, wid)); //showing result and calculation

                    Console.Read(); //waiting user to press enter to close the app
                    break;
                case "3": //if the user entered 3
                    Console.WriteLine("Please enter the radius of the base"); //asking the user the radius of the base
                    double r = Double.Parse(Console.ReadLine()); //double variable r to store the parsed value
                    Console.WriteLine("Please enter the height of the cylinder"); //asking the user to enter the height of the cylinder
                    double h = Double.Parse(Console.ReadLine()); //double variable h to store the parsed value
                    Console.WriteLine("The area of the cylinder with a radius of a base of {0} and the height of {1} is {2} unit squared", r, h, CylArea(r, h)); //showing the calculation result

                    Console.Read(); //waiting user to press enter to close the app
                    break;
                default:
                    Environment.Exit(0); //if the user entered every other thing, it will close the app
                    break;
            }
        }
    }
}
