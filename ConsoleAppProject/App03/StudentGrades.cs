using System;
using ConsoleAppProject.Helpers;

namespace ConsoleAppProject.App03
{
    public class StudentGrades
    {
        public const int students = 10;

        public string[] List { get; set; }
        public int[] Marks { get; set; }
        public Grades[] Grades { get; set; }
        public int[] Stats { get; set; }


        public int Total { get; set; }
        public double Mean { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }


        //Gives the user the options they have. 
        public void Run()
        {
            ConsoleHelper.OutputHeading("App03 = Student Grades");
            string[] choices = { "Change Marks", "See Grades", "See Average", "See Grade Statistics", "Exit" };
            int choice = ConsoleHelper.SelectChoice(choices);
            ChooseOptions(choice);
        }


        /// <summary>
        /// Selection Table
        /// </summary>
        private void ChooseOptions(int choice)
        {
            if (choice == 1)
            {
                ChangeMarks();


                Run();
            }
            else if (choice == 2)
            {
                OutputMarks();
                Run();
            }
            else if (choice == 3)
            {
                CalculateMean();
                CalculateMinMax();

                OutputStats();
                Run();
            }
            else if (choice == 4)
            {

                CalculateStats();
                ShowStats();

                Run();
            }
            else
            {
                Environment.Exit(0);
            }
        }
    //Changes the marks from the previously set value.
        private void ChangeMarks()
        {
            for (int i = 0; i < students; i++)
            {
                Marks[i] = (int)ConsoleHelper.InputNumber($"Please enter mark for {List[i]} ", 0, 100);
                Grades[i] = MarkstoGrade(Marks[i]);
            }
        }
    //Grade boundries
        public Grades MarkstoGrade(int mark)
        {
            if (mark < 40)
            {
                return App03.Grades.F;
            }

            else if (mark < 50)
            {
                return App03.Grades.D;
            }

            else if (mark < 60)
            {
                return App03.Grades.C;
            }

            else if (mark < 70)
            {
                return App03.Grades.B;
            }

            else
            {
                return App03.Grades.A;
            }
        }

        /// <summary>
        /// Pre Assigned Values which marks can be edited.
        /// Used for quick testing.
        /// </summary>
        public StudentGrades()
        {
            List = new string[students] { "Randall", "Ashley", "Gretchen", "Michael", "Theo", "Gus", "Vince", "King Bob", "Francis", "Chad" };
            Marks = new int[students] {55, 30, 22, 44, 87, 60, 26, 48, 91, 57};
            Grades = new Grades[students] {App03.Grades.C, App03.Grades.F, App03.Grades.F,
                            App03.Grades.D, App03.Grades.A,App03.Grades.B, App03.Grades.F,
                            App03.Grades.D, App03.Grades.A, App03.Grades.C};
            Stats = new int[5];
        }

        //Displays all marks and grade
        private void OutputMarks()
        {
            for (int x = 0; x < students; x++)
            {
                Console.WriteLine($"{List[x]} mark = {Marks[x]} grade = {Grades[x]}");
            }
        }

        public void CalculateMean()
        {
            foreach (int mark in Marks)
            {
                Total += mark;
            }

            Mean = Total / students;
        }


        // Finds the highest and lowest mark
        public void CalculateMinMax()
        {
            Min = Marks[0];
            Max = Marks[0];
            foreach (int mark in Marks)
            {
                if (mark < Min)
                {
                    Min = mark;
                }
                else if (mark > Max)
                {
                    Max = mark;
                }
            }
        }

        private void OutputStats()
        {
            Console.WriteLine($"The mean mark is {Mean}");
            Console.WriteLine($"The minimum mark is {Min}");
            Console.WriteLine($"The maximum mark is {Max}");
        }

        // Shows the amount of students that got each grade
        private void ShowStats()
        {
            foreach (Grades val in Enum.GetValues(typeof(Grades)))
            {
                Console.WriteLine($"The percentage of students that got {val} is {Stats[(int)val]} %");
            }
        }


        public void CalculateStats()
        {
            foreach (Grades grade in Grades)
            {
                Stats[(int)grade] += 1;
            }

            for (int x = 0; x < Stats.Length; x++)
            {
                Stats[x] = Stats[x] * 100 / students;
            }
        }

    }
}
