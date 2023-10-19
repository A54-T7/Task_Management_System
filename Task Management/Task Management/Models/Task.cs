using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management.Models.Contracts;

namespace Task_Management.Models
{
    public abstract class Task : ITask
    {
        private const int TitleMinLength = 10;
        private const int TitleMaxLength = 50;
        private const int DescriptionMinLength = 10;
        private const int DescriptionMaxLength = 500;
        private const string TaskErrorMessage = "Task title must be between 10 and 50 characters long!";
        private const string DescriptionErrorMessage = "Description must be between 10 and 500 characters long!";

        private string title;
        private string description;

        private readonly IList<IComment> comments;
        private readonly IList<string> activityLog;

        public Task(int id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
            comments = new List<IComment>();
            activityLog = new List<string>();
        }

        public int Id { get; }

        public string Title
        {
            get
            {
                return title;
            }
            private set
            {
                Validator.ValidateStringRange(value, TitleMinLength, TitleMaxLength, TaskErrorMessage);
                title = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
            private set
            {
                Validator.ValidateStringRange(value, DescriptionMinLength, DescriptionMaxLength, DescriptionErrorMessage);
                description = value;
            }
        }

        public IList<IComment> Comments
        {
            get
            {
                return new List<IComment>(comments);
            }
        }

        public IList<string> ActivityLog
        {
            get
            {
                return new List<string>(activityLog);
            }
        }

        public void AddComment(IComment comment)
        {
            comments.Add(comment);
        }

        public void AddActivity(string activityMessage)
        {
            activityLog.Add(activityMessage);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{GetType().Name}: {Title}");
            sb.AppendLine($"  Description: {Description}");

            return sb.ToString();
        }

        public string PrintComments()
        {
            StringBuilder sb = new StringBuilder();

            if (Comments.Count <= 0)
            {
                sb.AppendLine("   - None -");
            }

            else
            {
                foreach (var comment in Comments)
                {
                    sb.AppendLine($"   '{comment.Content}'");
                    sb.AppendLine($"     by {comment.Author}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public abstract void AdvanceStatus();
        public abstract void ReverseStatus();
    }
}