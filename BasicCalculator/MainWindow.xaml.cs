using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;

namespace BasicCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<CalcNumber> numbers = new List<CalcNumber>();
        char mathOperator = '+';

        public MainWindow()
        {
            InitializeComponent();
            numbers.Add(new CalcNumber());
        }

        private void input_Click(object sender, RoutedEventArgs e)
        {
            Button callingButton = (Button)sender;
            CurrentNumber().AddCharachter((char)callingButton.Content.ToString()[0]);
            UpdateScreen();
        }

        private void operator_Click(object sender, RoutedEventArgs e)
        {
            //if two numbers exist in the list, operate on them with the current opperator
            if(numbers.Count > 1)
            {
                calculate();
            }
            else
            {
                numbers.Add(new CalcNumber());
            }

            Button callingButton = (Button)sender;
            mathOperator = (char)callingButton.Content.ToString()[0];
            UpdateScreen();

        }

        private void equals_Click(object sender, RoutedEventArgs e)
        {
            if(numbers.Count > 1)
            {
                calculate();
                numbers.Add(new CalcNumber());
            }
        }

        private void calculate()
        {
            if(numbers.Count > 2)
            {
                MessageBox.Show("Looks like there are more numbers in the list than expeccted.");
            }
            //get first and second numbers, and calculate
            double num1 = numbers[0].Number();
            numbers.RemoveAt(0);
            double num2 = numbers[0].Number();
            numbers.RemoveAt(0);
            double result;

            switch(mathOperator)
            { 
                case '+':
                        result = num1 + num2;
                break;

                    case '-':
                        result = num1 - num2;
                break;
                    case '*':
                        result = num1 * num2;
                break;
                    case '/':
                    if (num2 == 0)
                    {
                        result = 0;
                    }
                    else
                    {
                        result = num1 / num2;
                    }
                break;
                default:
                    MessageBox.Show("You seem to have broken something with the " + mathOperator + " symbol");
                    result = 0; //bad practice should throw an exception
                break;
            }

            numbers.Clear();
            numbers.Add(new CalcNumber(result));
            UpdateScreen();

    }
        private void btnBackspace_Click(object sender, RoutedEventArgs e)
        {
            CurrentNumber().RemoveCharachter();
            UpdateScreen();
           
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            numbers.Clear(); // check if this will cause a memory leak. Not sure how .net will handle
            numbers.Add(new CalcNumber());
            UpdateScreen();
        }

        private void UpdateScreen()
        {
            string output = "";
            if(numbers.Count > 1)
            {
                output = mathOperator + " ";
            }
            output += CurrentNumber().ToString();
            lblScreen.Content = output;
        }

        private CalcNumber CurrentNumber()
        {
            return numbers[numbers.Count - 1];
        }

    }
}
