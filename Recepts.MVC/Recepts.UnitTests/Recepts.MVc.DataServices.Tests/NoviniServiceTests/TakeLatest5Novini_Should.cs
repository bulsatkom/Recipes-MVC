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
    public class TakeLatest5Novini_Should
    {
        [Test]
        public void Return_5Novini_When_ThereAreMoreThan5()
        {
            //Arrange
            var DbContextMock = new Mock<IEfDbSetWrapper<Novini>>();
            var noviniService = new NoviniService(DbContextMock.Object);
            List<Novini> novini = new List<Novini>();
            for (int i = 0; i < 6; i++)
            {
                novini.Add(new Novini()
                {
                    Date = DateTime.Now,
                    Description = "Description" + i,
                    Id = Guid.NewGuid(),
                    Image = "PrimernaKartinka" + i,
                    Title = "Title" + i
                });
            }

            DbContextMock.Setup(x => x.All).Returns(novini.AsQueryable());

            //Act
            var result = noviniService.TakeLatest5Novini();

            //Assert
            Assert.AreEqual(5, result.Count);
        }

        [Test]
        public void Return_CorrectNovini()
        {
            //Arrange
            var DbContextMock = new Mock<IEfDbSetWrapper<Novini>>();
            var noviniService = new NoviniService(DbContextMock.Object);
            List<Novini> novini = new List<Novini>();
            for (int i = 0; i < 5; i++)
            {
                novini.Add(new Novini()
                {
                    Date = DateTime.Now,
                    Description = "Description" + i,
                    Id = Guid.NewGuid(),
                    Image = "PrimernaKartinka" + i,
                    Title = "Title" + i
                });
            }

            DbContextMock.Setup(x => x.All).Returns(novini.AsQueryable());

            //Act
            var result = noviniService.TakeLatest5Novini();

            //Assert
            Assert.AreEqual(novini.OrderByDescending(x => x.Date), result);
        }
    }
}
