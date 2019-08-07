using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NerdStore.Catalogo.Domain;

namespace NerdStore.Catalogo.Data.Mappings
{
    public class CategoriaMapping : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(c => c.id);

            builder.Property(c => c.nome)
                .IsRequired()
                .HasColumnType("varchar(250)");

            // 1 : N => Categorias : Produtos
            builder.HasMany(c => c.produtos)
                .WithOne(p => p.categoria)
                .HasForeignKey(p => p.categoriaId);

            builder.ToTable("Categorias");
        }
    }
}