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
        IList<IComment> Comments { get; }
        IList<string> ActivityLog { get; }
        void AddComment(IComment comment);
        void AdvanceStatus();
        void ReverseStatus();

        //ToDo

        //IList<IHistory> History { get; }
    }
}