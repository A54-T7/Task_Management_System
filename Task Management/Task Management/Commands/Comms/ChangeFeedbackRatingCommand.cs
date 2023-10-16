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
    public class ChangeFeedbackRatingCommand : BaseCommand
    {
        public ChangeFeedbackRatingCommand(List<string> parameters, IRepository repository)
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
            int newRating = this.ParseIntParameter(this.CommandParameters[1], "Rating");

            return ChangeRating(taskID, newRating);
        }

        public string ChangeRating(int taskID, int newRating)
        {
            var feedback = this.Repository.GetFeedback(taskID);
            feedback.ChangeRating(newRating);

            return $"Changed the rating of feedback {feedback.Title} with ID {feedback.Id} to {newRating}!";
        }
    }
}
