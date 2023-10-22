using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management.Models;
using Task_Management.Models.Contracts;
using Task_Management.Models.Enums;

namespace Task_Management.Tests.Models
{
    [TestClass]
    public class MemberTests
    {
        [TestMethod]
        public void Should_Add_ActivityLog()
        {
            //Arrange
            string memberName = new string('a', 7);
            string activity = new string('a', 7);
            Member member = new Member(memberName);

            //Act
            member.AddActivity(activity);

            //Assert
            Assert.AreEqual(2, member.ActivityLog.Count);
        }

        [TestMethod]
        public void Should_Add_Tasks()
        {
            //Arrange
            int id = 1;
            string name = new string('a', 7);
            string title = new string('a', 15);
            string description = new string('a', 15);
            PriorityType priority = new PriorityType();
            SeverityType severity = new SeverityType();
            Member member = new Member(name);
            ITask task = new Bug(id, title, description, priority, severity);

            //Act
            member.AddTask(task);

            //Assert
            Assert.AreEqual(1, member.Tasks.Count);
        }

        [TestMethod]
        public void Should_Remove_Tasks()
        {
            //Arrange
            int id = 1;
            string name = new string('a', 7);
            string title = new string('a', 15);
            string description = new string('a', 15);
            PriorityType priority = new PriorityType();
            SeverityType severity = new SeverityType();
            Member member = new Member(name);
            ITask task = new Bug(id, title, description, priority, severity);

            //Act
            member.RemoveTask(task);

            //Assert
            Assert.AreEqual(0, member.Tasks.Count);
        }
    }
}
