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
    public class ListTasksCommand : BaseCommand
    {
        public ListTasksCommand(List<string> parameters, IRepository repository)
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

            return ListTasks(keyword);
        }

        public string ListTasks(string keyword)
        {
            StringBuilder sb = new StringBuilder();
            var taskList = Repository.Tasks;

            switch (keyword)
            {
                case "All":
                    taskList = Repository.Tasks.ToList();
                    break;
                case "SortByTitle":
                    taskList = Repository.Tasks.OrderBy(task => task.Title).ToList();
                    break;
                    
                case "FilterByTitle":
                    Console.Write("  Filter keyword - ");
                    string wordFilter = Console.ReadLine();
                    taskList = Repository.Tasks.Where(task => task.Title.Contains(wordFilter)).ToList();
                    break;
                default:
                    throw new InvalidUserInputException("The input keyword was incorrect!");
            }

            foreach (var task in taskList)
            {
                sb.AppendLine(task.ToString());
            }
            sb.AppendLine();
            return sb.ToString().Trim();
        }
    }
}
