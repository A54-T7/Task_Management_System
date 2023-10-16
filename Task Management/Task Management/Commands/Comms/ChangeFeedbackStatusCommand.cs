using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management.Core.Contracts;
using Task_Management.Exceptions;
using Task_Management.Models.Contracts;

namespace Task_Management.Commands.Comms
{
    public class ChangeFeedbackStatusCommand : BaseCommand
    {
        public ChangeFeedbackStatusCommand(List<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            throw new NotImplementedException();
        }
    }
}
