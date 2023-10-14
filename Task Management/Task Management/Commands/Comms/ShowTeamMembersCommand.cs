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
    public class ShowTeamMembersCommand : BaseCommand
    {
        public ShowTeamMembersCommand(List<string> parameters, IRepository repository)
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

            return this.ShowTeamMembers(teamName);
        }

        private string ShowTeamMembers(string teamName)
        {
            ITeam team = this.Repository.GetTeam(teamName);

            return team.PrintTeamMembers();
        }
    }
}
