using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management.Core.Contracts;
using Task_Management.Exceptions;

namespace Task_Management.Commands.Comms
{
    public class ShowBoardActivtyCommand : BaseCommand
    {
        public ShowBoardActivtyCommand(List<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            if (this.CommandParameters.Count != 2)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: 2, Received: {this.CommandParameters.Count}");
            }

            string boardName = this.CommandParameters[0];
            string teamName = this.CommandParameters[1];

            return ShowBoardActivity(boardName, teamName);
        }

        private string ShowBoardActivity(string boardName, string teamName)
        {
            var team = this.Repository.GetTeam(teamName);

            StringBuilder sb = new StringBuilder();
            int counter = 1;

            sb.AppendLine("--BOARD ACTIVITY LOG--");

            var board = this.Repository.GetBoard(boardName, team);
            foreach (var activity in board.ActivityLog)
            {
                sb.AppendLine($"{counter}. {activity}");
                counter++;
            }

            return sb.ToString().Trim();
        }
    }
}
