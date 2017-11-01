using Moq;
using NUnit.Framework;
using Recepts.MVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recepts_MVC_DataServices;

namespace Recepts.UnitTests.Recepts.MVc.DataServices.Tests.ChatServiceTests
{
    [TestFixture]
    public class GetLatest30Messages_Should
    {
        [Test]
        public void ReturnLatest30Messages_When_There_Are_More_Than_30()
        {
            //Arrange
            ICollection<Chat> allMessages = new List<Chat>();
            for (int i = 0; i < 31; i++)
            {
                allMessages.Add(new Chat()
                {
                    Id = Guid.NewGuid(),
                    Author = "Author" + i,
                    Content = "Content" + i,
                    Date = DateTime.Now
                });
            }

            var DbContextMock = new Mock<IEfDbSetWrapper<Chat>>();
            DbContextMock.Setup(x => x.All).Returns(allMessages.AsQueryable());          
            var ChatService = new ChatService(DbContextMock.Object);

            //Act
            var result = ChatService.GetLatest30Messages();

            //Assert
            Assert.AreEqual(30, result.Count);
        }

        [Test]
        public void ReturnAllMessages_When_There_Are_Less_Than30()
        {
            //Arrange
            ICollection<Chat> allMessages = new List<Chat>();
            for (int i = 0; i < 25; i++)
            {
                allMessages.Add(new Chat()
                {
                    Id = Guid.NewGuid(),
                    Author = "Author" + i,
                    Content = "Content" + i,
                    Date = DateTime.Now
                });
            }

            var DbContextMock = new Mock<IEfDbSetWrapper<Chat>>();
            DbContextMock.Setup(x => x.All).Returns(allMessages.AsQueryable());
            var ChatService = new ChatService(DbContextMock.Object);

            //Act
            var result = ChatService.GetLatest30Messages();

            //Assert
            Assert.AreEqual(25, result.Count);
        }
    }
}
