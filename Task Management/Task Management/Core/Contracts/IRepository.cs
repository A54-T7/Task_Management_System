using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management.Models.Contracts;
using Task_Management.Models.Enums;

namespace Task_Management.Core.Contracts
{
    public interface IRepository
    {
        IList<IMember> Members { get; }
        IList<ITeam> Teams { get; }
        IList<ITask> Tasks { get; }
        IList<IFeedback> Feedbacks { get; }
        IList<IBug> Bugs { get; }
        IList<IStory> Stories { get; }
        IMember CreateMember(string name);
        ITeam CreateTeam(string name);
        IBoard CreateBoard(string name);
        IFeedback CreateFeedback(string title, string description, int rating);
        IBug CreateBug(string title, string description, PriorityType priority, SeverityType severity);
        IStory CreateStory(string title, string description, PriorityType priority, StorySizeType size);
        public IComment CreateComment(string content, string author);
        void AddMember(IMember member);
        void AddTeam(ITeam team);
        bool MemberExist(string name);
        bool TeamExist(string name);
        IMember GetMember(string memberName);
        ITeam GetTeam(string teamName);
        IBoard GetBoard(string boardName, ITeam team);
        ITask GetTask(int ID);
        IFeedback GetFeedback(int ID);
        IBug GetBug(int ID);
        IStory GetStory(int ID);
    }
}
