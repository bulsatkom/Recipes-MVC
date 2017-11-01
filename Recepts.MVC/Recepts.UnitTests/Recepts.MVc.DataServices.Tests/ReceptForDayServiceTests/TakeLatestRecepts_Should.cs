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
    public class TakeLatestRecepts_Should
    {
        [Test]
        public void Return_9Recepts_When_ThereAreMoreThan9()
        {
            //Arrange
            var DbContextMock = new Mock<IEfDbSetWrapper<Recept>>();
            var receptiService = new ReceptForDayService(DbContextMock.Object);
            List<Recept> Recepti = new List<Recept>();
            for (int i = 0; i < 16; i++)
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
                    Views = 0
                });
            }

            DbContextMock.Setup(x => x.All).Returns(Recepti.AsQueryable());

            //Act
            var result = receptiService.TakeLatestRecepts();

            //Assert
            Assert.AreEqual(9, result.Count);
        }

        [Test]
        public void Return_CorrectRecepti()
        {
            //Arrange
            var DbContextMock = new Mock<IEfDbSetWrapper<Recept>>();
            var productiService = new ReceptForDayService(DbContextMock.Object);
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
                    Views = 0
                });
            }

            DbContextMock.Setup(x => x.All).Returns(Recepti.AsQueryable());

            //Act
            var result = productiService.TakeLatestRecepts();

            //Assert
            Assert.AreEqual(Recepti.OrderByDescending(x => x.Date), result);
        }
    }
}
