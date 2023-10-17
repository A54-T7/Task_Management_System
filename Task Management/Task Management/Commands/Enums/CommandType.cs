using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Management.Commands.Enums
{
    public enum CommandType
    {
        CreateMember,
        ShowMembers,
        ShowMemberActivity,
        CreateBoard,
        ShowBoards,
        ShowBoardActivity,
        CreateTeam,
        ShowTeams,
        ShowTeamActivity,
        AddTeamMember,
        ShowTeamMembers,
        CreateBug,
        ListBugs,
        ChangeBugPriority,
        ChangeBugSeverity,
        ChangeBugStatus,
        CreateStory,
        ShowStories,
        ChangeStoryPriority,
        ChangeStorySize,
        ChangeStoryStatus,
        CreateFeedback,
        ListFeedback,
        ChangeFeedbackRating,
        ChangeFeedbackStatus,
        AssignPerson,
        UnassingPerson,
        ShowAssignees,
        ListTasks,
        AddTaskComment
    }
}
