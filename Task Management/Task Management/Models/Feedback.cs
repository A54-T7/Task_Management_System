using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml.Linq;
using Task_Management.Exceptions;
using Task_Management.Models.Contracts;
using Task_Management.Models.Enums;

namespace Task_Management.Models
{
    public class Feedback : Task, IFeedback
    {
        private const string RatingErrorMessage = "Feedback rating must be a positive number!";

        private int rating;
        private FeedbackStatusType status;

        public Feedback(int id, string title, string description, int rating)
            : base(id, title, description)
        {
            Rating = rating;
            Status = FeedbackStatusType.New;
            base.AddActivity($"Created feedback {base.Title} with ID {base.Id}");
        }

        public int Rating
        {
            get
            {
                return rating;
            }
            private set
            {
                Validator.ValidateRatingNotNegative(value, RatingErrorMessage);
                rating = value;
            }
        }

        public FeedbackStatusType Status
        {
            get
            {
                return status;
            }
            private set
            {
                status = value;
            }
        }

        public void ChangeRating(int newRating)
        {
            int previousRating = Rating;
            Rating = newRating;

            AddActivity($"Changed the rating from {previousRating} to {newRating}");
        }

        public override void AdvanceStatus()
        {
            if (Status != FeedbackStatusType.Done)
            {
                FeedbackStatusType oldStatus = Status;
                Status++;

                AddActivity($"Advanced the status from {oldStatus} to {Status}");

            }
            else
            {
                string errorMessage = $"Feedback {Title} cannot be advanced further than the {Status} status.";
                throw new InvalidUserInputException(errorMessage);
            }
        }

        public override void ReverseStatus()
        {
            if (Status != FeedbackStatusType.New)
            {
                FeedbackStatusType oldStatus = Status;
                Status--;

                AddActivity($"Reverted the status from {oldStatus} to {Status}");
            }
            else
            {
                string errorMessage = $"Feedback {Title} cannot be reverted more than the {Status} status.";
                throw new InvalidUserInputException(errorMessage);
            }
        }

        public override string ToString()
        {
            StringBuilder feedbackInfo = new StringBuilder();

            feedbackInfo.Append(base.ToString());
            feedbackInfo.AppendLine($"  Rating: {Rating}");
            feedbackInfo.AppendLine($"  Status: {Status}");

            feedbackInfo.AppendLine($"  Comments:");
            feedbackInfo.AppendLine(base.PrintComments());

            return feedbackInfo.ToString().Trim();
        }
    }
}
