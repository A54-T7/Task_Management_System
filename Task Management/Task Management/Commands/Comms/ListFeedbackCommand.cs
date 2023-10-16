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
    public class ListFeedbackCommand : BaseCommand
    {
        public ListFeedbackCommand(List<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            if (this.CommandParameters.Count < 1)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: 1, Received: {this.CommandParameters.Count}");
            }

            string keyword = CommandParameters[0];
            // var feedbacks = Repository.Tasks.OfType<Feedback>().ToList();


            return ListFeedback(keyword);
        }

        public string ListFeedback(string keyword)
        {
            StringBuilder sb = new StringBuilder();
            var feedbackList = Repository.Feedbacks;

            switch (keyword)
            {
                case "All":
                    feedbackList = Repository.Feedbacks.ToList();
                    break;
                case "SortByTitle":
                    feedbackList = Repository.Feedbacks.OrderBy(feedback => feedback.Title).ToList();
                    break;
                case "SortByRating":
                    feedbackList = Repository.Feedbacks.OrderByDescending(feedback => feedback.Rating).ToList();
                    break;
                case "FilterNew":
                    feedbackList = Repository.Feedbacks.Where(feedback => feedback.Status == FeedbackStatusType.New).ToList();
                    break;
                case "FilterUnscheduled":
                    feedbackList = Repository.Feedbacks.Where(feedback => feedback.Status == FeedbackStatusType.Unscheduled).ToList();
                    break;
                case "FilterScheduled":
                    feedbackList = Repository.Feedbacks.Where(feedback => feedback.Status == FeedbackStatusType.Scheduled).ToList();
                    break;
                case "FilterDone":
                    feedbackList = Repository.Feedbacks.Where(feedback => feedback.Status == FeedbackStatusType.Done).ToList();
                    break;
                default:
                    throw new InvalidUserInputException("The input keyword was incorrect!");
            }

            foreach (var feedback in feedbackList)
            {
                sb.AppendLine(feedback.ToString());
                sb.AppendLine();
            }

            return sb.ToString().Trim();
        }
    }
}
