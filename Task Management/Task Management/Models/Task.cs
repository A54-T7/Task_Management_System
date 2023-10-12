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

        private string title;
        private string description;
        private const int TitleMinLength = 10;
        private const int TitleMaxLength = 50;
        private const int DescriptionMinLength = 10;
        private const int DescriptionMaxLength = 500;
        private const string TaskErrorMessage = "Task must be between 10 and 50 characters long!";
        private const string DescriptionErrorMessage = "Description must be between 10 and 500 characters long!";

        public Task(string title, string description)
        {
            Title = title;
            Description = description;
        }

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
    }
}