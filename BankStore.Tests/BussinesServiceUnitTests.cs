using Moq;
using BankStore.BL.Services;
using BankStore.DL.Interfaces;
using BankStore.Models.DTO;
using BankStore.BL.Interfaces;

namespace BankStore.Tests
{
    public class BussinesServiceUnitTests
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

        public BussinesServiceUnitTests()
        {
            _bankRepositoryMock = new Mock<IBankRepository>();
            _customerRepositoryMock = new Mock<ICustumerRepository>();
        }
        [Fact]
        public void GetAllBank_Ok()
        {
            //setup
            var expectedCount = 3;

            _bankRepositoryMock.Setup(x => x.GetAll()).Returns(_banks);
            _customerRepositoryMock.Setup(x => x.GetById(It.IsAny<string>())).Returns((string id) => _customers.FirstOrDefault(x => x.Id == id));

            //inject
            var businessService = new BussinesServises(

                _bankRepositoryMock.Object,
                _customerRepositoryMock.Object);

            //act
            var result = businessService.GetAllBank();

            //assert
            Assert.NotNull(result);
            Assert.Equal(expectedCount, result.Count);


        }

    }
}

