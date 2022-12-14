using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DevLuan.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace DevLuan.Data.Context
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions<MeuDbContext> options) : base(options)
        { 
            
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Endereco> Enderecos{ get; set; }
        public DbSet<Fornecedor> Fornecedores{ get; set; }

        protected override  void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
    }
}
