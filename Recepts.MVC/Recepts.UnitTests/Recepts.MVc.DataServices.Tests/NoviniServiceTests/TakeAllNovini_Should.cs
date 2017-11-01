using Moq;
using NUnit.Framework;
using Recepts.MVC.Data;
using Recepts_MVC_DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recepts.UnitTests.Recepts.MVc.DataServices.Tests.NoviniServiceTests
{
    [TestFixture]
    public class TakeAllNovini_Should
    {
        [Test]
        public void ReturnCorrectNoviniCount()
        {
            //Arrange
            var DbContextMock = new Mock<IEfDbSetWrapper<Novini>>();
            var noviniService = new NoviniService(DbContextMock.Object);
            List<Novini> novina = new List<Novini>()
            {
                    new Novini()
                {
                    Id = Guid.NewGuid(),
                    Date = DateTime.Now,
                    Description = "Description",
                    Image = "primrnaKartinka",
                    Title = "Title"
                }
            };

            DbContextMock.Setup(x => x.All).Returns(novina.AsQueryable());

            //Act
            var result = noviniService.TakeAllNovini();

            //Assert
            Assert.AreEqual(novina.Count, result.Count);
        }

        [Test]
        public void ReturnCorrectNovini()
        {
            //Arrange
            var DbContextMock = new Mock<IEfDbSetWrapper<Novini>>();
            var noviniService = new NoviniService(DbContextMock.Object);
            List<Novini> novina = new List<Novini>()
            {
                    new Novini()
                {
                    Id = Guid.NewGuid(),
                    Date = DateTime.Now,
                    Description = "Description",
                    Image = "primrnaKartinka",
                    Title = "Title"
                }
            };

            DbContextMock.Setup(x => x.All).Returns(novina.AsQueryable());

            //Act
            var result = noviniService.TakeAllNovini();

            //Assert
            Assert.AreEqual(novina, result);
        }
    }
}
