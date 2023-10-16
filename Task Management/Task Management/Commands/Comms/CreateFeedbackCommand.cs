using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management.Core.Contracts;
using Task_Management.Exceptions;
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
            Console.Write("  Team, Board - ");
            string teamBoardLine = Console.ReadLine();

            string teamName = teamBoardLine.Split(' ')[0];
            string boardName = teamBoardLine.Split(' ')[1];

            var team = this.Repository.GetTeam(teamName);
            var board = this.Repository.GetBoard(boardName, team);

            Console.Write("  Description - ");
            string description = Console.ReadLine();

            Console.Write("  Rating - ");
            int rating = int.Parse(Console.ReadLine());

            var feedback = this.Repository.CreateFeedback(title, description, rating);
            board.AddTask(feedback);
            Console.WriteLine(feedback.Description);

            return $"Feedback {title} with id {feedback.Id} was created successfully in team {teamName}, board {boardName}!";
        }
    }
}
