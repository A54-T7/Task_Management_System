using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management.Core.Contracts;
using Task_Management.Exceptions;
using Task_Management.Models.Contracts;

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
            if (this.CommandParameters.Count != 2)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: 2, Received: {this.CommandParameters.Count}");
            }

            int taskID = this.ParseIntParameter(this.CommandParameters[0], "ID");
            string assigneeName = CommandParameters[1];

            return AssignTask(taskID, assigneeName);
        }

        public string AssignTask(int taskID, string assigneeName)
        {
            var task = this.Repository.GetTask(taskID);
            var assignee = this.Repository.GetMember(assigneeName);

            string taskAsString = task.GetType().ToString().Split('.')[2];

            switch (taskAsString)
            {
                case "Bug":
                    var bug = this.Repository.GetBug(taskID);
                    bug.AddAssignee(assignee);
                    assignee.AddTask(bug);
                    break;
                case "Story":
                    var story = this.Repository.GetStory(taskID);
                    story.AddAssignee(assignee);
                    assignee.AddTask(story);
                    break;
                case "Feedback":
                    string errorMessage = "Feedback tasks are not assignable!";
                    throw new InvalidUserInputException(errorMessage);
            }

            return $"Member {assignee.Name} successfully assigned to {taskAsString} with ID {task.Id}";
        }

    }
}
