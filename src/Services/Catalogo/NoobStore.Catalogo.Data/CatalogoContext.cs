using System;
using Microsoft.EntityFrameworkCore;
using NoobStore.Catalogo.Domain.Entidades;
using NoobStore.Core.Data;
using System.Linq;
using System.Threading.Tasks;

namespace NoobStore.Catalogo.Data
{
    public class CatalogoContext : DbContext, IUnitOfWork
    {
        public CatalogoContext(DbContextOptions<CatalogoContext> options) : base(options){}
        
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Pega todas as propriedades do tipo string e mapeia para um varchar 100
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");
            {
                
            }
            //Busca todos as entidades mapping
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogoContext).Assembly);
        }
        
        public async Task<bool> Commit()
        {
            //Procura por propriedades que tem DataCadastro..
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                //Se for um novo registro seta uma data para o DataCadastro
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                //Se nao for um novo registro garante que a data cadastro nao seja modificada.
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }
            
            return await base.SaveChangesAsync() > 0;
        }
    }
}