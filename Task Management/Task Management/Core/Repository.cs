using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management.Core.Contracts;
using Task_Management.Models;
using Task_Management.Models.Contracts;
using Task_Management.Exceptions;

namespace Task_Management.Core
{
    public class Repository : IRepository
    {
        private readonly IList<IMember> members = new List<IMember>();
        private readonly IList<ITeam> teams = new List<ITeam>();

        public IList<IMember> Members
        {
            get
            {
                var membersCopy = new List<IMember>(members);
                return membersCopy;
            }
        }

        public IList<ITeam> Teams
        {
            get
            {
                var teamsCopy = new List<ITeam>(teams);
                return teamsCopy;
            }
        }

        public IMember CreateMember(string name)
        {
            return new Member(name);
        }

        public ITeam CreateTeam(string name)
        {
            return new Team(name);
        }
        public IBoard CreateBoard(string name)
        {
            return new Board(name);
        }

        public void AddMember(IMember member)
        {
            if (!members.Contains(member))
            {
                members.Add(member);
            }
        }
        public void AddTeam(ITeam team)
        {
            if (!teams.Contains(team))
            {
                teams.Add(team);
            }
        }

        public bool MemberExist(string name)
        {
            bool result = false;
            foreach (IMember member in members)
            {
                if (member.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        public bool TeamExist(string name)
        {
            bool result = false;
            foreach (ITeam team in teams)
            {
                if (team.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        public IMember GetMember(string memberName)
        {
            foreach (IMember member in members)
            {
                if (member.Name.Equals(memberName, StringComparison.InvariantCultureIgnoreCase))
                {
                    return member;
                }
            }
            throw new EntityNotFoundException($"There is no member with name {memberName}!");
        }

        public ITeam GetTeam(string teamName)
        {
            foreach (ITeam team in teams)
            {
                if (team.Name.Equals(teamName, StringComparison.InvariantCultureIgnoreCase))
                {
                    return team;
                }
            }
            throw new EntityNotFoundException($"There is no team with name {teamName}!");
        }

        
    }
}
