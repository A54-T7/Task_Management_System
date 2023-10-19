using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management.Core.Contracts;
using Task_Management.Exceptions;

namespace Task_Management.Commands.Comms
{
    public class AddBugReproductionStepsCommand : BaseCommand
    {
        public AddBugReproductionStepsCommand(List<string> parameters, IRepository repository)
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

            return AddBugSteps(taskID);
        }

        public string AddBugSteps(int taskID)
        {
            var bug = this.Repository.GetBug(taskID);

            Console.Write("How many steps do you wish to add? ");
            int stepCount = int.Parse(Console.ReadLine());

            for (int i = 1; i <= stepCount; i++)
            {
                Console.Write($"{i}. ");
                string stepMessage = Console.ReadLine();
                bug.AddReproduceStep(stepMessage);
            }

            return $"Added {stepCount} step(s) to bug {bug.Title} with ID {bug.Id} successfully!";
        }
    }
}
