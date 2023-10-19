using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management.Models.Enums;

namespace Task_Management.Models.Contracts
{
    public interface IStory : ITask
    {
        StoryStatusType Status { get; }
        StorySizeType Size { get; }
        PriorityType Priority { get; }
        IMember Assignee { get; }
        void ChangePriority(PriorityType newPriority);
        void ChangeSize(StorySizeType newSize);
        void AddAssignee(IMember newAssignee);
        void RemoveAssignee();
    }
}
