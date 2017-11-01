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
    public class TakeMostViewReceptsFromCategoryByRecept_Should
    {
        [Test]
        public void Return_2MostViewedReceptsFromCategory_When_ThereAreMoreThan2InCategory()
        {
            //Arrange
            var DbContextMock = new Mock<IEfDbSetWrapper<Recept>>();
            var receptiService = new ReceptForDayService(DbContextMock.Object);
            List<Recept> Recepti = new List<Recept>();
            var categoryId = Guid.NewGuid();
            var Recept = new Recept()
            {
                Date = DateTime.Now,
                Descrption = "Description",
                Id = Guid.NewGuid(),
                Image = "PrimernaKartinka",
                Title = "Title",
                CookingTime = 20,
                CategoryId = categoryId,
                Kitchen = "Test",
                Likes = 0,
                Views = 10,
            };

            for (int i = 0; i < 3; i++)
            {
                Recepti.Add(new Recept()
                {
                    Date = DateTime.Now,
                    Descrption = "Description" + i,
                    Id = Guid.NewGuid(),
                    Image = "PrimernaKartinka" + i,
                    Title = "Title" + i,
                    CookingTime = i,
                    CategoryId = categoryId,
                    Kitchen = "Test",
                    Likes = 0,
                    Views = i,                   
                });
            }

            Recepti.Add(Recept);

            DbContextMock.Setup(x => x.All).Returns(Recepti.AsQueryable());

            //Act
            var result = receptiService.TakeMostViewReceptsFromCategoryByRecept(Recept);

            //Assert
            Assert.AreEqual(2, result.Count);
            CollectionAssert.DoesNotContain(result, Recept);
        }

        [Test]
        public void Return_CorrectRecepts()
        {
            //Arrange
            var DbContextMock = new Mock<IEfDbSetWrapper<Recept>>();
            var receptiService = new ReceptForDayService(DbContextMock.Object);
            List<Recept> Recepti = new List<Recept>();
            var categoryId = Guid.NewGuid();
            var Recept = new Recept()
            {
                Date = DateTime.Now,
                Descrption = "Description",
                Id = Guid.NewGuid(),
                Image = "PrimernaKartinka",
                Title = "Title",
                CookingTime = 20,
                CategoryId = categoryId,
                Kitchen = "Test",
                Likes = 0,
                Views = 10,
            };

            for (int i = 2; i > 0; i--)
            {
                Recepti.Add(new Recept()
                {
                    Date = DateTime.Now,
                    Descrption = "Description" + i,
                    Id = Guid.NewGuid(),
                    Image = "PrimernaKartinka" + i,
                    Title = "Title" + i,
                    CookingTime = i,
                    CategoryId = categoryId,
                    Kitchen = "Test",
                    Likes = 0,
                    Views = i,
                });
            }

            DbContextMock.Setup(x => x.All).Returns(Recepti.AsQueryable());

            //Act
            var result = receptiService.TakeMostViewReceptsFromCategoryByRecept(Recept);

            //Assert
            Assert.AreEqual(Recepti, result);
        }
    }
}
