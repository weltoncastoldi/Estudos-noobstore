using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NoobStore.Catalogo.Domain.Entidades;
using NoobStore.Core.Data;

namespace NoobStore.Catalogo.Data
{
    public class CatalogoContext : DbContext, IUnitOfWork
    {
        public CatalogoContext(DbContextOptions<CatalogoContext> options) : base(options){}
        
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        
        public override void OnModel
        
        public Task<bool> Commit()
        {
            throw new System.NotImplementedException();
        }
    }
}