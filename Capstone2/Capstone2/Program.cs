using System;

namespace Capstone2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Task System 3000!");
            r
        }

        static void randomStartMessage()
        {
            Random random = new Random();
            int startMessageRandomizer = random.Next(0, 3);
            switch (startMessageRandomizer)
            {
                case 0:
                    Console.WriteLine("Enterprise grade task management at your fingertips!");
                    break;
                case 1:
                    Console.WriteLine("The other 2999 didn't turn out too well...");
                    break;
                case 2:
                    Console.WriteLine("Don't worry, aerobics aren't on the list. Probably.");
                    break;
                default:
                    Console.WriteLine("Jacob messed up the range on his start message randomizer. PM him on Slack about it and call him stinky.");
                    break;
            }
        }
    }
}
