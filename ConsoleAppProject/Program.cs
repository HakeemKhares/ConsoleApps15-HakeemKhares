using ConsoleAppProject.App01;
using ConsoleAppProject.App02;
using System;

namespace ConsoleAppProject
{
    /// <summary>
    /// The main method in this class is called first
    /// when the application is started.  It will be used
    /// to start App01 to App05 for CO453 CW1
    /// 
    /// This Project has been modified by:
    /// Derek Peacock 05/02/2022
    /// Hakeem Khares 
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine();
            Console.WriteLine(" =================================================");
            Console.WriteLine("    BNU CO453 Applications Programming 2021-2022! ");
            Console.WriteLine("                    Hakeem Khares                 ");
            Console.WriteLine(" =================================================");
            Console.WriteLine();

            Menu();
           
        }

        private static void Menu()
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("PLEASE SELECT APP");
            Console.WriteLine("1) APP01-DISTANCE CONVERTER");
            Console.WriteLine("2) APP02-BMI CALCULATOR");
            Console.WriteLine("--------------------------------");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Application converter = new Application();

                converter.ConvertDistance();
            }
            else if (choice == "2")
            {

                App02.BMI bmi = new BMI();


                bmi.Run();
            }
            else
            {
                Console.WriteLine(" 1 or 2");
            }
        }
    }

}

