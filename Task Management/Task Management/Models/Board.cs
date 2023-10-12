using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management.Models.Contracts;

namespace Task_Management.Models
{
    public class Board : IBoard
    {

        private string name;
        private List<ITask> tasks = new List<ITask>();
        private const int NameMinLength = 5;
        private const int NameMaxLength = 10;
        private const string NameErrorMessage = "Name must be between 5 and 10 characters long!";
        public Board(string name)
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

        public IList<ITask> Tasks
        {
            get
            {
                return new List<ITask>(tasks);
            }
        }

        //Add ActivityHistory
    }
}
