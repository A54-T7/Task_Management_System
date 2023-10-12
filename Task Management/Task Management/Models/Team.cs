using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management.Models.Contracts;

namespace Task_Management.Models
{
    internal class Team : ITeam
    {
        private string name;
        private List<IMember> members = new List<IMember>();
        private List<IBoard> boards = new List<IBoard>();
        private const int NameMinLength = 5;
        private const int NameMaxLength = 15;
        private const string NameErrorMessage = "Name must be between 5 and 15 characters long!";

        public Team(string name)
        {
            Name = name;
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

    }
}
