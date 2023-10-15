using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Management.Models.Contracts
{
    public interface ITask
    {
        string Title { get; }
        string Description { get; }
        int Id { get; }

        //ToDo

        //IList<IComments> Comments { get; }

        //IList<IHistory> History { get; }
    }
}