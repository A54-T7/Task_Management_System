using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management.Core.Contracts;
using Task_Management.Exceptions;

namespace Task_Management.Commands.Comms
{
    public class AssignTaskCommand : BaseCommand
    {
        public AssignTaskCommand(List<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }


        protected override string ExecuteCommand()
        {
            if (this.CommandParameters.Count != 1)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: 1, Received: {this.CommandParameters.Count}");
            }

            int taskID = this.ParseIntParameter(this.CommandParameters[0], "ID");

            return AssignTask(taskID);
        }

        public string AssignTask(int taskID)
        {
            var task = this.Repository.GetTask(taskID);

            throw new NotImplementedException();
        }

    }
}
