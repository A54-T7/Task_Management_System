using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management.Core.Contracts;
using Task_Management.Exceptions;
using Task_Management.Models.Contracts;

namespace Task_Management.Commands.Comms
{
    public class CreateMemberCommand : BaseCommand
    {
        public CreateMemberCommand(List<string> parameters, IRepository repository)
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

            return this.RegisterMember(name);
        }

        private string RegisterMember(string name)
        {
            if (this.Repository.MemberExist(name))
            {
                string errorMessage = $"Member {name} already exists. Choose a different name!";
                throw new InvalidUserInputException(errorMessage);
            }

            IMember member = this.Repository.CreateMember(name);
            this.Repository.AddMember(member);

            return string.Format("Member {0} registered successfully!", name);
        }
    }
}
