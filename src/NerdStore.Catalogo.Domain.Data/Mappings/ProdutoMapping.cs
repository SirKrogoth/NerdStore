using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NerdStore.Catalogo.Domain;

namespace NerdStore.Catalogo.Data.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        //Aqui será configurado a tabela que será criada no banco de dados.
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(c => c.id);

            builder.Property(c => c.nome)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(c => c.descricao)
                .IsRequired()
                .HasColumnType("varchar(500)");

            builder.Property(c => c.imagem)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.OwnsOne(c => c.dimensoes, cm =>
            {
                cm.Property(c => c.altura)
                    .HasColumnName("Altura")
                    .HasColumnType("int");

                cm.Property(c => c.largura)
                    .HasColumnName("Largura")
                    .HasColumnType("int");

                cm.Property(c => c.profundidade)
                    .HasColumnName("Profundidade")
                    .HasColumnType("int");
            });

            builder.ToTable("Produtos");
        }
    }
}