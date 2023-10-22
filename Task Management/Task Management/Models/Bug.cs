using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Task_Management.Exceptions;
using Task_Management.Models.Contracts;
using Task_Management.Models.Enums;

namespace Task_Management.Models
{
    public class Bug : Task, IBug
    {
        private PriorityType priority;
        private SeverityType severity;
        private BugStatusType status;

        private IMember assignee;

        private List<string> stepsToReproduce = new List<string>();

        public Bug(int id, string title, string description, PriorityType priority, SeverityType severity) 
            : base(id, title, description)
        {
            Priority = priority;
            Severity = severity;
            Status = BugStatusType.Active;
            base.AddActivity($"Created bug '{Title}' with ID {Id}");
        }

        public IList<string> StepsToReproduce
        {
            get
            {
                return new List<string>(stepsToReproduce);
            }
        }

        public PriorityType Priority
        {
            get
            {
                return priority;
            }
            private set
            {
                priority = value;
            }
        }

        public SeverityType Severity
        {
            get
            {
                return severity;
            }
            private set
            {
                severity = value;
            }
        }

        public BugStatusType Status
        {
            get
            {
                return status;
            }
            private set
            {
                status = value;
            }
        }

        
        public IMember Assignee
        {
            get
            {
                return assignee;
            }
            private set
            {
                assignee = value;
            }
        }

        public void ChangePriority(PriorityType newPriority)
        {
            if (newPriority != Priority)
            {
                AddActivity($"Changed priority from {Priority} to {newPriority}");
                Priority = newPriority;
            }
            else throw new InvalidUserInputException($"Priority is already set at {Priority}");
            
        }
        public void ChangeSeverity(SeverityType newSeverity)
        {
            if (newSeverity != Severity)
            {
                AddActivity($"Changed severity from {Severity} to {newSeverity}");
                Severity = newSeverity;
            }
            else throw new InvalidUserInputException($"Severity is already set at {Severity}");
        }
        public void AddAssignee(IMember newAssignee)
        {
            if (Assignee != newAssignee)
            {
                AddActivity($"Assigned to member {newAssignee}.");
                Assignee = newAssignee;
            }
            else throw new InvalidUserInputException($"Task is already assigned to {Assignee}");
        }

        public void RemoveAssignee()
        {
            if (Assignee == null)
            {
                string errorMessage = $"Bug {Title} is already unassigned!";
                throw new InvalidUserInputException(errorMessage);
            }
            else
            {
                AddActivity($"Unassigned member {Assignee}");
                Assignee = null;
            }
        }

        public override void AdvanceStatus()
        {
            if (Status != BugStatusType.Fixed)
            {
                BugStatusType oldStatus = Status;
                Status++;

                AddActivity($"Advanced status from {oldStatus} to {Status}");
            }
            else
            {
                string errorMessage = $"Bug {Title} cannot be advanced further than the {Status} status.";
                throw new InvalidUserInputException(errorMessage);
            }
        }

        public override void ReverseStatus()
        {
            if (Status != BugStatusType.Active)
            {
                BugStatusType oldStatus = Status;
                Status--;


                AddActivity($"Reverted status from {oldStatus} to {Status}");
            }
            else
            {
                string errorMessage = $"Bug {Title} cannot be reverted more than the {Status} status.";
                throw new InvalidUserInputException(errorMessage);
            }
        }

        public void AddReproduceStep(string newStep)
        {
            stepsToReproduce.Add(newStep);
        }

        public override string ToString()
        {
            StringBuilder bugInfo = new StringBuilder();

            bugInfo.Append(base.ToString());
            bugInfo.AppendLine($"  Priority: {Priority}");
            bugInfo.AppendLine($"  Severity: {Severity}");
            bugInfo.AppendLine($"  Status: {Status}");

            string assigneeAsString = (Assignee != null) ? Assignee.Name : "N/A";
            bugInfo.AppendLine($"  Assignee: {assigneeAsString}");

            bugInfo.AppendLine($"  Reproduction steps:");
            bugInfo.AppendLine(PrintReproductionSteps());

            bugInfo.AppendLine($"  Comments:");
            bugInfo.AppendLine(base.PrintComments());

            return bugInfo.ToString().Trim();
        }

        public string PrintReproductionSteps()
        {
            StringBuilder sb = new StringBuilder();
            int counter = 1;

            if (StepsToReproduce.Count <= 0)
            {
                sb.AppendLine("   - None -");
            }
            else
            {
                foreach (var step in StepsToReproduce)
                {
                    sb.AppendLine($"   {counter++}. {step}");
                }
            }

            return sb.ToString().TrimEnd();
        }


        //    * Bugs must have an ID, a title, a description, a list of steps to reproduce it, a priority, a
        //            severity, a status, an assignee, a list of comments and a list of changes history.
        //    • Assignee is a member from the team.
    }
}