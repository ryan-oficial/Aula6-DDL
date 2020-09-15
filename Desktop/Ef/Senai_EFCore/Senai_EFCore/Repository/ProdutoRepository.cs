using Senai_EFCore.Contexts;
using Senai_EFCore.Domains;
using Senai_EFCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_EFCore.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly PedidoContext _ctx;
        
        public ProdutoRepository()
        {
            _ctx = new PedidoContext();
        }


        #region Leitura
        /// <summary>
        /// Lista os produtos cadastrados
        /// </summary>
        /// <returns>Retorna uma lista de produtos</returns>
        public List<Produto> Listar()
        {
            try
            {
                return _ctx.Produtos.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Busca um produto pelo seu Id
        /// </summary>
        /// <param name="id">Id do produto</param>
        /// <returns>Retorna o produto(s) procurados</returns>
        public Produto BuscarPorId(Guid id)
        {
            try
            {
                //return _ctx.Produtos.FirstOrDefault(x => x.Id == id);
                return _ctx.Produtos.Find(id);
                
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca produtos usando o nome
        /// </summary>
        /// <param name="nome">Nome do produto</param>
        /// <returns>Retorna o produto procurado</returns>
        public List<Produto> BuscarPorNome(string nome)
        {
            try
            {
                return _ctx.Produtos.Where(x => x.Nome.Contains(nome)).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion


        #region Gravaçao

        public void Adicionar(Produto produto)
        {

            try
            {
            //Adiciona um produto
            _ctx.Produtos.Add(produto);
            //Salva as alteraçoes
            _ctx.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Edita um produto
        /// </summary>
        /// <param name="produto">Produto ja editado</param>
        public void Editar(Produto produto)
        {
            try
            {
                //Busca produto pelo id
                Produto produtoTemp = BuscarPorId(produto.Id);

                //verifica se o produto existe
                //caso não exista gera uma exeçao
                if (produtoTemp == null)
                    throw new Exception("Produto não encontrado");

                //caso exista altera as propriedades
                produtoTemp.Nome = produto.Nome;
                produtoTemp.Preço = produto.Preço;

                //Altera produtos no contexto
                _ctx.Produtos.Update(produtoTemp);
                //Salva o contexto
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Remove um produto
        /// </summary>
        /// <param name="id">Id do produto</param>
        public void Remover(Guid id)
        {
            try
            {
                //Busca produto pelo id
                Produto produtoTemp = BuscarPorId(id);

                //verifica se o produto existe
                //caso não exista gera uma exeçao
                if (produtoTemp == null)
                    throw new Exception("Produto não encontrado");

                //Remove o produto
                _ctx.Produtos.Remove(produtoTemp);
                //Salva a alteraçao
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
