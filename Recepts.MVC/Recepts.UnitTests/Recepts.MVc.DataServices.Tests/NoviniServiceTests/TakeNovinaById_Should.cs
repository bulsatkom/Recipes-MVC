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
    public class TakeNovinaById_Should
    {
        [Test]
        public void ReturnModel_WhenThereIsAModelWithThePassedId()
        {
            //Arrange
            var DbContextMock = new Mock<IEfDbSetWrapper<Novini>>();
            var noviniService = new NoviniService(DbContextMock.Object);
            Guid id = Guid.NewGuid();
            Novini novina = new Novini()
            {
                Date = DateTime.Now,
                Description = "Description",
                Id = id,
                Image = "PrimernaKartinka",
                Title = "Title"
            };

            DbContextMock.Setup(x => x.GetById(id)).Returns(novina);

            //Act
            var result = noviniService.TakeNovinaById(id);

            //Assert
            Assert.AreEqual(id, result.Id);
        }

        [Test]
        public void ReturnNull_WhenThereIsNoModelWithThePassedId()
        {
            //Arrange
            var DbContextMock = new Mock<IEfDbSetWrapper<Novini>>();
            var noviniService = new NoviniService(DbContextMock.Object);
            Guid id = Guid.NewGuid();            
            DbContextMock.Setup(x => x.GetById(id)).Returns((Novini)null);

            //Act
            var result = noviniService.TakeNovinaById(id);

            //Assert
            Assert.IsNull(result);
        }
    }
}
