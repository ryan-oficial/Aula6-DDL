using Microsoft.EntityFrameworkCore;
using Senai_EFCore.Contexts;
using Senai_EFCore.Domains;
using Senai_EFCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_EFCore.Repository
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
                //Criaçao do projeto pedido
                Pedido pedido = new Pedido
                {
                    Status = "Pedido Efetuado",
                    OrderDate = DateTime.Now
                };
                //retorna a lista de pedidos 
                foreach (var item in pedidosItens)
                {
                    //adiciona um pedidoitem a lista
                    pedido.PedidosItens.Add(new PedidoItem
                    {
                        IdPedido = pedido.Id, // id do pedido criado
                        IdProduto = item.IdProduto,
                        Quantidade = item.Quantidade
                    }); 
                }
                //adiciona pedido
                _ctx.Pedidos.Add(pedido);
                //salva as alteraçoes
                _ctx.SaveChanges();

                return pedido;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Pedido Adicionar(object pedidositens)
        {
            throw new NotImplementedException();
        }


        public Pedido BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Pedidos.Include(x => x.PedidosItens).ThenInclude(x => x.Produto).FirstOrDefault(x => x.Id == id);
                
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        private void FirstOrDefault(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }

        public List<Pedido> Listar()
        {
            try
            {
                return _ctx.Pedidos.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
