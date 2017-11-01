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
    public class TakeMostViewedRecepts_Should
    {
        [Test]
        public void Return_3Recepts_When_ThereAreMoreThan3()
        {
            //Arrange
            var DbContextMock = new Mock<IEfDbSetWrapper<Recept>>();
            var receptiService = new ReceptForDayService(DbContextMock.Object);
            List<Recept> Recepti = new List<Recept>();
            for (int i = 0; i < 9; i++)
            {
                Recepti.Add(new Recept()
                {
                    Date = DateTime.Now,
                    Descrption = "Description" + i,
                    Id = Guid.NewGuid(),
                    Image = "PrimernaKartinka" + i,
                    Title = "Title" + i,
                    CookingTime = i,
                    CategoryId = Guid.NewGuid(),
                    Kitchen = "Test",
                    Likes = 0,
                    Views = i
                });
            }

            DbContextMock.Setup(x => x.AllWithInclude(y => y.Category)).Returns(Recepti.AsQueryable());

            //Act
            var result = receptiService.TakeMostViewedRecepts();

            //Assert
            Assert.AreEqual(3, result.Count);
        }

        [Test]
        public void Return_CorrectRecepts()
        {
            //Arrange
            var DbContextMock = new Mock<IEfDbSetWrapper<Recept>>();
            var receptiService = new ReceptForDayService(DbContextMock.Object);
            List<Recept> Recepti = new List<Recept>();
            for (int i = 3; i > 0; i--)
            {
                Recepti.Add(new Recept()
                {
                    Date = DateTime.Now,
                    Descrption = "Description" + i,
                    Id = Guid.NewGuid(),
                    Image = "PrimernaKartinka" + i,
                    Title = "Title" + i,
                    CookingTime = i,
                    CategoryId = Guid.NewGuid(),
                    Kitchen = "Test",
                    Likes = 0,
                    Views = i
                });
            }

            DbContextMock.Setup(x => x.AllWithInclude(y => y.Category)).Returns(Recepti.AsQueryable());

            //Act
            var result = receptiService.TakeMostViewedRecepts();

            //Assert
            Assert.AreEqual(Recepti, result);
        }
    }
}
