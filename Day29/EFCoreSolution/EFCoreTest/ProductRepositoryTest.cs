using EFCoreFirstAPI.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.InMemory;
using EFCoreFirstAPI.Repositories;
using EFCoreFirstAPI.Models;
using EFCoreFirstAPI.Exceptions;
using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using Moq;

namespace EFCoreTest
{
    public class ProductRepositoryTest
    {
        DbContextOptions options;
        ShoppingContext context;
        ProductRepository repository;
        Mock<ILogger<ProductRepository>> logger;
        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<ShoppingContext>()
              .UseInMemoryDatabase("TestAdd")
              .Options;
            context = new ShoppingContext(options);
            logger = new Mock<ILogger<ProductRepository>>();
            repository = new ProductRepository(context,logger.Object);
        }


        [Test]
        [TestCase( "TestAdd1",120,4,"","Test description for Product",1)]
        [TestCase("TestAdd2", 120, 4, "", "Test description for Product",2)]
        public async Task TestAdd(string name,float price,int quantity,string image,string desc,int id)
        {
            //Arrange
            Product product = new Product
            {
                Name = name,
                Price = price,
                Quantity = quantity,
                BasicImage = image,
                Description = desc
            };
            //Act
            var result = await repository.Add(product);
            //Assert
            Assert.AreEqual(id, result.Id);
        }

        [Test]
        [TestCase("TestAdd1", 120, 4, "", "Test description for Product", 1)]

        public async Task TestAddException(string name, float price, int quantity, string image, string desc, int id)
        {
            //Arrange
            Product product = new Product
            {
                Name = null,
                Price = price,
                Quantity = quantity,
                BasicImage = image,
                Description = desc
            };

            //Assert
            Assert.ThrowsAsync<CouldNotAddException>(async () => await repository.Add(product));
           
        }
    }
}
