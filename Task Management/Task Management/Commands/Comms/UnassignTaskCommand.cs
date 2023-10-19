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
    public class UnassignTaskCommand : BaseCommand
    {
        public UnassignTaskCommand(List<string> parameters, IRepository repository)
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

            return UnassignTask(taskID);
        }

        
        public string UnassignTask(int taskID)
        {
            var task = this.Repository.GetTask(taskID);
            string taskAsString = task.GetType().ToString().Split('.')[2];

            IMember assignee;

            switch (taskAsString)
            {
                case "Bug":
                    var bug = this.Repository.GetBug(taskID);
                    assignee = this.Repository.GetMember(bug.Assignee.Name);
                    assignee.RemoveTask(bug);
                    bug.RemoveAssignee();
                    break;
                case "Story":
                    var story = this.Repository.GetStory(taskID);
                    assignee = this.Repository.GetMember(story.Assignee.Name);
                    assignee.RemoveTask(story);
                    story.RemoveAssignee();
                    break;
                default:
                    string errorMessage = "Feedback tasks are not assignable, and therefore cannot be unassigned!";
                    throw new InvalidUserInputException(errorMessage);
            }

            return $"Member {assignee.Name} successfully unassigned from {taskAsString} with ID {task.Id}";
        }
    }
}
