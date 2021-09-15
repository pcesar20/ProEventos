using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
    public class GeralPersistence : IGeralPersistence
    {
        private readonly ProEventosContext _context;

        public GeralPersistence(ProEventosContext context)
        {
            _context = context;
        }
        void IGeralPersistence.Add<T>(T entity)
        {
           _context.Add(entity);
        }

        void IGeralPersistence.Update<T>(T entity)
        {
           _context.Update(entity);
        }

        void IGeralPersistence.Delete<T>(T entity)
        {
            _context.Remove(entity);
        }

        void IGeralPersistence.DeleteRange<T>(T[] entityArray)
        {
             _context.Remove(entityArray);
        }

       
        async Task<bool> IGeralPersistence.SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}