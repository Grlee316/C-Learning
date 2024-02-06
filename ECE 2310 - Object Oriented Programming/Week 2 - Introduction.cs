using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Programmed by Jonathan Hanbali
            /*display the following message:
             *          Good - 
             *              Morning !
             *          What is your name, please?
             */

            Console.WriteLine("What is your name, please?");
            string name = Console.ReadLine();
            Console.WriteLine("Welcome, " + name + " !");

            //ask for input of width and length of a rectangle, and display the area of it

            Console.WriteLine("\nPlease enter a width of a rectangle:");
            double width = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please enter a length of a rectangle:");
            double length = Convert.ToDouble(Console.ReadLine());
            double result = width * length;
            result = Math.Round(result,1);
            Console.WriteLine("The Area of your rectangle is {0}", result);


            Console.Read();
        }
    }
}
