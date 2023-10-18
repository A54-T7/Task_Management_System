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
    internal class CreateStoryCommand : BaseCommand
    {
        public CreateStoryCommand(IList<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            if (this.CommandParameters.Count < 1)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected at least 1, Received: {this.CommandParameters.Count}");
            }

            string title = this.CommandParameters[0];

            return CreateBug(title);
        }

        private string CreateBug(string title)
        {
            Console.Write("  Team - ");
            string teamName = Console.ReadLine();
            Console.Write("  Board - ");
            string boardName = Console.ReadLine();

            var team = this.Repository.GetTeam(teamName);
            var board = this.Repository.GetBoard(boardName, team);

            Console.Write("  Description - ");
            string description = Console.ReadLine();

            Console.Write("  Priority - ");
            string priorityAsString = Console.ReadLine();
            PriorityType priority = ParsePriorityTypeParameter(priorityAsString, "PriorityType");

            Console.Write("  Size - ");
            string sizeAsString = Console.ReadLine();
            StorySizeType size = ParseStorySizeTypeParameter(sizeAsString, "SeverityType");

            var story = this.Repository.CreateStory(title, description, priority, size);
            board.AddTask(story);

            return $"Story {title} with ID {story.Id} was created successfully in team {teamName}, board {boardName}!";
        }
    }
}
