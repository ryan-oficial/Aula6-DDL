using EfCore2.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfCore2.Interfaces
{
     public interface IPedidoRepository
    {
        List<Pedido> Listar();

        Pedido Adicionar(List<PedidoItem> pedidoItens);
    }
}
