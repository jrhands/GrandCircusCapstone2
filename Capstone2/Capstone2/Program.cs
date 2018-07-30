using System;

namespace Capstone2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Task System 3000!");
            RandomStartMessage();
            MainMenu();
        }

        static void RandomStartMessage()
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

        static void MainMenu()
        {
            bool menuFlag = true;
            string input;
            do
            {
                Console.WriteLine("1. List tasks");
                Console.WriteLine("2. Add task");
                Console.WriteLine("3. Delete task");
                Console.WriteLine("4. Mark task complete");
                Console.WriteLine("5. Quit");
                Console.Write("What would you like to do? ");
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        ListTasks();
                        break;
                    case "2":
                        AddTask();
                        break;
                    case "3":
                        DeleteTask();
                        break;
                    case "4":
                        MarkTaskComplete();
                        break;
                    case "5":
                        Quit();
                        break;
                    default:
                        Console.WriteLine("Invalid input.");
                        break;
                }
            } while (menuFlag);
        }

        static void ListTasks()
        {
            Console.WriteLine("This will list tasks.");
        }

        static void AddTask()
        {
            Console.WriteLine("This will add a task to the list.");
        }

        static void DeleteTask()
        {
            Console.WriteLine("This will delete a task from the list.");
        }

        static void MarkTaskComplete()
        {
            Console.WriteLine("This will mark a task complete.");
        }

        static void Quit()
        {
            Console.WriteLine("This will quit out of the program.");
        }
    }
}
