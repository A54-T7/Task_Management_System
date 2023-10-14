using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Task_Management.Core.Contracts;
using Task_Management.Exceptions;
using Task_Management.Models.Contracts;

namespace Task_Management.Commands.Comms
{
    public class CreateBoardCommand : BaseCommand
    {
        public CreateBoardCommand(List<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            if (this.CommandParameters.Count != 2)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: 2, Received: {this.CommandParameters.Count}");
            }

            string boardName = this.CommandParameters[0];
            string teamName = this.CommandParameters[1];

            return this.AddBoard(boardName, teamName);
        }

        private string AddBoard(string boardName, string teamName)
        {
            ITeam team = this.Repository.GetTeam(teamName);
            IBoard board = this.Repository.CreateBoard(boardName);


            foreach (var item in team.Boards)
            {
                if (boardName == item.Name)
                {
                    string errorMessage = $"Board {boardName} already exists. Choose a different name!";
                    throw new InvalidUserInputException(errorMessage);
                }
            }

            team.AddBoard(board);

            return $"Board {boardName} created successfully!";
        }
    }
}
