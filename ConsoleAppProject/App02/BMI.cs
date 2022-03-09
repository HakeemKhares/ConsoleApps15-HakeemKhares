using System;
namespace ConsoleAppProject.App02
{
    /// <summary>
    /// The user choses what units of measurement they wish to use and then input information on their height and weight.
    /// The program then uses this information to calculate their BMI. 
    /// </summary>
    /// <author>
    /// Hakeem Khares V1.0
    /// </author>
    public class BMI
    {
        public int Bmi { get; set; }

        public string Choice { get; set; }

        public double WeightStones { get; set; }
        public double WeightPounds { get; set; }

        public double HeightFeet { get; set; }
        public double HeightInches { get; set; }

        public double Weight { get; set; }
        public double Height { get; set; }

        public void Run()
        {
            do
            {
                Choice = SelectUnits();
            }
            while (Choice == null);

            if (Choice == "imperial")
            {
                InputImperial();
            }
            else
            {
                InputMetric();
            }

            if (Choice == "imperial")
            {
                CalcBMIImperial();
            }
            else
            {
                CalcBMIMetric();
             }
            OutputBMI();
            OutputWHO();
            OutputBAME();
        }

        public void OutputHeading()
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("        Body Mass Index     ");
            Console.WriteLine("          Calculator        ");
            Console.WriteLine("  created by Hakeem Khares  ");
            Console.WriteLine("----------------------------");
        }

        public string SelectUnits()
        {
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Please Select one of the Following Measurements");
            Console.WriteLine("No.| NAME  |    WEIGHT     |  HEIGHT      ");
            Console.WriteLine("1) IMPERIAL - STONES+POUNDS FEET/INCH");
            Console.WriteLine("2) METRIC   - KILOGRAM      METRES");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Please enter 1 or 2");
            Choice = Console.ReadLine();
            if (Choice == "1")
            {
                return "imperial";
            }
            else if (Choice == "2")
            {
                return "metric";
            }
            else
            {
                Console.WriteLine("Please enter 1 for imperial or 2 for metric units.");
                Console.WriteLine("--------------------------------------------------");
                return null;
            }

        }


        public double InputMeasurement(string prompt, double measurement)
        {
            Console.WriteLine(prompt);
            string value = Console.ReadLine();

            if (Double.TryParse(value, out measurement))
            {
                measurement = Convert.ToDouble(value);
                if (measurement < 0)
                {
                    measurement = InputMeasurement("Please enter a positive value", measurement);

                }
                return measurement;
            }
            else
            {
                measurement = InputMeasurement("Please enter a positive value", measurement);

                return measurement;
            }
        }


        /// <summary>
        /// Gathers the data of the user in Imperial units
        /// </summary>
        private void InputImperial()
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine(" WEIGHT STONES/POUNDS + HEIGHT FEET/INCH ");
            Console.WriteLine("-----------------------------------------");

            WeightStones = InputMeasurement("ENTER WEIGHT IN STONES: ", WeightStones);
            WeightPounds = InputMeasurement("ENTER WEIGHT IN POUNDS: ", WeightPounds);
            Console.WriteLine("-----------------");

            HeightFeet = InputMeasurement("ENTER HEIGHT IN FEET: ", HeightFeet);
            HeightInches = InputMeasurement("ENTER HEIGHT IN INCH: ", HeightInches);

        }

        /// <summary>
        /// Gathers the data of the user in Metric units
        /// </summary>
        private void InputMetric()
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine(" WEIGHT KILOGRAMS    +   HEIGHT METRES   ");
            Console.WriteLine("-----------------------------------------");

            Weight = InputMeasurement("ENTER WEIGHT IN KILOS: ", Weight);
            Height = InputMeasurement("ENTER HEIGHT IN METRES: ", Height);
            Console.WriteLine("------------------");
        }


        /// <summary>
        /// To calculate users BMI
        /// </summary>
        public void CalcBMIImperial()
        {
            if (Weight == 0)
            {
                Weight = (WeightStones * 14 + WeightPounds) * 703;
                Height = HeightFeet * 12 + HeightInches;
            }
            Bmi = (int)(Weight / (Height * Height));
        }
        public void CalcBMIMetric()
        {
            if (Weight == 0)
            {
                Weight = Weight;
                Height = Height;
            }
            Bmi = (int)(Weight / (Height * Height));
        }
        /// <summary>
        /// Tells the user what BMI class they fall into.
        /// </summary>
        private void OutputBMI()
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine($"Your BMI totals to {Bmi}");
            Console.WriteLine("-------------------------");

            if (Bmi < 18.5)
            {
                Console.WriteLine("Your BMI suggests you are underweight!");
            }
            else if (Bmi < 24.9)
            {
                Console.WriteLine("Your BMI suggests you are healthy");
            }
            else if (Bmi < 29.9)
            {
                Console.WriteLine("Your BMI suggests you are overweight");
            }
            else if (Bmi < 34.9)
            {
                Console.WriteLine("Your BMI suggests you are obese class 1");
            }
            else if (Bmi < 39.9)
            {
                Console.WriteLine("Your BMI suggests you are obese class 2");
            }
            else
            {
                Console.WriteLine("Your BMI suggests you are obese class 3");
            }

        }

        private void OutputBAME()
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("                 Be aware                ");
            Console.WriteLine("The result of this calculation is only accurate if you do not fall into the BAME catagory");
            Console.WriteLine("-Black");
            Console.WriteLine("-Asian");
            Console.WriteLine("-Other Minority Groups");
            Console.WriteLine("  It is believed you are at a higher risk  ");
            Console.WriteLine(" of obesity and other relating positions ");
            Console.WriteLine("-----------------------------------------");
        }

        private void OutputWHO()
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Results are based on the BMI charts released");
            Console.WriteLine("by the World Health Organuisation");             
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("WHO Weight Status      BMI kg/m^2");
            Console.WriteLine("Underweight           18.5 - 24.9");
            Console.WriteLine("Normal	              18.5 - 24.9");
            Console.WriteLine("Overweight	      25.0 - 29.9");
            Console.WriteLine("Obese Class I         30.0 - 34.9");
            Console.WriteLine("Obese Class II	      35.0 - 39.9");
            Console.WriteLine("Obese Class III           >= 40.0");
            Console.WriteLine("");
        }
    }

}