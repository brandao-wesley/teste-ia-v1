using ApiDeClientesTesteDevAgent.Application.Customers;
using ApiDeClientesTesteDevAgent.Domain.Customers;
using Moq;

namespace ApiDeClientesTesteDevAgent.UnitTests.Customers
{
    public sealed class CustomerServiceTests
    {
        [Fact]
        public async Task CreateAsync_Should_Add_Customer_And_Save()
        {
            var repo = new Mock<ICustomerRepository>();
            Customer? captured = null;
            repo.Setup(x => x.AddAsync(It.IsAny<Customer>(), It.IsAny<CancellationToken>()))
                .Callback<Customer, CancellationToken>((c, _) => captured = c)
                .Returns(Task.CompletedTask);
            repo.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
            var service = new CustomerService(repo.Object);

            var dto = await service.CreateAsync(new CreateCustomerRequest("Maria", "maria@email.com", "24"));

            Assert.Equal("Maria", dto.Name);
            Assert.NotNull(captured);
            repo.Verify(x => x.AddAsync(It.IsAny<Customer>(), It.IsAny<CancellationToken>()), Times.Once);
            repo.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task GetByIdAsync_Should_Throw_When_Not_Found()
        {
            var repo = new Mock<ICustomerRepository>();
            repo.Setup(x => x.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync((Customer?)null);
            var service = new CustomerService(repo.Object);
            await Assert.ThrowsAsync<KeyNotFoundException>(() => service.GetByIdAsync(Guid.NewGuid()));
        }

        [Fact]
        public async Task UpdateAsync_Should_Update_All_Fields()
        {
            var customer = new Customer("Joao", "joao@email.com", "1");
            var repo = new Mock<ICustomerRepository>();
            repo.Setup(x => x.GetByIdAsync(customer.Id, It.IsAny<CancellationToken>())).ReturnsAsync(customer);
            repo.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
            var service = new CustomerService(repo.Object);

            var dto = await service.UpdateAsync(customer.Id, new UpdateCustomerRequest("Joana", "joana@email.com", "2", false));

            Assert.Equal("Joana", dto.Name);
            Assert.False(dto.Active);
            repo.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
