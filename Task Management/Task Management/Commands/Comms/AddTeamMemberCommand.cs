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
    internal class AddTeamMemberCommand : BaseCommand
    {

        public AddTeamMemberCommand(IList<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            if (CommandParameters.Count != 2)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: 1, Received: {CommandParameters.Count}");
            }


            string memberName = CommandParameters[0];
            string teamNameToAdd = CommandParameters[1];

            return AddToTeam(memberName, teamNameToAdd);
        }

        private string AddToTeam(string memberName, string teamNameToAdd)
        {
            ITeam team = this.Repository.GetTeam(teamNameToAdd);
            IMember member = this.Repository.GetMember(memberName);

            team.AddTeamMember(member);

            return $"Member {memberName} added to team {teamNameToAdd}!";
        }
    }
}
