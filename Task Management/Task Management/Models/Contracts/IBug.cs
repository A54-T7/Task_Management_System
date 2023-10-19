using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management.Models.Enums;

namespace Task_Management.Models.Contracts
{
    public interface IBug : ITask
    {
        IList<string> StepsToReproduce { get; }

        PriorityType Priority { get; }

        SeverityType Severity { get; }

        BugStatusType Status { get; }
        void ChangeSeverity(SeverityType newSeverity);
        void ChangePriority(PriorityType newPriority);
        void AddReproduceStep(string newStep);
        string Assignee {  get; }
        
    }
}