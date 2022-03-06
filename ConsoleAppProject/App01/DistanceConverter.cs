using System;
namespace ConsoleAppProject.App01
{
    /// <summary>
    /// This aplication is designed to convert distances from one to the other.
    /// It allows the user to select a starting unit, to input their distance in that unit and the unit they want it converted to.
    /// It will then display the converted distance.
    /// </summary>
    /// <author>
    /// Hakeem Khares V1.0
    /// </author>
    public class Application

    {
        public const int FEET_IN_MILES = 5280;

        public const double METRES_IN_MILES = 1609.34;

        public const double FEET_IN_METRES = 3.281;

        public const string FEET = "Feet";
        public const string METRES = "Metres";
        public const string MILES = "Miles";

        private double fromDistance;
        private double toDistance;

        private string fromUnit;
        private string toUnit;

        public Application()
        {
            fromUnit = MILES;
            toUnit = FEET;
        }



        // Unit Selection Page
        // Display of finished calculations. 
        public void ConvertDistance()
        {
            OutputHeading();

            fromUnit = ChooseUnit(" Select the distance you wish to convert from: ");
            toUnit = ChooseUnit(" Select the unit you want this distance converted to: ");

            Console.WriteLine($"\n Converting {fromUnit} to {toUnit}");

            fromDistance = GetDistance($"Please enter the number of {fromUnit} > ");

            CalculateDistance();

            OutputDistance();

            Application converter = new Application();

            converter.ConvertDistance();
        }


        // Distance Calculations
        private void CalculateDistance()
        {
            if (fromUnit == MILES && toUnit == FEET)
            {
                toDistance = fromDistance * FEET_IN_MILES;
            }
            else if (fromUnit == FEET && toUnit == MILES)
            {
                toDistance = fromDistance / FEET_IN_MILES;
            }
            else if (fromUnit == MILES && toUnit == METRES)
            {
                toDistance = fromDistance * METRES_IN_MILES;
            }
            else if (fromUnit == METRES && toUnit == MILES)
            {
                toDistance = fromDistance / METRES_IN_MILES;
            }
            else if (fromUnit == METRES && toUnit == FEET)
            {
                toDistance = fromDistance * FEET_IN_METRES;
            }
            else if (fromUnit == FEET && toUnit == METRES)
            {
                toDistance = fromDistance / FEET_IN_METRES;
            }

        }

        /// <summary>
        /// Display of what the user chooses as their selected unit
        /// </summary>

        private string ChooseUnit(string prompt)
        {
            string choice = DisplayChoices(prompt);

            string unit = ShowChoice(choice);
            Console.WriteLine($"\n You have chosen {unit}");
            return unit;
        }

        private static string ShowChoice(string choice)
        {
            if (choice.Equals("1"))
            {
                return FEET;

            }
            else if (choice == "2")
            {
                return METRES;

            }
            else if (choice.Equals("3"))
            {
                return MILES;

            }
            else
            {
                Console.WriteLine("------------------------");
                Console.WriteLine("Chose one of the three options available.");

                Application converter = new Application();

                converter.ConvertDistance();
            }
            return null;
        }



        /// <summary>
        /// Display Menu items and take
        /// and repeat input choice
        /// </summary>
        private static string DisplayChoices(string prompt)
        {
            Console.WriteLine();
            Console.WriteLine($" 1. {FEET}");
            Console.WriteLine($" 2. {METRES}");
            Console.WriteLine($" 3. {MILES}");
            Console.WriteLine();

            Console.Write(prompt);
            string choice = Console.ReadLine();
            return choice;
        }




        /// <summary>
        /// Prompt user to input of miles
        /// Issue an error if input value below 0/negative
        /// </summary>
        private double GetDistance(string prompt)
        {
            Console.Write(prompt);
            string value = Console.ReadLine();
            if (Double.TryParse(value, out double fromDistance))
            {
                fromDistance = Convert.ToDouble(value);
                if (fromDistance < 0)
                {
                    fromDistance = GetDistance("Please enter a valid value: ");
                }
                return fromDistance;
            }
            else
            {
                fromDistance = GetDistance("Please enter a valid value ");
                return fromDistance;
            }

        }


        /// <summary>
        /// To display output of measurements
        /// </summary>
        private void OutputDistance()
        {
            Console.WriteLine($" {fromDistance} {fromUnit} is {toDistance} {toUnit}!");
        }


        /// <summary>
        /// To have a heading display
        /// </summary>
        private void OutputHeading()
        {
            Console.WriteLine("\n-------------------------------");
            Console.WriteLine("     Distance Converter      ");
            Console.WriteLine("        Hakeem Khares        ");
            Console.WriteLine("-------------------------------\n");

        }
    }

}