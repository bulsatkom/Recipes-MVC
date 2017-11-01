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
    public class GetCommentForNovina_Should
    {
        [Test]
        public void ReturnModel_WhenThereIsAModelWithThePassedId()
        {
            //Arrange
            Guid Id = Guid.NewGuid();
            var Comments = new List<CommentsForNovini>()
            {
                 new CommentsForNovini()
               {
                    Author = "Author",
                    Content = "Content",
                    Date = DateTime.Now,
                    Id = Guid.NewGuid(),
                     NoviniId = Id
               }
            };

            var DbContextMock = new Mock<IEfDbSetWrapper<CommentsForNovini>>();
            var commentService = new CommentsForNoviniService(DbContextMock.Object);
            DbContextMock.Setup(x => x.All).Returns(Comments.AsQueryable);

            //Act
            var result = commentService.GetCommentForNovina(Id);

            //Assert
            Assert.AreEqual(Comments, result);
        }

        [Test]
        public void ReturnNull_WhenThereIsNoModelWithThePassedId()
        {
            //Arrange
            Guid Id = Guid.NewGuid();
            var Comments = new List<CommentsForNovini>()
            {
                 new CommentsForNovini()
               {
                    Author = "Author",
                    Content = "Content",
                    Date = DateTime.Now,
                    Id = Guid.NewGuid(),
                     NoviniId = Id
               }
            };

            var DbContextMock = new Mock<IEfDbSetWrapper<CommentsForNovini>>();
            var commentService = new CommentsForNoviniService(DbContextMock.Object);
            DbContextMock.Setup(x => x.All).Returns(Comments.AsQueryable);

            //Act
            var result = commentService.GetCommentForNovina(Guid.NewGuid());

            //Assert
            Assert.IsEmpty(result);
        }
    }
}
