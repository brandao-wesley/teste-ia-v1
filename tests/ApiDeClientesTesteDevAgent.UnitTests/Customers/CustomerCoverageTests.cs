using ApiDeClientesTesteDevAgent.Application.Customers;
using ApiDeClientesTesteDevAgent.Domain.Customers;
using Moq;

namespace ApiDeClientesTesteDevAgent.UnitTests.Customers
{
    public sealed class CustomerCoverageTests
    {
        private static Mock<ICustomerRepository> Repository() => new(MockBehavior.Strict);

        [Fact]
        public void Constructor_Should_Trim_Values_And_Allow_Empty_Optional_Fields()
        {
            var customer = new Customer("  Maria  ", "  maria@email.com  ", null!);
            Assert.Equal("Maria", customer.Name);
            Assert.Equal("maria@email.com", customer.Email);
            Assert.Equal(string.Empty, customer.Phone);
            Assert.NotEqual(Guid.Empty, customer.Id);
            Assert.True(customer.CreatedAtUtc <= DateTime.UtcNow);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("A")]
        public void Constructor_Should_Reject_Invalid_Name(string? name)
            => Assert.Throws<ArgumentException>(() => new Customer(name!, "ok@email.com"));

        [Theory]
        [InlineData("invalid")]
        [InlineData("invalid.com")]
        public void Constructor_Should_Reject_Invalid_Email(string email)
            => Assert.Throws<ArgumentException>(() => new Customer("Cliente", email));

        [Fact]
        public void ChangeEmail_Should_Accept_Empty_And_ChangePhone_Should_Trim()
        {
            var customer = new Customer("Cliente", "old@email.com", "  123  ");
            customer.ChangeEmail("");
            customer.ChangePhone("  456  ");
            Assert.Equal(string.Empty, customer.Email);
            Assert.Equal("456", customer.Phone);
            Assert.NotNull(customer.UpdatedAtUtc);
        }

        [Fact]
        public async Task ListAsync_Should_Map_All_Customers()
        {
            var items = new[] { new Customer("Aline", "aline@email.com", "1"), new Customer("Theo", "theo@email.com", "2") };
            var repo = Repository();
            repo.Setup(x => x.ListAsync(It.IsAny<CancellationToken>())).ReturnsAsync(items);
            var result = await new CustomerService(repo.Object).ListAsync();
            Assert.Equal(2, result.Count);
            Assert.Equal(items[0].Id, result[0].Id);
            Assert.Equal("Theo", result[1].Name);
            repo.VerifyAll();
        }

        [Fact]
        public async Task GetByIdAsync_Should_Return_Dto_When_Found()
        {
            var customer = new Customer("Arthur", "arthur@email.com", "9");
            var repo = Repository();
            repo.Setup(x => x.GetByIdAsync(customer.Id, It.IsAny<CancellationToken>())).ReturnsAsync(customer);
            var dto = await new CustomerService(repo.Object).GetByIdAsync(customer.Id);
            Assert.Equal(customer.Id, dto.Id);
            Assert.Equal(customer.Phone, dto.Phone);
            repo.VerifyAll();
        }

        [Theory]
        [InlineData("", "ok@email.com")]
        [InlineData("A", "ok@email.com")]
        [InlineData("Nome", "invalido")]
        public async Task CreateAsync_Should_Validate_Request(string name, string email)
        {
            var repo = Repository();
            var service = new CustomerService(repo.Object);
            await Assert.ThrowsAsync<ArgumentException>(() => service.CreateAsync(new CreateCustomerRequest(name, email, "")));
        }

        [Fact]
        public async Task UpdateAsync_Should_Throw_When_Not_Found()
        {
            var repo = Repository();
            repo.Setup(x => x.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync((Customer?)null);
            var service = new CustomerService(repo.Object);
            await Assert.ThrowsAsync<KeyNotFoundException>(() => service.UpdateAsync(Guid.NewGuid(), new UpdateCustomerRequest("Nome", "nome@email.com", "", true)));
            repo.VerifyAll();
        }

        [Theory]
        [InlineData("", "ok@email.com")]
        [InlineData("Nome", "invalido")]
        public async Task UpdateAsync_Should_Validate_Before_Repository(string name, string email)
        {
            var repo = Repository();
            var service = new CustomerService(repo.Object);
            await Assert.ThrowsAsync<ArgumentException>(() => service.UpdateAsync(Guid.NewGuid(), new UpdateCustomerRequest(name, email, "", true)));
        }

        [Fact]
        public async Task UpdateAsync_Should_Activate_Customer()
        {
            var customer = new Customer("Cliente", "cliente@email.com");
            customer.Deactivate();
            var repo = Repository();
            repo.Setup(x => x.GetByIdAsync(customer.Id, It.IsAny<CancellationToken>())).ReturnsAsync(customer);
            repo.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
            var dto = await new CustomerService(repo.Object).UpdateAsync(customer.Id, new UpdateCustomerRequest("Novo Nome", "novo@email.com", "5", true));
            Assert.True(dto.Active);
            Assert.Equal("5", dto.Phone);
            repo.VerifyAll();
        }

        [Fact]
        public async Task DeleteAsync_Should_Remove_And_Save()
        {
            var customer = new Customer("Cliente", "cliente@email.com");
            var repo = Repository();
            repo.Setup(x => x.GetByIdAsync(customer.Id, It.IsAny<CancellationToken>())).ReturnsAsync(customer);
            repo.Setup(x => x.Remove(customer));
            repo.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
            await new CustomerService(repo.Object).DeleteAsync(customer.Id);
            repo.VerifyAll();
        }

        [Fact]
        public async Task DeleteAsync_Should_Throw_When_Not_Found()
        {
            var repo = Repository();
            repo.Setup(x => x.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync((Customer?)null);
            await Assert.ThrowsAsync<KeyNotFoundException>(() => new CustomerService(repo.Object).DeleteAsync(Guid.NewGuid()));
            repo.VerifyAll();
        }
    }
}
