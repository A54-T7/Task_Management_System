using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Task_Management.Core.Contracts;
using Task_Management.Exceptions;
using Task_Management.Models;
using Task_Management.Models.Contracts;

namespace Task_Management.Commands.Comms
{
    internal class AddTaskCommentCommand : BaseCommand
    {
        public AddTaskCommentCommand(List<string> parameters, IRepository repository)
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

            return CreateComment(taskID);
        }

        public string CreateComment(int taskID)
        {
            var task = this.Repository.GetTask(taskID);

            Console.Write("  Comment - ");
            string content = Console.ReadLine();

            Console.Write("  Author - ");
            string author = Console.ReadLine();

            var member = this.Repository.GetMember(author);

            var newComment = this.Repository.CreateComment(content, author);
            task.AddComment(newComment);

            return $"{member.Name} added a new comment to {task.GetType().ToString().Split('.')[2]} {task.Title} successfully!";
        }
    }
}
