using System;
using System.Collections.Generic;
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
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoRepository _pedidoRespository;

        public PedidosController()
        {
            _pedidoRespository = new PedidoRepository();
        }

        [HttpPost]
        public IActionResult Post(List<PedidoItem> pedidosItens)
        {
            try
            {
                //adiciona um pedido
                Pedido pedido = _pedidoRespository.Adicionar(pedidosItens);
                return Ok(pedido);
            }
            catch (System.Exception ex)
            { 
                return BadRequest(ex.Message);
            }
        }
    }
}
