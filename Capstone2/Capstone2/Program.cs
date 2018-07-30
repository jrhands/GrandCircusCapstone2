using Capstone2.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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
                        DeleteTask(taskList);
                        break;
                    case "4":
                        MarkTaskComplete(taskList);
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
                Console.WriteLine("{0,15}{1,15}{2,20}{3,15}{4,15}", "Task Number", "Name", "Description", "Due Date", "Complete");
                Console.WriteLine("{0,15}{1,15}{2,20}{3,15}{4,15}", index + 1, task.teamMembersName, task.briefDescription, task.dueDate.ToShortDateString(), task.completeFlag);
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
            Console.WriteLine("Added!");
        }

        static void DeleteTask(List<Task> taskList)
        {
            if (taskList.Count() == 0)
            {
                Console.WriteLine("List is empty! There's nothing to delete!");
            }
            else
            {
                int taskNumber = -1;
                Console.WriteLine("Enter the number of the task you would like to delete:");
                while (!int.TryParse(Console.ReadLine(), out taskNumber) || taskNumber < 1 || taskNumber >= taskList.Count() + 1)
                {
                    Console.WriteLine($"Invalid input. Must be an integer between 1 and {taskList.Count()}");
                }
                Task taskOnChoppingBlock = taskList[taskNumber - 1];
                Console.WriteLine("Task to be removed:");
                Console.WriteLine("{0,15}{1,15}{2,20}{3,15}{4,15}", taskNumber, taskOnChoppingBlock.teamMembersName, taskOnChoppingBlock.briefDescription, taskOnChoppingBlock.dueDate.ToShortDateString(), taskOnChoppingBlock.completeFlag);
                Console.Write("Delete this task? (y/n): ");
                string input = Console.ReadLine().ToLower();
                while (!Regex.IsMatch(input, "y|yes|n|no"))
                {
                    Console.WriteLine("Invalid input. Please choose yes or no.");
                    input = Console.ReadLine().ToLower();
                }
                if (input == "y" || input == "yes")
                {
                    taskList.Remove(taskOnChoppingBlock);
                    Console.WriteLine("Task removed. Returning to main menu.");
                }
                else
                {
                    Console.WriteLine("Returning to main menu.");
                }
            }
        }

        static void MarkTaskComplete(List<Task> taskList)
        {
            int taskNumber;
            Console.WriteLine("Please enter the number of the task you are marking complete:");
            while (!int.TryParse(Console.ReadLine(), out taskNumber) || taskNumber < 1 || taskNumber >= taskList.Count() + 1)
            {
                Console.WriteLine($"Invalid input. Must be an integer between 1 and {taskList.Count()}");
            }
            Task taskToComplete = taskList[taskNumber - 1];
            if (taskToComplete.completeFlag)
            {
                Console.WriteLine("This task is already complete!");
            }
            else
            {
                Console.WriteLine("Task to be completed:");
                Console.WriteLine("{0,15}{1,15}{2,20}{3,15}{4,15}", taskNumber, taskToComplete.teamMembersName, taskToComplete.briefDescription, taskToComplete.dueDate.ToShortDateString(), taskToComplete.completeFlag);
                Console.Write("Mark this task as complete? (y/n): ");
                string input = Console.ReadLine().ToLower();
                while (!Regex.IsMatch(input, "y|yes|n|no"))
                {
                    Console.WriteLine("Invalid input. Please choose yes or no.");
                    input = Console.ReadLine().ToLower();
                }
                if (input == "y" || input == "yes")
                {
                    taskList[taskNumber - 1].completeFlag = true;
                    Console.WriteLine("Task marked as complete. Returning to main menu.");
                }
                else
                {
                    Console.WriteLine("Returning to main menu.");
                }
            }
        }

        static bool Quit()
        {
            while (true)
            {
                Console.Write("Would you like to quit? (y/n): ");
                string input = Console.ReadLine().ToLower();
                if (input == "y" || input == "yes")
                {
                    return false;
                }
                else if (input == "n" || input == "no")
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }
            }
        }
    }
}
