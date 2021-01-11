using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_ListOfObjects
{
    class Validate
    {
        public static int ReadInteger(string prompt)
        {
            int ret;
            Console.Write($"\t{prompt}");
            ret = IsValidInt();
            return ret;
        }
        public static int ReadInteger(string prompt, int min, int max)
        {
            Console.Write(prompt);
            int thresholdValue = IsValidInt();
            thresholdValue = IsValidThresholdAndRange(thresholdValue, min, max);
            return thresholdValue;
        }
        public static double ReadDouble(string prompt)
        {
            double ret;
            Console.Write($"\t{prompt}");
            ret = IsValidDouble();
            return ret;
        }
        public static double ReadDouble(string prompt, int min, int max)
        {

            Console.Write(prompt);
            double thresholdValue = IsValidDouble();
            thresholdValue = IsValidThresholdAndRange(thresholdValue, min, max);
            return thresholdValue;
        }
        static int IsValidInt()
        {
            bool IsValidInt = false;
            int validInt = 0;
            while (!IsValidInt)
            {
                IsValidInt = int.TryParse(Console.ReadLine(), out validInt);
                if (!IsValidInt)
                {
                    Console.WriteLine();
                    Console.Write("\tPlease enter an integer value: ");
                    IsValidInt = false;
                }
            }
            return validInt;
        }
        static double IsValidDouble()
        {
            bool IsValidDouble = false;
            double validDouble = 0;
            while (!IsValidDouble)
            {
                IsValidDouble = double.TryParse(Console.ReadLine(), out validDouble);
                if (!IsValidDouble)
                {
                    Console.WriteLine();
                    Console.Write("\tPlease enter a numeric value: ");
                    IsValidDouble = false;
                }
            }
            return validDouble;
        }

        static int IsValidThresholdAndRange(int thresholdValue, int min, int max)
        {
            bool isValidThreshold = false;
            while (!isValidThreshold)
            {
                if (thresholdValue > max || thresholdValue < min)
                {
                    Console.WriteLine();
                    Console.Write($"\tPlease enter a threshold value between {min} and {max}: ");
                    thresholdValue = IsValidInt();
                }
                else
                {
                    isValidThreshold = true;
                }
            }
            return thresholdValue;
        }

        static double IsValidThresholdAndRange(double thresholdValue, int min, int max)
        {
            bool isValidThreshold = false;
            while (!isValidThreshold)
            {
                if (thresholdValue > max || thresholdValue < min)
                {
                    Console.WriteLine();
                    Console.Write($"\tPlease enter a threshold value between {min} and {max}: ");
                    thresholdValue = IsValidDouble();
                }
                else
                {
                    isValidThreshold = true;
                }
            }
            return thresholdValue;
        }

    }

}
