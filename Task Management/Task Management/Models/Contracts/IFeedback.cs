using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management.Models.Enums;

namespace Task_Management.Models.Contracts
{
    public interface IFeedback : ITask
    {
        int Rating { get; set; }
        FeedbackStatusType Status { get; }
        //ToDo

        //IList<IComments> Comments { get; }

        //IList<IHistory> History { get; }
    }
}
