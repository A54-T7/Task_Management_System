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
        ShowBugs,
        ChangeBugPriority,
        ChangeBugSeverity,
        ChangeBugStatus,
        CreateStory,
        ShowStories,
        ChangeStoryPriority,
        ChangeStorySize,
        ChangeStoryStatus,
        CreateFeedback,
        ShowFeedback,
        ChangeFeedbackRating,
        ChangeFeedbackStatus,
        AssignPerson, //AssignTask
        UnassingPerson, //UnassignTask
        ShowAssignees,
        ShowTasks,
        AddTaskComment
    }
}
