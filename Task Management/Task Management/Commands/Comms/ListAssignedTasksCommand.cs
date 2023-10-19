using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management.Core.Contracts;
using Task_Management.Exceptions;

namespace Task_Management.Commands.Comms
{
    public class ListAssignedTasksCommand : BaseCommand
    {
        public ListAssignedTasksCommand(List<string> parameters, IRepository repository)
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

            throw new NotImplementedException();

            return sb.ToString().Trim();
        }
    }
}
