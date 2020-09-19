using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_EFCore.Domains
{

    /// <summary>
    ///  Define a classe produto
    /// </summary>
    public class Produto : BaseDomain
    {

        public string Nome { get; set; }
        public float Preço { get; set; }

        [NotMapped] //Nao mapeia a propriedade no banco
        public IFormFile Imagem { get; set; }

        //Url de imagem do produto
        public string UrlIMagem { get; set; }
        public List<PedidoItem> PedidoItens { get; set; }


    }
}
