using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management.Exceptions;
using Task_Management.Models;

namespace Task_Management.Tests.Models
{
    [TestClass]
    public class TeamTests
    {
        [TestMethod]
        public void Should_Add_TeamMember()
        {
            //Arrange
            string teamName = new string('s', 7);
            string memberName = new string('s', 7);
            Team team = new Team(teamName);
            Member member = new Member(memberName);

            //Act
            team.AddTeamMember(member);

            //Assert
            Assert.AreEqual(1, team.Members.Count);
        }

        [TestMethod]
        public void Should_Add_Board()
        {
            //Arrange
            string teamName = new string('a', 7);
            string boardName = new string('a', 7);
            Team team = new Team(teamName);
            Board board = new Board(boardName);

            //Act
            team.AddBoard(board);

            //Assert
            Assert.AreEqual(1, team.Boards.Count);
        }

        [TestMethod]
        public void Should_Add_ActivityLog()
        {
            //Arrange
            string teamName = new string('a', 7);
            string activity = new string('a', 7);
            Team team = new Team(teamName);

            //Act
            team.AddActivity(activity);

            //Assert
            Assert.AreEqual(2, team.ActivityLog.Count);
        }
    }
}
