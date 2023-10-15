using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management.Core.Contracts;
using Task_Management.Exceptions;

namespace Task_Management.Commands.Comms
{
    public class ShowTeamActivityCommand : BaseCommand
    {
        public ShowTeamActivityCommand(List<string> parameters, IRepository repository)
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

            return ShowTeamActivity(teamName);
        }

        private string ShowTeamActivity(string teamName)
        {
            var team = this.Repository.GetTeam(teamName);

            StringBuilder sb = new StringBuilder();
            int counter = 1;

            sb.AppendLine("--TEAM ACTIVITY LOG--");
            foreach (var activity in team.ActivityLog)
            {
                sb.AppendLine($"{counter}. {activity}");
                counter++;
            }

            return sb.ToString().Trim();
        }
    }
}
