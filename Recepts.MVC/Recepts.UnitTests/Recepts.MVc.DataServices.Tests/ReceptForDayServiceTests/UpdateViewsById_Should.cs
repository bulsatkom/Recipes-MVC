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
    public class UpdateViewsById_Should
    {
        [Test]
        public void UpdateRecept_Views_WhenContainsPassedId()
        {
            //Arrange
            var DbContextMock = new Mock<IEfDbSetWrapper<Recept>>();
            var productiService = new ReceptForDayService(DbContextMock.Object);
            Guid id = Guid.NewGuid();
            int views = 0;
            List<Recept> Recepti = new List<Recept>()
             {
              new Recept()
                {
                   Date = DateTime.Now,
                   Descrption = "Description",
                   Id = id,
                   Image = "PrimernaKartinka",
                   Title = "Title",
                   CookingTime = 30,
                   CategoryId = Guid.NewGuid(),
                   Kitchen = "Test",
                   Likes = 0,
                   Views = views
                }
            };

            DbContextMock.Setup(x => x.All).Returns(Recepti.AsQueryable());
            //Act
            productiService.UpdateViewsById(id);

            //Assert
            Assert.AreEqual(++views, Recepti[0].Views);
        }

        [Test]
        public void NotUpdateReceptViews_WhenNotContainsPassedId()
        {
            //Arrange
            var DbContextMock = new Mock<IEfDbSetWrapper<Recept>>();
            var productiService = new ReceptForDayService(DbContextMock.Object);
            Guid id = Guid.NewGuid();
            int views = 0;
            List<Recept> Recepti = new List<Recept>()
             {
              new Recept()
                {
                   Date = DateTime.Now,
                   Descrption = "Description",
                   Id = id,
                   Image = "PrimernaKartinka",
                   Title = "Title",
                   CookingTime = 30,
                   CategoryId = Guid.NewGuid(),
                   Kitchen = "Test",
                   Likes = 0,
                   Views = views
                }
            };

            DbContextMock.Setup(x => x.All).Returns(Recepti.AsQueryable());
            //Act
            productiService.UpdateViewsById(Guid.NewGuid());

            //Assert
            Assert.AreEqual(views, Recepti[0].Views);
        }
    }
}
