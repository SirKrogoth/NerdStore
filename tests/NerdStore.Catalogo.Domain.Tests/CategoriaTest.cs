using NerdStore.Core.DomainObject;
using Xunit;

namespace NerdStore.Catalogo.Domain.Tests
{
    public class CategoriaTest
    {
        [Fact]
        public void CategoriaValidarValidacoesRetornarExceptions()
        {
            var ex = Assert.Throws<DomainException>(() =>
                new Categoria(string.Empty, 1)
            );

            Assert.Equal("O campo Nome do Produto não pode estar vazio.", ex.Message);

            ex = Assert.Throws<DomainException>(() => 
                new Categoria("nome", 0)
            );

            Assert.Equal("O campo Código do Produto não pode ser zero.", ex.Message);
        }
    }
}