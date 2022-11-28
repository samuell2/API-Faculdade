using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aula01.Data.Mapping;
using Aula01.Domain;
using Microsoft.EntityFrameworkCore;

namespace Aula01.Data
{
    public class GestaoProdutoContext : DbContext
    {
        public GestaoProdutoContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Categoria> CATEGORIA { get; set; }
        public DbSet<Produto> PRODUTO { get; set; }
        public DbSet<Fornecedor> FORNECEDOR { get; set; }

        public DbSet<Usuario> USUARIO { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new FornecedorMap());
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
        }
    }
}
