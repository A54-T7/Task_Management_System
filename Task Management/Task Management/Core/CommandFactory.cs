using Task_Management.Commands.Comms;
using Task_Management.Commands.Contracts;
using Task_Management.Core.Contracts;
using Task_Management.Exceptions;
using Task_Management.Commands.Enums;

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Task_Management.Core
{
    public class CommandFactory : ICommandFactory
    {
        private const char SplitCommandSymbol = ' ';
        private const string CommentOpenSymbol = "{{";
        private const string CommentCloseSymbol = "}}";

        private readonly IRepository repository;

        public CommandFactory(IRepository repository)
        {
            this.repository = repository;
        }

        public ICommand Create(string commandLine)
        {
            CommandType commandType = ParseCommandType(commandLine);
            List<string> commandParameters = ExtractCommandParameters(commandLine);

            switch (commandType)
            {
                case CommandType.CreateMember:
                    return new CreateMemberCommand(commandParameters, repository);
                case CommandType.ShowMembers:
                    return new ShowMembersCommand(repository);
                case CommandType.ShowMemberActivity:
                    throw new NotImplementedException();
                case CommandType.CreateBoard:
                    throw new NotImplementedException();
                case CommandType.ShowBoards:
                    throw new NotImplementedException();
                case CommandType.ShowBoardActivity:
                    throw new NotImplementedException();
                case CommandType.CreateTeam:
                    return new CreateTeamCommand(commandParameters, repository);
                case CommandType.ShowTeams:
                    return new ShowTeamsCommand(repository);
                case CommandType.ShowTeamActivity:
                    throw new NotImplementedException();
                case CommandType.AddTeamMember:
                    return new AddTeamMemberCommand(commandParameters, repository);
                case CommandType.ShowTeamMembers:
                    throw new NotImplementedException();
                case CommandType.CreateBug:
                    throw new NotImplementedException();
                case CommandType.ShowBugs:
                    throw new NotImplementedException();
                case CommandType.ChangeBugPriority:
                    throw new NotImplementedException();
                case CommandType.ChangeBugSeverity:
                    throw new NotImplementedException();
                case CommandType.ChangeBugStatus:
                    throw new NotImplementedException();
                case CommandType.CreateStory:
                    throw new NotImplementedException();
                case CommandType.ShowStories:
                    throw new NotImplementedException();
                case CommandType.ChangeStoryPriority:
                    throw new NotImplementedException();
                case CommandType.ChangeStorySize:
                    throw new NotImplementedException();
                case CommandType.ChangeStoryStatus:
                    throw new NotImplementedException();
                case CommandType.CreateFeedback:
                    throw new NotImplementedException();
                case CommandType.ShowFeedback:
                    throw new NotImplementedException();
                case CommandType.ChangeFeedbackRating:
                    throw new NotImplementedException();
                case CommandType.ChangeFeedbackStatus:
                    throw new NotImplementedException();
                case CommandType.AssignPerson:
                    throw new NotImplementedException();
                case CommandType.UnassingPerson:
                    throw new NotImplementedException();
                case CommandType.ShowAssignees:
                    throw new NotImplementedException();
                case CommandType.ShowTasks:
                    throw new NotImplementedException();
                case CommandType.AddTaskComment:
                    throw new NotImplementedException();
                default:
                    throw new InvalidUserInputException($"Command with name: {commandType} doesn't exist!");
            }
        }


        // Receives a full line and extracts the command to be executed from it.
        // For example, if the input line is "FilterBy Assignee John", the method will return "FilterBy".
        private CommandType ParseCommandType(string commandLine)
        {
            string commandName = commandLine.Split(SplitCommandSymbol)[0];
            Enum.TryParse(commandName, true, out CommandType result);
            return result;
        }


        // Receives a full line and extracts the parameters that are needed for the command to execute.
        // For example, if the input line is "FilterBy Assignee John",
        // the method will return a list of ["Assignee", "John"].
        private List<string> ExtractCommandParameters(string commandLine)
        {
            List<string> parameters = new List<string>();

            var indexOfOpenComment = commandLine.IndexOf(CommentOpenSymbol);
            var indexOfCloseComment = commandLine.IndexOf(CommentCloseSymbol);
            if (indexOfOpenComment >= 0)
            {
                var commentStartIndex = indexOfOpenComment + CommentOpenSymbol.Length;
                var commentLength = indexOfCloseComment - CommentCloseSymbol.Length - indexOfOpenComment;
                string commentParameter = commandLine.Substring(commentStartIndex, commentLength);
                parameters.Add(commentParameter);

                Regex regex = new Regex("{{.+(?=}})}}");
                commandLine = regex.Replace(commandLine, string.Empty);
            }

            var indexOfFirstSeparator = commandLine.IndexOf(SplitCommandSymbol);
            parameters.AddRange(commandLine.Substring(indexOfFirstSeparator + 1).Split(new[] { SplitCommandSymbol }, StringSplitOptions.RemoveEmptyEntries));

            return parameters;
        }
    }
}
