/**
 * Design an inheritance hierarchy to include classes for Student, GraduateStudent, and  UnderGraduate and show it in the form of UML diagram. 
 * Name your own members for each class. For example, GraduateStudent may include a data member for the type of undergraduate degree awarded, 
 * such as B.A. or B.S., and the location of the institution that awarded the degree. UnderGraduate may include classification (freshman, sophomore).  
 * Implement your design in C#, and write a driver program to test it. 
 * 
**/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW10
{
    //The base class student
    class Student
    {
        //data member of the Student base/parent class
        protected string studentName;
        protected int id;

        //default constructor
        public Student()
        {
            studentName = "No Name";
            id = 0;
        }

        //overloaded constructor
        public Student(int a , string b)
        {
            studentName = b;
            id = a;
        }

        //accessor and mutator
        //ID
        public int ID
        {
            get { return id; }
            set { this.id = value; }
        }

        //Student Name
        public string StudentName
        {
            get { return studentName; }
            set { this.studentName = value; }
        }

        //destructor
        ~Student() { }
    }

    //CHILD CLASSES

    //child class UnderGraduate with the parent class Student
    class UnderGraduate : Student
    {
        string yearClassf; //year classification

        //default constructor
        public UnderGraduate() : base()
        {
            yearClassf = "freshman";
        }

        //overload constructor
        public UnderGraduate(string progress) : base()
        {
            yearClassf = progress;
        }

        //accessor and mutator
        //Year Classification
        public string YearClassf
        {
            get { return this.yearClassf; }
            set { this.yearClassf = value; }
        }
        
        //override the tostring function
        public override string ToString()
        {
            string res = this.studentName + " is the student number " + this.ID + " and has a " + this.yearClassf + " standing\n";
            return res;
        }

        //destructor
        ~UnderGraduate() { }
    }

    //child class GraduateStudent with base class student
    class GraduateStudent : Student
    {
        //data members of the GraduateStudent child class
        string undergraduateAwards;
        string location;
        string institution;

        //default constructor
        public GraduateStudent() : base()
        {
            undergraduateAwards = "No Awards";
            location = "Unknown Location";
            institution = "Unknown School";
        }

        //overloaded constructor
        public GraduateStudent(string awards, string loc, string inst) : base()
        {
            undergraduateAwards = awards;
            location = loc;
            institution = inst;

        }

        //accessor and mutators
        //Institution
        public string Institution
        {
            get { return this.institution; }
            set { this.institution = value; }
        }

        //Location
        public string Location
        {
            get { return this.location; }
            set { this.location = value; }
        }

        //Undergraduate Awards
        public string UndergraduateAwards
        {
            get { return this.undergraduateAwards; }
            set { this.undergraduateAwards = value; }
        }
        
        //ToString override
        public override string ToString()
        {
            string str1 = this.studentName + " is the graduate student number " + this.id + " and had earned " + undergraduateAwards + "\n";
            string str2 = "from " + institution + " in " + location + "\n"; 
            return str1 + str2;
        }

        //Destructor
        ~GraduateStudent() { }
    }

    //Driver Program
    class Program
    {
        static void Main(string[] args)
        {
            //This line will create only the base class
            Student std0 = new Student();                                                                   //Creating new student std0
            std0.ID = 1;                                                                                    //Setting the student ID = 1

            //This line will create undergraduate class with a junior standing
            UnderGraduate std1 = new UnderGraduate("junior");                                               //Creating new undergraduate student std1
            std1.ID = 2;                                                                                    //Setting the student id = 2
            std1.StudentName = "Jonathan";                                                                  //Setting the student name to Jonathan
            Console.WriteLine(std1.ToString());                                                             //Calling overloaded function ToString() to display the info

            //This line will create a graduate student class with a default constructor
            GraduateStudent std2 = new GraduateStudent();                                                   //Creating new graduate student std2 with default constructor
            std2.Institution = "California Polytechnic";                                                    //Setting the institution to California Polytechnic
            std2.Location = "Pomona";                                                                       //Setting the location to pomona
            std2.ID = 3;                                                                                    //Setting the student ID to 3
            std2.StudentName = "Michael Myers";                                                             //Setting the student name to Michael Myers
            Console.Write("-----------------------------------------------------------\n");                 //Print line
            Console.WriteLine(std2.ToString());                                                             //Calling overloaded function ToString() to display the info

            //this line will create a graduate student with overloaded constructor 
            GraduateStudent std3 = new GraduateStudent("B.Eng", "Pomona", "California Polytechnic");        //Creating new graduate student std3 with overloaded constructor
            std3.ID = 4;                                                                                    //Setting the student ID to #4
            std3.StudentName = "Peter Parker";                                                              //Setting the name to Peter Parker
            Console.Write("-----------------------------------------------------------\n");                 //Print line
            Console.WriteLine(std3.ToString());                                                             //Calling overloaded function ToString to display the info

            Console.ReadLine();
        }

    }
}
