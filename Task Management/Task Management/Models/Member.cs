using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management.Models.Contracts;

namespace Task_Management.Models
{
    public class Member : IMember
    {
        private const int NameMinLength = 5;
        private const int NameMaxLength = 15;
        private const string NameErrorMessage = "Name must be between 5 and 15 characters long!";

        private List<ITask> tasks = new List<ITask>();
        private List<string> activityLog = new List<string>();

        private string name;

        public Member(string name)
        {
            Name = name;
            AddActivity($"Created member: {Name}");
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

        public void AddActivity(string activityMessage)
        {
            activityLog.Add($"{activityMessage} [{DateTime.Now.ToString("yyyy-MM-dd|HH:mm:ss")}]");
        }

        public void AddTask(ITask task)
        {
            tasks.Add(task);
            AddActivity($"Assigned to task {task.Title} with ID {task.Id}");
        }

        public void RemoveTask(ITask task)
        {
            tasks.Remove(task);
            AddActivity($"Unassigned from task {task.Title} with ID {task.Id}");

        }

        public override string ToString()
        {
            StringBuilder memberInfo = new StringBuilder();

            memberInfo.AppendLine($"{Name}");
            memberInfo.AppendLine($"Tasks:");
            memberInfo.AppendLine(PrintTasks());

            return memberInfo.ToString().Trim();

        }

        public string PrintTasks()
        {
            StringBuilder sb = new StringBuilder();
            int counter = 1;

            if (tasks.Count == 0)
            {
                sb.AppendLine("    No assigned tasks!");
            }
            else
            {
                foreach (var task in tasks)
                {
                    sb.AppendLine($"    {counter++}. {task.ToString()}");
                }
            }

            return sb.ToString().Trim();
        }

        public string PrintActivityLog()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("    Activities:");
            foreach (var activity in activityLog)
            {
                sb.AppendLine($"    {activity}");
            }

            return sb.ToString();
        }

    }
}
