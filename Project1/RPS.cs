using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project1
{
    class RPS
    {
        public bool rockpaperscissors(string Name)
        {
            GameTools.WriteParagraph(@"
We will play best of three games.
");
            bool finalWinner = false;
            int userWins = 0;
            int computerWins = 0;
            string computerChoice = "";

            while (userWins <= 1 && computerWins <= 1)
            {
                Console.WriteLine();
                Console.WriteLine("The current score is - Wizard: {0}  {1}:{2}", computerWins, Name, userWins);
                Console.WriteLine();

                //Get users choice
                GameTools.WriteColoredParagraph("Pick paper, rock, or scissors.", ConsoleColor.Black, ConsoleColor.Cyan);
                string userChoice = GameTools.GetChoice("paper", "rock", "scissors");
                Console.WriteLine();

                //Computer picks random number between 0.0 -1.0
                Random number = new Random();
                double randomNumber = number.NextDouble();

                //Divide that number into equal thirds and convert to computer's choice
                if (randomNumber <= 0.33)
                {
                    computerChoice = "paper";
                }
                else if (randomNumber <= 0.66 && randomNumber >= 0.33)
                {
                    computerChoice = "rock";
                }
                else if (randomNumber >= 0.66)
                {
                    computerChoice = "scissors";
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Error occurred, let's try again!");
                    Console.WriteLine();
                    this.rockpaperscissors(Name);
                }

                //compare choices to determine winner
                if (computerChoice == userChoice)
                {
                    Console.WriteLine();
                    Console.WriteLine("A tie, keep playing");
                    Console.WriteLine();
                }
                else if (computerChoice == "paper" && userChoice == "rock")
                {
                    Console.WriteLine();
                    Console.WriteLine("Paper wins!  HAHA I move one round closer to killing you!");
                    Console.WriteLine();
                    computerWins++;
                }
                else if (computerChoice == "paper" && userChoice == "scissors")
                {
                    Console.WriteLine();
                    Console.WriteLine("Scissors cut paper, You win this round. Lucky you!");
                    Console.WriteLine();
                        userWins++;
                }
                else if(computerChoice == "rock" && userChoice == "paper")
                {
                    Console.WriteLine();
                    Console.WriteLine("Paper covers Rock!! Lucky guess, even a blind squirrel can find a nut!");
                    Console.WriteLine();
                    userWins++;
                }
                else if(computerChoice == "rock" && userChoice == "scissors")
                {
                    Console.WriteLine();
                    Console.WriteLine("Rock crushes scissors!!");
                    Console.WriteLine();
                    computerWins++;
                }
                else if(computerChoice == "scissors" && userChoice == "rock")
                {
                    Console.WriteLine();
                    Console.WriteLine("Your rock crushes my scissors! No skin off my nose!");
                    Console.WriteLine();
                    userWins++;
                }
                else if(computerChoice == "scissors" && userChoice == "paper")
                {
                    Console.WriteLine();
                    Console.WriteLine("My scissors snip your paper up!!");
                    Console.WriteLine();
                        computerWins++;
                }
            }

            if (userWins == 2)
            {
                finalWinner = true;
                Console.WriteLine();
                Console.WriteLine("You win!! You defeated the wizard, well done.");
                Console.WriteLine();
            }
            return finalWinner;
        }
    }
}
