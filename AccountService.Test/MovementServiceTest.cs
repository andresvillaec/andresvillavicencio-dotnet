using AccountMS.Exceptions;
using AccountService.Api.Mappers.Interfaces;
using AccountService.Api.Repositories.Interfaces;
using AccountService.Api.Services;
using AccountService.Api.Services.Interfaces;
using Moq;
using Newtonsoft.Json.Linq;
using System.ComponentModel;

namespace AccountService.Test
{
    [TestClass]
    public class MovementServiceTest
    {
        private Mock<IMovementRepository> _repositoryMock;
        private Mock<IMovementMapper> _mapperMock;
        private MovementService _movementService;

        [TestInitialize]
        public void Setup()
        {
            _repositoryMock = new Mock<IMovementRepository>();
            _mapperMock = new Mock<IMovementMapper>();
            _movementService = new MovementService(_repositoryMock.Object, _mapperMock.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(AccountException))]
        public void ValidateFunds_ShouldThrowAccountException_WhenNewBalanceIsNegative()
        {
            // Arrange
            decimal newBalance = -1;

            // Act
            _movementService.ValidateFunds(newBalance);
        }

        [TestMethod]
        public void ValidateFunds_ShouldNotThrowException_WhenNewBalanceIsZeroOrPositive()
        {
            // Arrange
            decimal newBalanceZero = 0;
            decimal newBalancePositive = 100;

            // Act & Assert
            try
            {
                _movementService.ValidateFunds(newBalanceZero);
                _movementService.ValidateFunds(newBalancePositive);
            }
            catch (Exception ex)
            {
                Assert.Fail($"No exception should be thrown, but got: {ex.GetType().Name}");
            }
        }
    }
}