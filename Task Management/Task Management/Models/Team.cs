using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Task_Management.Models.Contracts;

namespace Task_Management.Models
{
    internal class Team : ITeam
    {
        private const int NameMinLength = 5;
        private const int NameMaxLength = 15;
        private const string NameErrorMessage = "Name must be between 5 and 15 characters long!";

        private List<IMember> members = new List<IMember>();
        private List<IBoard> boards = new List<IBoard>();
        private List<string> activityLog = new List<string>();

        private string name;

        public Team(string name)
        {
            Name = name;
            AddActivity($"Created team: {Name}");
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                Validator.ValidateStringRange(value, NameMinLength, NameMaxLength, NameErrorMessage);
                name = value;
            }
        }

        public IList<IMember> Members
        {
            get
            {
                return new List<IMember>(members);
            }
        }

        public IList<IBoard> Boards
        {
            get
            {
                return new List<IBoard>(boards);
            }
        }

        public IList<string> ActivityLog
        {
            get
            {
                return new List<string>(activityLog);
            }
        }

        public void AddTeamMember(IMember member)
        {
            members.Add(member);
            AddActivity($"Added member: {member.Name}");
        }

        public void AddBoard(IBoard board)
        {
            boards.Add(board);
            AddActivity($"Created board: {board.Name}");
        }

        public void AddActivity(string message)
        {
            activityLog.Add($"{message} - [{DateTime.Now.ToString("yyyy-MM-dd|HH:mm:ss")}]");
        }

        public string PrintTeamMembers()
        {
            StringBuilder sb = new StringBuilder();
            var counter = 1;

            if (members.Count == 0)
            {
                sb.AppendLine("No members!");
            }
            else
            {
                foreach (var member in members)
                {
                    sb.AppendLine($"{counter}. {member.Name}");
                    counter++;
                }
            }

            return sb.ToString().Trim();
        }
    }
}
