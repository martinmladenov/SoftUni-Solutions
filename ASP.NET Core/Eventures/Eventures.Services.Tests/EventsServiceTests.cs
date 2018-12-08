namespace Eventures.Services.Tests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Data;
    using Eventures.Models;
    using Infrastructure.Mapping;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Xunit;

    public class EventsServiceTests : BaseTests
    {
        [Fact]
        public async Task Create_WithValidModel_ShouldAddToDatabase()
        {
            // Arrange
            var context = new EventuresDbContext(new DbContextOptionsBuilder<EventuresDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options);
            var eventsService = new EventsService(context);
            var model = new EventuresEventServiceModel
            {
                Name = "Test Event",
                Place = "Test Place",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow,
                TotalTickets = 1,
                PricePerTicket = 1
            };

            // Act
            await eventsService.CreateAsync(model);

            // Assert
            var count = await context.Events.CountAsync();
            Assert.Equal(1, count);
        }

        [Fact]
        public async Task Create_WithInvalidModel_ShouldNotAddToDatabase()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<EventuresDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new EventuresDbContext(options);
            var eventsService = new EventsService(context);
            var model = new EventuresEventServiceModel
            {
                Name = "Test Event",
                Place = "Test Place",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow,
                TotalTickets = -1,
                PricePerTicket = 1
            };

            // Act
            await eventsService.CreateAsync(model);

            // Assert
            var count = await context.Events.CountAsync();
            Assert.Equal(0, count);
        }

        [Fact]
        public async Task GetAll_WithTickets_ShouldReturnCorrectValue()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<EventuresDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new EventuresDbContext(options);
            var eventsService = new EventsService(context);
            object[] models =
            {
                new EventuresEvent
                {
                    Name = "Test Event 1",
                    Place = "Test Place 1",
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow,
                    TotalTickets = 2,
                    PricePerTicket = 2
                },
                new EventuresEvent
                {
                    Name = "Test Event 2",
                    Place = "Test Place 2",
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow,
                    TotalTickets = 3,
                    PricePerTicket = 3
                }
            };
            await context.AddRangeAsync(models);
            await context.SaveChangesAsync();

            // Act
            var count = (await eventsService.GetAll()).Count();

            // Assert
            Assert.Equal(2, count);
        }

        [Fact]
        public async Task GetAll_WithZeroTickets_ShouldReturnCorrectValue()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<EventuresDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new EventuresDbContext(options);
            var eventsService = new EventsService(context);
            object[] models =
            {
                new EventuresEvent
                {
                    Name = "Test Event 1",
                    Place = "Test Place 1",
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow,
                    TotalTickets = 2,
                    PricePerTicket = 2
                },
                new EventuresEvent
                {
                    Name = "Test Event 2",
                    Place = "Test Place 2",
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow,
                    TotalTickets = 0,
                    PricePerTicket = 3
                }
            };
            await context.AddRangeAsync(models);
            await context.SaveChangesAsync();

            // Act
            var count = (await eventsService.GetAll()).Count();

            // Assert
            Assert.Equal(1, count);
        }
    }
}