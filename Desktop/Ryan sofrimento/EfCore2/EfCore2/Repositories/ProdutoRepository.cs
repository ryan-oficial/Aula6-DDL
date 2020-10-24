using EfCore2.Contexts;
using EfCore2.Domains;
using EfCore2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfCore2.Repositories
{
    public class ProdutoRepository : IProdutoRepository , IDisposable
    {
        private readonly PedidoContext ctx;

        public ProdutoRepository()
        {
            ctx = new PedidoContext();
        }
        public void Adicionar(Produto produto)
        {
            try
            {
                ctx.Add(produto);
                ctx.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Produto BuscarPorId(Guid id)
        {
            try
            {
                return ctx.Produtos.Find(id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<Produto> BuscarPorNome(string nome)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Editar(Produto produto)
        {
            try
            {
                var produtoTemp = ctx.Produtos.Find(produto.Id);
                produtoTemp.Nome = produto.Nome;
                produtoTemp.Preco = produto.Preco;

                ctx.Update(produtoTemp);
                ctx.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<Produto> Listar()
        {
            try
            {
                return ctx.Produtos.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Remover(Guid id)
        {
            try
            {
                var produtoTemp = ctx.Produtos.Find(id);
                ctx.Update(produtoTemp);
                ctx.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
