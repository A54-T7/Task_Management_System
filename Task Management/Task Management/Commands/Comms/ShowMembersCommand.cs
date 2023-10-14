using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management.Core.Contracts;

namespace Task_Management.Commands.Comms
{
    public class ShowMembersCommand : BaseCommand
    {
        public ShowMembersCommand(IRepository repository)
            : base(repository)
        {
        }

        protected override string ExecuteCommand()
        {
            return this.ShowAllMembers();
        }

        private string ShowAllMembers()
        {
            StringBuilder sb = new StringBuilder();
            int counter = 1;

            sb.AppendLine("--MEMBERS--");
            foreach (var member in this.Repository.Members)
            {
                sb.AppendLine($"{counter}. {member.Name}");
                counter++;
            }

            return sb.ToString().Trim();
        }
    }
}
