using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_ListOfObjects
{
    /// <summary>
    /// ******************************************************
    ///             VALIDATION CLASS
    /// ******************************************************
    /// </summary>
    class Validate
    {
        /// <summary>
        /// ******************************************************
        ///             PROMPT USER FOR AN INTEGER
        /// ******************************************************
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>
        public static int ReadInteger(string prompt)
        {
            int ret;
            Console.Write($"\t{prompt}");
            ret = IsValidInt();
            return ret;
        }
        /// <summary>
        /// ******************************************************
        ///             VALIDATE USER INPUT IS AN INTEGER
        /// ******************************************************
        /// </summary>
        /// <returns></returns>
        static int IsValidInt()
        {
            bool IsValidInt = false;
            int validInt = 0;
            while (!IsValidInt)
            {
                // set Console Color to White
                Console.ForegroundColor = ConsoleColor.White;
                // test user input to see if it's an integer
                IsValidInt = int.TryParse(Console.ReadLine(), out validInt);
                if (!IsValidInt)
                {
                    Console.WriteLine();
                    // prompt for an integer
                    // return console color to green
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("\tPlease enter an integer value: ");
                    // set Console Color to White
                    Console.ForegroundColor = ConsoleColor.White;
                    IsValidInt = false;
                }
            }

            // return console color to green
            Console.ForegroundColor = ConsoleColor.Green;
            // return the integer
            return validInt;
        }
    }
}
