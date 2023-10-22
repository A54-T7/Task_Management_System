using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Task_Management.Core;
using Task_Management.Core.Contracts;
using Task_Management.Models;
using Task_Management.Models.Contracts;
using Task_Management.Models.Enums;
using Task = Task_Management.Models.Task;

namespace Task_Management.Tests.Core
{
    [TestClass]
    public class RepositoryTests
    {
        private readonly Repository repository = new Repository();
        [TestMethod]
        public void Members_Should_ReturnCopyOfTheCollection()
        {
            // Arrange
            string name = "Valid Name";

            // Act
            Member member = new Member(name);
            repository.Members.Add(member);

            // Assert
            Assert.AreEqual(0, repository.Members.Count);
        }

        [TestMethod]
        public void Teams_Should_ReturnCopyOfTheCollection()
        {
            // Arrange
            string name = "Valid Name";

            // Act
            Team team = new Team(name);
            repository.Teams.Add(team);

            // Assert
            Assert.AreEqual(0, repository.Teams.Count);
        }

        [TestMethod]
        public void Feedbacks_Should_ReturnCopyOfTheCollection()
        {
            // Arrange
            int id = 10;
            string title = new string('a', 15);
            string description = new string('b', 15);
            int rating = 5;

            // Act
            Feedback feedback = new Feedback(id, title, description, rating);
            repository.Feedbacks.Add(feedback);

            // Assert
            Assert.AreEqual(0, repository.Feedbacks.Count);
        }

        [TestMethod]
        public void Bug_Should_ReturnCopyOfTheCollection()
        {
            // Arrange
            int id = 10;
            string title = new string('a', 15);
            string description = new string('b', 15);
            PriorityType priority = new PriorityType();
            SeverityType severity = new SeverityType();

            // Act
            Bug bug = new Bug(id, title, description, priority, severity);
            repository.Bugs.Add(bug);

            // Assert
            Assert.AreEqual(0, repository.Bugs.Count);
        }

        [TestMethod]
        public void Stories_Should_ReturnCopyOfTheCollection()
        {
            // Arrange
            int id = 10;
            string title = new string('a', 15);
            string description = new string('b', 15);
            PriorityType priority = new PriorityType();
            StorySizeType size = new StorySizeType();

            // Act
            Story story = new Story(id, title, description, priority, size);
            repository.Stories.Add(story);

            // Assert
            Assert.AreEqual(0, repository.Stories.Count);
        }


        [TestMethod]
        public void CreateMember_Should_CreateNewMember()
        {
            //Arrange
            string name = "Valid Name";
            //Act
            IMember member = repository.CreateMember(name);
            //Assert
            Assert.AreEqual("Valid Name", member.Name);
        }

        [TestMethod]
        public void CreateTeam_Should_CreateNewTeam()
        {
            //Arrange
            string name = "Valid Name";
            //Act
            ITeam team = repository.CreateTeam(name);
            //Assert
            Assert.AreEqual("Valid Name", team.Name);
        }

        [TestMethod]
        public void CreateBoard_Should_CreateNewBoard()
        {
            //Arrange
            string name = "Valid Name";
            //Act
            IBoard board = repository.CreateBoard(name);
            //Assert
            Assert.AreEqual("Valid Name", board.Name);
        }

        [TestMethod]
        public void CreateFeedback_Should_CreateNewFeedback()
        {
            //Arrange
            string title = new string('a', 15);
            string description = new string('b', 15);
            int rating = 5;

            // Act
            IFeedback feedback = repository.CreateFeedback(title, description, rating);

            //Assert
            Assert.AreEqual(new string('a', 15), feedback.Title);
            Assert.AreEqual(new string('b', 15), feedback.Description);
            Assert.AreEqual(5, feedback.Rating);
        }

        [TestMethod]
        public void CreateBug_Should_CreateNewBug()
        {
            //Arrange
            string title = new string('a', 15);
            string description = new string('b', 15);
            PriorityType priority = PriorityType.Low;
            SeverityType severity = SeverityType.Major;

            // Act
            IBug bug = repository.CreateBug(title, description, priority, severity);

            //Assert
            Assert.AreEqual(new string('a', 15), bug.Title);
            Assert.AreEqual(new string('b', 15), bug.Description);
            Assert.AreEqual(PriorityType.Low, bug.Priority);
            Assert.AreEqual(SeverityType.Major, bug.Severity);
        }

        [TestMethod]
        public void CreateStory_Should_CreateNewStory()
        {
            //Arrange
            string title = new string('a', 15);
            string description = new string('b', 15);
            PriorityType priority = PriorityType.Low;
            StorySizeType size = StorySizeType.Large;

            // Act
            IStory story = repository.CreateStory(title, description, priority, size);

            //Assert
            Assert.AreEqual(new string('a', 15), story.Title);
            Assert.AreEqual(new string('b', 15), story.Description);
            Assert.AreEqual(PriorityType.Low, story.Priority);
            Assert.AreEqual(StorySizeType.Large, story.Size);
        }

        [TestMethod]
        public void CreateComment_Should_CreateNewComment()
        {
            //Arrange
            string content = "Valid Content";
            string author = "Valid Author";
            //Act
            IComment comment = repository.CreateComment(content, author);
            //Assert
            Assert.AreEqual("Valid Content", comment.Content);
            Assert.AreEqual("Valid Author", comment.Author);
        }

        [TestMethod]
        public void AddMember_Should_AddMemberToTheCollection()
        {
            //Arrange
            string name = "Valid Name";
            //Act
            IMember member = new Member(name);
            repository.AddMember(member);
            //Assert
            Assert.AreEqual(1, repository.Members.Count);
        }

        [TestMethod]
        public void AddTeam_Should_AddTeamToTheCollection()
        {
            //Arrange
            string name = "Valid Name";
            //Act
            ITeam team = new Team(name);
            repository.AddTeam(team);
            //Assert
            Assert.AreEqual(1, repository.Teams.Count);
        }

        [TestMethod]
        public void MemberExist_Should_ReturnTrue_IfTheMemberExists()
        {
            //Arrange
            string name = "Valid Name";
            //Act
            IMember member = new Member(name);
            repository.AddMember(member);
            //Assert
            Assert.AreEqual(true, repository.MemberExist("Valid Name"));
        }

        [TestMethod]
        public void TeamExist_Should_ReturnTrue_IfTheTeamExists()
        {
            //Arrange
            string name = "Valid Name";
            //Act
            ITeam team = new Team(name);
            repository.AddTeam(team);
            //Assert
            Assert.AreEqual(true, repository.TeamExist("Valid Name"));
        }

        [TestMethod]
        public void GetMember_Should_ReturnTheMember_IfTheMemberExists()
        {
            //Arrange
            string name = "Valid Name";
            //Act
            IMember member = new Member(name);
            repository.AddMember(member);
            //Assert
            Assert.AreEqual(member, repository.GetMember("Valid Name"));
        }

        [TestMethod]
        public void GetTeam_Should_ReturnTheTeam_IfTheTeamExists()
        {
            //Arrange
            string name = "Valid Name";
            //Act
            ITeam team = new Team(name);
            repository.AddTeam(team);
            //Assert
            Assert.AreEqual(team, repository.GetTeam("Valid Name"));
        }

        [TestMethod]
        public void GetBoard_Should_ReturnTheBoard_IfTheBoardExists()
        {
            //Arrange
            string name = "Valid Name";
            //Act
            IBoard board = new Board(name);
            ITeam team = new Team(name);
            team.AddBoard(board);
            //Assert
            Assert.AreEqual(board, repository.GetBoard("Valid Name", team));
        }

        [TestMethod]
        public void GetFeedback_Should_ReturnTheFeedback_IfTheFeedbackExists()
        {
            //Arrange
            string title = new string('a', 15);
            string description = new string('b', 15);
            int rating = 5;
            //Act
            IFeedback feedback = repository.CreateFeedback(title, description, rating);
            //Assert
            Assert.AreEqual(feedback, repository.GetFeedback(feedback.Id));
        }

        [TestMethod]
        public void GetBug_Should_ReturnTheBug_IfTheBugExists()
        {
            //Arrange
            string title = new string('a', 15);
            string description = new string('b', 15);
            PriorityType priority = PriorityType.Low;
            SeverityType severity = SeverityType.Major;

            // Act
            IBug bug = repository.CreateBug(title, description, priority, severity);
            //Assert
            Assert.AreEqual(bug, repository.GetBug(bug.Id));
        }

        [TestMethod]
        public void GetStory_Should_ReturnTheStory_IfTheStoryExists()
        {
            //Arrange
            string title = new string('a', 15);
            string description = new string('b', 15);
            PriorityType priority = PriorityType.Low;
            StorySizeType size = StorySizeType.Large;

            // Act
            IStory story = repository.CreateStory(title, description, priority, size);
            //Assert
            Assert.AreEqual(story, repository.GetStory(story.Id));
        }
    }
}
