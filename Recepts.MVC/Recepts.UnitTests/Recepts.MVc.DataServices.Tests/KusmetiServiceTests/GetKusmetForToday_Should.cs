using Moq;
using NUnit.Framework;
using Recepts.MVC.Data;
using Recepts_MVC_DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recepts.UnitTests.Recepts.MVc.DataServices.Tests.KusmetiServiceTests
{
    [TestFixture]
    public class GetKusmetForToday_Should
    {
        [Test]
        public void ReturnCorrectString_WhenContainsKusmetForToday()
        {
            //Arrange
            string kusmetString = "kusmet";
            var DbContextMock = new Mock<IEfDbSetWrapper<Kusmeti>>();
            var kusmetiService = new KusmetiService(DbContextMock.Object);
            List<Kusmeti> kusmeti = new List<Kusmeti>()
            {
                    new Kusmeti()
                {
                    Id = Guid.NewGuid(),
                    Date = DateTime.Now.Date,
                    Kusmet = kusmetString
                },
            };

            DbContextMock.Setup(x => x.All).Returns(kusmeti.AsQueryable);

            //Act
            string result = kusmetiService.GetKusmetForToday();

            //Assert
            Assert.AreEqual(kusmetString, result);
        }

        [Test]
        public void ReturnEmptyString_WhenNotContainsKusmetForToday()
        {
            //Arrange
            string kusmetString = "kusmet";
            var DbContextMock = new Mock<IEfDbSetWrapper<Kusmeti>>();
            var kusmetiService = new KusmetiService(DbContextMock.Object);
            List<Kusmeti> kusmeti = new List<Kusmeti>()
            {
                    new Kusmeti()
                {
                    Id = Guid.NewGuid(),
                    Date = new DateTime(2005, 12, 12),
                    Kusmet = kusmetString
                },
            };

            DbContextMock.Setup(x => x.All).Returns(kusmeti.AsQueryable);

            //Act
            string result = kusmetiService.GetKusmetForToday();

            //Assert
            Assert.IsNull(result);
        }
    }
}
