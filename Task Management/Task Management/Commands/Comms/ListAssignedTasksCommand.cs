using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management.Core.Contracts;
using Task_Management.Exceptions;
using Task_Management.Models.Contracts;

namespace Task_Management.Commands.Comms
{
    public class ListAssignedTasksCommand : BaseCommand
    {
        public ListAssignedTasksCommand(List<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            if (this.CommandParameters.Count < 1)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: 1, Received: {this.CommandParameters.Count}");
            }

            string keyword = CommandParameters[0];

            return ListTasks(keyword);
        }

        public string ListTasks(string keyword)
        {
            StringBuilder sb = new StringBuilder();

            List<IBug> bugList = new List<IBug>();
            List<IStory> storyList = new List<IStory>();

            string memberName;
            string status;

            switch (keyword)
            {
                case "SortByTitle":
                    bugList = Repository.Bugs.Where(bug => bug.Assignee != null)
                        .OrderBy(bug => bug.Assignee.Name).ToList();
                    storyList = Repository.Stories.Where(story => story.Assignee != null)
                        .OrderBy(story => story.Assignee.Name).ToList();                 

                    break;
                case "FilterByAssignee":
                    memberName = InputAssignee().Name;

                    bugList = Repository.Bugs.Where(bug => bug.Assignee.Name == memberName).ToList();
                    storyList = Repository.Stories.Where(story => story.Assignee.Name == memberName).ToList();

                    break;
                case "FilterByStatus":
                    status = InputStatus();

                    bugList = Repository.Bugs.Where(bug => bug.Status.ToString() == status).ToList();
                    storyList = Repository.Stories.Where(story => story.Status.ToString() == status).ToList();

                    break;

                case "FilterByStatusAndAssignee":
                    memberName = InputAssignee().Name;
                    status = InputStatus();

                    bugList = Repository.Bugs.Where(bug => bug.Assignee.Name == memberName)
                        .Where(bug => bug.Status.ToString() == status).ToList();
                    storyList = Repository.Stories.Where(story => story.Assignee.Name == memberName)
                        .Where(story => story.Status.ToString() == status).ToList();

                    break;


                default:
                    throw new InvalidUserInputException("No such command!");
            }

            if (bugList != null)
            {
                foreach (var bug in bugList)
                {
                    sb.AppendLine(bug.ToString());
                }
            }
            if (storyList != null)
            {
                foreach (var story in storyList)
                {
                    sb.AppendLine(story.ToString());
                }
            }
            
            if (sb.Length == 0)
            {
                Console.WriteLine("There are no tasks that meet the conditions!");
            }

            return sb.ToString().Trim();
        }

        public IMember InputAssignee()
        {
            Console.Write(" Assignee to filter by - ");
            string memberName = Console.ReadLine();

            return Repository.GetMember(memberName);
        }

        public string InputStatus()
        {
            Console.Write(" Status to filter by - ");
            string statusAsString = Console.ReadLine();

            return statusAsString;
        }
    }
}
