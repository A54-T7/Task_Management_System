using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Management.Models.Contracts
{
    public interface IMember
    {
        string Name { get; }

        IList<ITask> Tasks { get; }
        IList<string> ActivityLog { get; }
        void AddActivity(string message);
        public void AddTask(ITask task);
        public void RemoveTask(ITask task);




        //IList<IActivityHistrory> ActivityHistory { get; }
    }
}
