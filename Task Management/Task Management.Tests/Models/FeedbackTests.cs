using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management.Exceptions;
using Task_Management.Models;
using Task_Management.Models.Enums;

namespace Task_Management.Tests.Models
{
    [TestClass]
    public class FeedbackTests
    {
        [TestMethod]
        public void Check_If_Task_Construct_Create_Valid_Instance()
        {
            //Arrange
            int id = 10;
            string title = new string('a', 15);
            string description = new string('b', 15);
            int rating = 5;


            //Act
            Feedback name = new Feedback(id, title, description, rating);

            //Assert

            Assert.IsNotNull(name);
        }

        [TestMethod]
        public void Construct_Should_Throw_Exception_When_Title_Is_ToShort()
        {
            //Arrange
            int id = 10;
            string title = new string('a', 1);
            string description = new string('b', 15);
            int rating = 5;

            //Act & Assert

            Assert.ThrowsException<InvalidUserInputException>(() => new Feedback(id, title, description, rating));
        }

        [TestMethod]
        public void Construct_Should_Throw_Exception_When_Title_Is_ToLong()
        {
            //Arrange
            int id = 10;
            string title = new string('a', 51);
            string description = new string('b', 15);
            int rating = 5;

            //Act & Assert

            Assert.ThrowsException<InvalidUserInputException>(() => new Feedback(id, title, description, rating));
        }
        [TestMethod]
        public void Construct_Should_Throw_Exception_When_Description_Is_ToShort()
        {
            //Arrange
            int id = 10;
            string title = new string('a', 15);
            string description = new string('b', 5);
            int rating = 5;

            //Act & Assert

            Assert.ThrowsException<InvalidUserInputException>(() => new Feedback(id, title, description, rating));
        }
        [TestMethod]
        public void Construct_Should_Throw_Exception_When_Description_Is_ToLong()
        {
            //Arrange
            int id = 10;
            string title = new string('a', 15);
            string description = new string('b', 505);
            int rating = 5;

            //Act & Assert

            Assert.ThrowsException<InvalidUserInputException>(() => new Feedback(id, title, description, rating));
        }
        [TestMethod]
        public void Member_AddComent_Should_AddNewComment_When_Comment_Is_Valid()
        {
            //Arrange
            int id = 10;
            string title = new string('a', 15);
            string description = new string('b', 15);
            int rating = 5;

            Feedback feedback = new Feedback(id, title, description, rating);
            Comment comment = new Comment("aaaaa", "aaaaaa");

            //Act
            feedback.AddComment(comment);

            //Assert
            Assert.AreEqual(1, feedback.Comments.Count);
        }
        [TestMethod]
        public void Should_Add_ActivityLog()
        {
            //Arrange
            int id = 10;
            string title = new string('a', 15);
            string description = new string('b', 15);
            int rating = 5;
            string activity = new string('a', 7);
            Feedback member = new Feedback(id, title, description, rating);

            //Act
            member.AddActivity(activity);

            //Assert
            Assert.AreEqual(2, member.ActivityLog.Count);
        }

        [TestMethod]
        public void Change_Rating()
        {
            int id = 10;
            string title = new string('a', 15);
            string description = new string('a', 20);
            int rating = 5;
            int newRating = 5;
            string addActMess = new string('a', 5);

            Feedback na = new Feedback(id, title, description, rating);
            na.ChangeRating(newRating);

            Assert.AreEqual(rating, newRating);
        }

        [TestMethod]
        public void Should_Advance_Status()
        {
            //Arrange
            int id = 10;
            string title = new string('a', 15);
            string description = new string('b', 15);
            int rating = 5;
            FeedbackStatusType status = new FeedbackStatusType();
            FeedbackStatusType done = FeedbackStatusType.Done;
            Feedback feedback = new Feedback(id, title, description, rating);

            //Act
            feedback.AdvanceStatus();

            //Assert
            Assert.AreNotEqual(status, done);
        }
    }
}
