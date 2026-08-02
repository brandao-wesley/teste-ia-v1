using ApiDeClientesTesteDevAgent.Domain.Customers;

namespace ApiDeClientesTesteDevAgent.UnitTests.Customers
{
    public sealed class CustomerTests
    {
        [Fact]
        public void Constructor_Should_Create_Active_Customer()
        {
            var customer = new Customer("Wesley", "wesley@email.com", "24999999999");
            Assert.Equal("Wesley", customer.Name);
            Assert.Equal("wesley@email.com", customer.Email);
            Assert.True(customer.Active);
        }

        [Theory]
        [InlineData("")]
        [InlineData("A")]
        public void Rename_Should_Reject_Invalid_Name(string name)
        {
            var customer = new Customer("Cliente", "cliente@email.com");
            Assert.Throws<ArgumentException>(() => customer.Rename(name));
        }

        [Fact]
        public void ChangeEmail_Should_Reject_Invalid_Email()
        {
            var customer = new Customer("Cliente", "cliente@email.com");
            Assert.Throws<ArgumentException>(() => customer.ChangeEmail("email-invalido"));
        }

        [Fact]
        public void Deactivate_And_Activate_Should_Change_Status()
        {
            var customer = new Customer("Cliente", "cliente@email.com");
            customer.Deactivate();
            Assert.False(customer.Active);
            customer.Activate();
            Assert.True(customer.Active);
        }
    }
}
