using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
    public class PalestrantePersistence : IPalestrantePersistence
    {
        private readonly ProEventosContext _context;

        public PalestrantePersistence(ProEventosContext context)
        {
            _context = context;
        }
       

        async Task<Palestrante[]> IPalestrantePersistence.GetAllPalestrantesAsync(bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
            .Include(e => e.RedeSociais);

            if(includeEventos)
            {
                query = query
                .Include(e => e.PalestrantesEventos)
                .ThenInclude(pe => pe.Evento);
            }

            query = query.OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        async Task<Palestrante[]> IPalestrantePersistence.GetAllPalestrantesByNomeAsync(string nome, bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
            .Include(p => p.RedeSociais);

            if(includeEventos)
            {
                query = query
                .Include(e => e.PalestrantesEventos)
                .ThenInclude(pe => pe.Evento);
            }

            query = query.OrderBy(p => p.Id).Where(p => p.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }

       
        async Task<Palestrante> IPalestrantePersistence.GetPalestranteByIdAsync(int PalestranteId, bool includeEventos)
        {
             IQueryable<Palestrante> query = _context.Palestrantes
            .Include(p => p.RedeSociais);

            if(includeEventos)
            {
                query = query
                .Include(p => p.PalestrantesEventos)
                .ThenInclude(pe => pe.Evento);
            }

            query = query.OrderBy(e => e.Id)
            .Where(e => e.Id == PalestranteId);

            return await query.FirstOrDefaultAsync();
        }

    }
}