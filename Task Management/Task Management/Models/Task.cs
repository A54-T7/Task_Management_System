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

        public Task(int id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Task: {GetType().Name}");
            sb.AppendLine($"  Title: {Title}");
            sb.AppendLine($"  Description: {Description}");

            return sb.ToString();
        }
    }
}