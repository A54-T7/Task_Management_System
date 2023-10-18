using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management.Core.Contracts;
using Task_Management.Exceptions;
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
                case "FilterNotDone":
                    storyList = Repository.Stories.Where(story => story.Status == StoryStatusType.NotDone).ToList();
                    break;
                case "FilterInProgress":
                    storyList = Repository.Stories.Where(story => story.Status == StoryStatusType.InProgress).ToList();
                    break;
                case "FilterDone":
                    storyList = Repository.Stories.Where(story => story.Status == StoryStatusType.Done).ToList();
                    break;
                default:
                    throw new InvalidUserInputException("The input keyword was incorrect!");
            }

            foreach (var story in storyList)
            {
                sb.AppendLine(story.ToString());
                sb.AppendLine();
            }

            return sb.ToString().Trim();
        }
    }
}
