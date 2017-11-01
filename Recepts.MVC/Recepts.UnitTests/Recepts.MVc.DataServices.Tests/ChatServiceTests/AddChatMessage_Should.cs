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
    public class AddChatMessage_Should
    {
        [Test]
        public void ThrowExceptionWhen_Author_IsNull()
        {
            //Arrange
            var DbContextMock = new Mock<IEfDbSetWrapper<Chat>>();
            var ChatService = new ChatService(DbContextMock.Object);

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => ChatService.AddChatMessage(null, "Content"));
        }

        [Test]
        public void ThrowExceptionWhen_Content_IsNull()
        {
            //Arrange
            var DbContextMock = new Mock<IEfDbSetWrapper<Chat>>();
            var ChatService = new ChatService(DbContextMock.Object);

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => ChatService.AddChatMessage("Author", null));
        }

        [Test]
        public void ThrowExceptionWhen_Content_And_Author_AreNull()
        {
            //Arrange
            var DbContextMock = new Mock<IEfDbSetWrapper<Chat>>();
            var ChatService = new ChatService(DbContextMock.Object);

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => ChatService.AddChatMessage(null, null));
        }
    }
}
