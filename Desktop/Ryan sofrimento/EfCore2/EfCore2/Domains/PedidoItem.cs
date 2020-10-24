using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EfCore2.Domains
{
    public class PedidoItem
    {
        [Key]

        public Guid IdPedido { get; set; }
        [ForeignKey("Pedido")]
        public Pedido Pedido { get; set; }

        public Guid IdProduto { get; set; }
        [ForeignKey("Produto")]
        public Produto Produto { get; set; }

        [Required]
        public int Quantidade { get; set; }

        public PedidoItem()
        {

        }
    }
}
