/*
 * 1. A grocery list is provided below:
Item   Unit price      Quantity
Milk 	$4.75 		1
Bread 	$2.50 		2
Eggs 	$4.00 		3

Create three different classes named Milk, Bread, and Eggs, where each has the following members :
· private data member “unit_price
· private data member “quantity”.
· Default and overloaded constructors
· Provide properties for the private data members
· public total_price method which returns the total price (e.g., unit_price × quantity)
· A ToString() method that returns the info of the object
Create a class named Grocery, which has the following members
· my_milk of type Milk
· my_bread of type Bread
· my_eggs of type Eggs
· An overloaded constructor which takes all the items above as inputs
· An expense method which calculates the total price of all items. This function must call the individual
total_price methods reside in the classes Milk, Bread, and Eggs
· A ToString() function
Develop a driver main function to demonstrate all of the above
* 
 */

using System;

namespace HW09
{
    //Class milk
    class milk
    {
        //milk class data member
        private double unit_price;
        private int quantity;

        //default constructor
        public milk()
        {
            unit_price = 0;
            quantity = 0;
        }

        //overloading constructor 1, with a double variable
        public milk(double price)
        {
            unit_price = price;
            quantity = 0;
        }

        //overloading constructor 2, with an integer variable
        public milk(int q)
        {
            unit_price = 0;
            quantity = q;
        }

        //overloading constructor 3, with a double variable and an integer
        public milk(double price, int q)
        {
            unit_price = price;
            quantity = q;
        }

        //total_price method that will return the total price
        public double total_price()
        {
            return unit_price * quantity;
        }

        //UnitPrice accessor and mutator
        public double UnitPrice
        {
            get { return this.unit_price; }
            set { this.unit_price = value; }
        }

        //quantity accessor and mutator
        public int Quantity
        {
            get { return this.quantity; }
            set { this.quantity = value; }
        }

        //this is the override for the toString()
        public override string ToString()
        {
            string outstr = "Milk            $" + unit_price + "              " + quantity + "                $" + this.total_price() + "\n";
            return outstr;
        }

        //destructor
        ~milk() { }
    }

    //class bread
    class bread
    {
        //bread class data member
        private double unit_price;
        private int quantity;

        //default constructor
        public bread()
        {
            unit_price = 0;
            quantity = 0;
        }

        //overloading constructor 1, with a double variable
        public bread(double price)
        {
            unit_price = price;
            quantity = 0;
        }

        //overloading constructor 2, with an integer variable
        public bread(int q)
        {
            unit_price = 0;
            quantity = q;
        }

        //overloading constructor 3, with a double variable and an integer
        public bread(double price, int q)
        {
            unit_price = price;
            quantity = q;
        }

        //total_price method that will return the total price
        public double total_price()
        {
            return unit_price * quantity;
        }

        //UnitPrice accessor and mutator
        public double UnitPrice
        {
            get { return this.unit_price; }
            set { this.unit_price = value; }
        }

        //quantity accessor and mutator
        public int Quantity
        {
            get { return this.quantity; }
            set { this.quantity = value; }
        }

        //this is the override for the toString()
        public override string ToString()
        {
            string outstr = "Bread           $" + unit_price + "               " + quantity + "                $" + this.total_price() + "\n";
            return outstr;
        }

        //destructor
        ~bread() { }
    }

    //class eggs
    class eggs
    {
        //eggs class data member
        private double unit_price;
        private int quantity;

        //default constructor
        public eggs()
        {
            unit_price = 0;
            quantity = 0;
        }

        //overloading constructor 1, with a double variable
        public eggs(double price)
        {
            unit_price = price;
            quantity = 0;
        }

        //overloading constructor 2, with an integer variable
        public eggs(int q)
        {
            unit_price = 0;
            quantity = q;
        }

        //overloading constructor 3, with a double variable and an integer
        public eggs(double price, int q)
        {
            unit_price = price;
            quantity = q;
        }

        //total_price method that will return the total price
        public double total_price()
        {
            return unit_price * quantity;
        }

        //UnitPrice accessor and mutator
        public double UnitPrice
        {
            get { return this.unit_price; }
            set { this.unit_price = value; }
        }

        //quantity accessor and mutator
        public int Quantity
        {
            get { return this.quantity; }
            set { this.quantity = value; }
        }

        //this is the override for the toString()
        public override string ToString()
        {
            string outstr = "Eggs            $" + unit_price + "                 " + quantity + "                $" + this.total_price() + "\n";
            return outstr;
        }

        //destructor
        ~eggs() { }
    }

    //class grocery
    class grocery
    {
        //class data member
        private milk my_milk;
        private bread my_bread;
        private eggs my_eggs;


        //since the task does not ask for a default constructor, I only created a single overloaded constructor with three data members
        public grocery(milk my_milk, bread my_bread, eggs my_eggs)
        {
            this.my_milk = my_milk;
            this.my_bread = my_bread;
            this.my_eggs = my_eggs;
        }

        //expense method that will sum all the total price of this class data member
        public double expense()
        {
            return (my_eggs.total_price() + my_bread.total_price() + my_milk.total_price());
        }

        //ToString overloading method that will return all the string information from the data members
        public override string ToString()
        {
            return my_milk.ToString() + my_bread.ToString() + my_eggs.ToString();
        }

        ~grocery() { }
    }

    //tester class
    class tester
    {
        static void Main(string[] args)
        {
            //I used different method to initiate the classes
            //The milk class will be initiated using a default constructor
                //>> The milk class will use .Quantity to set the quantity of the milk purchased to 1
                //>> The milk class will use .UnitPrice to set the price of the unit to $4.75
            //The bread class will be initiated using an overloaded constructor with two variables, a double and an integer to set initial values
            //The eggs class will be initiated using an overloaded constructor with one variable, an integer to set the initial quantity
                //>> The milk class will use .UnitPrice to set the price of the unit to $4.0


            //Class Member my_milk
            milk my_milk = new milk();
            my_milk.Quantity = 1;
            my_milk.UnitPrice = 4.75;
            //Console.WriteLine(my_milk.ToString());

            //Class member my_bread
            bread my_bread = new bread(2.50,2);
            //Console.WriteLine(my_bread.ToString());

            //Class member my_eggs 
            eggs my_eggs = new eggs(3);
            my_eggs.UnitPrice = 4.0;
            //Console.WriteLine(my_eggs.ToString());

            //Initiate grocery class with the name my_grocery
            //since it does not have a default constructor on the question / tasks, then I only created one with an overloaded constructor which takes all the classes above.
            grocery my_grocery = new grocery(my_milk, my_bread, my_eggs);

            //Get the value of the string from my_grocery
            Console.WriteLine("Your Grocery list:");
            Console.WriteLine("============================================");
            string headStr = "Item Name       Unit Price         Quantity        Total Price";
            Console.WriteLine(headStr);
            Console.WriteLine(my_grocery.ToString());

            //Getting the total expense of the grocery.
            Console.WriteLine("Total Expense of Grocery : $" + my_grocery.expense());
        }
    }
}
