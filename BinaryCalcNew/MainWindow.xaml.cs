using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BinaryCalcNew
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isLocked = true;        // Activate only when the ON/CE pressed
        bool isOperatorAdd = false;
        bool isRepeat = false;       //To Repeating last operation
                                     // int answer = 0;
                                     // int lastval = 0;
        const int sizeofarray = 50;  //Formula can have sizeofarray/2 size of binary numbers at once
        int currval = 0;             // Keeping the pressing Value in memory       

        string[] eleme_of_formula = new string[sizeofarray]; // Array to hold the formula
        int last_pos = 0;            // Last Position of the formula in array
        string Last_Operator = " ";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnOne_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (isLocked)
                {
                    //isLocked = false;
                    txtDisplay.Clear();
                }
                else
                {
                    txtDisplay.Text += "1";
                    currval += currval + 1;
                    lblFormula.Content = String.Concat(eleme_of_formula);  // Formula Counter
                    //isOperatorAdd = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error", "Error has occured:" + ex.ToString(), MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
        }

        private void btnON_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (isLocked)
                {
                    isLocked = false;   // Activate the boolean type lock to activate the operations of the calculator
                    currval = 0;        //Current value counter
                    isRepeat = false;   // This is to use for repeating the last operation when "=" pressed.
                    txtDisplay.Clear();
                }
                else
                {
                    isLocked = true;
                    txtDisplay.Clear();
                }          

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error", "Error has occured:" + ex.ToString(), MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void btnZero_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (isLocked)
                {
                    //isLocked = false;
                    txtDisplay.Clear();
                }
                else
                {
                    txtDisplay.Text += "0"; 
                    lblFormula.Content += "0";
                    currval += currval;                 // Updating Current value counter
                    lblFormula.Content = String.Concat(eleme_of_formula); //Copying Array data back to the formula counter
                    //isOperatorAdd = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error", "Error has occured:" + ex.ToString(), MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (isLocked)
                {
                    //isLocked = false;
                    // txtDisplay.Clear();
                }
                else
                {
                    if ((sizeofarray > last_pos) && (currval > 0))   // Can be added only 50 elements to the array
                    {

                        eleme_of_formula[last_pos] = currval.ToString(); // Copying Last value to the array
                        last_pos++;                                      // Incrementing inserting pointer variable of the array
                        eleme_of_formula[last_pos] = "+";                // Copying Last operator to the array
                        last_pos++;
                        Last_Operator = "+";                            // last Operator for repeating purposes.
                        currval = 0;                                     // Reset the current value                                         
                        txtDisplay.Clear();
                        
                        lblFormula.Content = String.Concat(eleme_of_formula); 
                        
                    }
                    else if (currval == 0)
                    {
                        eleme_of_formula[last_pos - 1] = "+";
                        lblFormula.Content = String.Concat(eleme_of_formula);
                    }
                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error", "Error has occured:" + ex.ToString(), MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
        }

        private void btnCE_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (isLocked)
                {
                    //isLocked = false;
                    txtDisplay.Clear();
                }
                else
                {
                    if (last_pos >= 2)              // Can be romed until last value of the array
                    {
                        last_pos--; 
                        eleme_of_formula[last_pos] = "";    // Removing last value from array
                        last_pos--;
                        eleme_of_formula[last_pos] = "";     // Removing last operator from array

                        Last_Operator = eleme_of_formula[last_pos];
                        lblFormula.Content = String.Concat(eleme_of_formula);
                        txtDisplay.Clear();
                        txtDisplay.Text = Convert.ToString(calc_Total(eleme_of_formula), 2);
                    }
                    //isOperatorAdd = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error", "Error has occured:" + ex.ToString(), MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
        }

        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (isLocked)
                {
                    //isLocked = false;
                    // txtDisplay.Clear();
                }
                else
                {
                    if ((sizeofarray > last_pos) && (currval > 0))
                    {
                        eleme_of_formula[last_pos] = currval.ToString();   // Adding values to the array
                        last_pos++;
                        eleme_of_formula[last_pos] = "-";                   // Adding values to the array
                        last_pos++;
                        Last_Operator = "-";                                // Operator sign updating
                        currval = 0;
                        // answer = answer - lastval;
                        txtDisplay.Clear();
                        lblFormula.Content = String.Concat(eleme_of_formula);
                        //isOperatorAdd = true;
                    }
                    else if (currval == 0)
                    {
                        eleme_of_formula[last_pos - 1] = "-";
                        lblFormula.Content = String.Concat(eleme_of_formula);
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error has occured:" + ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
        }

        private void btnEquel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (isLocked)
                {
                    //isLocked = false;
                    // txtDisplay.Clear();
                }
                else if (last_pos > 0)
                {
                    if (isRepeat == false) // Equel presses one time
                    {
                        if (currval > 0)
                        {
                            eleme_of_formula[last_pos] = currval.ToString();
                            last_pos++;
                            //eleme_of_formula[last_pos] = Last_Operator;
                            //last_pos++;
                            //lblFormula.Content = String.Concat(eleme_of_formula);
                            //txtDisplay.Clear();
                            //txtDisplay.Text = Convert.ToString( calc_Total(eleme_of_formula),2); //Convert.ToString( answer+currval, 2); //string binary = Convert. ToString(val, 2);
                            //isOperatorAdd = true;
                            isRepeat = true;
                        }
                    }
                    else   // Equel presses more than one time
                    {

                        eleme_of_formula[last_pos] = eleme_of_formula[last_pos - 2];  // Repeating Last operation
                        last_pos++;
                        eleme_of_formula[last_pos] = eleme_of_formula[last_pos - 2];    // Repeating Last operation
                        last_pos++;
                        //lblFormula.Content = String.Concat(eleme_of_formula);
                        //txtDisplay.Clear();
                        //txtDisplay.Text = Convert.ToString(calc_Total(eleme_of_formula), 2); //Convert.ToString( answer+currval, 2); //string binary = Convert. ToString(val, 2);

                    }
                    lblFormula.Content = String.Concat(eleme_of_formula); 
                    txtDisplay.Clear();
                    txtDisplay.Text = Convert.ToString(calc_Total(eleme_of_formula), 2); //Convert.ToString( answer+currval, 2); //string binary = Convert. ToString(val, 2);
                    lblFormula.Content += " = "+ calc_Total(eleme_of_formula).ToString();


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error has occured:" + ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
        }


        private int calc_Total(string[] arr)  // Function to calculate the answer by reading values in the array
        {
            int Total = 0, Curr_CellValue = 0;
            for (int i = 0; i < last_pos; i++)
            {
                if (i == 0)
                    Total = Convert.ToInt32(arr[0]);
                else if (i % 2 == 0)                            // Operators are storing in even numbers cells of the array
                {
                    Curr_CellValue = Convert.ToInt32(arr[i]);   // reading current cell value
                    if (arr[i - 1].ToString() == "+")
                    {
                        Total = Total + Curr_CellValue;
                    }
                    else if (arr[i - 1].ToString() == "-")
                    {
                        Total = Total - Curr_CellValue;
                    }
                }
            }
            return Total;   // final answer
                    }

        private void btnC_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                isLocked = false;
                currval = 0;
                //lastval = 0;
                Array.Clear(eleme_of_formula, 0, sizeofarray);  // Clearing formula array

                last_pos = 0;
                lblFormula.Content = "";
                txtDisplay.Clear();
                isRepeat = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error", "Error has occured:" + ex.ToString(), MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
