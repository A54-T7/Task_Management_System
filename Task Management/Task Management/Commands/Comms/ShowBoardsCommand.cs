using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management.Core.Contracts;
using Task_Management.Exceptions;

namespace Task_Management.Commands.Comms
{
    public class ShowBoardsCommand : BaseCommand
    {
        public ShowBoardsCommand(List<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            if (this.CommandParameters.Count != 1)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: 1, Received: {this.CommandParameters.Count}");
            }

            string teamName = this.CommandParameters[0];

            return this.ShowTeamBoards(teamName);
        }

        public string ShowTeamBoards(string teamName)
        {
            StringBuilder sb = new StringBuilder();
            var team = this.Repository.GetTeam(teamName);
            int counter = 1;

            if (team.Boards.Count == 0)
            {
                sb.AppendLine("No boards!");
            }
            else
            {
                foreach (var item in team.Boards)
                {
                    sb.AppendLine($"{counter}. {item.Name}");
                    counter++;
                }
            }

            return sb.ToString().Trim();
        }
    }
}
