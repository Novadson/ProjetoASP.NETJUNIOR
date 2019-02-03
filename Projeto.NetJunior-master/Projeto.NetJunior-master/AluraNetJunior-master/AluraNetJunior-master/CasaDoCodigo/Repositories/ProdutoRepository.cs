using CasaDoCodigo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        Categoria categoria = new Categoria();

        private readonly ICategoriaRepository categoriaRepository;

        public ProdutoRepository(ApplicationContext contexto,
             ICategoriaRepository categoriaRepository) : base(contexto)
        {
            this.categoriaRepository = categoriaRepository;
        }





    public async Task SaveProdutos(List<Livro> livros)
        {

            foreach (var livro in livros)
            {

                await categoriaRepository.SaveCategoria(livro.Categoria);

                if (!dbSet.Where(p => p.Codigo == livro.Codigo).Any())
                {
                    dbSet.Add(new Produto(livro.Codigo, livro.Nome, livro.Preco, categoria));
                }
            }
            await contexto.SaveChangesAsync();
        }

        public IList<Produto> GetProdutos()
        {
            return dbSet.ToList();
        }



        List<Produto> produtos = new List<Produto>();

        List<Categoria> categorias = new List<Categoria>();



        /*Instrutor Tentei fazer essa consulta,mas dando ERRO*/
        //public IList<Produto> GetProdutosPo()
        //{
        //    var busca = (from p in produtos

        //                 join c in categorias on p.Categoria.Id equals c.Id

        //                 select new {
        //                    Produto = c.Nome,
        //                    p.Categoria
        //                 });

        //    return busca.ToList();
        //}


        public IList<Produto> GetProdutos(string busca)
        {
            dbSet.Where(p => p.Nome.Trim().StartsWith(busca) || p.Categoria.Nome.Trim().StartsWith(busca));
                
            return dbSet.ToList();
        }



    }
}

