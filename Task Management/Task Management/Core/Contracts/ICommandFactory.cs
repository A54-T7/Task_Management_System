using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management.Commands.Contracts;

namespace Task_Management.Core.Contracts
{
    public interface ICommandFactory
    {
        ICommand Create(string commandLine);
    }
}
