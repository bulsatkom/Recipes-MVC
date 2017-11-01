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
    public class TakeMost3ViewPredQstiqTests
    {
        [Test]
        public void Return_CorrectRecepts()
        {
            //Arrange
            var DbContextMock = new Mock<IEfDbSetWrapper<Recept>>();
            var receptiService = new ReceptForDayService(DbContextMock.Object);
            List<Recept> Recepti = new List<Recept>();
            Guid predQstieId = Guid.Parse("79DAD09D-1ED0-4A77-9FD8-0BBEB75F283A");
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
                    CategoryId = predQstieId,
                    Kitchen = "Test",
                    Likes = 0,
                    Views = i,
                });
            }

            DbContextMock.Setup(x => x.All).Returns(Recepti.AsQueryable());

            //Act
            var result = receptiService.TakeMost3ViewPredQstiq();

            //Assert
            Assert.AreEqual(3, result.Count);
            int expectedresult = 10;
            foreach (var recept in result)
            {
                Assert.AreEqual(expectedresult, recept.Views);
                --expectedresult;
            }
        }

        [Test]
        public void Return_EmptyResult_When_NotContains_PredQstieId()
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

            DbContextMock.Setup(x => x.All).Returns(Recepti.AsQueryable());

            //Act
            var result = receptiService.TakeMost3ViewPredQstiq();

            //Assert
            Assert.IsEmpty(result);
        }
    }
}
