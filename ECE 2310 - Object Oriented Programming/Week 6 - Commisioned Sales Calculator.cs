/** Write a Windows Forms application that calculates and prints the take-home pay for a commissioned sales employee. 
 * Allow the user to enter values for the name of the employee and the sales amount for the week. 
 * Employees receive 7% of the total sales. Federal tax rate is 18%. Retirement contribution is 15%. Social Security tax rate is 9%. 
 * Use appropriate constants. Write Input, Display, and Calculate methods. Your final output should display all calculated values, 
 * including the total deductions and all defined constants. 
 * 
 * Programmed By Jonathan Hanbali
 ***/



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW05_03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool numValidator(string str1)                                                  //boolean function numValidator that will validate userEntered string
        {
            decimal num;                                                                            //integer variable num

            if (!decimal.TryParse(str1, out num))                                                   //tryParse string 1 with output as integer num, if it failed, then return false
            {
                return false;
            }
            else                                                                                //else if its true, return true only and if only number is bigger than 0 and less than 100
            {
                if (decimal.Parse(str1) < 0)
                {
                    return false;                                                               //if its less than 0, then it will return false
                }
                else
                {
                    return true;                                                                //else return true
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal totalSales, fedTax, sosSec, retMoney, net;
            string sales = salesBox.Text;
            bool valid = numValidator(sales);

            if (!valid)
            {
                MessageBox.Show("Please enter a right sales value\nTotal weekly sales must be a positive dollar amount", "Error Message");
                salesBox.Clear();
                salesBox.Focus();
            }
            else
            {
                totalSales = decimal.Parse(sales) * Convert.ToDecimal(0.07);
                fedTax = Convert.ToDecimal(0.18) * totalSales;
                retMoney = totalSales * Convert.ToDecimal(0.15);
                sosSec = totalSales * Convert.ToDecimal(0.09);
                net = totalSales - fedTax - retMoney - sosSec;

                netPay.Text = String.Format("{0,5:C2}", net);
                ss.Text = String.Format("{0,5:C2}", sosSec);
                ret.Text = String.Format("{0,5:C2}", retMoney);
                Ft.Text = String.Format("{0,5:C2}", fedTax);
            }
        }

        private void clr_Click(object sender, EventArgs e)
        {
            netPay.Text = "";
            ss.Clear();
            ret.Clear();
            Ft.Clear();

            nameBox.Clear();
            salesBox.Clear();

            nameBox.Focus();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
