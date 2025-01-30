using Moq;
using BankStore.BL.Services;
using BankStore.DL.Interfaces;
using BankStore.Models.DTO;
using Microsoft.Extensions.Logging;

namespace BankStore.Tests
{
    public class BankServiceTests
    {
        private readonly Mock<IBankRepository> _bankRepositoryMock;
        private readonly Mock<ICustumerRepository> _customerRepositoryMock;

        private List<Customers> _customers = new List<Customers>
        {
          new Customers()
          {
              Id="1",
              Name ="Ivan Draganov",
          },
          new Customers()
          {
              Id="2",
              Name ="Dragan Ivanov"
          },
          new Customers()
          {
              Id="3",
              Name ="Mihail Ivanov"
          },
        };

        private List<Bank> _banks = new List<Bank>
        {
            new Bank()
            {
               Id = "1",
               Name = "UnicreditBulbank",
               Nomer = 10

            },
            new Bank()
            {
                Id = "2",
                Name ="OBB",
                Nomer = 20

            },
            new Bank()
            {
                Id = "3",
                Name ="DSK",
                Nomer = 30
            }
        };

        public BankServiceTests()
        {
            _bankRepositoryMock = new Mock<IBankRepository>();
            _customerRepositoryMock = new Mock<ICustumerRepository>();
        }


        [Fact]
        void GetById_Ok()
        {
            //Arrange
            var bankId = _banks[0].Id;

            _bankRepositoryMock.Setup(x => x.GetById(It.IsAny<string>())).Returns((string id) => _banks.FirstOrDefault(m => m.Id == id));


            var loggerMock = new Mock<ILogger<BankServises>>();
            ILogger<BankServises> logger = loggerMock.Object;

            //Act
            var teamService = new BankServises(
                _bankRepositoryMock.Object,
                logger,
                _customerRepositoryMock.Object);

            var result = teamService.GetById(bankId);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(bankId, result.Id);
        }

        [Fact]
        void GetById_NotExistingId()
        {
            //Arrange
            var bankId = Guid.NewGuid().ToString();

            _bankRepositoryMock.Setup(x => x.GetById(It.IsAny<string>())).Returns((string id) => _banks.FirstOrDefault(m => m.Id == id));

            var loggerMock = new Mock<ILogger<BankServises>>();
            ILogger<BankServises> logger = loggerMock.Object;

            //Act
            var bankService = new BankServises(
                _bankRepositoryMock.Object,
                logger,
                _customerRepositoryMock.Object);

            var result = bankService.GetById(bankId);

            //Assert
            Assert.Null(result);
        }

        [Fact]
        void GetById_WrongGuidId()
        {
            //Arrange
            var bankId = "hjhj";

            _bankRepositoryMock.Setup(x => x.GetById(It.IsAny<string>())).Returns((string id) => _banks.FirstOrDefault(m => m.Id == id));

            var loggerMock = new Mock<ILogger<BankServises>>();
            ILogger<BankServises> logger = loggerMock.Object;

            //Act
            var bankService = new BankServises(
                _bankRepositoryMock.Object,
                logger,
                _customerRepositoryMock.Object);

            var result = bankService.GetById(bankId);

            //Assert
            Assert.Null(result);
        }


    }
}

