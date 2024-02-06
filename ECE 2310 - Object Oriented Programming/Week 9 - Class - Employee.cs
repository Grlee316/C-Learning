/************************************************************************************************************************************
 * 2. Write a program that includes an Employee class that can be used to calculate and print the take-home pay for a commissioned sales employee. 
 * Items to include as data members are employee number, first name, last name, and total sales. 
 * All employees receive 9% of the total sales of the month. Federal tax rate is 18%. Retirement 
 * contribution is 10%. Social Security tax rate is 6%. Use appropriate constants, design an 
 * object-oriented solution, and write constructors. Include at least one mutator and one accessor method;
 * provide properties for the other data members.
 **********************************************************************************************************************************/

using System;

namespace Hw08
{
    class Employee
    {
        //data members
        //all data members that hold critical values will be set as a private data member
        private int empNum;
        private string lastName, firstName;
        private double totalSales, grossComm;
        private double yearNet, ssTax, fedTax, retCon;
        public int counter = 0;


        //default constructor
        public Employee()
        {
            empNum = 0;
            firstName = "FNU"; //First Name Unknown
            lastName = "LNU"; //Last Name Unknown
            totalSales = 0;
            counter++;
        }

        //overloading constructors
        //there are several different overload that we can do, but for this homework, I will only do 3 overloads

        /**
        public Employee(int emNum)
        {
            empNum = emNum;
            firstName = "unknown first name";
            lastName = "unknown last name";
            totalSales = 0;
        }

        public Employee(int emNum, int sal)
        {
            empNum = emNum;
            firstName = "unknown first name";
            lastName = "unknown last name";
            totalSales = sal;
        }

        public Employee(int EmNum, string fName)
        {
            empNum = EmNum;
            firstName = fName;
            lastName = "unknown last name";
            totalSales = 0;
        }
        **/

        //The first overload is when the user enter the first and last name into the Employee class
        //it will set the emp number equals to 0, and the msal into 0
        public Employee(string fName, string lName)
        {
            empNum = 0;
            firstName = fName;
            lastName = lName;
            totalSales = 0;
            counter++;
        }

        //the second overoad is when the user enter the employee number, first name and last name
        //the monthly salary will be set to 0
        public Employee(int EmNum, string fName, string lName)
        {
            empNum = EmNum;
            firstName = fName;
            lastName = lName;
            totalSales = 0;
            counter++;
        }

        //the second overload is when the user enter all of the employee data
        //all data will be assigned to its respective holders
        public Employee(int EmNum, string fName, string lName, double sal)
        {
            empNum = EmNum;
            firstName = fName;
            lastName = lName;
            totalSales = sal;
            counter++;
        }

        //This function will calculate the annual pay of the employee
        //It will multiply the monthly salary by 12 (yearly) and then calculate the 9% of it
        //from the 9% year Gross, we will deduct the federal Tax, retirement contributuion, and ss tax
        //after that this function will store it inside the yearNet double variable for easy access
        public void calcAnnPay()
        {
            grossComm = 0.09 * totalSales;
            fedTax = 0.18 * grossComm;
            retCon = 0.1 * grossComm;
            ssTax = 0.06 * grossComm;
            yearNet = grossComm - fedTax - retCon - ssTax;
        }

        //This function will display the information of the employee
        public void dispInfo()
        {
            Console.WriteLine(firstName + " " + lastName + " is the employee number " + Convert.ToString(empNum) + " and has total commision of $" + Convert.ToString(grossComm));
            Console.WriteLine("They pay $ " + Convert.ToString(fedTax) + " in federal tax (18%), $ " + Convert.ToString(retCon) + " in retirement fund (10%), and $ " + Convert.ToString(ssTax) + " for social security fund (%6).");
            Console.WriteLine("Their net pay is: $ {0}", Convert.ToString(yearNet));
            Console.WriteLine("-------------------------------------------------------------------------------------------------------\n");

        }


        //accessor and mutators
        //this function will modify / get the value of the EmpNum
        public int EmpNum
        {
            //if the user asked as a get, then this function will return the employee number
            get { return this.empNum; }

            //else if the user as as a set, then this function will set the employee number
            set { this.empNum = value; }
        }

        //this function will modify / get the value of the monthly sales
        public double TotalSales
        {
            //if the user want to get their monthly sales, then it will retrn the monthly sales
            get { return this.totalSales; }

            //else if the user want to set it, if the value is less than 0, then it will reset back to 0
            //if the value is higher than 0, then it will set as that new value that user entered.
            set
            {
                if (value < 0)
                {
                    totalSales = 0;
                    Console.WriteLine("Monthly Sales value is not valid, it will be set to 0");
                }
                else
                    this.totalSales = value;
            }

        }

        //return user first name
        public string FirstName
        {
            get { return firstName; }
        }

        //return user last name
        public string LastName
        {
            get { return lastName; }
        }


        ~Employee() { }
    }

    /**
    * Create a second class to test your Employee class by instantiating
    * two Employee objects and display all the above information of each individual.
    * **/

    //this class will test the employee class
    class HW08_Test
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the first name of the employee");
            string firstN = Console.ReadLine();
            Console.WriteLine("Please enter the last name of the employee");
            string lastN = Console.ReadLine();
            Console.WriteLine("Please enter the total sales amount for the month");
            string userInt = Console.ReadLine();

            double moSales = Convert.ToDouble(userInt);

            Employee emp1 = new Employee(1, firstN, lastN, moSales);
            emp1.calcAnnPay();
            emp1.dispInfo();
        }
    }
}
