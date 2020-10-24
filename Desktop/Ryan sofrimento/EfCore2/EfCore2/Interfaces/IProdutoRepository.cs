using EfCore2.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfCore2.Interfaces
{
    public interface IProdutoRepository
    {
        List<Produto> Listar();
        List<Produto> BuscarPorNome(string nome);
        Produto BuscarPorId(Guid Id);
        void Adicionar(Produto produto);
        void Editar(Produto produto);
        void Remover(Guid id);


    }
}
