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
    public class Constructor_Should
    {
        [Test]
        public void Return_An_Instance_When_Parameter_Is_NotNull()
        {
            //Arrange
            var DbContextMock = new Mock<IEfDbSetWrapper<CommentsForNovini>>();

            //Act
            var commentService = new CommentsForNoviniService(DbContextMock.Object);

            //Assert
            Assert.IsNotNull(commentService);
        }

        [Test]
        public void Throw_Exception_Wnen_Parameter_IsNull()
        {
            //Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new CommentsForNoviniService(null));
        }
    }
}
