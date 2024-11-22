using AccountService.Api.Dtos;
using AccountService.Api.Mappers.Interfaces;
using AccountService.Api.Models;
using AccountService.Api.Repositories.Interfaces;
using AccountService.Api.Services;
using Moq;

namespace AccountService.Test
{
    [TestClass]
    public class MovementServiceIntegrationTests
    {
        private Mock<IMovementMapper> _mapperMock;
        private Mock<IMovementRepository> _repositoryMock;
        private MovementService _movementService;

        [TestInitialize]
        public void Setup()
        {
            _mapperMock = new Mock<IMovementMapper>();
            _repositoryMock = new Mock<IMovementRepository>();
            _movementService = new MovementService(_repositoryMock.Object, _mapperMock.Object);
        }

        [TestMethod]
        public async Task ValidateFunds_ShouldNotThrowException_WhenNewBalanceIsPositive()
        {
            // Arrange
            var movementDto = new MovementDto
            {
                AccountNumber = "12345",
                Amount = 100
            };

            var movement = new Movement
            {
                AccountNumber = "12345",
                Amount = 100,
                Balance = 100
            };

            _repositoryMock.Setup(r => r.GetOpeningDeposit(It.IsAny<string>())).ReturnsAsync(0);
            _repositoryMock.Setup(r => r.SumMovements(It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(0);
            _mapperMock.Setup(m => m.ParseToMovement(It.IsAny<MovementDto>())).Returns(movement);
            _mapperMock.Setup(m => m.ParseToMovementDto(It.IsAny<Movement>())).Returns(new ReadonlyMovementDto());

            // Act
            var result = await _movementService.AddAsync(movementDto);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
