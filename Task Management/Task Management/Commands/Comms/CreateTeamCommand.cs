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
    public class CreateTeamCommand : BaseCommand
    {
        public CreateTeamCommand(List<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            if (this.CommandParameters.Count != 1)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: 1, Received: {this.CommandParameters.Count}");
            }

            string name = this.CommandParameters[0];

            return this.RegisterTeam(name);
        }

        private string RegisterTeam(string name)
        {
            if (this.Repository.TeamExist(name))
            {
                string errorMessage = $"Team {name} already exists. Choose a different name!";
                throw new InvalidUserInputException(errorMessage);
            }

            ITeam team = this.Repository.CreateTeam(name);
            this.Repository.AddTeam(team);

            return string.Format("Team {0} registered successfully!", name);
        }
    }
}
