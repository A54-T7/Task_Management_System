using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management.Models.Contracts;
using Task_Management.Models.Enums;

namespace Task_Management.Models
{
    public class Story : Task, IStory
    {

        private StoryStatusType status;
        private StorySizeType size;
        private PriorityType priority;
        private string assigne;


        public Story(string title, string description, PriorityType priority, StorySizeType size,StoryStatusType status, string assigne) : base(title, description)
        {
            Status = status;
            Size = size;
            Priority = priority;
            Assigne = assigne;
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
        public void ChangeSize(StorySizeType newSize)
        {
            Size = newSize;
        }
        public void ChangeAssigne(string newAssigne)
        {
            Assigne = newAssigne;
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
