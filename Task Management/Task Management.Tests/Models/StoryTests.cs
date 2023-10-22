using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management.Models.Enums;
using Task_Management.Models;
using Task_Management.Exceptions;
using Task_Management.Models.Contracts;

namespace Task_Management.Tests.Models
{
    [TestClass]
    public class StoryTests
    {
        [TestMethod]
        public void Is_Priority_Low()
        {
            //Arrange
            string title = new string('a', 11);
            string description = new string('a', 11);
            int id = 10;
            PriorityType priorityType = new PriorityType();
            PriorityType low = PriorityType.Low;
            StorySizeType storySizeType = new StorySizeType();
            Story story = new Story(id, title, description, priorityType, storySizeType);

            //Acr & Assert
            Assert.ThrowsException<InvalidUserInputException>(() => story.ChangePriority(low));
        }

        [TestMethod]
        public void Is_Priority_Changed_To_Medium()
        {
            //Arrange
            string title = new string('a', 11);
            string description = new string('b', 11);
            int id = 10;
            PriorityType priorityType = new PriorityType();
            PriorityType medium = PriorityType.Medium;
            StorySizeType storySizeType = new StorySizeType();
            Story story = new Story(id, title, description, priorityType, storySizeType);

            //Act
            story.ChangePriority(medium);

            //Assert
            Assert.AreEqual(medium, story.Priority);
        }

        [TestMethod]
        public void Is_Priority_Changed_To_High()
        {
            //Arrange
            string title = new string('a', 11);
            string description = new string('b', 11);
            int id = 10;
            StorySizeType medium = StorySizeType.Medium;
            PriorityType priorityType = new PriorityType();
            StorySizeType storySizeType = new StorySizeType();
            Story story = new Story(id, title, description, priorityType, storySizeType);

            //Act
            story.ChangeSize(medium);

            //Assert
            Assert.AreEqual(medium, story.Size);
        }

        [TestMethod]
        public void Should_Throw_Exeption_When()
        {
            //Arrange
            string title = new string('a', 11);
            string description = new string('b', 11);
            int id = 10;
            StorySizeType small = StorySizeType.Small;
            PriorityType priorityType = new PriorityType();
            StorySizeType storySizeType = new StorySizeType();
            Story story = new Story(id, title, description, priorityType, storySizeType);
            
            //Act & Assert
            Assert.ThrowsException<InvalidUserInputException>(() => story.ChangeSize(small));
        }

        [TestMethod]
        public void ADd_ASsignee()
        {
            //Arrange
            int id = 1;
            string name = new string('a', 7);
            string title = new string('a', 15);
            string description = new string('a', 15);
            StorySizeType size = new StorySizeType();
            PriorityType priority = new PriorityType();
            SeverityType severity = new SeverityType();
            Member member = new Member(name);
            ITask task = new Bug(id, title, description, priority, severity);
            Story story = new Story(id, title, description, priority, size);
            member.AddTask(task);

            //Act
            story.AddAssignee(member);

            //Assert
            Assert.AreEqual(member, story.Assignee);
        }

        [TestMethod]
        public void Remove_Assignee()
        {
            //Arrange
            int id = 1;
            string name = new string('a', 7);
            string title = new string('a', 15);
            string description = new string('a', 15);
            StorySizeType size = new StorySizeType();
            PriorityType priority = new PriorityType();
            SeverityType severity = new SeverityType();
            ITask task = new Bug(id, title, description, priority, severity);
            Story story = new Story(id, title, description, priority, size);

            //Assert
            Assert.ThrowsException<InvalidUserInputException>(() => story.RemoveAssignee());
        }
    }
}
