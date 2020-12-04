using CicekSepeti.Core;
using CicekSepeti.Core.IRepository;
using CicekSepeti.Core.IUnitOfWork;
using CicekSepeti.Core.Repositories;
using CicekSepeti.Domain.Context;
using CicekSepeti.Domain.Entities;
using CicekSepeti.Service;
using CicekSepeti.Service.IServices;
using CicekSepeti.Service.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CicekSepeti.UnitTest
{
    public class UnitTest1
    {
        private readonly ProductRepository _repo;
        private readonly UnitOfWork _unitOfWork;
        private readonly CicekSepetiDbContext _dbContext;
        public UnitTest1()
        {
            _dbContext = new InMemoryDbContextFactory().GetDbContext();
            //var moviesMock = CreateDbSetMock(GetFakeListOfMovies());
            //var mockDbContext = new Mock<CicekSepetiDbContext>();
            //mockDbContext.Setup(x => x.Products).Returns(moviesMock.Object);
            _repo = new ProductRepository(_dbContext);
            _unitOfWork = new UnitOfWork(_dbContext);
        }

        [Fact]
        public async Task DbContext()
        {
            // Arrange
            _dbContext.Products.Add(new Product { Id = Guid.NewGuid(), Count = 1, Name = "a", Price = 3 });
            _dbContext.SaveChanges();

            var test = await _repo.GetAllAsync();

            await _repo.AddAsync(new Product { Id = Guid.NewGuid(), Count = 1, Name = "a2", Price = 3 });
            await _unitOfWork.CommitAsync();

            var test1 = await _repo.GetAllAsync();
            // Act
            //_repo.CreateBook(new Book());
            var a = 5;
        }

       

        [Fact]
        public async Task Test1()
        {
            var list = new List<Product>();
            var productId = Guid.NewGuid();
            var product = new Product() { Id = productId, Count = 1, Name = "a", Price = 12 };
            list.Add(product);

            var aa = new Mock<DbSet<Product>>();

            var productRepositoryMock = new Mock<IProductRepository>().Object;

            var db = new Mock<CicekSepetiDbContext>();

            db.Setup(m => m.Products).Returns(aa.Object);
            //productRepositoryMock.Setup(m => m.GetByIdAsync(productId).Result).Returns(product).Verifiable();

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(m => m.ProductRepositories).Returns(productRepositoryMock);
            IProductService sut = new ProductService(unitOfWorkMock.Object);

            var actual = sut.GetAllProducts().Result;

            var test = 44;

        }
        [Fact]
        public async Task Test2()
        {
            IList<Product> users = new List<Product>
              {
               new Product{Id = Guid.NewGuid(),Count=1,Name ="a",Price=1},
               new Product{Id = Guid.NewGuid(),Count=2,Name ="1a",Price=1}
              };

            var usersMock = CreateDbSetMock(users);

            var userContextMock = new Mock<CicekSepetiDbContext>();
            userContextMock.Setup(x => x.Products).Returns(usersMock.Object);


            var productRepositoryMock = new Mock<IProductRepository>().Object;

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(m => m.ProductRepositories).Returns(productRepositoryMock);
            IProductService sut = new ProductService(unitOfWorkMock.Object);

            var actual = sut.GetAllProducts().Result;

            var test = 44;

        }
        [Fact]
        public async Task Test3()
        {
            List<Product> users = new List<Product>
              {
               new Product{Id = Guid.NewGuid(),Count=1,Name ="a",Price=1},
               new Product{Id = Guid.NewGuid(),Count=2,Name ="1a",Price=1}
              };

            var product = GetQueryableMockDbSet(users);


            var options = new DbContextOptionsBuilder<CicekSepetiDbContext>()
                    .UseInMemoryDatabase(databaseName: "FekaConnectionString")
                    .Options;
            var userContextMock = new Mock<CicekSepetiDbContext>(options);

            userContextMock.Setup(x => x.Products).Returns(product);


            var productRepositoryMock = new Mock<IProductRepository>().Object;

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(m => m.ProductRepositories).Returns(productRepositoryMock);
            IProductService sut = new ProductService(unitOfWorkMock.Object);

            var actual = sut.GetAllProducts().Result;

            var test = 44;

        }
        [Fact]
        public async Task Test4()
        {
            List<Product> products = new List<Product>
              {
               new Product{Id = Guid.NewGuid(),Count=1,Name ="a",Price=1},
               new Product{Id = Guid.NewGuid(),Count=2,Name ="1a",Price=1}
              };
            var product = GetQueryableMockDbSet(products);

            List<User> users = new List<User>
              {
               new User{Id = Guid.NewGuid(),AccountName = "a",AccountPassword="d"},
               new User{Id = Guid.NewGuid(),AccountName = "aa",AccountPassword="ad"}
              };
            var user = GetQueryableMockDbSet(users);

            List<Basket> baskets = new List<Basket>
              {
               new Basket{Id = Guid.NewGuid(),Count=1,ProductId =Guid.NewGuid(),UserId = Guid.NewGuid()},
               new Basket{Id = Guid.NewGuid(),Count=11,ProductId =Guid.NewGuid(),UserId = Guid.NewGuid()},
              };

            var basket = GetQueryableMockDbSet(baskets);


            var userContextMock = new Mock<ICicekSepetiDbContext>(MockBehavior.Loose);

            userContextMock.Setup(x => x.Products).Returns(product);
            userContextMock.Setup(x => x.Users).Returns(user);
            userContextMock.Setup(x => x.Baskets).Returns(basket);


            IEnumerable<Product> productsTest = new List<Product>
              {
               new Product{Id = Guid.NewGuid(),Count=1,Name ="a",Price=1},
               new Product{Id = Guid.NewGuid(),Count=2,Name ="1a",Price=1}
              };

            var testMock = new Mock<IProductRepository>(MockBehavior.Loose);
            //testMock.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(productsTest));
            testMock.Setup(x => x.GetAllAsync()).ReturnsAsync(productsTest);

            var productRepositoryMock = new ProductRepository((userContextMock.Object));
            var userRepositoryMock = new UserRepository((userContextMock.Object));
            var basketRepositoryMock = new BasketRepository((userContextMock.Object));
            //productRepositoryMock.Setup(x=>x.get)

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(m => m.ProductRepositories).Returns(testMock.Object);
            //unitOfWorkMock.Setup(m => m.UserRepositories).Returns(userRepositoryMock);
            //unitOfWorkMock.Setup(m => m.BasketRepositories).Returns(basketRepositoryMock);

            IProductService sut = new ProductService(unitOfWorkMock.Object);

            var actual = await sut.GetAllProducts();

            var test = actual.ToList();

        }
        [Fact]
        public async Task Test5()
        {
            IEnumerable<Product> productsTest = new List<Product>
              {
               new Product{Id = Guid.NewGuid(),Count=1,Name ="a",Price=1},
               new Product{Id = Guid.NewGuid(),Count=2,Name ="1a",Price=1}
              };

            var testMock = new Mock<IProductRepository>(MockBehavior.Loose);
            testMock.Setup(x => x.GetAllAsync()).ReturnsAsync(productsTest);

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(m => m.ProductRepositories).Returns(testMock.Object);

            IProductService sut = new ProductService(unitOfWorkMock.Object);

            var actual = await sut.GetAllProducts();

            var test = actual.ToList();

        }
        [Fact]
        public async Task AddBasketApiResponseTest_FalseUserNull()
        {
            var userId = Guid.NewGuid();
            var productId = Guid.NewGuid();
            var count = 5;

            Basket basket = new Basket { UserId = userId, ProductId = productId, Count = count };
            User user = new User { Id = userId, AccountName = "a", AccountPassword = "fd" };
            Product product = new Product { Id = productId, Count = 1, Name = "asd", Price = 12 };

            //IEnumerable<Product> productsTest = new List<Product>
            //  {
            //   new Product{Id = Guid.NewGuid(),Count=1,Name ="a",Price=1},
            //   new Product{Id = Guid.NewGuid(),Count=2,Name ="1a",Price=1}
            //  };

            var userRepositoriesMock = new Mock<IUserRepository>(MockBehavior.Loose);
            userRepositoriesMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((User)null);

            var productRepositoriesMock = new Mock<IProductRepository>(MockBehavior.Loose);
            productRepositoriesMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(product);

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(m => m.UserRepositories).Returns(userRepositoriesMock.Object);
            unitOfWorkMock.Setup(m => m.ProductRepositories).Returns(productRepositoriesMock.Object);

            IBasketService basketService = new BasketService(unitOfWorkMock.Object);

            var actual = await basketService.AddBasketApiResponseTest(basket);

            Assert.False(actual.IsSuccess);
        }
        [Fact]
        public async Task AddBasketApiResponseTest_FalseProductNull()
        {
            var userId = Guid.NewGuid();
            var productId = Guid.NewGuid();
            var count = 5;

            Basket basket = new Basket { UserId = userId, ProductId = productId, Count = count };
            User user = new User { Id = userId, AccountName = "a", AccountPassword = "fd" };
            Product product = new Product { Id = productId, Count = 1, Name = "asd", Price = 12 };

            //IEnumerable<Product> productsTest = new List<Product>
            //  {
            //   new Product{Id = Guid.NewGuid(),Count=1,Name ="a",Price=1},
            //   new Product{Id = Guid.NewGuid(),Count=2,Name ="1a",Price=1}
            //  };

            var userRepositoriesMock = new Mock<IUserRepository>(MockBehavior.Loose);
            userRepositoriesMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(user);

            var productRepositoriesMock = new Mock<IProductRepository>(MockBehavior.Loose);
            productRepositoriesMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((Product)null);

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(m => m.UserRepositories).Returns(userRepositoriesMock.Object);
            unitOfWorkMock.Setup(m => m.ProductRepositories).Returns(productRepositoriesMock.Object);

            IBasketService basketService = new BasketService(unitOfWorkMock.Object);

            var actual = await basketService.AddBasketApiResponseTest(basket);

            Assert.False(actual.IsSuccess);
        }
        [Fact]
        public async Task AddBasketApiResponseTest_FalseCount()
        {
            var userId = Guid.NewGuid();
            var productId = Guid.NewGuid();
            var count = 5;

            Basket basket = new Basket { UserId = userId, ProductId = productId, Count = count };
            User user = new User { Id = userId, AccountName = "a", AccountPassword = "fd" };
            Product product = new Product { Id = productId, Count = 1, Name = "asd", Price = 12 };

            //IEnumerable<Product> productsTest = new List<Product>
            //  {
            //   new Product{Id = Guid.NewGuid(),Count=1,Name ="a",Price=1},
            //   new Product{Id = Guid.NewGuid(),Count=2,Name ="1a",Price=1}
            //  };

            var userRepositoriesMock = new Mock<IUserRepository>(MockBehavior.Loose);
            userRepositoriesMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(user);

            var productRepositoriesMock = new Mock<IProductRepository>(MockBehavior.Loose);
            productRepositoriesMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(product);

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(m => m.UserRepositories).Returns(userRepositoriesMock.Object);
            unitOfWorkMock.Setup(m => m.ProductRepositories).Returns(productRepositoriesMock.Object);

            IBasketService basketService = new BasketService(unitOfWorkMock.Object);

            var actual = await basketService.AddBasketApiResponseTest(basket);

            Assert.False(actual.IsSuccess);
        }

        [Fact]
        public async Task AddBasketApiResponseTest_TrueNewBasket()
        {
            var userId = Guid.NewGuid();
            var productId = Guid.NewGuid();
            var count = 5;

            Basket basket = new Basket { UserId = userId, ProductId = productId, Count = count };
            User user = new User { Id = userId, AccountName = "a", AccountPassword = "fd" };
            Product product = new Product { Id = productId, Count = 10, Name = "asd", Price = 12 };

            //IEnumerable<Product> productsTest = new List<Product>
            //  {
            //   new Product{Id = Guid.NewGuid(),Count=1,Name ="a",Price=1},
            //   new Product{Id = Guid.NewGuid(),Count=2,Name ="1a",Price=1}
            //  };

            var userRepositoriesMock = new Mock<IUserRepository>(MockBehavior.Loose);
            userRepositoriesMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(user);

            var productRepositoriesMock = new Mock<IProductRepository>(MockBehavior.Loose);
            productRepositoriesMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(product);

            var basketRepositoriesMock = new Mock<IBasketRepository>(MockBehavior.Loose);
            basketRepositoriesMock.Setup(x => x.GetBasketsByUserIdAndProductId(It.IsAny<Guid>(), It.IsAny<Guid>())).ReturnsAsync((Basket)null);

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(m => m.UserRepositories).Returns(userRepositoriesMock.Object);
            unitOfWorkMock.Setup(m => m.ProductRepositories).Returns(productRepositoriesMock.Object);
            unitOfWorkMock.Setup(m => m.BasketRepositories).Returns(basketRepositoriesMock.Object);

            IBasketService basketService = new BasketService(unitOfWorkMock.Object);

            var actual = await basketService.AddBasketApiResponseTest(basket);

            Assert.True(actual.IsSuccess);
        }
        [Fact]
        public async Task AddBasketApiResponseTest_TrueUpdateBasket()
        {
            var userId = Guid.NewGuid();
            var productId = Guid.NewGuid();
            var count = 5;

            Basket basket = new Basket { Id = Guid.NewGuid(), UserId = userId, ProductId = productId, Count = 1 };
            User user = new User { Id = userId, AccountName = "a", AccountPassword = "fd" };
            Product product = new Product { Id = productId, Count = 10, Name = "asd", Price = 12 };

            //IEnumerable<Product> productsTest = new List<Product>
            //  {
            //   new Product{Id = Guid.NewGuid(),Count=1,Name ="a",Price=1},
            //   new Product{Id = Guid.NewGuid(),Count=2,Name ="1a",Price=1}
            //  };

            var userRepositoriesMock = new Mock<IUserRepository>(MockBehavior.Loose);
            userRepositoriesMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(user);

            var productRepositoriesMock = new Mock<IProductRepository>(MockBehavior.Loose);
            productRepositoriesMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(product);

            var basketRepositoriesMock = new Mock<IBasketRepository>(MockBehavior.Loose);
            basketRepositoriesMock.Setup(x => x.GetBasketsByUserIdAndProductId(It.IsAny<Guid>(), It.IsAny<Guid>())).ReturnsAsync(basket);

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(m => m.UserRepositories).Returns(userRepositoriesMock.Object);
            unitOfWorkMock.Setup(m => m.ProductRepositories).Returns(productRepositoriesMock.Object);
            unitOfWorkMock.Setup(m => m.BasketRepositories).Returns(basketRepositoriesMock.Object);

            IBasketService basketService = new BasketService(unitOfWorkMock.Object);

            var actual = await basketService.AddBasketApiResponseTest(basket);

            Assert.True(actual.IsSuccess);
        }
        [Fact]
        public void GetAllTest()
        {
            var options = new DbContextOptionsBuilder<CicekSepetiDbContext>()
                .UseInMemoryDatabase(databaseName: "CicekSepetiDB")
                .Options;

            // Insert seed data into the database using one instance of the context
            //using (var context = new CicekSepetiDbContext(options))
            //{
            //    context.Products.Add(new Product { Id = Guid.NewGuid(), Count = 1, Name = "a", Price = 3 });
            //    context.Products.Add(new Product { Id = Guid.NewGuid(), Count = 1, Name = "a", Price = 3 });
            //    context.Products.Add(new Product { Id = Guid.NewGuid(), Count = 1, Name = "a", Price = 3 });
            //    context.Products.Add(new Product { Id = Guid.NewGuid(), Count = 1, Name = "a", Price = 3 });
            //    context.SaveChanges();
            //}

            // Use a clean instance of the context to run the test
            //using (var context = new MovieDbContext(options))
            //{
            //    MovieRepository movieRepository = new MovieRepository(context);
            //    List<Movies> movies == movieRepository.GetAll()

            //Assert.Equal(3, movies.Count);
            //}
        }

        [Fact]
        public void GetAll_WhenCalled_ReturnsAllItems()
        {
            //Act
            var items = _repo.GetAllAsync().Result;

            //Assert
            Assert.Equal(3, items.Count());
        }


        public class InMemoryDbContextFactory
        {
            public CicekSepetiDbContext GetDbContext()
            {
                var options = new DbContextOptionsBuilder<CicekSepetiDbContext>()
                                .UseInMemoryDatabase(databaseName: "CicekSepetiDB")
                                // and also tried using SqlLite approach. But same issue reproduced.
                                .Options;
                //var dbContext = new CicekSepetiDbContext(options);

                return null;
            }
        }

        private IEnumerable<Product> GetFakeListOfMovies()
        {
            var movies = new List<Product>
        {
            new Product {Id = Guid.NewGuid(),Count =1,Name ="a",Price=3},
            new Product {Id = Guid.NewGuid(),Count =1,Name ="a",Price=3},
            new Product {Id = Guid.NewGuid(),Count =1,Name ="a",Price=3},
        };

            return movies;
        }
        //private static Mock<DbSet<T>> CreateDbSetMock<T>(IEnumerable<T> elements) where T : class
        //{
        //    var elementsAsQueryable = elements.AsQueryable();
        //    var dbSetMock = new Mock<DbSet<T>>();

        //    dbSetMock.As<IQueryable<T>>().Setup(m => m.Provider).Returns(elementsAsQueryable.Provider);
        //    dbSetMock.As<IQueryable<T>>().Setup(m => m.Expression).Returns(elementsAsQueryable.Expression);
        //    dbSetMock.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(elementsAsQueryable.ElementType);
        //    dbSetMock.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(elementsAsQueryable.GetEnumerator());

        //    return dbSetMock;
        //}

        public static DbSet<T> GetQueryableMockDbSet<T>(List<T> sourceList) where T : class
        {
            var queryable = sourceList.AsQueryable();
            var dbSet = new Mock<DbSet<T>>();
            dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            dbSet.Setup(d => d.Add(It.IsAny<T>())).Callback<T>((s) => sourceList.Add(s));
            return dbSet.Object;
        }
        private static Mock<DbSet<T>> CreateDbSetMock<T>(IEnumerable<T> elements) where T : class
        {
            var elementsAsQueryable = elements.AsQueryable();
            var dbSetMock = new Mock<DbSet<T>>();

            dbSetMock.As<IQueryable<T>>().Setup(m => m.Provider).Returns(elementsAsQueryable.Provider);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.Expression).Returns(elementsAsQueryable.Expression);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(elementsAsQueryable.ElementType);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(elementsAsQueryable.GetEnumerator());

            return dbSetMock;
        }
    }
}
