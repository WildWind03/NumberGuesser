using System;

namespace NumberGuesser
{
    class Program
    {
        private const int MaxRandomNumber = 100;
        private const int MaxCoundOfFailedAttempts = 1000;
        private const int OffensiveCommentsFrequency = 4;
        private const int CountOfComments = 4;
        private const string AuthoName = "Alexander Chirikhin";
        private const string QuitString = "q";

        static void Main(string[] args)
        {
            TimeSpan timeSpan = DateTime.Now - DateTime.Now;
            Console.WriteLine("Please, type your name");
            string userName = Console.ReadLine();

            string[] offensiveComments = new string[CountOfComments];

            if (userName != AuthoName)
            {
                Console.WriteLine("What's a crappy name! Just type a number and pray that I'll come up with the same!");

                offensiveComments[0] = "It's Roman Posokhin, isn't it? Even if it isn't, your smell and your creepy face make me suppose that your are his sibling! What are you talking?! You are {0}?! Then I'm sorry! You just a piece of crap, nothing more!";
                offensiveComments[1] = "Come on, {0}! Don't be like Roman Posokhin!";
                offensiveComments[2] = "Your 'intellegence' is your major flaw! {0}, you are from Omsk, aren't you?";
                offensiveComments[3] = "{0}, are really so foolish?! It's incredible that you exist despite the evolution!";

            } else
            {
                Console.WriteLine("Welcome, brother! Glad to see you again! Please, type a number to start the game!");
                offensiveComments[0] = "Hold on, {0}! Together we'll win!";
                offensiveComments[1] = "{0}, just believe and you'll make it!";
                offensiveComments[2] = "Don't worry, {0}! I feel that the victory is so near!";
                offensiveComments[3] = "{0}, you are the smartest man I've ever met! So cool!";
            }

            int[] failedAttempts = new int[MaxCoundOfFailedAttempts];
            int countOfFailedAttempts = 0;
            Random random = new Random();

            int randomNumber = random.Next() % MaxRandomNumber;

            for (int k = 0; ; k++)
            {
                string typedNumberString = Console.ReadLine();

                if (typedNumberString == QuitString)
                {
                    Console.WriteLine("Buzz like never before!");
                    break;
                }

                try
                {
                    int typedNumberInteger = int.Parse(typedNumberString);

                    if (typedNumberInteger == randomNumber)
                    {
                        Console.WriteLine("Congratulations!");
                        Console.WriteLine("Attempts Count: {0}", countOfFailedAttempts + 1);
                        Console.Write("History: ");

                        for (int i = 0; i < countOfFailedAttempts; ++i)
                        {
                            string lessOrGreaterLabel;
                            if (failedAttempts[i] > randomNumber)
                            {
                                lessOrGreaterLabel = ">";
                            }
                            else
                            {
                                lessOrGreaterLabel = "<";
                            }
                            Console.Write(" {0}({1})", failedAttempts[i], lessOrGreaterLabel);
                        }

                        Console.Write(" {0}({1})", randomNumber, "=");

                        Console.WriteLine();
                        Console.WriteLine("Count of passed minutes: {0}", timeSpan.Minutes);
                        break;
                    }
                    if (countOfFailedAttempts >= MaxCoundOfFailedAttempts - 1)
                    {
                        Console.WriteLine("Too many attempts. You are just a looser!");
                        break;
                    }

                    failedAttempts[countOfFailedAttempts++] = typedNumberInteger;

                    if (typedNumberInteger < randomNumber)
                    {
                        Console.WriteLine("Your number is less");
                    }
                    else
                    {
                        Console.WriteLine("Your number is greater");
                    }

                    if (0 == countOfFailedAttempts % (OffensiveCommentsFrequency - 1))
                    {
                        Console.WriteLine(offensiveComments[random.Next() % CountOfComments], userName);
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("What kind of boolshit you have typed!? It's even not a number!");
                    break;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Put such numbers into your tremendous butthole!");
                    break;
                }
            }

            Console.ReadKey();
        }
    }
}
