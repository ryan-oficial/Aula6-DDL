using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EfCore2.Domains
{
    public class Pedido : BaseDomain
    {
        [Key]

        public string Status { get; set; }
        public DateTime OrderDate { get; set; }

        public List<PedidoItem> PedidosItens { get; set; }
    }
}
