using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management.Models.Contracts;
using Task_Management.Models.Enums;

namespace Task_Management.Models
{
    public class Bug : Task, IBug
    {

        private List<string> steps = new List<string>();
        private PriorityType priority;
        private SeverityType severity;
        private BugStatusType status;
        private string assigne;

        public Bug(int id, string title, string description, PriorityType priority, SeverityType severity, BugStatusType status, string assigne) 
            : base(id, title, description)
        {
            Priority = priority;
            Severity = severity;
            Status = status;
            Assigne = assigne;
        }

        public IList<string> Steps
        {
            get
            {
                return new List<string>(steps);
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

        public string Assigne
        {
            get
            {
                return assigne;
            }
            private set
            {
                assigne = value;
            }
        }
        public void ChangePriority(PriorityType newPriority)
        {
            Priority = newPriority;
        }
        public void ChangeSeverity(SeverityType newSeverity)
        {
            Severity = newSeverity;
        }
        public void ChangeAssigne(string newAssigne)
        {
            Assigne = newAssigne;
        }


        //    * Bugs must have an ID, a title, a description, a list of steps to reproduce it, a priority, a
        //            severity, a status, an assignee, a list of comments and a list of changes history.
        //    • Assignee is a member from the team.
    }
}