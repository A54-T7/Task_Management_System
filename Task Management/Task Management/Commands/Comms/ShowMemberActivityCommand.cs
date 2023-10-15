using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management.Core.Contracts;
using Task_Management.Exceptions;

namespace Task_Management.Commands.Comms
{
    public class ShowMemberActivityCommand : BaseCommand
    {
        public ShowMemberActivityCommand(List<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            if (this.CommandParameters.Count != 1)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: 1, Received: {this.CommandParameters.Count}");
            }

            string memberName = this.CommandParameters[0];

            return ShowMemberActivity(memberName);
        }

        private string ShowMemberActivity(string memberName)
        {
            var member = this.Repository.GetMember(memberName);

            StringBuilder sb = new StringBuilder();
            int counter = 1;

            sb.AppendLine("--MEMBER ACTIVITY LOG--");
            foreach (var activity in member.ActivityLog)
            {
                sb.AppendLine($"{counter}. {activity}");
                counter++;
            }

            return sb.ToString().Trim();
        }
    }
}
