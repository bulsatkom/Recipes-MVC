using Moq;
using NUnit.Framework;
using Recepts.MVC.Data;
using Recepts_MVC_DataServices;
using System;

namespace Recepts.UnitTests.Recepts.MVc.DataServices.Tests.NoviniServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Return_An_Instance_When_Parameter_Is_NotNull()
        {
            //Arrange
            var DbContextMock = new Mock<IEfDbSetWrapper<Novini>>();

            //Act
            var noviniService = new NoviniService(DbContextMock.Object);

            //Assert
            Assert.IsNotNull(noviniService);
        }

        [Test]
        public void Throw_Exception_Wnen_Parameter_IsNull()
        {
            //Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new NoviniService(null));
        }
    }
}
