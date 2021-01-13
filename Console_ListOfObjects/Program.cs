using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Console_ListOfObjects
{
    // **************************************************
    //
    // Title: Classes
    // Application Type: Console
    // Description: Get Vehicle Name, year and if it has
    //              four wheel drive.
    // Author: Smyka, Doug
    // Dated Created: 1/11/2021
    // Last Modified: 1/11/2021
    //
    // **************************************************

    class Program
    {
        #region Main

        static void Main(string[] args)
        {
            // set cursor invisible
            Console.CursorVisible = false;

            // set console color
            Console.ForegroundColor = ConsoleColor.Green;

            // Greet the user
            Console.WriteLine("\tWelcome to the Quick Code: List of Objects assignment for CIT 195");
            Console.WriteLine();
            Console.WriteLine();

            // Prompt user to continue
            DisplayContinuePrompt();
            var vehicles = addVehicle();
            displayVehicle(vehicles);
            
            // Clear Console
            Console.Clear();
            SaveVehicles(vehicles);
            Console.WriteLine();
            Console.WriteLine();

            // Thank user
            Console.WriteLine($"\tThank you for checking out this application, have a nice day!");
            Console.WriteLine();
            Console.WriteLine();

            // Pause application for user to close
            //Set Console Color to Dark Yellow
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"\tPress any key to exit.");
            Console.ReadKey();

        }
        #endregion

        #region Vehicle
        /// <summary>
        /// ******************************************************
        ///             ADD VEHICLE METHOD
        /// ******************************************************
        /// </summary>
        /// <returns></returns>
        private static List<Vehicle> addVehicle()
        {
            //
            // Initialize variables
            //
            string name;
            int year;
            var vehicles = new List<Vehicle>();
            bool fwd;
            bool addVehicle;

            //
            // Clear Console
            Console.Clear();

            // set curosr invisible
            Console.CursorVisible = false;

            // set Console Color to Dark Magenta
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"\t\tAdd Vehicle");

            // Return Console Color to Green
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();

            do
            {
                // get name of vehicle
                name = getString("Enter the name of your vehicle");
                
                // get year of vehicle
                year = ReadInteger("Enter the year your vehicle was made: ");

                // get bool if vehicle has four wheel drive or not
                fwd = yesNo("Does your vehicle have four wheel drive");

                // create new vehicle
                Vehicle myVehicle = new Vehicle { Name = name, Year = year, Fwd = fwd };

                // use method for getting model from enum list with validation
                GetModel(myVehicle);               

                // add vehicle to list
                vehicles.Add(myVehicle);

                Console.WriteLine();

                // ask user if they want to add another vehicle
                addVehicle = yesNo("Would you like to add another vehicle");
                
                Console.WriteLine();

            } while (!addVehicle);

            // Pause application for user
            DisplayContinuePrompt();

            // return the list of vehicles
            return vehicles;
            
        }




        /// <summary>
        /// ******************************************************
        ///             DISPLAY VEHICLE METHOD
        /// ******************************************************
        /// </summary>
        /// <param name="vehicles"></param>
        static void displayVehicle(List<Vehicle> vehicles)
        {
            // initialize variables
            int numberOfVehicles = 0;

            // Clear Console
            Console.Clear();

            // Set cursor invisible
            Console.CursorVisible = false;

            Console.WriteLine();
            // display headers for columns
            //
            Console.WriteLine(string.Format($"\t{ "Vehicle Name",12} {"Year",12} {"\tFour Wheel Drive",17} {"\tModel",12}"));
            Console.WriteLine();

            // iterate through the list of vehicles and print in table
            // set Console Color to White
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(string.Format($"\t{vehicle.Name,12}{$" {vehicle.Year}",12}{vehicle.Fwd,17}{vehicle.Make,20}"));
                
                // increment number of vehicles listed
                numberOfVehicles += 1;
            }

            Console.WriteLine();
            Console.WriteLine();

            // Set Console Color to Green
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"\tNumber of Vehicles: ");
            
            // set Console Color to White
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{numberOfVehicles}");

            // Set Console Color to Green
            Console.ForegroundColor = ConsoleColor.Green;
            DisplayContinuePrompt();
        }
        /// <summary>
        /// ******************************************************
        ///             SAVE VEHICLE TO FILE METHOD
        /// ******************************************************
        /// </summary>
        /// <param name="vehicles"></param>

        static void SaveVehicles(List<Vehicle> vehicles)
        {
            // initialize variables
            string dataPath = @"Data/Vehicles.txt";
            string userVehcicle;

            // iterate through list and save it to file
            foreach (var vehicle in vehicles)
            {
                userVehcicle = vehicle.Name + "," + vehicle.Year + "," + vehicle.Fwd + "\n";
                File.AppendAllText(dataPath, userVehcicle);
            }
            
            
        }
        #endregion

        #region User Input
        /// <summary>
        /// ******************************************************
        ///             GET STRING METHOD
        /// ******************************************************
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>
        static string getString(string prompt)
        {
            // prompt user for a string response
            Console.Write($"\t{prompt}: ");

            // Set Console Color to white for user input
            Console.ForegroundColor = ConsoleColor.White;

            // get string from user
            string ret = Console.ReadLine();

            // Return Console Color to Green
            Console.ForegroundColor = ConsoleColor.Green;
            // return response
            return ret;
        }
        /// <summary>
        /// ******************************************************
        ///         YES OR NO BOOLEAN METHOD
        /// ******************************************************
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>
        static bool yesNo(string prompt)
        {
            // initialize variable
            bool yN;
            
            // prompt user for input with yes or no question
            Console.Write($"\t{prompt}? ");

            // Set Console Color to white for user input
            Console.ForegroundColor = ConsoleColor.White;

            // take the input
            string userResponse = Console.ReadLine();

            // if yes or y set boolean to false
            if (userResponse == "yes" || userResponse == "y")
            {
                yN = false;
            }

            // else set the variable to true
            else
            {
                yN = true;
            }
                        
            // Return Console Color to Green
            Console.ForegroundColor = ConsoleColor.Green;
            
            // return the boolean
            return yN;

        }
        #endregion

        #region Validation
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
                    Console.ForegroundColor = ConsoleColor.DarkRed;
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

        /// <summary>
        /// ******************************************************
        ///             VALIDATE USER ENUM
        /// ******************************************************
        /// </summary>
        /// <param name="myVehicle"></param>
        static void GetModel(Vehicle myVehicle)
        {
            // initialize variables
            bool validResponse;

            // set color to green
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\tPlease enter the model of your car: ");
            do
            {
                // set color to white for user input
                Console.ForegroundColor = ConsoleColor.White;

                if(Enum.TryParse(Console.ReadLine().ToUpper(), out Vehicle.Model model))
                {
                    // set vehicles model
                    myVehicle.Make = model;
                    validResponse = true;
                }
                else
                {

                    Console.WriteLine();
                    Console.Write("\t");

                    // Display the enum choices in table
                    foreach (Vehicle.Model make in Enum.GetValues(typeof(Vehicle.Model)))
                    {
                        Console.Write(" | " + make);
                    }

                    // set to red for invalid entry
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine();

                    // Ask user for valid model 
                    Console.Write("\tPlease enter a valid model: ");

                    // set to white for user input
                    Console.ForegroundColor = ConsoleColor.White;
                    validResponse = false;
                }
            } while (!validResponse);

            // set color back to green
            Console.ForegroundColor = ConsoleColor.Green;

        }
        #endregion

        #region Theme
        /// <summary>
        /// ******************************************************
        ///         DISPLAY CONTINUE PROMPT
        /// ******************************************************
        /// </summary>
        public static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            //
            // Continue prompt
            //

            //Set Console Color to Dark Yellow
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"\tPress any key to continue.");

            // Return Console Color to Green
            Console.ForegroundColor = ConsoleColor.Green;
            Console.ReadKey();
        }
        #endregion

    }
}
