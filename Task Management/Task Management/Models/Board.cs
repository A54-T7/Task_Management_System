using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management.Models.Contracts;

namespace Task_Management.Models
{
    public class Board : IBoard
    {
        private const int NameMinLength = 5;
        private const int NameMaxLength = 10;
        private const string NameErrorMessage = "Name must be between 5 and 10 characters long!";

        private List<ITask> tasks = new List<ITask>();
        private List<string> activityLog = new List<string>();

        private string name;

        public Board(string name)
        {
            Name = name;
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                Validator.ValidateStringRange(value, NameMinLength, NameMaxLength, NameErrorMessage);
                name = value;
            }
        }

        public IList<ITask> Tasks
        {
            get
            {
                return new List<ITask>(tasks);
            }
        }

        public IList<string> ActivityLog
        {
            get
            {
                return new List<string>(activityLog);
            }
        }

        public void AddActivity(string message)
        {
            activityLog.Add($"{message} [{DateTime.Now.ToString("yyyy-MM-dd|HH:mm:ss")}]");
        }
        public void AddTask(ITask task)
        {
            tasks.Add(task);
        }

        public string PrintActivity()
        {
            StringBuilder sb = new StringBuilder();
            int counter = 1;

            sb.AppendLine("Board Activity Log:");

            foreach (var activity in ActivityLog)
            {
                sb.AppendLine($"{counter}. {activity}");
                counter++;
            }

            return sb.ToString().Trim();
        }
    }
}
