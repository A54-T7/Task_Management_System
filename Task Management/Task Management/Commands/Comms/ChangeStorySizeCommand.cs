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
    public class ChangeStorySizeCommand : BaseCommand
    {
        public ChangeStorySizeCommand(List<string> parameters, IRepository repository)
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
            string newSizeAsString = CommandParameters[1];
            StorySizeType newSize = ParseStorySizeTypeParameter(newSizeAsString, "StorySizeType");

            return ChangeSize(taskID, newSize);
        }

        public string ChangeSize(int taskID, StorySizeType newSize)
        {
            var story = this.Repository.GetStory(taskID);
            story.ChangeSize(newSize);

            return $"Changed the size of story {story.Title} with ID {story.Id} to {newSize}!";
        }
    }
}
