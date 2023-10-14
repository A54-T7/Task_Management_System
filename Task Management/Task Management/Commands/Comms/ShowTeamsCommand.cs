using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management.Core.Contracts;
using Task_Management.Models;

namespace Task_Management.Commands.Comms
{
    public class ShowTeamsCommand : BaseCommand
    {
        public ShowTeamsCommand(IRepository repository)
            : base(repository)
        {
        }

        protected override string ExecuteCommand()
        {
            return this.ShowAllTeams();
        }

        private string ShowAllTeams()
        {
            StringBuilder sb = new StringBuilder();
            int counter = 1;

            sb.AppendLine("--TEAMS--");
            foreach (var team in this.Repository.Teams)
            {
                sb.AppendLine($"{counter}. {team.Name}");
                counter++;
            }

            return sb.ToString().Trim();
        }
    }
}
