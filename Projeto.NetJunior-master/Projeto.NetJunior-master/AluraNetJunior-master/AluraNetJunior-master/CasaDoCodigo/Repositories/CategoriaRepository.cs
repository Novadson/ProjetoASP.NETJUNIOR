
using CasaDoCodigo.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public interface ICategoriaRepository
    {
        Task SaveCategoria(string categoria);
        IList<Categoria> GetCategoria();
    }
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public IList<Categoria> GetCategoria()
        {
            return dbSet.ToList();
        }
      
        public async Task SaveCategoria(string categoria)
        {
            if (!dbSet.Where(c => c.Nome == categoria).Any())
            {
                dbSet.Add(new Categoria(categoria));
            }
            await contexto.SaveChangesAsync();
        }
    }
}
