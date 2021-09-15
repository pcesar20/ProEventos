using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
    public class EventosPersistence : IEventosPersistence
    {
        private readonly ProEventosContext _context;

        public EventosPersistence(ProEventosContext context)
        {
            _context = context;
        }
       

        async Task<Evento[]> IEventosPersistence.GetAllEventosAsync(bool includePalestrantes)
        {
            IQueryable<Evento> query = _context.Eventos
            .Include(e => e.Lotes)
            .Include(e => e.RedesSociais);

            if(includePalestrantes)
            {
                query = query
                .Include(e => e.PalestranteEventos)
                .ThenInclude(pe => pe.PalestranteId);
            }

            query = query.OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        async Task<Evento[]> IEventosPersistence.GetAllEventosByTemaAsync(string tema, bool includePalestrantes)
        {
              IQueryable<Evento> query = _context.Eventos
            .Include(e => e.Lotes)
            .Include(e => e.RedesSociais);

            if(includePalestrantes)
            {
                query = query
                .Include(e => e.PalestranteEventos)
                .ThenInclude(pe => pe.PalestranteId);
            }

            query = query.OrderBy(e => e.Id)
            .Where(e => e.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }

    
        async Task<Evento> IEventosPersistence.GetEventoByIdAsync(int EventoId, bool includePalestrantes)
        {
               IQueryable<Evento> query = _context.Eventos
            .Include(e => e.Lotes)
            .Include(e => e.RedesSociais);

            if(includePalestrantes)
            {
                query = query
                .Include(e => e.PalestranteEventos)
                .ThenInclude(pe => pe.PalestranteId);
            }

            query = query.OrderBy(e => e.Id)
            .Where(e => e.Id == EventoId);

            return await query.FirstOrDefaultAsync();
        }

    }
}