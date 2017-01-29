using System.Collections.Generic;

namespace BasicCalculator
{
    class CalcNumber
    {
        private bool decimalPoint = false;
        private List<char> numbers = new List<char>();

        public CalcNumber()
        {
        }

        public CalcNumber(double num)
        {
            string input = num.ToString();
            foreach (var charachter in input)
            {
                numbers.Add(charachter);
                if(charachter == '.')
                {
                    decimalPoint = true;
                }
            }
        }

        public override string ToString()
        {
            if(numbers.Count == 0)
            {
                return "0";
            }
            else // refactor. could be more efficient
            {
                char[] numberCharachters = new char[numbers.Count];
                int i = 0;
                foreach(var charachter in numbers)
                {
                    numberCharachters[i] = charachter;
                    i++;
                }
                return (new string(numberCharachters));
            }
            
        }

        public void AddCharachter(char next)
        {
            if(next == '.' )
            {
                addDecimal();
            }
            else
            {
                numbers.Add(next);
            }
        }

        public void RemoveCharachter()
        {
            if (numbers.Count > 0)
            {
                numbers.RemoveAt(numbers.Count - 1);
            }
        }
        
        private void addDecimal()
        {
            if(decimalPoint == false)
            {
                numbers.Add('.');
                decimalPoint = true;
            }
        }

        public void Clear()
        {
            numbers.Clear();
            decimalPoint = false;
        }

        public double Number()
        {
            return double.Parse(ToString());
        }
    }
}
