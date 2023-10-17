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
    public class ChangeBugSeverityCommand : BaseCommand
    {
        public ChangeBugSeverityCommand(List<string> parameters, IRepository repository)
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
            string newSeverityAsString = CommandParameters[1];
            SeverityType newSeverity = ParseSeverityTypeParameter(newSeverityAsString, "SeverityType");

            return ChangeSeverity(taskID, newSeverity);
        }

        public string ChangeSeverity(int taskID, SeverityType newSeverity)
        {
            var bug = this.Repository.GetBug(taskID);
            bug.ChangeSeverity(newSeverity);

            return $"Changed the severity of bug {bug.Title} with ID {bug.Id} to {newSeverity}!";
        }
    }
}
