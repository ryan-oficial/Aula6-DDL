using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai_EFCore.Domains;
using Senai_EFCore.Interfaces;
using Senai_EFCore.Repository;

namespace Senai_EFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutosController()
        {
            _produtoRepository = new ProdutoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Lista os produtos no repositorio
                var produtos = _produtoRepository.Listar();

                //verifica se existe produtos
                if (produtos.Count == 0)
                    return NoContent();

                // caso exista retonra os produtos
                return Ok(new{ 
                    totalCount = produtos.Count,
                    data = produtos
                });
            }
            catch (Exception ex)
            {
                // No caso de algum erro retorn BadRequest
                return BadRequest(new
                {
                    statusCode = 400,
                    error = ex.Message
                }); 
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                //Busca o produto no repositorio
                Produto produto = _produtoRepository.BuscarPorId(id);

                //Verifica se o produto existe
                if (produto == null)
                    return NotFound();

                //Caso exista restorna ok
                return Ok(produto);
              
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna badrequest 
                return BadRequest(ex.Message);
            }
        }

        //FromForm - recebe os dados do produto na form-data
        [HttpPost]
        public IActionResult Post([FromForm]Produto produto)
        {
            try
            {
                if(produto.Imagem != null)
                {
                      //Gera o nome do arquivo unico
                      //Pego a extensao do arquivo
                      //Contateno o nome do arquivo com sua extensao
                      var nomeArquivo = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(produto.Imagem.FileName);

                    //GetCurrentDirectory - peg ao caminho do diretorio atual 
                    var caminhoarquivo = Path.Combine(Directory.GetCurrentDirectory(), @"wwwRoot\Upload\Imagens", nomeArquivo);

                    //Cria um objeto do tipo filestream passando o caminho do arquivo
                   
                    using var streamImagen = new FileStream(caminhoarquivo, FileMode.Create);

                    //executo o comando de criaçao no arquivo do local informado
                    produto.Imagem.CopyTo(streamImagen);

                    produto.UrlImagem = 
                };


                _produtoRepository.Adicionar(produto);

                return Ok(produto); 
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Produto produto)
        {
            try
            {
                var produtoTemp = _produtoRepository.BuscarPorId(id);

                if (produtoTemp == null)
                    return NotFound();

                _produtoRepository.Editar(produto);

                return Ok(produto);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _produtoRepository.Remover(id);

                return Ok(id);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


    }
}
