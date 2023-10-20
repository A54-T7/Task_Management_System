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
    public class CommentTests
    {
        [TestMethod]
        public void Valid_Comment_Author()
        {
            //Arrange
            string author = new string('a', 15);
            string content = new string('s', 10);

            //Act
            Comment comment = new Comment(author, content);

            //Assert
            Assert.IsNotNull(comment.Author);
        }

        [TestMethod]
        public void Valid_Comment_Content()
        {
            //Arrange
            string author = new string('a', 15);
            string content = new String('s', 5);

            //Act
            Comment comment = new Comment(author, content);
            //Aassert
            Assert.IsNotNull(comment.Content);
        }

        [TestMethod]
        public void Should_Throw_Exception_When_Author_Is_ToShort() 
        {
            //Arrange
            string author = new String('a', 1);
            string content = new String('s', 5);

            //Act & Assert
            Assert.ThrowsException<InvalidUserInputException>(() => new Comment(content, author));
        }

        [TestMethod]
        public void Should_Throw_Exception_When_Author_Is_ToLong()
        {
            //Arrange
            string author = new String('a', 16);
            string content = new String('s', 5);

            //Act & Assert
            Assert.ThrowsException<InvalidUserInputException>(() => new Comment(content, author));
        }

        [TestMethod]
        public void Should_Throw_Exception_When_Content_Is_ToShort()
        {
            //Arrange
            string author = new String('a', 15);
            string content = new String('s', 0);

            //Act & Assert
            Assert.ThrowsException<InvalidUserInputException>(() => new Comment(content, author));
        }

        [TestMethod]
        public void Should_Throw_Exception_When_Content_Is_ToLong()
        {
            //Arrange
            string author = new String('a', 15);
            string content = new String('s', 10001);

            //Act & Assert
            Assert.ThrowsException<InvalidUserInputException>(() => new Comment(content, author));
        }
    }
}
