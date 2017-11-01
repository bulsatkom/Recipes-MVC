using Moq;
using NUnit.Framework;
using Recepts.MVC.Data;
using Recepts_MVC_DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recepts.UnitTests.Recepts.MVc.DataServices.Tests.ReceptForDayServiceTests
{
    [TestFixture]
    public class GetByID_Should
    {
        [Test]
        public void Return_CorrectRecept_WhenPassedCorrectId()
        {
            //Arrange
            var DbContextMock = new Mock<IEfDbSetWrapper<Recept>>();
            var receptiService = new ReceptForDayService(DbContextMock.Object);
            Guid Id = Guid.NewGuid();

            List<Recept> Recepti = new List<Recept>()
            {
                new Recept()
                {
                    Date = DateTime.Now,
                    Descrption = "Description",
                    Id = Id,
                    Image = "PrimernaKartinka",
                    Title = "Title",
                    CookingTime = 30,
                    CategoryId = Guid.NewGuid(),
                    Kitchen = "Test",
                    Likes = 0,
                    Views = 0
                }
            };

            DbContextMock.Setup(x => x.All).Returns(Recepti.AsQueryable());

            //Act
            var result = receptiService.GetByID(Id);

            //Assert
            Assert.AreEqual(Recepti[0], result);
        }

        [Test]
        public void Return_null_WhenPassedInCorrectId()
        {
            //Arrange
            var DbContextMock = new Mock<IEfDbSetWrapper<Recept>>();
            var receptiService = new ReceptForDayService(DbContextMock.Object);
            Guid Id = Guid.NewGuid();

            List<Recept> Recepti = new List<Recept>()
            {
                new Recept()
                {
                    Date = DateTime.Now,
                    Descrption = "Description",
                    Id = Id,
                    Image = "PrimernaKartinka",
                    Title = "Title",
                    CookingTime = 30,
                    CategoryId = Guid.NewGuid(),
                    Kitchen = "Test",
                    Likes = 0,
                    Views = 0
                }
            };

            DbContextMock.Setup(x => x.All).Returns(Recepti.AsQueryable());

            //Act
            var result = receptiService.GetByID(Guid.NewGuid());

            //Assert
            Assert.IsNull(result);
        }
    }
}
