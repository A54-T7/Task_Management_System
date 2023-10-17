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
            string memberName = CommandParameters[1];

            return ChangeStatus(taskID, memberName);
        }

        public string ChangeStatus(int taskID, string memberName)
        {
            var feedback = this.Repository.GetFeedback(taskID);
            var member = this.Repository.GetMember(memberName);

            Console.WriteLine($"Feedback {feedback.Title}'s current status is {feedback.Status}");
            Console.Write("  Advance or Revert? ");

            string keyword = Console.ReadLine().ToLower();

            switch (keyword)
            {
                case "advance":
                    feedback.AdvanceStatus();
                    break;
                case "revert":
                    feedback.ReverseStatus();
                    break;
            }

            return $"Changed the status of feedback {feedback.Title} with ID {feedback.Id} to {feedback.Status}!";
        }
    }
}
