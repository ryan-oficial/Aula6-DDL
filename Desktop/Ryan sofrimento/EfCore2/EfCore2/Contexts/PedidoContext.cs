using EfCore2.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfCore2.Contexts
{
    public class PedidoContext : DbContext
    {
        public DbSet<PedidoItem> PedidosItens { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Data Source=LAB107001\SQLEXPRESS2;Initial Catalog=loja;User ID=sa;Password=sa132");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
