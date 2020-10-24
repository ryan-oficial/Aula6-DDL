using EfCore2.Contexts;
using EfCore2.Domains;
using EfCore2.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfCore2.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly PedidoContext _ctx;

            public PedidoRepository()
        {
            _ctx = new PedidoContext();
        }
        public Pedido Adicionar(List<PedidoItem> pedidosItens)
        {
            try
            {
                Pedido pedido = new Pedido
                {
                    Status = "Pedido Efetuado",
                    OrderDate = DateTime.Now,
                    PedidosItens = new List<PedidoItem>()
                };
                foreach (var item in pedidosItens)
                {
                    pedido.PedidosItens.Add(new PedidoItem
                    {
                        IdPedido = pedido.Id,
                        IdProduto = item.IdProduto,
                        Quantidade = item.Quantidade
                    });

                }
                _ctx.Pedidos.Add(pedido);
                _ctx.SaveChanges();

                return pedido;
            }
            catch (System.Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<Pedido> Listar()
        {
            try
            {
                return _ctx.Pedidos
                    .Include(i => i.PedidosItens)
                    .ThenInclude(x => x.Produto)
                    .ToList();
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
