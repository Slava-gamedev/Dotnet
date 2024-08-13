using Slava.TaskPlanner.Domain.Models;

namespace Slava.TaskPlanner.Domain.Logic
{
    public class SimpleTaskPlanner
    {
        public WorkItem[] CreatePlan(WorkItem[] items)
        {
            List<WorkItem> workItems = items.ToList();

            workItems.Sort(CompareWorkItemsByPriority);

            WorkItem[] sortetItems = workItems.ToArray();
            return sortetItems;
        }

        public static int CompareWorkItemsByPriority(WorkItem firstItem, WorkItem secondItem)
        {
            if(firstItem.Priority > secondItem.Priority)
            {
                return -1;
            }
            else if(firstItem.Priority < secondItem.Priority)
            {
                return 1;
            }
            return 0;
        }
    }
}
