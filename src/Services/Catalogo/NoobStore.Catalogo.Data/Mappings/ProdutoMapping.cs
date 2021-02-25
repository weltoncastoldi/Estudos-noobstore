using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoobStore.Catalogo.Domain.Entidades;

namespace NoobStore.Catalogo.Data.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos");
            
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(250)");
            
            builder.Property(c => c.Descricao)
                .IsRequired()
                .HasColumnType("varchar(250)");
            
            builder.Property(c => c.Imagem)
                .IsRequired()
                .HasColumnType("varchar(250)");
            
            //transforma objeto de valor em colunas na tabela
            builder.OwnsOne(c => c.Dimensoes, cm =>
            {
                cm.Property(c => c.Altura).HasColumnName("Altura").HasColumnType("int");
                cm.Property(c => c.Largura).HasColumnName("Largura").HasColumnType("int");
                cm.Property(c => c.Profundidade).HasColumnName("Profundidade").HasColumnType("int");
            });
            
        }
    }
}
