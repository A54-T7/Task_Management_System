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

        //ToDo
        //Assigne
        
    }
}
