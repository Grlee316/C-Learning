/*********************************************************************************
 3. Write a C# program (Your choice of Windows Forms application , or,  
Console Application) that computes a weighted total grade ( with precision to 1 decimal digit) 
giving the following weights. 
			Homework: 10% 
			Projects: 25% 
			Quizzes: 20% 
			Exams: 20% 
			Final Exam: 25% 
Test your program with the following values: 
Homework: 97; 
Projects: 82; 
Quizzes: 60; 
Exams: 75; 
Final Exam 80. 
Display all values, including the weights, appropriately labeled and formatted:
 
Programmed by Jonathan Hanbali
 **********************************************************************************/


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework1_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //creating double variables that will hold the values.
            //I use double just in case the grade have decimal value.
            double hwv, projv, quizv, examv, finalv, resultv;

            //An if statement to check if all of the textboxes have values
            //if all of the textboxes have values, then it will calculate the average
            //if one or more of the textboxes is empty, then it will show warning to the user
            //if the user enter 0, this program will still calculate the grade according to the weight

            if (!string.IsNullOrEmpty(hw.Text) &&
                !string.IsNullOrEmpty(proj.Text) &&
                !string.IsNullOrEmpty(quiz.Text) &&
                !string.IsNullOrEmpty(exam.Text) &&
                !string.IsNullOrEmpty(final.Text))
            {
                //getting all the values from the textboxes and convert it to double
                //then store it at the appropriate variables
                hwv = Convert.ToDouble(hw.Text);
                projv = Convert.ToDouble(proj.Text);
                quizv = Convert.ToDouble(quiz.Text);
                examv = Convert.ToDouble(exam.Text);
                finalv = Convert.ToDouble(final.Text);

                //calculating the results
                resultv = (hwv * 0.1) + (projv * 0.25) + (quizv * 0.2) + (examv * 0.2) + (finalv * 0.25);
                
                //outputting the result into the textbox
                grade.Text = Convert.ToString(Math.Round(resultv, 1));
            }
            else
            {
                //error message that will be shown to the user if one or more boxes is empty
                //it will ask the user to enter a values or 0 in order for the program to calculate
                string message = "Please enter all the values or 0";
                string title = "Error";
                MessageBox.Show(message, title);
            }

        }

        //The clear button will clear the textboxes
        private void button2_Click(object sender, EventArgs e)
        {
            hw.Text = "";
            proj.Text = "";
            quiz.Text = "";
            exam.Text = "";
            final.Text = "";
            grade.Text = "";
        }
    }
}

//double.parse to convert to double
//int32.parse to conver to integer
//you can also use mile.ToString() -> converting 'object' to string