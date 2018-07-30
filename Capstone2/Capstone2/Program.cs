using Capstone2.Library;
using System;
using System.Collections.Generic;

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
            List<Task> taskList = new List<Task>();
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
                        ListTasks(taskList);
                        break;
                    case "2":
                        AddTask(taskList);
                        break;
                    case "3":
                        DeleteTask();
                        break;
                    case "4":
                        MarkTaskComplete();
                        break;
                    case "5":
                        menuFlag = Quit();
                        break;
                    default:
                        Console.WriteLine("Invalid input.");
                        break;
                }
            } while (menuFlag);
        }

        static void ListTasks(List<Task> taskList)
        {
            int index = 0;
            Console.WriteLine("Here are the tasks:");
            foreach (Task task in taskList)
            {
                Console.WriteLine("{0,10}{1,10}{2,10}{3,10}{4,10}", "Task Number", "Name", "Description", "Due Date", "Complete");
                Console.WriteLine("{0,10}{1,10}{2,10}{3,10}{4,10}", index, task.teamMembersName, task.briefDescription, task.dueDate, task.completeFlag);
                index++;
            }
        }

        static void AddTask(List<Task> taskList)
        {
            Console.WriteLine("Please enter the data about the task you would like to add.");
            Console.WriteLine("Name:");
            string teamMembersName = Console.ReadLine();
            Console.WriteLine("Description:");
            string briefDescription = Console.ReadLine();
            Console.WriteLine("Due date:");
            DateTime dueDate = new DateTime();
            while (!DateTime.TryParse(Console.ReadLine(), out dueDate))
            {
                Console.WriteLine("Invalid input. Please enter a valid date:");
            }
            taskList.Add(new Task(teamMembersName, briefDescription, dueDate));
        }

        static void DeleteTask()
        {
            Console.WriteLine("This will delete a task from the list.");
        }

        static void MarkTaskComplete()
        {
            Console.WriteLine("This will mark a task complete.");
        }

        static bool Quit()
        {
            while (true)
            {
                Console.Write("Would you like to quit? (y/n): ");
                string input = Console.ReadLine().ToLower();
                if (input == "y" || input == "yes")
                {
                    return true;
                }
                else if (input == "n" || input == "no")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }
            }
        }
    }
}
