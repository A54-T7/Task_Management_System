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
    public class ChangeFeedbackStatusCommand : BaseCommand
    {
        public ChangeFeedbackStatusCommand(List<string> parameters, IRepository repository)
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
            string keyword = CommandParameters[1].ToLower();

            return ChangeStatus(taskID, keyword);
        }

        public string ChangeStatus(int taskID, string keyword)
        {
            var feedback = this.Repository.GetFeedback(taskID);

            switch (keyword)
            {
                case "advance":
                    feedback.AdvanceStatus();
                    break;
                case "revert":
                    feedback.ReverseStatus();
                    break;
                default:
                    throw new InvalidUserInputException("No such command! Use 'Advance' or 'Revert'.");
            }

            return $"Changed the status of feedback {feedback.Title} with ID {feedback.Id} to {feedback.Status}!";
        }
    }
}
