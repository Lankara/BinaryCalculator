using System;
using System.Windows;
using System.Windows.Media;


namespace BinaryCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool calculatorLock = false;
        
        private readonly Calculator calculator = new Calculator();
        public MainWindow()
        {
            InitializeComponent();
            ElipseLight.Fill = new SolidColorBrush(Colors.Red);
        }

        private void BtnOne_Click(object sender, RoutedEventArgs e)
        {
            if (calculatorLock)
            {
                string arrayOFFormula = calculator.AddOne();
                TxtDisplay.Text = arrayOFFormula;
            }
        }

        private void BtnON_Click(object sender, RoutedEventArgs e)
        {
            if (!calculatorLock)
            {
                calculator.OnOff(false);
                TxtDisplay.Clear();
                TxtDisplay.Text = "0";
                LblFormula.Content = null;
                ElipseLight.Fill = new SolidColorBrush(Colors.LightGreen);
                calculatorLock = !calculatorLock;
            }
            else
            {
                calculator.OnOff(true);
                calculatorLock = !calculatorLock;
                TxtDisplay.Clear();
                LblFormula.Content = null;
                calculator.ClearAll();
                ElipseLight.Fill = new SolidColorBrush(Colors.Red);
            }
        }

        private void BtnZero_Click(object sender, RoutedEventArgs e)
        {
            if (calculatorLock)
            {
                string arrayOFFormula = calculator.AddZero();
                TxtDisplay.Text = arrayOFFormula;
            }
        }

        private void BtnPlus_Click(object sender, RoutedEventArgs e)
        {
            if (calculatorLock)
            {
                TxtDisplay.Clear();
                LblFormula.Content = string.Concat(calculator.AddBinary());
            }
        }

        private void BtnCE_Click(object sender, RoutedEventArgs e)
        {
            if (calculatorLock)
            {
                if (calculatorLock)
                {
                    string[] arrayOFFormula = calculator.ClearEntry();
                    ShowTotalValue(arrayOFFormula);
                }
            }
        }

        private void BtnMinus_Click(object sender, RoutedEventArgs e)
        {
            if (calculatorLock)
            {
                TxtDisplay.Clear();
                LblFormula.Content = string.Concat(calculator.DeductBinary());
            }
        }

        private void BtnEquel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (calculatorLock)
                {
                    string[] arrayOFFormula = calculator.CalculateAnswer();
                    ShowTotalValue(arrayOFFormula);
                }
            }
            catch (FormatException)
            {
                _ = MessageBox.Show(this,  "Error has occured:" + "Input String Format error.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ShowTotalValue(string[] arrayString)
        {
            try
            {
                int answer = calculator.CalculateTotal(arrayString);
                LblFormula.Content = string.Concat(arrayString);
                LblFormula.Content += "=" + answer.ToString();
                TxtDisplay.Clear();
                TxtDisplay.Text = Convert.ToString(answer, 2);
            }
            catch (FormatException)
            {
                _ = MessageBox.Show(this, "Error has occured:" + "Input String Format error.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
        private void BtnC_Click(object sender, RoutedEventArgs e)
        {
            if (calculatorLock)
            {
                LblFormula.Content = "";
                TxtDisplay.Clear();
                calculator.ClearAll();
            }
        }
    }
}
