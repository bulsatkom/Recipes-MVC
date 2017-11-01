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
    public class GetByDate_Should
    {
        [Test]
        public void ReturnCorrectRecept_WhenContainsReceptFoDay()
        {
            var DbContextMock = new Mock<IEfDbSetWrapper<Recept>>();
            var receptiService = new ReceptForDayService(DbContextMock.Object);
            List<Recept> Recepti = new List<Recept>();
            for (int i = 0; i < 9; i++)
            {
                Recepti.Add(new Recept()
                {
                    Date = DateTime.Now.Date,
                    Descrption = "Description" + i,
                    Id = Guid.NewGuid(),
                    Image = "PrimernaKartinka" + i,
                    Title = "Title" + i,
                    CookingTime = i,
                    CategoryId = Guid.NewGuid(),
                    Kitchen = "Test",
                    Likes = 0,
                    Views = 0,
                    ReceptForDay = DateTime.Now.Date
                });
            }

            DbContextMock.Setup(x => x.AllWithInclude(y => y.Category)).Returns(Recepti.AsQueryable());

            //Act
            var result = receptiService.GetByDate();

            Assert.AreEqual(Recepti[0], result);
        }

        [Test]
        public void ReturnNull_WhenNotContainsReceptFoDay()
        {
            var DbContextMock = new Mock<IEfDbSetWrapper<Recept>>();
            var receptiService = new ReceptForDayService(DbContextMock.Object);
            List<Recept> Recepti = new List<Recept>();
            for (int i = 0; i < 9; i++)
            {
                Recepti.Add(new Recept()
                {
                    Date = DateTime.Now.Date,
                    Descrption = "Description" + i,
                    Id = Guid.NewGuid(),
                    Image = "PrimernaKartinka" + i,
                    Title = "Title" + i,
                    CookingTime = i,
                    CategoryId = Guid.NewGuid(),
                    Kitchen = "Test",
                    Likes = 0,
                    Views = 0,
                });
            }

            DbContextMock.Setup(x => x.AllWithInclude(y => y.Category)).Returns(Recepti.AsQueryable());

            //Act
            var result = receptiService.GetByDate();

            Assert.IsNull(result);
        }
    }
}
