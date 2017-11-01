using Moq;
using NUnit.Framework;
using Recepts.MVC.Data;
using Recepts_MVC_DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recepts.UnitTests.Recepts.MVc.DataServices.Tests.ProductServiceTests
{
    [TestFixture]
    public class GetProductForReceptById_Should
    {
        [Test]
        public void Return_Correct_Product_When_PassCorrectId()
        {
            //Arrange
            var DbContextMock = new Mock<IEfDbSetWrapper<Product>>();
            var productService = new ProductService(DbContextMock.Object);
            var id = Guid.NewGuid();
            List<Product> products = new List<Product>()
            {
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Test",
                    Quantity = "Testovo",
                    ReceptId = id
                }
            };

            DbContextMock.Setup(x => x.All).Returns(products.AsQueryable());

            //Act
            var result = productService.GetProductForReceptById(id);

            //Assert
            Assert.AreEqual(products, result);
        }

        [Test]
        public void Return_EmptyProduct_When_PassedIdIsNotContains()
        {
            //Arrange
            var DbContextMock = new Mock<IEfDbSetWrapper<Product>>();
            var productService = new ProductService(DbContextMock.Object);
            var id = Guid.NewGuid();
            List<Product> products = new List<Product>()
            {
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Test",
                    Quantity = "Testovo",
                    ReceptId = id
                }
            };

            DbContextMock.Setup(x => x.All).Returns(products.AsQueryable());

            //Act
            var result = productService.GetProductForReceptById(Guid.NewGuid());

            //Assert
            Assert.IsEmpty(result);
        }
    }
}
