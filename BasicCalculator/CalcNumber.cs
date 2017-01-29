using System.Collections.Generic;

namespace BasicCalculator
{
    class CalcNumber
    {
        private bool containsDecimalPoint = false;
        private bool buildingNumber = true;
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
                    containsDecimalPoint = true;
                }
            }
            buildingNumber = false;
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

        public bool AddCharachter(char next)
        {
            if (buildingNumber)
            {
                if (next == '.')
                {
                    addDecimal();
                    return true;
                }
                else
                {
                    numbers.Add(next);
                    return true;
                }
            }
            return false;
        }

        public void RemoveCharachter()
        {
            if (!buildingNumber)
            {
                Clear();
            }

            if (numbers.Count > 0 && buildingNumber)
            {
                numbers.RemoveAt(numbers.Count - 1);
            }

            
        }
        
        private void addDecimal()
        {
            if(containsDecimalPoint == false)
            {
                numbers.Add('.');
                containsDecimalPoint = true;
            }
        }

        public void Clear()
        {
            numbers.Clear();
            containsDecimalPoint = false;
            buildingNumber = true;
        }

        public double Number()
        {
            return double.Parse(ToString());
        }
    }
}
