namespace Eventures.Services.Tests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Data;
    using Eventures.Models;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Xunit;

    public class OrdersServiceTests : BaseTests
    {
        [Fact]
        public async Task Create_WithValidModel_ShouldWorkCorrectly()
        {
            // Arrange
            const int ticketsCount = 10;

            var context = new EventuresDbContext(new DbContextOptionsBuilder<EventuresDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options);
            var ordersService = new OrdersService(context);

            var user = new EventuresUser
            {
                UserName = "TestUser"
            };
            await context.Users.AddAsync(user);

            var eventModel = new EventuresEvent
            {
                Name = "TestEvent",
                TotalTickets = ticketsCount
            };
            await context.Events.AddAsync(eventModel);

            await context.SaveChangesAsync();

            var model = new OrderServiceModel
            {
                OrderedOn = DateTime.UtcNow,
                EventId = eventModel.Id,
                TicketsCount = 2
            };

            // Act
            var result = await ordersService.Create(model, user.UserName);

            // Assert
            Assert.True(result);

            var remainingTickets = (await context.Events.SingleAsync()).TotalTickets;
            Assert.Equal(ticketsCount - model.TicketsCount, remainingTickets);

            var count = await context.Orders.CountAsync();
            Assert.Equal(1, count);

            var orderUserId = (await context.Orders.SingleAsync()).UserId;
            Assert.Equal(user.Id, orderUserId);
        }

        [Fact]
        public async Task Create_WithNullUser_ShouldNotChangeAnything()
        {
            // Arrange
            const int ticketsCount = 10;

            var context = new EventuresDbContext(new DbContextOptionsBuilder<EventuresDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options);
            var ordersService = new OrdersService(context);

            var eventModel = new EventuresEvent
            {
                Name = "TestEvent",
                TotalTickets = ticketsCount
            };
            await context.Events.AddAsync(eventModel);

            await context.SaveChangesAsync();

            var model = new OrderServiceModel
            {
                OrderedOn = DateTime.UtcNow,
                EventId = eventModel.Id,
                TicketsCount = 2
            };

            // Act
            var result = await ordersService.Create(model, null);

            // Assert
            Assert.False(result);

            var remainingTickets = (await context.Events.SingleAsync()).TotalTickets;
            Assert.Equal(ticketsCount, remainingTickets);

            var count = await context.Orders.CountAsync();
            Assert.Equal(0, count);
        }

        [Fact]
        public async Task Create_WithNonExistentEvent_ShouldNotChangeAnything()
        {
            // Arrange
            var context = new EventuresDbContext(new DbContextOptionsBuilder<EventuresDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options);
            var ordersService = new OrdersService(context);

            var user = new EventuresUser
            {
                UserName = "TestUser"
            };
            await context.Users.AddAsync(user);

            await context.SaveChangesAsync();

            var model = new OrderServiceModel
            {
                EventId = Guid.NewGuid().ToString(),
                TicketsCount = 2
            };

            // Act
            var result = await ordersService.Create(model, user.UserName);

            // Assert
            Assert.False(result);

            var count = await context.Orders.CountAsync();
            Assert.Equal(0, count);
        }

        [Fact]
        public async Task Create_WithNotEnoughAvailableTickets_ShouldNotChangeAnything()
        {
            // Arrange
            const int ticketsCount = 10;

            var context = new EventuresDbContext(new DbContextOptionsBuilder<EventuresDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options);
            var ordersService = new OrdersService(context);

            var user = new EventuresUser
            {
                UserName = "TestUser"
            };
            await context.Users.AddAsync(user);

            var eventModel = new EventuresEvent
            {
                Name = "TestEvent",
                TotalTickets = ticketsCount
            };
            await context.Events.AddAsync(eventModel);

            await context.SaveChangesAsync();

            var model = new OrderServiceModel
            {
                OrderedOn = DateTime.UtcNow,
                EventId = eventModel.Id,
                TicketsCount = 20
            };

            // Act
            var result = await ordersService.Create(model, user.UserName);

            // Assert
            Assert.False(result);

            var remainingTickets = (await context.Events.SingleAsync()).TotalTickets;
            Assert.Equal(ticketsCount, remainingTickets);

            var count = await context.Orders.CountAsync();
            Assert.Equal(0, count);
        }

        [Fact]
        public async Task GetAll_WithOrders_ShouldWorkCorrectly()
        {
            // Arrange
            var context = new EventuresDbContext(new DbContextOptionsBuilder<EventuresDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options);
            var ordersService = new OrdersService(context);

            var eventModel = new EventuresEvent
            {
                Name = "Test Event",
                TotalTickets = 30,
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow,
                Place = "Test Place",
                PricePerTicket = 30
            };
            await context.Events.AddAsync(eventModel);

            var user = new EventuresUser
            {
                UserName = "User"
            };
            await context.Users.AddAsync(user);

            var orders = new[]
            {
                new Order
                {
                    OrderedOn = DateTime.UtcNow,
                    TicketsCount = 1,
                    Event = eventModel,
                    User = user
                },
                new Order
                {
                    OrderedOn = DateTime.UtcNow,
                    TicketsCount = 2,
                    Event = eventModel,
                    User = user
                },
                new Order
                {
                    OrderedOn = DateTime.UtcNow,
                    TicketsCount = 3,
                    Event = eventModel,
                    User = user
                }
            };
            await context.Orders.AddRangeAsync(orders);

            await context.SaveChangesAsync();

            // Act
            var all = await ordersService.GetAll();

            // Assert
            var count = all.Count();
            Assert.Equal(3, count);
        }

        [Fact]
        public async Task GetAll_WithNoOrders_ShouldWorkCorrectly()
        {
            // Arrange
            var context = new EventuresDbContext(new DbContextOptionsBuilder<EventuresDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options);
            var ordersService = new OrdersService(context);

            // Act
            var all = await ordersService.GetAll();

            // Assert
            var count = all.Count();
            Assert.Equal(0, count);
        }

        [Fact]
        public async Task GetAllForUser_WithOrders_ShouldWorkCorrectly()
        {
            // Arrange
            var context = new EventuresDbContext(new DbContextOptionsBuilder<EventuresDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options);
            var ordersService = new OrdersService(context);

            var eventModel = new EventuresEvent
            {
                Name = "Test Event",
                TotalTickets = 30,
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow,
                Place = "Test Place",
                PricePerTicket = 30
            };
            await context.Events.AddAsync(eventModel);

            var user = new EventuresUser
            {
                UserName = "User"
            };
            await context.Users.AddAsync(user);

            var otherUser = new EventuresUser
            {
                UserName = "OtherUser"
            };
            await context.Users.AddAsync(otherUser);

            var orders = new[]
            {
                new Order
                {
                    OrderedOn = DateTime.UtcNow,
                    TicketsCount = 1,
                    Event = eventModel,
                    User = otherUser
                },
                new Order
                {
                    OrderedOn = DateTime.UtcNow,
                    TicketsCount = 2,
                    Event = eventModel,
                    User = user
                },
                new Order
                {
                    OrderedOn = DateTime.UtcNow,
                    TicketsCount = 3,
                    Event = eventModel,
                    User = user
                }
            };
            await context.Orders.AddRangeAsync(orders);

            await context.SaveChangesAsync();

            // Act
            var all = await ordersService.GetAllForUser(user.UserName);

            // Assert
            var count = all.Count();
            Assert.Equal(2, count);
        }

        [Fact]
        public async Task GetAllForUser_WithNoOrders_ShouldWorkCorrectly()
        {
            // Arrange
            var context = new EventuresDbContext(new DbContextOptionsBuilder<EventuresDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options);
            var ordersService = new OrdersService(context);

            var eventModel = new EventuresEvent
            {
                Name = "Test Event",
                TotalTickets = 30,
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow,
                Place = "Test Place",
                PricePerTicket = 30
            };
            await context.Events.AddAsync(eventModel);

            var user = new EventuresUser
            {
                UserName = "User"
            };
            await context.Users.AddAsync(user);

            var otherUser = new EventuresUser
            {
                UserName = "OtherUser"
            };
            await context.Users.AddAsync(otherUser);

            var orders = new[]
            {
                new Order
                {
                    OrderedOn = DateTime.UtcNow,
                    TicketsCount = 1,
                    Event = eventModel,
                    User = otherUser
                },
                new Order
                {
                    OrderedOn = DateTime.UtcNow,
                    TicketsCount = 2,
                    Event = eventModel,
                    User = otherUser
                },
                new Order
                {
                    OrderedOn = DateTime.UtcNow,
                    TicketsCount = 3,
                    Event = eventModel,
                    User = otherUser
                }
            };
            await context.Orders.AddRangeAsync(orders);

            await context.SaveChangesAsync();

            // Act
            var all = await ordersService.GetAllForUser(user.UserName);

            // Assert
            var count = all.Count();
            Assert.Equal(0, count);
        }

        [Fact]
        public async Task GetAllForUser_WithNonExistentUser_ShouldWorkCorrectly()
        {
            // Arrange
            var context = new EventuresDbContext(new DbContextOptionsBuilder<EventuresDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options);
            var ordersService = new OrdersService(context);

            // Act
            var all = await ordersService.GetAllForUser("NonExistentUser");

            // Assert
            Assert.Null(all);
        }
    }
}