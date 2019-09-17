 using System;
using System.Collections.Generic;
using System.Linq;

namespace ToDoList
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var taskList = new TaskList();

            taskList.NewTaskItem();
            taskList.DisplayList();

        }
    }

    public class TaskItem
    {
        public int Number { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }

        public TaskItem() { }

        public TaskItem(string title, string desc)
        {
            Title = title;
            Description = desc;
            IsCompleted = false;
        }
        public TaskItem(int number, string title, string desc)
        {
            Number = number;
            Title = title;
            Description = desc;
            IsCompleted = true;
        }
    }

    public class TaskList : List<TaskItem>
    {
        public TaskList() { }

        public void Add(string title, string desc)
        {
            int numberOfTasks = this.Count();
            int number = numberOfTasks++;

            this.Add(new TaskItem(number, title, desc));
        }

        public void DisplayList()
        {
            Console.WriteLine();
            Console.WriteLine("Num |  Title  | Description");
            Console.WriteLine("---------------------------");
            foreach (var t in this)
            {
                Console.WriteLine(
                    "{0}    {1}\t{2}",
                    t.Number.ToString(),
                    t.Title,
                    t.Description
                );
            }
        }

        public void NewTaskItem()
        {
            string title = String.Empty;
            string desc = String.Empty;
            bool moreTask = false;
            do
            {
                moreTask = false;
                Console.Write("Enter new task Title: ");
                title = Console.ReadLine().Trim();
                Console.WriteLine("{0}\n", title);

                Console.Write("Enter new task Description: ");
                desc = Console.ReadLine();
                Console.WriteLine("\"{0}\"", desc);

                this.Add(title, desc);
                Console.WriteLine("Want to add more tasks? Press 'y' if yes.");
                string answer = Console.ReadLine();
                if (answer == "y") moreTask = true;
            } while (moreTask);
        }
    }
}