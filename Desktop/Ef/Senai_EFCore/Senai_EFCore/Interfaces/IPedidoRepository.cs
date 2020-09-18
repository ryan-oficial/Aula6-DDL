using Senai_EFCore.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_EFCore.Interfaces
{
    interface IPedidoRepository
    {

        List<Pedido> Listar();
        Pedido BUscarPorId(Guid id);
        Pedido Adicionar(List<PedidoItem> pedidosItens);
    }
}
