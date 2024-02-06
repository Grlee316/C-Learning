using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz04
{
    class BankAccount
    {
        //creating data members
        private double balance;
        private string ownerFirstName;
        private string ownerLastName;

        //default constructor
        BankAccount()
        {
            //will set the balance to 0, ownerFirstName to FNU, and ownerLastName to LNU
            balance = 0;
            ownerFirstName = "FNU"; //first name unknown
            ownerLastName = "LNU"; //last name unknown
        }

        //overload constructor I. this will set the balance eq to balance, ownerFirstName FNU, and ownerLastName LNU
        public BankAccount(double bal)
        {
            balance = bal;
            ownerFirstName = "FNU";
            ownerLastName = "LNU";
        }

        //overload constructor II. This constructor will set balance = 0, and ownerFirstName with the firstName. ownerLastName will be set to LNU
        public BankAccount(string firstName)
        {
            balance = 0;
            ownerFirstName = firstName;
            ownerLastName = "LNU";
        }


        //overload constructor III. This constructor will set balance = bal, and ownerFirstName with the firstName. ownerLastName will be set to LNU
        public BankAccount(double bal, string firstName)
        {
            balance = bal;
            ownerFirstName = firstName;
            ownerLastName = "LNU";
        }

        //overload constructor IV. This constructor will set balance = 0, and ownerFirstName with the firstName. ownerLastName will be set with lastName
        public BankAccount(string firstName, string lastName)
        {
            ownerFirstName = firstName;
            ownerLastName = lastName;
            balance = 0;
        }

        //overload constructor V. This constructor will set balance = bal, and ownerFirstName with the firstName. ownerLastName will be set with lastName
        public BankAccount(double bal, string firstName, string lastName)
        {
            balance = bal;
            ownerFirstName = firstName;
            ownerLastName = lastName;
        }

        //accessor and mutators
        //get will return the balance
        //set will set the balance
        public double Balance
        {
            get { return this.balance; }
            set { this.balance = value; }
        }

        //get will return the owner first name
        //set will set the owner first name
        public string FirstName
        {
            get { return this.ownerFirstName; }
            set { this.ownerFirstName = value; }
        }

        //get will return the owner last name
        //set will set the owner last name
        public string LastName
        {
            get { return this.ownerLastName; }
            set { this.ownerLastName = value; }
        }

        //withdraw will show the final amount, if the transaction sucessfull (it will deduct), if not, then it will be the same amount
        public double withdraw(double drawAmt)
        {
            if(balance > drawAmt)
            {
                balance = balance - drawAmt;
            }
            else
            {
                Console.WriteLine("Insufficient Fund");
            }
            return balance;
        }

        //deposit will only show the deposited amount;
        public void deposit(double deptAmt)
        {
            balance = balance + deptAmt;
            Console.Write("Your new balance is $" + balance);
        }

        ~BankAccount() { }
    }

    class Program
    {

        static void Main(string[] args)
        {
        }
    }
}
