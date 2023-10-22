using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management.Core.Contracts;
using Task_Management.Exceptions;
using Task_Management.Models.Contracts;
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

            return ListFeedback(keyword);
        }

        public string ListFeedback(string keyword)
        {
            StringBuilder sb = new StringBuilder();
            List<IFeedback> feedbackList = new List<IFeedback>();

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
                case "FilterByStatus":
                    FeedbackStatusType feedbackToFilterBy = InputStatus();
                    feedbackList = Repository.Feedbacks.Where(feedback => feedback.Status == feedbackToFilterBy).ToList();
                    break;
                default:
                    throw new InvalidUserInputException("The input keyword was incorrect!");
            }

            foreach (var feedback in feedbackList)
            {
                sb.AppendLine(feedback.ToString());
                sb.AppendLine();
            }

            if (sb.Length == 0)
            {
                Console.WriteLine("There are no feedback tasks that meet the conditions!");
            }

            return sb.ToString().Trim();
        }

        public FeedbackStatusType InputStatus()
        {
            Console.Write(" Status to filter by - ");
            string statusAsString = Console.ReadLine();
            FeedbackStatusType status = ParseFeedbackStatusTypeParameter(statusAsString, "FeedbackStatusType");

            return status;
        }
    }
}
