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
using Task_Management.Models.Enums;

namespace Task_Management.Core
{
    public class Repository : IRepository
    {
        private readonly IList<IMember> members = new List<IMember>();
        private readonly IList<ITeam> teams = new List<ITeam>();
        private readonly IList<ITask> tasks = new List<ITask>();

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

        public IList<ITask> Tasks
        {
            get
            {
                var tasksCopy = new List<ITask>(tasks);
                return tasksCopy;
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

        public IFeedback CreateFeedback(string title, string description, int rating)
        {
            var nextId = tasks.Count;
            var feedback = new Feedback(++nextId, title, description, rating);

            tasks.Add(feedback);
            return feedback;
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

        public IBoard GetBoard(string boardName, ITeam team)
        {
            foreach (var board in team.Boards)
            {
                if (board.Name.Equals(boardName, StringComparison.InvariantCultureIgnoreCase))
                {
                    return board;
                }
            }

            throw new EntityNotFoundException($"There is no board with name {boardName}!");
        }

        public ITask GetTask(int ID)
        {
            foreach (var task in tasks)
            {
                if (task.Id == ID)
                {
                    return task;
                }
            }

            throw new EntityNotFoundException($"There is no task with ID {ID}");
        }
    }
}
