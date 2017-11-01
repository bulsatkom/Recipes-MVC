using Moq;
using NUnit.Framework;
using Recepts.MVC.Data;
using Recepts_MVC_DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recepts.UnitTests.Recepts.MVc.DataServices.Tests.CommentServiceTests
{
    [TestFixture]
    public class AddComment_Should
    {
        [Test]
        public void ThrowExceptionWhen_Author_IsNull()
        {
            //Arrange
            var DbContextMock = new Mock<IEfDbSetWrapper<Comment>>();
            var commentService = new CommentService(DbContextMock.Object);

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => commentService.AddComment(Guid.NewGuid(), null, "Content"));
        }

        [Test]
        public void ThrowExceptionWhen_Content_IsNull()
        {
            //Arrange
            var DbContextMock = new Mock<IEfDbSetWrapper<Comment>>();
            var commentService = new CommentService(DbContextMock.Object);

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => commentService.AddComment(Guid.NewGuid(), "Author", null));
        }

        [Test]
        public void ThrowExceptionWhen_Content_And_Author_AreNull()
        {
            //Arrange
            var DbContextMock = new Mock<IEfDbSetWrapper<Comment>>();
            var commentService = new CommentService(DbContextMock.Object);

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => commentService.AddComment(Guid.NewGuid(), null, null));
        }
    }
}
