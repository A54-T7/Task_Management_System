using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management.Exceptions;
using Task_Management.Models.Contracts;
using Task_Management.Models.Enums;

namespace Task_Management.Models
{
    public class Story : Task, IStory
    {
        private StoryStatusType status;
        private StorySizeType size;
        private PriorityType priority;

        private string assignee;


        public Story(int id, string title, string description, PriorityType priority, StorySizeType size) 
            : base(id, title, description)
        {
            Status = StoryStatusType.NotDone;
            Size = size;
            Priority = priority;
            Assignee = "N/A";
        }

        public StoryStatusType Status
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

        public StorySizeType Size
        {
            get
            {
                return size;
            }
            private set
            {
                size = value;
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

        public string Assignee
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
            Priority = newPriority;
        }
        public void ChangeSize(StorySizeType newSize)
        {
            Size = newSize;
        }
        public void ChangeAssignee(string newAssignee)
        {
            Assignee = newAssignee;
        }

        public override void AdvanceStatus()
        {
            if (Status != StoryStatusType.Done)
            {
                Status++;
            }
            else
            {
                string errorMessage = $"Story {Title} cannot be advanced further than the {Status} status.";
                throw new InvalidUserInputException(errorMessage);
            }
        }

        public override void ReverseStatus()
        {
            if (Status != StoryStatusType.NotDone)
            {
                Status--;
            }
            else
            {
                string errorMessage = $"Story {Title} cannot be reverted more than the {Status} status.";
                throw new InvalidUserInputException(errorMessage);
            }
        }

        public override string ToString()
        {
            StringBuilder storyInfo = new StringBuilder();

            storyInfo.Append(base.ToString());
            storyInfo.AppendLine($"  Priority: {Priority}");
            storyInfo.AppendLine($"  Size: {Size}");
            storyInfo.AppendLine($"  Status: {Status}");
            storyInfo.AppendLine($"  Assignee: {Assignee}");

            storyInfo.AppendLine($"  Comments:");
            storyInfo.AppendLine(base.PrintComments());

            return storyInfo.ToString().Trim();
        }


        /* Stories must have an ID, a title, a description, a priority, a size, a status, an assignee, a
            list of comments and a list of changes history.
       • Priority is one of the following: High, Medium, or Low.
       • Size is one of the following: Large, Medium, or Small.
       • Status is one of the following: Not Done, InProgress, or Done.
       • Assignee is a member from the team.
       • Comments is a list of comments (string messages with author).
       • History is a list of all changes(string messages) that were done to the story. */
    }
}
