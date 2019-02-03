using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Models.ViewModels
{
    public class BuscaDeProdutoViewModel
    {
        public BuscaDeProdutoViewModel(IList<Produto> produtos)
        {
            Produtos = produtos;
        }

        public BuscaDeProdutoViewModel(IList<Categoria> categorias)
        {
            Categorias = categorias;
        }

        public IList<Produto> Produtos { get; }

        public IList<Categoria> Categorias { get; }

      


    }
}
