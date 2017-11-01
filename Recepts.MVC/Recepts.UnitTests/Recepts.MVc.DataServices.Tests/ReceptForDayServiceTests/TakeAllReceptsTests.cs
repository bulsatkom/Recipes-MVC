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
    public class TakeAllReceptsTests
    {
        [Test]
        public void Return_AllRecepts()
        {
            //Arrange
            var DbContextMock = new Mock<IEfDbSetWrapper<Recept>>();
            var receptiService = new ReceptForDayService(DbContextMock.Object);
            List<Recept> Recepti = new List<Recept>();
            for (int i = 10; i > 0; i--)
            {
                Recepti.Add(new Recept()
                {
                    Date = new DateTime(1994, 10, i),
                    Descrption = "Description" + i,
                    Id = Guid.NewGuid(),
                    Image = "PrimernaKartinka" + i,
                    Title = "Title" + i,
                    CookingTime = i,
                    CategoryId = Guid.NewGuid(),
                    Kitchen = "Test",
                    Likes = 0,
                    Views = i,
                });
            }

            DbContextMock.Setup(x => x.All).Returns(Recepti.AsQueryable());

            //Act
            var result = receptiService.TakeAllRecepts();

            //Assert
            Assert.AreEqual(10, result.Count);
            Assert.AreEqual(Recepti, result);
        }

        [Test]
        public void Return_EmptyResult_When_NotContains_Recepti()
        {
            //Arrange
            var DbContextMock = new Mock<IEfDbSetWrapper<Recept>>();
            var receptiService = new ReceptForDayService(DbContextMock.Object);
            List<Recept> Recepti = new List<Recept>();
            for (int i = 10; i > 0; i--)
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
                    Views = i,
                });
            }

            DbContextMock.Setup(x => x.All).Returns((new List<Recept>()).AsQueryable());

            //Act
            var result = receptiService.TakeAllRecepts();

            //Assert
            Assert.IsEmpty(result);
        }
    }
}
