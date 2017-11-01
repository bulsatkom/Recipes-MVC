using Moq;
using NUnit.Framework;
using Recepts.MVC.Data;
using Recepts.MVC.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recepts.UnitTests.Recepts.MVc.DataServices.Tests.CommentsForNoviniServiceTests
{
    [TestFixture]
    public class AddCommentForNovina_Should
    {
        [Test]
        public void ThrowExceptionWhen_Author_IsNull()
        {
            //Arrange
            var DbContextMock = new Mock<IEfDbSetWrapper<CommentsForNovini>>();
            var commentService = new CommentsForNoviniService(DbContextMock.Object);

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => commentService.AddCommentForNovina(Guid.NewGuid(), null, "Content"));
        }

        [Test]
        public void ThrowExceptionWhen_Content_IsNull()
        {
            //Arrange
            var DbContextMock = new Mock<IEfDbSetWrapper<CommentsForNovini>>();
            var commentService = new CommentsForNoviniService(DbContextMock.Object);

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => commentService.AddCommentForNovina(Guid.NewGuid(), "Author", null));
        }

        [Test]
        public void ThrowExceptionWhen_Content_And_Author_AreNull()
        {
            //Arrange
            var DbContextMock = new Mock<IEfDbSetWrapper<CommentsForNovini>>();
            var commentService = new CommentsForNoviniService(DbContextMock.Object);

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => commentService.AddCommentForNovina(Guid.NewGuid(), null, null));
        }
    }
}
