﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        static void Main(string[] args)
        {

            var vehicles = addVehicle();
            displayVehicle(vehicles);
            Console.ReadKey();
        }

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

            do
            {
                // get name of vehicle
                name = getString("Enter the name of your vehicle");
                
                // get year of vehicle
                year = Validate.ReadInteger("Enter the year your vehicle was made: ");

                // get bool if vehicle has four wheel drive or not
                fwd = yesNo("Does your vehicle have four wheel drive");

                // create new vehicle
                Vehicle myVehicle = new Vehicle { Name = name, Year = year, Fwd = fwd };

                // add vehicle to list
                vehicles.Add(myVehicle);

                // ask user if they want to add another vehicle
                addVehicle = yesNo("Would you like to add another vehicle");

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
            // Clear Console
            Console.Clear();

            // Set cursor invisible
            Console.CursorVisible = false;

            Console.WriteLine();
            // display headers for columns
            //
            Console.WriteLine(string.Format($"\t{ "Vehicle Name",12} {"Year",12} {"\tFour Wheel Drive",17}"));
            Console.WriteLine();
            
            // iterate through the list of vehicles and print in table
            //
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(string.Format($"\t{vehicle.Name,12}{$" {vehicle.Year}",12}{vehicle.Fwd,17}"));
            }
        }
        /// <summary>
        /// ******************************************************
        ///             GET STRING METHOD
        /// ******************************************************
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>
        static string getString(string prompt)
        {
            Console.Write($"\t{prompt}: ");
            string ret = Console.ReadLine();
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

            // return the boolean
            return yN;

        }

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
            Console.WriteLine($"\tPress any key to continue.");
            Console.ReadKey();
        }

    }
}
