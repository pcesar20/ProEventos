using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contratos
{
    public interface IEventosPersistence
    {

        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes);

        Task<Evento[]> GetAllEventosAsync(bool includePalestrantes);

        Task<Evento> GetEventoByIdAsync(int EventoId, bool includePalestrantes);
     
    }
}