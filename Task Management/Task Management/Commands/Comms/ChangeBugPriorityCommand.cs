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
    public class ChangeBugPriorityCommand : BaseCommand
    {
        public ChangeBugPriorityCommand(List<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            if (this.CommandParameters.Count != 2)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: 2, Received: {this.CommandParameters.Count}");
            }

            int taskID = this.ParseIntParameter(this.CommandParameters[0], "ID");
            string newPriorityAsString = CommandParameters[1];
            PriorityType newPriority = ParsePriorityTypeParameter(newPriorityAsString, "PriorityType");

            return ChangeSeverity(taskID, newPriority);
        }

        public string ChangeSeverity(int taskID, PriorityType newPriority)
        {
            var bug = this.Repository.GetBug(taskID);
            bug.ChangePriortiy(newPriority);

            return $"Changed the priority of bug {bug.Title} with ID {bug.Id} to {newPriority}!";
        }
    }
}
