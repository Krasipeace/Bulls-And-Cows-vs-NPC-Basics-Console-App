using System;

namespace BullsAndCows
{
    public class Program
    {
        static void Main(string[] args)
        {
            PrintWelcomeMessage();

            bool isCheater = false;
            int cgOne, cgTwo, cgThree, cgFour, counter, cheater;
            string input;

            GeneratingComputerNumber(out cgOne, out cgTwo, out cgThree, out cgFour, out input, out counter, out cheater);

            while (true)
            {
                Console.Write("Enter number (4 digits): ");
                input = Console.ReadLine();
                counter++;

                if (input == "iGiveUp")
                {
                    counter -= 1;
                    PrintDefeatMessage(counter);

                    return;
                }

                if (input == "ShowMeTheMilk")
                {
                    isCheater = true;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("YOU CHEATER!!!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(cheater);
                    continue;
                }

                int userOne, userTwo, userThree, userFour;

                GetUserNumber(input, out userOne, out userTwo, out userThree, out userFour);

                while (input != "iGiveUp")
                {
                    int bullCounter = 0;
                    int cowsCounter = 0;

                    bullCounter = GetBulls(cgOne, cgTwo, cgThree, cgFour, userOne, userTwo, userThree, userFour, bullCounter);

                    if (bullCounter == 4)
                    {
                        PrintVictoryMessage(counter, isCheater);

                        return;
                    }

                    cowsCounter = GetCows(cgOne, cgTwo, cgThree, cgFour, userOne, userTwo, userThree, userFour, cowsCounter);

                    if (cowsCounter <= 4 || bullCounter < 4)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"Keep trying you have found {bullCounter} bulls and {cowsCounter} cows...");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    }
                }
            }
        }

        static void PrintWelcomeMessage()
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("     ***   B  U  L  L  S    A  N  D    C  O  W  S   ***     ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine();
            Console.WriteLine("Bulls and Cows is a logic game for guessing the number invented by the computer.");
            Console.WriteLine("After each move, the computer gives the number of matches. ");
            Console.WriteLine("If a number of the conjecture is contained in the secret number and is in the right place,");
            Console.WriteLine("it is BULL, if it is in a different place, it is COW.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Write iGiveUp to admit Defeat!");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void GeneratingComputerNumber(out int cgOne, out int cgTwo, out int cgThree, out int cgFour, out string input, out int counter, out int cheater)
        {
            int pcNumber = new Random().Next(1000, 9999);
            cheater = pcNumber;

            //Console.WriteLine(pcNumber);                                      //shows PC number

            cgOne = pcNumber / 1000 % 10;
            cgTwo = pcNumber / 100 % 10;
            cgThree = pcNumber / 10 % 10;
            cgFour = pcNumber / 1 % 10;
            input = string.Empty;
            counter = 0;

            //Console.WriteLine($"{cgOne} + {cgTwo} + {cgThree} + {cgFour}");   //shows each digit
        }

        static void PrintDefeatMessage(int counter)
        {
            switch (counter)
            {
                case <= 1:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"You have been DEFEATED! Computer won after {counter} try...");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"You have been DEFEATED! Computer won after {counter} tries...");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }

        static void GetUserNumber(string input, out int userOne, out int userTwo, out int userThree, out int userFour)
        {
            int userNumber = int.Parse(input);

            userOne = userNumber / 1000 % 10;
            userTwo = userNumber / 100 % 10;
            userThree = userNumber / 10 % 10;
            userFour = userNumber / 1 % 10;
        }

        static void PrintVictoryMessage(int counter, bool isCheater)
        {
            switch (counter)
            {
                case <= 1 when !isCheater:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Lucky Guess! You have found the lost Bulls on the first try!!!");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case > 1 when !isCheater:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"VICTORY! You have found the lost Bulls after {counter} tries!");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                default:
                    if (isCheater && counter > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Cheated Victory! You have found the lost Bulls after {counter} tries!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    break;
            }

            return;
        }

        static int GetBulls(int cgOne, int cgTwo, int cgThree, int cgFour, int userOne, int userTwo, int userThree, int userFour, int bullCounter)
        {
            if (userOne == cgOne)
            {
                bullCounter++;
            }
            if (userTwo == cgTwo)
            {
                bullCounter++;
            }
            if (userThree == cgThree)
            {
                bullCounter++;
            }
            if (userFour == cgFour)
            {
                bullCounter++;
            }

            return bullCounter;
        }

        static int GetCows(int cgOne, int cgTwo, int cgThree, int cgFour, int userOne, int userTwo, int userThree, int userFour, int cowsCounter)
        {
            if (userOne == cgTwo || userOne == cgThree || userOne == cgFour)
            {
                cowsCounter++;
            }
            if (userTwo == cgOne || userTwo == cgThree || userTwo == cgFour)
            {
                cowsCounter++;
            }
            if (userThree == cgOne || userThree == cgTwo || userThree == cgFour)
            {
                cowsCounter++;
            }
            if (userFour == cgOne || userFour == cgTwo || userFour == cgThree)
            {
                cowsCounter++;
            }

            return cowsCounter;
        }
    }
}
