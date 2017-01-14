using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project1
{
    public class Game
    {
        /*
         * Class-level variable (i.e., attribute or field) to keep track of the
         * next scene to visit. This is set at the end of every scene method and
         * used in the Play method to determine which scene method to call next.
         * When the NextScene field is set to "GameOver" then the game ends and
         * control passes back to the Program.Main() method.
         * 
         * NOTE: YOU WILL NEED TO CHANGE THIS TO MATCH YOUR ACTUAL FIRST ROOM
         */
        string nextScene = "Entry Way";

        /*
         * Class-level variables (i.e., attributes or fields) for the game to 
         * store progress towards solving "puzzles." Could also be used to store 
         * a score, etc.
         */
        bool food = false;
		bool workoutRoom = false;
        bool darkRoom = false;
		bool potteryRoom = false;
		bool finalRoom = false;
        bool tvRoom = false;
        bool diningRoom = false;
        bool finalBoss = false;
        DateTime gameStart = DateTime.Now;
        long startTicks;
        string Name;


        /*
         * Main method for the class. You can use this method, but you will
         * need to modify it to check NextScene for YOUR scenes (i.e., rooms,
         * places, etc.). Make sure to set the NextScene field in your
         * Program.Main() method to the first room in your adventure before
         * calling Play().
         */
        public void Play()
        {
            //Get users name for use later
            Console.Write("What is your name? ");
            Name = Console.ReadLine();

            while (nextScene != "GameOver")
            {
                if (nextScene == "Bedroom")
                {
                    Bedroom();
                }
                else if (nextScene == "Entry Way")
                {
                    EntryWay();
                }
                else if (nextScene == "Dining Room")
                {
                    DiningRoom();
                }
                else if (nextScene == "Workout Room")
                {
                    WorkoutRoom();
                }
                else if (nextScene == "TV Room")
                {
                    TVRoom();
				}else if (nextScene == "Study")
				{
					Study();
				}
				else if (nextScene == "Pottery Room")
				{
					PotteryRoom();
				}
                else if (nextScene == "Dark Room")
				{
					DarkRoom();
				}else if (nextScene == "Final Room")
				{
					FinalRoom();
				}
                else if (nextScene == "Outside")
                {
                    Outside();
                }
                else
                {
                    GameTools.WriteColoredParagraph("ERROR: ROOM NOT FOUND!!!", ConsoleColor.White, ConsoleColor.Red);
                    nextScene = "GameOver";
                }
            }
        }

        //*************************************************************************
        // Everything else below here is unique to MY game. Don't even THINK about
        // copying this stuff. You're making your own game with your own puzzles
        // and your own witticisms.
        //*************************************************************************

     
        private void Bedroom()
        {
            Console.WriteLine();
            GameTools.WriteColoredParagraph("Bedroom:", ConsoleColor.White, ConsoleColor.DarkGray);
            Console.WriteLine();
            GameTools.WriteParagraph(@"
Awkward!!! You are in a bedroom, probably tons of cooties. There is a four-post bed against the left wall, which 
seems like an amazing idea because of how tired you are.  SHAKE THAT OFF " + Name + @"! You've got a princess to save. A window on the wall
across from you let's the light shine in. On the wall to the right there is a chest of drawers.  You walk over to it and realize something weird.  
It has today's date but it's in roman numerals, hmm.  Who uses roman numerals today...geez.  Old school wizard.
                ");
            Console.WriteLine();
            GameTools.WriteColoredParagraph("You can go (E)ast to the room you were just in.", ConsoleColor.Black, ConsoleColor.Cyan);

            string choice = GameTools.GetChoice("e");

            if (choice == "e")
            {
                nextScene = "Entry Way";
            }
		}

        private void EntryWay()
        {
            //Starts the game clock
            startTicks = gameStart.Ticks;
            
            //starts the first room
            Console.WriteLine();
            GameTools.WriteColoredParagraph("Entry Way:", ConsoleColor.White, ConsoleColor.DarkGray);
            Console.WriteLine();
            if (finalRoom == true)
            {
                Console.WriteLine();
                Console.WriteLine();
                GameTools.WriteParagraph(@"
On NOOOOOOOOO!!!! Clearly you answered wrong in the final room or the wizard defeated you in rock, paper,
scissors.  Now you have to work your way back there and try again!
                ");
                Console.WriteLine();
            }
            Console.WriteLine();
            GameTools.WriteParagraph(@"For 10 years you have been tracking the wizard.  He has eluded you at every turn
but finally you found where his last hideout is. He stole your princess years ago and you hope
to find her before it is too late.  You resolutely walk into his mansion, your will cannot be detered.  This must end.");

            Console.WriteLine();
            GameTools.WriteParagraph(@"You are in an entry way to the house.  You see this inscribed on the north wall:");
            Console.WriteLine();
            Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "          THIS HOUSE:          "));
            Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "     IT WILL TEST YOUR WITS.   "));
            Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "     IT'LL TEAR TO YOU BITS.   "));
            Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "   YOUR DEMISE IS GUARANTEED,  "));
            Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "SO TAKE HEED BEFORE YOU PROCEED!"));
            Console.WriteLine();
            Console.WriteLine();
            GameTools.WriteParagraph(@"You must hurry, you can tell time is ticking down
on the princess' life.");

            Console.WriteLine();
            GameTools.WriteColoredParagraph("You can go (E)ast or (W)est.", ConsoleColor.Black, ConsoleColor.Cyan);
            Console.WriteLine();

            string choice = GameTools.GetChoice("e", "w");
            Console.WriteLine();

            if (choice == "w")
            {
                nextScene = "Bedroom";
            }
            else if (choice == "e")
            {
                nextScene = "Dining Room";
            }
		}

        private void DiningRoom()
        {
            Console.WriteLine();
            GameTools.WriteColoredParagraph("Dining Room:", ConsoleColor.White, ConsoleColor.DarkGray);
            Console.WriteLine();
            
            Console.WriteLine();

            string choice;
            if (food == false)
            {
                Console.WriteLine();
                GameTools.WriteParagraph(@"The aroma hits you hard in the face.  An entire Thanksgiving dinner is staring at you on a huge oak table.
Interestingly there is exactly one table, one window, two lit candles, three plush rugs, five high-backed chairs, and eight paintings of the wizard 
and his family (who thought wizards had famlily!). The delicious food is calling for you. " + Name + @", COME EAT ME!!!
                    ");
                Console.WriteLine();
                GameTools.WriteColoredParagraph("You can go (N)orth or (W)est, or you can (D)evour the food.", ConsoleColor.Black, ConsoleColor.Cyan);
                Console.WriteLine();
                choice = GameTools.GetChoice("n", "w", "d");
                Console.WriteLine();
            }
            else if (food == true && diningRoom == false)
            {
                Console.WriteLine();
                GameTools.WriteParagraph(@"
You eat all of the food.  Your belly is so huge you are sure you have eaten more than Tim ""Eater X"" Janus ever could. You feel more alert and ready for
any challenge.  Bring it on Mr. Wizard.
                    ");
                diningRoom = true;
                Console.WriteLine();
                GameTools.WriteColoredParagraph("You can go (N)orth or (W)est.", ConsoleColor.Black, ConsoleColor.Cyan);
                Console.WriteLine();
                choice = GameTools.GetChoice("n", "w");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
                GameTools.WriteParagraph(@"
Sadly no food is left on the table because you already ate it all.  Seriously, are you already thinking about food again. Soon you're gonna be nicknamed, Chubbs!
                ");
                Console.WriteLine();
                GameTools.WriteColoredParagraph("You can go (N)orth or (W)est.", ConsoleColor.Black, ConsoleColor.Cyan);
                Console.WriteLine();
                choice = GameTools.GetChoice("n", "w");
                Console.WriteLine();

            }

            if (choice == "n" && workoutRoom == false)
            {
                Console.WriteLine();
                GameTools.WriteParagraph(@"Hmm..You try the door and it is locked.  You hear a voice laugh at you.  It says, ""The door will only unlock with the right answer.
Tell me the first letter of the famous mathmatician whose famouse number sequence this room's decor is designed after.");
                Console.WriteLine();
                GameTools.WriteColoredParagraph("You can go (W)est or type the magic letter.", ConsoleColor.Black, ConsoleColor.Cyan);
                Console.WriteLine();
                Console.Write("Enter your choice: (W) or magic letter: ");
                Console.WriteLine();
                string input = Console.ReadLine();
                input = input.ToLower();
                Console.WriteLine();

                if (input == "f")
                {
                    workoutRoom = true;
                    nextScene = "Workout Room";
                }
                else if (input == "w")
                {
                    nextScene = "Entry Way";
                }
                else
                {
                    Console.WriteLine("Try again!");
                    nextScene = "Dining Room";
                }
			}
            else if (choice == "n" && workoutRoom == true)
            {
                nextScene = "Workout Room";
            }
            else if (choice == "w")
            {
                nextScene = "Entry Way";
            }
            else if (choice == "d")
            {
                food = true;
                nextScene = "Dining Room";
            }
            else if (food == true)
            {
                nextScene = "Workout Room";
            }
		}

        private void WorkoutRoom()
        {
            Console.WriteLine();
            GameTools.WriteColoredParagraph("Workout Room:", ConsoleColor.White, ConsoleColor.DarkGray);
            Console.WriteLine();
            GameTools.WriteParagraph(@"
As you step into the next room, you think to yourself, ""This must be one in shape wizard!"". As you look around see all of the workout equipment
You just never imagined a white-bearded old wizard with a pointy hat running on a treadmill.  I guess heart disease can catch us all by 
surprise!  On the far wall looks like a workout calendar.
                ");
            Console.WriteLine();
            GameTools.WriteColoredParagraph("You can go (S)outh or (W)est or (V)iew the calendar.", ConsoleColor.Black, ConsoleColor.Cyan);
            Console.WriteLine();
            string choice = GameTools.GetChoice("s", "w", "v");

            if (choice == "s")
            {
                nextScene = "Dining Room";
            }
            else if (choice == "w")
            {
                nextScene = "TV Room";
            }
            else if (choice == "v")
            {
                Console.WriteLine();
                 GameTools.WriteParagraph(@"
The calendar shows the entire year.  Clearly he has been training for something as the 7th to the 11th month are highlighted.
");
                 Console.WriteLine();
                 GameTools.WriteColoredParagraph("You can go (S)outh or (W)est.", ConsoleColor.Black, ConsoleColor.Cyan);
                 Console.WriteLine();
                choice = GameTools.GetChoice("s", "w");
                if(choice == "s")
                {
                    nextScene = "Dining Room";
                }
                else if(choice == "w")
                {
                    nextScene = "TV Room";
                }

            }
        }

        private void TVRoom()
        {
            Console.WriteLine();
            GameTools.WriteColoredParagraph("TV Room:", ConsoleColor.White, ConsoleColor.DarkGray);
            Console.WriteLine();
            GameTools.WriteParagraph(@"
This wizard is clearly a baller, a 70 inch 4K TV stands in one corner with surround sound speakers set up.  In the center of the room is a
leather L-shaped couch facing the TV with a cold beer in the cup holders!  Maybe I should rest a bit and see what's on ESPN...WAIT! That is exactly what the wizard wants me to
do.  His cunning almost got me to forgot about my quest and the princess.  ""NEVER"" you shout, ""I WILL NOT REST UNTIL I RESCUE THE PRINCESS
!!""
                ");
            Console.WriteLine();
            GameTools.WriteColoredParagraph("There are doors to the (N)orth, (W)est or (E)ast.", ConsoleColor.Black, ConsoleColor.Cyan);
            Console.WriteLine();
            string choice = GameTools.GetChoice("n", "w", "e");
            Console.WriteLine();

            if (choice == "n")
            {
                if(tvRoom == false)
                {
                    Console.WriteLine();
                    GameTools.WriteParagraph(@"
This door is locked.  You see the handle is a combination lock.  All you need to do is figure out what letter is next in the sequence to unlock it.
The sequence goes like this, ""J-A-S-O-N-?"".  This seems tough, I wonder if the wizard was careless and left clues about this in other rooms.
                ");
                    Console.WriteLine();
                    GameTools.WriteColoredParagraph("You can either go to the door to the (E)ast, (W)est or type in your answer to the riddle to go through the door to the north.", ConsoleColor.Black, ConsoleColor.Cyan);
                    Console.WriteLine();
                    string input = Console.ReadLine();       
                    if(input == "d")
                    {
                        tvRoom = true;
                        nextScene = "Dark Room";
                    }
                    else if(input == "e")
                    {
                        nextScene = "Workout Room";
                    }
                    else if (input == "w")
                    {
                        nextScene = "Study";
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Please Try Again!");
                        Console.WriteLine();
                        nextScene = "TV Room";
                    }
                }
                else if(tvRoom == true)
                {
                nextScene = "Dark Room";
                }
            }
            else if (choice == "w")
            {
                nextScene = "Study";
            }
            else if (choice == "e")
            {
                nextScene = "Workout Room";
            }
        }
    

        private void Study()
        {
            Console.WriteLine();
            GameTools.WriteColoredParagraph("The Study:", ConsoleColor.White, ConsoleColor.DarkGray);
            Console.WriteLine();
            GameTools.WriteParagraph(@"
No surprise here, the wizard has a study.  Clearly he is a brilliant man (aren't all wizards?).  The room is simple with a chandelier providing light.  Across from you is a well worn
desk and chair.  One of the legs of the chair looks like it has been gnawned on by a dog.  You notice there is a parchment on the desk.
                ");
            Console.WriteLine();
            GameTools.WriteColoredParagraph("You can go (E)ast to the room you were just in, or (L)ook at the parchment to read it.", ConsoleColor.Black, ConsoleColor.Cyan);

            string choice = GameTools.GetChoice("e", "l");
            Console.WriteLine();


            if (choice == "e")
            {
                nextScene = "TV Room";
            }
            else if(choice == "l")
            {
                Console.WriteLine();
                GameTools.WriteParagraph(@"
The parchment is written in shaky old man handwriting.  It reads:");
                Console.WriteLine();
                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "               Dear Jack Handy,                 "));
                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "      I've had some deep thoughts lately.       "));
                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "         Like, I love reading Chinese,          "));
                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "       even though I can't understand it!       "));
                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "I can't tell the difference forward or backward,"));
                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "              it's always the same!              "));
                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "             It's just greek to me!             "));

                Console.WriteLine();
                GameTools.WriteParagraph(@"
The wizard seems to have watched too many Sesame Street episodes and is reliving his childhood.
            ");
             
                Console.WriteLine();
                GameTools.WriteColoredParagraph("You can go (E)ast to the room you were just in.", ConsoleColor.Black, ConsoleColor.Cyan);
                choice = GameTools.GetChoice("e");
                Console.WriteLine();
            }
            if (choice == "e")
            {
                nextScene = "TV Room";
            }

		}

        private void PotteryRoom()
        {
            Console.WriteLine();
            GameTools.WriteColoredParagraph("Pottery Room:", ConsoleColor.White, ConsoleColor.DarkGray);
            Console.WriteLine();
            GameTools.WriteParagraph(@"
This wizard is a Renaissance Man. He works out, studies, and sculpts pottery. You notice next to his potter's
wheel is as sheet of paper written in his shaky handwritting.  You can go look at it or head back through
the door ");
            Console.WriteLine();
            GameTools.WriteColoredParagraph("You can go (E)ast to the room you were just in, or (L)ook at the parchment to read it.", ConsoleColor.Black, ConsoleColor.Cyan);
            Console.WriteLine();
            string choice = GameTools.GetChoice("e", "l");

            if (choice == "e")
            {
                nextScene = "Dark Room";
            }
            else if (choice == "l")
            {
                Console.WriteLine();
                GameTools.WriteParagraph(@"
The parchment is written in shaky old man handwriting.  It reads:");
                Console.WriteLine();
                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "                      Dear Jack Handy,                         "));
                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "             I've had some deep thoughts lately.               "));
                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "              Like, The alphabet is the best!                  "));
                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "      It reminds me of a big yellow bird I saw one time.       "));
                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "Everything can be alphabatized, even numbers if you spell them!"));
                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "  Crazy, numbers becoming words...what's the world coming too! "));
                Console.WriteLine();
                GameTools.WriteParagraph(@"
The wizard seems to have watched too many Sesame Street episodes and is reliving his childhood.
            ");
                Console.WriteLine();
                GameTools.WriteColoredParagraph("You can go (E)ast to the room you were just in.", ConsoleColor.Black, ConsoleColor.Cyan);
                choice = GameTools.GetChoice("e");
                Console.WriteLine();
                if (choice == "e")
                {
                    nextScene = "Dark Room";
                }
            }
        }

        private void DarkRoom()
        {
            string choice;
            Console.WriteLine();
            GameTools.WriteColoredParagraph("The Dark Room:", ConsoleColor.White, ConsoleColor.DarkGray);
            Console.WriteLine();
            if (darkRoom == false)
            {
                Console.WriteLine();
                GameTools.WriteParagraph(@"
You can't see anything but you hear a voice.  ""I can tell you are getting close and so I've saved some especially tricky puzzles to stump you.  To get the lights on, you must
tell me what my favorite word is!  I'll give you a hint.  It's a seven letter word starting with ""s"" and four consecutive vowels in it.  Good luck, you're gonna need it, muahahahahah!
            ");
                Console.WriteLine();
                GameTools.WriteColoredParagraph("You can go (S)outh to the room you were just in or type in what the wizard's favorite word is.", ConsoleColor.Black, ConsoleColor.Cyan);
                Console.WriteLine();
                string input = Console.ReadLine();
                input = input.ToLower();
                if (input == "s")
                {
                    nextScene = "TV Room";
                }
                else if (input == "sequoia")
                {
                    darkRoom = true;
                    nextScene = "Dark Room";
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Please Try Again!");
                    Console.WriteLine();
                    nextScene = "Dark Room";
                }

            }
            else if (darkRoom == true)
            {
                Console.WriteLine();
                GameTools.WriteParagraph(@"
You're so glad you can finally see again with the lights on.  The room is completely bare.  Kind of scary feeling that you might be missing something.
");
                Console.WriteLine();
                GameTools.WriteColoredParagraph("You can try to go through the door to the (E)ast or (W)est or (S)outh.", ConsoleColor.Black, ConsoleColor.Cyan);
                Console.WriteLine();
                choice = GameTools.GetChoice("e", "w", "s");
                Console.WriteLine();
                Console.WriteLine();
                if (choice == "w" && potteryRoom == false)
                {
                    Console.WriteLine();
                    GameTools.WriteParagraph(@"
    Riddle me this " + Name + @".");
                    Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "      A Man.        "));
                    Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "      A Plan.       "));
                    Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "      A Canal.      "));
                    Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "   ______________,  "));
                    
                    Console.WriteLine();
                    GameTools.WriteColoredParagraph("You can go back (S)outh, (R)estart the room or type your answer to the riddle.", ConsoleColor.Black, ConsoleColor.Cyan);
                    Console.WriteLine();
                    string input = Console.ReadLine();
                    if (input == "s")
                    {
                        nextScene = "TV Room";
                    }
                    else if (input == "panama")
                    {
                        potteryRoom = true;
                        nextScene = "Pottery Room";
                    }
                    else if (input == "r")
                    {
                        nextScene = "Dark Room";
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Please Try Again!");
                        Console.WriteLine();
                        nextScene = "Dark Room";
                    }
                }
                else if (choice == "w" && potteryRoom == true)
                {
                    nextScene = "Pottery Room";
                }
                else if (choice == "e" && finalRoom == false)
                {
                    Console.WriteLine();
                    GameTools.WriteParagraph(@"
Riddle me this " + Name + @".");
                    Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "I'm your follower in the light,"));
                    Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "yet I'm invisible in the night."));
                    Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "  At various sizes I appear,   "));
                    Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "I won't harm you, have no fear."));
                    Console.WriteLine();
                    Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "       What am I?              "));

                    Console.WriteLine();
                    GameTools.WriteColoredParagraph("You can go back (S)outh, (R)estart the room or type your answer to the riddle.", ConsoleColor.Black, ConsoleColor.Cyan);
                    Console.WriteLine();
                    string input = Console.ReadLine();
                    Console.WriteLine();

                    if (input == "s")
                    {
                        nextScene = "TV Room";
                    }
                    else if (input == "r")
                    {
                        nextScene = "Dark Room";
                    }
                    else if (input == "shadow")
                    {
                        finalRoom = true;
                        nextScene = "Final Room";
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Please Try Again!");
                        Console.WriteLine();
                        nextScene = "Dark Room";
                    }
                }
                else if (choice == "e" && finalRoom == true)
                {
                    nextScene = "Final Room";
                }
                else if (choice == "s")
                {
                    nextScene = "TV Room";
                }
            }
        }
        private void FinalRoom()
        {
            Console.WriteLine();
            GameTools.WriteColoredParagraph("THE FINAL TEST:", ConsoleColor.White, ConsoleColor.DarkGray);
            Console.WriteLine();
            GameTools.WriteParagraph(@"
Your heart quickens at the thought of defeating the wizard at his own game! You breath heavily to get your bearings.  You realize that 
the door behind you just locked, click, no going back. \n

You hear the wizard's voice.  ""I have saved one more riddle for you that is sure to crush your spirit! 
Place these numbers in the correct order: 902,172,10,8040,47.  What order is ""correct""...well that is for you to
figure out!
");
            Console.WriteLine();
            GameTools.WriteColoredParagraph("Enter your first number.", ConsoleColor.Black, ConsoleColor.Cyan);
            Console.WriteLine();
            int choice1 = GameTools.GetChoiceNumber(902, 172, 10, 8040, 47);
            Console.WriteLine();
            GameTools.WriteColoredParagraph("Enter your second number.", ConsoleColor.Black, ConsoleColor.Cyan);
            Console.WriteLine();
            int choice2 = GameTools.GetChoiceNumber(902, 172, 10, 8040, 47);
            Console.WriteLine();
            GameTools.WriteColoredParagraph("Enter your third number.", ConsoleColor.Black, ConsoleColor.Cyan);
            Console.WriteLine();
            int choice3 = GameTools.GetChoiceNumber(902, 172, 10, 8040, 47);
            Console.WriteLine();
            GameTools.WriteColoredParagraph("Enter your fourth number.", ConsoleColor.Black, ConsoleColor.Cyan);
            Console.WriteLine();
            int choice4 = GameTools.GetChoiceNumber(902, 172, 10, 8040, 47);
            Console.WriteLine();
            GameTools.WriteColoredParagraph("Enter your fifth number.", ConsoleColor.Black, ConsoleColor.Cyan);
            Console.WriteLine();
            int choice5 = GameTools.GetChoiceNumber(902, 172, 10, 8040, 47);
            Console.WriteLine();

            if (choice1 == 8040 && choice2 == 47 && choice3 == 902 && choice4 == 172 && choice5 == 10)
            {
                Console.WriteLine();
                GameTools.WriteParagraph(@"
Congratulations!! You are clearly cunning but how good are you at
thinking on your feet.  I challenge you to a duel to the death in the most
daring of games...PAPER,ROCK, SCISSORS.  You shall certainly be crushed!!
");
                Console.WriteLine();
                RPS FinalGame = new RPS();
                finalBoss = FinalGame.rockpaperscissors(Name);

                if(finalBoss)
                {
                    nextScene = "Outside";
                }
                else 
                {
                    nextScene = "Entry Way";
                }
            }
            else
            {
                Console.WriteLine();
                GameTools.WriteParagraph(@"
Congratulations!! The door to the north opened up.  Press (W)alk to go through the door.
");
                Console.WriteLine();
                string choice = GameTools.GetChoice("w");
                if (choice == "w")
                {
                    nextScene = "Entry Way";
                }
            }

        }

        private void Outside()
        {
            Console.WriteLine();
            GameTools.WriteColoredParagraph("OUTSIDE:", ConsoleColor.White, ConsoleColor.DarkGray);
            Console.WriteLine();
            DateTime gameEnd = DateTime.Now;
            long endTicks = gameEnd.Ticks;
            long Difference = (endTicks-startTicks);
            
            Console.WriteLine();
            //FIX THIS - This is a terrible work around.  How do you get C# to recognize scientific notation
            //basically, I have just hard coded the number I want to represent 15 min as a number of ticks
            if(Difference <= (9000000000))
            {
                Console.WriteLine();
                GameTools.WriteParagraph(@"You have just defeated the wizard and as you step through the door to go outside, your Princess runs through the door
and throws her arms around you! You are ecstatic to see her and worn out from your journey. You two run off together
and live happily ever after.
");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
                GameTools.WriteParagraph(@"
Well there's good and bad news.  The good news is that you made it through alive and beat the wizard! The bad news is that it took you too
long and your Princess died waiting for you.  Maybe if you had gotten to her sooner she would still be alive...");
                Console.WriteLine();
            }

            nextScene = "GameOver";
        }
    }
}
