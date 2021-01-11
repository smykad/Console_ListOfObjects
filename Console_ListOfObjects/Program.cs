using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_ListOfObjects
{
    class Program
    {
        static void Main(string[] args)
        {

            var vehicles = addVehicle();
            displayVehicle(vehicles);
            Console.ReadKey();
        }


        private static List<Vehicle> addVehicle()
        {

            string name;
            int year;
            var vehicles = new List<Vehicle>();
            bool fwd;
            bool addVehicle;

            do
            {
                name = getString("Enter the name of your vehicle");
                year = Validate.ReadInteger("Enter the year your vehicle was made: ");
                fwd = yesNo("Does your vehicle have four wheel drive");
                Vehicle myVehicle = new Vehicle { Name = name, Year = year, Fwd = fwd };
                vehicles.Add(myVehicle);
                addVehicle = yesNo("Would you like to add another vehicle");

            } while (!addVehicle);

            return vehicles;
        }

        static void displayVehicle(List<Vehicle> vehicles)
        {
            Console.WriteLine();
            Console.WriteLine(string.Format($"\t{ "Vehicle Name",12} {"Year",12} {"\tFour Wheel Drive",17}"));
            Console.WriteLine();
            foreach (var vehicle in vehicles)
            {
                
                Console.WriteLine(string.Format($"\t{vehicle.Name,12}{$" {vehicle.Year}",12}{vehicle.Fwd,17}"));
            }
        }
        static string getString(string prompt)
        {
            Console.Write($"\t{prompt}: ");
            string ret = Console.ReadLine();
            return ret;
        }
        static bool yesNo(string prompt)
        {
            bool yN = false;
            Console.Write($"\t{prompt}? ");
            string ret = Console.ReadLine();
            if (ret == "yes" || ret == "y")
            {
                yN = false;
            }
            else
            {
                yN = true;
            }
            return yN;

        }

    }
}
