using ApiDeClientesTesteDevAgent.Domain.Estoques;

namespace ApiDeClientesTesteDevAgent.UnitTests.Estoques
{
    public sealed class EstoqueTests
    {
        [Fact] public void Constructor_Creates_Active_Item() { var x=new Estoque("Fornecedor Alpha","123456","alpha@example.com"); Assert.True(x.Active); Assert.Equal("Fornecedor Alpha",x.Name); }
        [Theory] [InlineData("")] [InlineData("A")] public void Rename_Rejects_Invalid(string value) { var x=new Estoque("Fornecedor","123"); Assert.Throws<ArgumentException>(()=>x.Rename(value)); }
        [Fact] public void Email_Rejects_Invalid() { var x=new Estoque("Fornecedor","123"); Assert.Throws<ArgumentException>(()=>x.ChangeEmail("invalido")); }
        [Fact] public void Status_Can_Change() { var x=new Estoque("Fornecedor","123"); x.Deactivate(); Assert.False(x.Active); x.Activate(); Assert.True(x.Active); }
    }
}
