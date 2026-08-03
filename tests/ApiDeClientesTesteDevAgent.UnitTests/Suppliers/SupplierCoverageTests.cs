using Moq;
using ApiDeClientesTesteDevAgent.Application.Suppliers;
using ApiDeClientesTesteDevAgent.Domain.Suppliers;

namespace ApiDeClientesTesteDevAgent.UnitTests.Suppliers
{
    public sealed class SupplierCoverageTests
    {
        private static Mock<ISupplierRepository> Repository() => new(MockBehavior.Strict);

        [Fact]
        public void Constructor_Should_Normalize_Values_And_Set_Defaults()
        {
            var item = new Supplier("  Fornecedor Alpha  ", "  123456  ", "  alpha@example.com  ");
            Assert.Equal("Fornecedor Alpha", item.Name);
            Assert.Equal("123456", item.Document);
            Assert.Equal("alpha@example.com", item.Email);
            Assert.True(item.Active);
            Assert.NotEqual(Guid.Empty, item.Id);
            Assert.True(item.CreatedAtUtc <= DateTime.UtcNow);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("A")]
        public void Rename_Should_Reject_Invalid_Name(string value)
        {
            var item = new Supplier("Fornecedor", "123");
            Assert.Throws<ArgumentException>(() => item.Rename(value));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("12")]
        public void ChangeDocument_Should_Reject_Invalid_Document(string value)
        {
            var item = new Supplier("Fornecedor", "123");
            Assert.Throws<ArgumentException>(() => item.ChangeDocument(value));
        }

        [Fact]
        public void ChangeEmail_Should_Accept_Empty_And_Reject_Invalid_Value()
        {
            var item = new Supplier("Fornecedor", "123", "old@example.com");
            item.ChangeEmail("");
            Assert.Equal(string.Empty, item.Email);
            Assert.Throws<ArgumentException>(() => item.ChangeEmail("invalid"));
        }

        [Fact]
        public void State_And_Update_Timestamp_Should_Change()
        {
            var item = new Supplier("Fornecedor", "123");
            item.Deactivate();
            Assert.False(item.Active);
            Assert.NotNull(item.UpdatedAtUtc);
            item.Activate();
            item.Rename("Fornecedor Novo");
            item.ChangeDocument("999");
            Assert.True(item.Active);
            Assert.Equal("Fornecedor Novo", item.Name);
            Assert.Equal("999", item.Document);
        }

        [Fact]
        public async Task ListAsync_Should_Map_All_Items()
        {
            var items = new[] { new Supplier("Alpha", "111", "a@example.com"), new Supplier("Beta", "222", "b@example.com") };
            var repo = Repository();
            repo.Setup(x => x.ListAsync(It.IsAny<CancellationToken>())).ReturnsAsync(items);
            var result = await new SupplierService(repo.Object).ListAsync();
            Assert.Equal(2, result.Count);
            Assert.Equal(items[0].Id, result[0].Id);
            Assert.Equal("Beta", result[1].Name);
            repo.VerifyAll();
        }

        [Fact]
        public async Task GetByIdAsync_Should_Map_Item()
        {
            var item = new Supplier("Alpha", "111", "a@example.com");
            var repo = Repository();
            repo.Setup(x => x.GetByIdAsync(item.Id, It.IsAny<CancellationToken>())).ReturnsAsync(item);
            var result = await new SupplierService(repo.Object).GetByIdAsync(item.Id);
            Assert.Equal(item.Id, result.Id);
            Assert.Equal(item.Document, result.Document);
            repo.VerifyAll();
        }

        [Fact]
        public async Task GetByIdAsync_Should_Throw_When_Missing()
        {
            var repo = Repository();
            repo.Setup(x => x.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync((Supplier?)null);
            await Assert.ThrowsAsync<KeyNotFoundException>(() => new SupplierService(repo.Object).GetByIdAsync(Guid.NewGuid()));
            repo.VerifyAll();
        }

        [Fact]
        public async Task CreateAsync_Should_Add_Save_And_Map()
        {
            var repo = Repository();
            repo.Setup(x => x.AddAsync(It.IsAny<Supplier>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
            repo.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
            var result = await new SupplierService(repo.Object).CreateAsync(new CreateSupplierRequest("Alpha", "111", "a@example.com"));
            Assert.Equal("Alpha", result.Name);
            Assert.True(result.Active);
            repo.VerifyAll();
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task UpdateAsync_Should_Update_All_Fields_And_Status(bool active)
        {
            var item = new Supplier("Alpha", "111", "a@example.com");
            var repo = Repository();
            repo.Setup(x => x.GetByIdAsync(item.Id, It.IsAny<CancellationToken>())).ReturnsAsync(item);
            repo.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
            var result = await new SupplierService(repo.Object).UpdateAsync(item.Id, new UpdateSupplierRequest("Beta", "222", "b@example.com", active));
            Assert.Equal("Beta", result.Name);
            Assert.Equal("222", result.Document);
            Assert.Equal(active, result.Active);
            repo.VerifyAll();
        }

        [Fact]
        public async Task UpdateAsync_Should_Throw_When_Missing()
        {
            var repo = Repository();
            repo.Setup(x => x.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync((Supplier?)null);
            await Assert.ThrowsAsync<KeyNotFoundException>(() => new SupplierService(repo.Object).UpdateAsync(Guid.NewGuid(), new UpdateSupplierRequest("Beta", "222", "b@example.com", true)));
            repo.VerifyAll();
        }

        [Fact]
        public async Task DeleteAsync_Should_Remove_And_Save()
        {
            var item = new Supplier("Alpha", "111");
            var repo = Repository();
            repo.Setup(x => x.GetByIdAsync(item.Id, It.IsAny<CancellationToken>())).ReturnsAsync(item);
            repo.Setup(x => x.Remove(item));
            repo.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
            await new SupplierService(repo.Object).DeleteAsync(item.Id);
            repo.VerifyAll();
        }

        [Fact]
        public async Task DeleteAsync_Should_Throw_When_Missing()
        {
            var repo = Repository();
            repo.Setup(x => x.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync((Supplier?)null);
            await Assert.ThrowsAsync<KeyNotFoundException>(() => new SupplierService(repo.Object).DeleteAsync(Guid.NewGuid()));
            repo.VerifyAll();
        }
    }
}
