using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management.Core.Contracts;
using Task_Management.Exceptions;
using Task_Management.Models;
using Task_Management.Models.Enums;

namespace Task_Management.Commands.Comms
{
    public class CreateFeedbackCommand : BaseCommand
    {
        public CreateFeedbackCommand(IList<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            if (this.CommandParameters.Count < 1)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected at least 1, Received: {this.CommandParameters.Count}");
            }

            string title = this.CommandParameters[0];

            return CreateFeedback(title);
        }

        private string CreateFeedback(string title)
        {
            Console.Write("  Team - ");
            string teamName = Console.ReadLine();
            Console.Write("  Board - ");
            string boardName = Console.ReadLine();

            var team = this.Repository.GetTeam(teamName);
            var board = this.Repository.GetBoard(boardName, team);

            Console.Write("  Description - ");
            string description = Console.ReadLine();

            Console.Write("  Rating - ");
            int rating = int.Parse(Console.ReadLine());

            var feedback = this.Repository.CreateFeedback(title, description, rating);
            board.AddTask(feedback);

            board.AddActivity($"Added feedback {feedback.Title} with ID {feedback.Id}.");

            return $"Feedback {title} with ID {feedback.Id} was created successfully in team {teamName}, board {boardName}!";
        }
    }
}
