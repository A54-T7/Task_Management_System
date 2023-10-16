using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management.Core.Contracts;

namespace Task_Management.Commands.Comms
{
    public class ListFeedbackCommand : BaseCommand
    {
        public ListFeedbackCommand(List<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            throw new NotImplementedException();
        }
    }
}
