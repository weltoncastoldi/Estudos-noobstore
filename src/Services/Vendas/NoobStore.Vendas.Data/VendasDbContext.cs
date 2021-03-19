using Microsoft.EntityFrameworkCore;
using NoobStore.Core.Data;
using NoobStore.Vendas.Domain;
using System;
using System.Linq;
using System.Threading.Tasks;
using NoobStore.Core.Messages;

namespace NoobStore.Vendas.Data
{
    public class VendasDbContext : DbContext, IUnitOfWork
    {
        public VendasDbContext(DbContextOptions<VendasDbContext> options) : base(options) { }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoItem> PedidosItens { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Pega todas as propriedades do tipo string e mapeia para um varchar 100
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");
            {

            }
            modelBuilder.Ignore<Evento>();

            //Busca todos as entidades mapping
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(VendasDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                
            }

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
