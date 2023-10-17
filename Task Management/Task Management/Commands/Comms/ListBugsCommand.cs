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
    internal class ListBugsCommand : BaseCommand
    {
        public ListBugsCommand(List<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            if (this.CommandParameters.Count != 1)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: 1, Received: {this.CommandParameters.Count}");
            }

            string keyword = CommandParameters[0];

            return ListBugs(keyword);
        }

        public string ListBugs(string keyword)
        {
            StringBuilder sb = new StringBuilder();
            var bugList = Repository.Bugs;

            switch (keyword)
            {
                case "All":
                    bugList = Repository.Bugs.ToList();
                    break;
                case "SortByTitle":
                    bugList = Repository.Bugs.OrderBy(bug => bug.Title).ToList();
                    break;
                case "SortByPriority":
                    bugList = Repository.Bugs.OrderByDescending(bug => bug.Priority).ToList();
                    break;
                case "SortBySeverity":
                    bugList = Repository.Bugs.OrderByDescending(bug => bug.Severity).ToList();
                    break;
                case "FilterActive":
                    bugList = Repository.Bugs.Where(bug => bug.Status == BugStatusType.Active).ToList();
                    break;
                case "FilterFixed":
                    bugList = Repository.Bugs.Where(bug => bug.Status == BugStatusType.Fixed).ToList();
                    break;
                default:
                    throw new InvalidUserInputException("The input keyword was incorrect!");
            }

            foreach (var bug in bugList)
            {
                sb.AppendLine(bug.ToString());
                sb.AppendLine();
            }

            return sb.ToString().Trim();
        }
    }
}
