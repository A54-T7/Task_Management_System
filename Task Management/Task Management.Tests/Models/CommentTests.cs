using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Assert.IsNotNull(comment);
        }

    }
}
