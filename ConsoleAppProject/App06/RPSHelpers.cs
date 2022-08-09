using System;

namespace ConsoleAppProject.App05
{
    internal static class RPSHelpers
    {
        private static void Game(string[] args)
        {
            Random random = new Random();
            bool playAgain = true;
            String player;
            String computer;
            String answer;

            while (playAgain)
            {
                player = "";
                computer = "";
                answer = "";

                while (player != "rock" && player != "paper" && player != "scissors")
                {
                    Console.Write("Enter rock, paper, or scissors: ");
                    player = Console.ReadLine();
                    player = player.ToLower();
                }


                switch (random.Next(1, 4))
                {
                    case 1:
                        computer = "rock";
                        break;
                    case 2:
                        computer = "paper";
                        break;
                    case 3:
                        computer = "scissors";
                        break;
                }

                Console.WriteLine("Player: " + player);
                Console.WriteLine("Computer: " + computer);

                switch (player)
                {
                    case "rock":
                        if (computer == "rock")
                        {
                            Console.WriteLine("It's a draw!");
                        }
                        else if (computer == "paper")
                        {
                            Console.WriteLine("You lose!");
                        }
                        else
                        {
                            Console.WriteLine("You win!");
                        }
                        break;
                    case "paper":
                        if (computer == "rock")
                        {
                            Console.WriteLine("You win!");
                        }
                        else if (computer == "paper")
                        {
                            Console.WriteLine("It's a draw!");
                        }
                        else
                        {
                            Console.WriteLine("You lose!");
                        }
                        break;
                    case "scissors":
                        if (computer == "rock")
                        {
                            Console.WriteLine("You lose!");
                        }
                        else if (computer == "paper")
                        {
                            Console.WriteLine("You win!");
                        }
                        else
                        {
                            Console.WriteLine("It's a draw!");
                        }
                        break;
                }

                Console.Write("Would you like to play again (Y/N): ");
                answer = Console.ReadLine();
                answer = answer.ToLower();

                if (answer == "Y")
                {
                    playAgain = true;
                }
                else
                {
                    playAgain = false;
                }

            }

            Console.WriteLine("Thanks for playing!");

            Console.ReadKey();
        }
    }
}