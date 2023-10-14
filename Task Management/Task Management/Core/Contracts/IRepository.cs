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
        IMember CreateMember(string name);
        ITeam CreateTeam(string name);
        IBoard CreateBoard(string name);
        void AddMember(IMember member);
        void AddTeam(ITeam team);
        bool MemberExist(string name);
        bool TeamExist(string name);
        IMember GetMember(string memberName);
        ITeam GetTeam(string teamName);

    }
}
