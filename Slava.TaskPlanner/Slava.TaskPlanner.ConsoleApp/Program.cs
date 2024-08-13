using Slava.TaskPlanner.Domain.Models;
using Slava.TaskPlanner.Domain.Logic;
namespace Slava.TaskPlanner.ConsoleApp
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            List<WorkItem> workItems = new List<WorkItem>();
            SimpleTaskPlanner taskPlanner = new SimpleTaskPlanner();

            while (true)
            {
                WorkItem workItem = new WorkItem();
                Console.WriteLine("Enter work item title:");
                workItem.Title = Console.ReadLine();

                Console.WriteLine("Enter work item description:");
                workItem.Description = Console.ReadLine();

                Console.WriteLine("Enter work item priority:(none, low, medium, high, urgent)");
                workItem.Priority = Enum.Parse<Priority>(Console.ReadLine(),true);

                Console.WriteLine("Enter work item due time (yyyy/MM/dd or MM/dd/yyyy or dd/MM/yyyy):");
                workItem.DueTime = DateTime.Parse(Console.ReadLine());

                workItems.Add(workItem);
                Console.WriteLine("stop entering work items?(y/n)");
                string answer = Console.ReadLine();

                if (answer.Equals("y"))
                {
                    workItems = taskPlanner.CreatePlan(workItems.ToArray()).ToList();
                    Console.WriteLine("\n");
                    break;   
                }
            }

            foreach (WorkItem item in workItems)
            {
                Console.WriteLine(item.ToString());
            }

            Console.Read();
        }
    }
}
