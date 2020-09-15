﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_EFCore.Domains
{
    public class PedidoItem
    {
        public Guid Id { get; set; }

        [ForeignKey("IdPedido")]          
        public Guid IdPedido { get; set; }
        public Pedido Pedido { get; set; }

        [ForeignKey("IdProduto")]
        public Produto Produto { get; set; }
        public Guid IdProduto { get; set; }



    }
}
