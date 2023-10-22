using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management.Core.Contracts;
using Task_Management.Exceptions;
using Task_Management.Models.Contracts;
using Task_Management.Models.Enums;

namespace Task_Management.Commands.Comms
{
    public class ListStoriesCommand : BaseCommand
    {
        public ListStoriesCommand(List<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            if (this.CommandParameters.Count != 1)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: 1, Received: {this.CommandParameters.Count}");
            }

            string keyword = CommandParameters[0];

            return ListBugs(keyword);
        }

        public string ListBugs(string keyword)
        {
            StringBuilder sb = new StringBuilder();
            var storyList = Repository.Stories;

            IMember assigneeToFilterBy;
            StoryStatusType statusToFilterBy;

            switch (keyword)
            {
                case "All":
                    storyList = Repository.Stories.ToList();
                    break;
                case "SortByTitle":
                    storyList = Repository.Stories.OrderBy(story => story.Title).ToList();
                    break;
                case "SortByPriority":
                    storyList = Repository.Stories.OrderByDescending(story => story.Priority).ToList();
                    break;
                case "SortBySize":
                    storyList = Repository.Stories.OrderByDescending(story => story.Size).ToList();
                    break;
                case "FilterByStatus":
                    statusToFilterBy = InputStatus();
                    storyList = Repository.Stories.Where(story => story.Status == statusToFilterBy).ToList();
                    break;
                case "FilterByAssignee":
                    assigneeToFilterBy = InputAssignee();
                    storyList = Repository.Stories.Where(story => story.Assignee == assigneeToFilterBy).ToList();
                    break;
                case "FilterByStatusAndAssignee":
                    assigneeToFilterBy = InputAssignee();
                    statusToFilterBy = InputStatus();
                    storyList = Repository.Stories.Where(story => story.Assignee == assigneeToFilterBy)
                        .Where(story => story.Status == statusToFilterBy).ToList();
                    break;
                default:
                    throw new InvalidUserInputException("The input keyword was incorrect!");
            }

            foreach (var story in storyList)
            {
                sb.AppendLine(story.ToString());
                sb.AppendLine();
            }

            if (sb.Length == 0)
            {
                Console.WriteLine("There are no stories that meet the conditions!");
            }

            return sb.ToString().Trim();
        }

        public IMember InputAssignee()
        {
            Console.Write(" Assignee to filter by - ");
            string memberName = Console.ReadLine();

            return Repository.GetMember(memberName);
        }

        public StoryStatusType InputStatus()
        {
            Console.Write(" Status to filter by - ");
            string statusAsString = Console.ReadLine();
            StoryStatusType status = ParseStoryStatusTypeParameter(statusAsString, "StoryStatusType");

            return status;
        }
    }
}
