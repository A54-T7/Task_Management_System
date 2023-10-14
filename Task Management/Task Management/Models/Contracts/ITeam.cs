using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Management.Models.Contracts
{
    public interface ITeam
    {
        string Name { get; }
        IList<IMember> Members { get; }
        IList<IBoard> Boards { get; }
        void AddTeamMember(IMember member);
        void AddBoard(IBoard board);
        string PrintTeamMembers();
    }
}
