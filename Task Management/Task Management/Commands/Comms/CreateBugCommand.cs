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
    public class CreateBugCommand : BaseCommand
    {
        public CreateBugCommand(IList<string> parameters, IRepository repository)
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

            Console.Write("  Severity - ");
            string severityAsString = Console.ReadLine();
            SeverityType severity = ParseSeverityTypeParameter(severityAsString, "SeverityType");

            var bug = this.Repository.CreateBug(title, description, priority, severity);
            board.AddTask(bug);

            board.AddActivity($"Added bug {bug.Title} with ID {bug.Id}.");

            return $"Bug {title} with ID {bug.Id} was created successfully in team {teamName}, board {boardName}!";
        }
    }
}
