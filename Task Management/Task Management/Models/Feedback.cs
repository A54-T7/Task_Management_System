using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml.Linq;
using Task_Management.Models.Contracts;
using Task_Management.Models.Enums;

namespace Task_Management.Models
{
    public class Feedback : Task, IFeedback
    {
        private int rating;
        private FeedbackStatusType status;
        public Feedback(string title, string description, int rating, FeedbackStatusType status) : base(title, description)
        {
            Rating = rating;
            Status = status;
        }

        public int Rating
        {
            get
            {
                return rating;
            }
            private set
            {
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
            Rating = newRating;
        }
    }
}
