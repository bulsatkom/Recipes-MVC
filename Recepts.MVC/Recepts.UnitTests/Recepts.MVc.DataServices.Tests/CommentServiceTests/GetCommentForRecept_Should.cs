using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recepts.MVC.Data;
using Moq;
using Recepts_MVC_DataServices;

namespace Recepts.UnitTests.Recepts.MVc.DataServices.Tests.CommentServiceTests
{
    [TestFixture]
    public class GetCommentForRecept_Should
    {
        [Test]
        public void ReturnModel_WhenThereIsAModelWithThePassedId()
        {
            //Arrange
            Guid Id = Guid.NewGuid();
            var Comments = new List<Comment>()
            {
                 new Comment()
               {
                    Author = "Author",
                    Content = "Content",
                    Date = DateTime.Now,
                    Id = Guid.NewGuid(),
                    ReceptId = Id
               }
            };

            var DbContextMock = new Mock<IEfDbSetWrapper<Comment>>();
            var commentService = new CommentService(DbContextMock.Object);
            DbContextMock.Setup(x => x.All).Returns(Comments.AsQueryable);

            //Act
            var result = commentService.GetCommentForRecept(Id);

            //Assert
            Assert.AreEqual(Comments, result);
        }

        [Test]
        public void ReturnNull_WhenThereIsNoModelWithThePassedId()
        {
            //Arrange
            Guid Id = Guid.NewGuid();
            var Comments = new List<Comment>()
            {
                 new Comment()
               {
                    Author = "Author",
                    Content = "Content",
                    Date = DateTime.Now,
                    Id = Guid.NewGuid(),
                    ReceptId = Id
               }
            };

            var DbContextMock = new Mock<IEfDbSetWrapper<Comment>>();
            var commentService = new CommentService(DbContextMock.Object);
            DbContextMock.Setup(x => x.All).Returns(Comments.AsQueryable);

            //Act
            var result = commentService.GetCommentForRecept(Guid.NewGuid());

            //Assert
            Assert.IsEmpty(result);
        }
    }
}
