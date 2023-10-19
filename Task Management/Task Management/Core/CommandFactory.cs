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
                    return new ShowMemberActivityCommand(commandParameters, repository);
                case CommandType.CreateBoard:
                    return new CreateBoardCommand(commandParameters, repository);
                case CommandType.ShowBoards:
                    return new ShowBoardsCommand(commandParameters, repository);
                case CommandType.ShowBoardActivity:
                    return new ShowBoardActivityCommand(commandParameters, repository);
                case CommandType.CreateTeam:
                    return new CreateTeamCommand(commandParameters, repository);
                case CommandType.ShowTeams:
                    return new ShowTeamsCommand(repository);
                case CommandType.ShowTeamActivity:
                    return new ShowTeamActivityCommand(commandParameters, repository);
                case CommandType.AddTeamMember:
                    return new AddTeamMemberCommand(commandParameters, repository);
                case CommandType.ShowTeamMembers:
                    return new ShowTeamMembersCommand(commandParameters, repository);
                case CommandType.CreateBug:
                    return new CreateBugCommand(commandParameters, repository);
                case CommandType.ListBugs:
                    return new ListBugsCommand(commandParameters, repository);
                case CommandType.ChangeBugPriority:
                    return new ChangeBugPriorityCommand(commandParameters, repository);
                case CommandType.ChangeBugSeverity:
                    return new ChangeBugSeverityCommand(commandParameters, repository);
                case CommandType.ChangeBugStatus:
                    return new ChangeBugStatusCommand(commandParameters, repository);
                case CommandType.CreateStory:
                    return new CreateStoryCommand(commandParameters, repository);
                case CommandType.ListStories:
                    return new ListStoriesCommand(commandParameters, repository);
                case CommandType.ChangeStoryPriority:
                    return new ChangeStoryPriorityCommand(commandParameters, repository);
                case CommandType.ChangeStorySize:
                    return new ChangeStorySizeCommand(commandParameters, repository);
                case CommandType.ChangeStoryStatus:
                    return new ChangeStoryStatusCommand(commandParameters, repository);
                case CommandType.CreateFeedback:
                    return new CreateFeedbackCommand(commandParameters, repository);
                case CommandType.ListFeedback:
                    return new ListFeedbackCommand(commandParameters, repository);
                case CommandType.ChangeFeedbackRating:
                    return new ChangeFeedbackRatingCommand(commandParameters, repository);
                case CommandType.ChangeFeedbackStatus:
                    return new ChangeFeedbackStatusCommand(commandParameters, repository);
                case CommandType.AssignTask:
                    return new AssignTaskCommand(commandParameters, repository);
                case CommandType.UnassignTask:
                    return new UnassignTaskCommand(commandParameters, repository);
                case CommandType.ShowAssignees:
                    throw new NotImplementedException();
                case CommandType.ListTasks:
                    return new ListTasksCommand(commandParameters, repository);
                case CommandType.AddTaskComment:
                    return new AddTaskCommentCommand(commandParameters, repository);
                case CommandType.AddBugReproductionSteps:
                    return new AddBugReproductionStepsCommand(commandParameters, repository);
                case CommandType.ListAssignedTasks:
                    return new ListAssignedTasksCommand(commandParameters, repository);
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
