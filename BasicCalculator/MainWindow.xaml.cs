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
            char newChar = (char)callingButton.Content.ToString()[0];
            if (!CurrentNumber().AddCharachter(newChar) )
            {
                numbers.Clear();
                numbers.Add(new CalcNumber());
                numbers[0].AddCharachter((newChar));
            }
            UpdateScreen();
        }

        private void operator_Click(object sender, RoutedEventArgs e)
        {
            
            
            //if two numbers exist in the list, operate on them with the current opperator
            if(numbers.Count > 1)
            {
                calculate();
                numbers.Add(new CalcNumber());
            }

            if (numbers.Count == 1)
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
            }
        }

        //uses the currently selected  operator, and operatres on the first two numbers
        //updates list so the the first number contains the result
        private void calculate() 
        {
           
            if (numbers.Count > 1)
            {
                //get first and second numbers, and calculate
                double num1 = numbers[0].Number();
                double num2 = numbers[1].Number();
                double result;

                switch (mathOperator)
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
                        MessageBox.Show("no operator selected");
                        result = 0; //bad practice should throw an exception
                        break;
                }

                numbers.Clear();
                numbers.Add(new CalcNumber(result));
                UpdateScreen();
            } 
    }
        private void btnBackspace_Click(object sender, RoutedEventArgs e)
        {
            CurrentNumber().RemoveCharachter();
            UpdateScreen();
           
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            numbers.Clear();
            numbers.Add(new CalcNumber());
            UpdateScreen();
        }

        private void UpdateScreen()
        {
            string output = "";
            if(numbers.Count > 1)
            {
                output = numbers[0].ToString() + " " +  mathOperator + " ";
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
