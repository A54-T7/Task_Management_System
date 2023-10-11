using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Management.Commands.Contracts
{
    public interface ICommand
    {
        string Execute();
    }
}
