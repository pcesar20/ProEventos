using System;
using System.Threading.Tasks;
using ProEventos.Application.Contratos;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Application
{
    public class EventoService : IEventosService
    {
        private readonly IGeralPersistence _geralPersistence;
        private readonly IEventosPersistence _eventosPersistence;

        public EventoService(IGeralPersistence geralPersistence, IEventosPersistence eventosPersistence)
        {
            _geralPersistence = geralPersistence;
            _eventosPersistence = eventosPersistence;
        }
        async Task<Evento> IEventosService.AddEventos(Evento model)
        {
            try
            {
                 _geralPersistence.Add<Evento>(model);
                 if(await _geralPersistence.SaveChangesAsync())
                 {
                     return await _eventosPersistence.GetEventoByIdAsync(model.Id, false);
                 }
                 return null;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        async Task<Evento> IEventosService.UpdateEventos(int eventoId, Evento model)
        {
            try
            {
                 var evento = await _eventosPersistence.GetEventoByIdAsync(eventoId, false);
                 if(evento == null) return null;

                 model.Id = evento.Id;

                 _geralPersistence.Update(model);

                 if(await _geralPersistence.SaveChangesAsync())
                 {
                     return await _eventosPersistence.GetEventoByIdAsync(model.Id, false);
                 }
                 return null;

            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        async Task<bool> IEventosService.DeleteEvento(int eventoId)
        {
           try
            {
                 var evento = await _eventosPersistence.GetEventoByIdAsync(eventoId, false);
                 if(evento == null) throw new Exception("Evento não encontrado");
                 
                 _geralPersistence.Delete<Evento>(evento);

                return await _geralPersistence.SaveChangesAsync();
                

            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        async Task<Evento[]> IEventosService.GetAllEventosAsync(bool includePalestrantes)
        {
            try
            {
                 var eventos = await _eventosPersistence.GetAllEventosAsync(includePalestrantes);
                 if(eventos == null) return null;

                 return null;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        async Task<Evento[]> IEventosService.GetAllEventosByTemaAsync(string tema, bool includePalestrantes)
        {
            try
            {
                 var eventos = await _eventosPersistence.GetAllEventosByTemaAsync(tema, includePalestrantes);
                 if(eventos == null) return null;

                 return null;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        async Task<Evento> IEventosService.GetEventoByIdAsync(int EventoId, bool includePalestrantes)
        {
           try
            {
                 var eventos = await _eventosPersistence.GetEventoByIdAsync(EventoId, includePalestrantes);
                 if(eventos == null) return null;

                 return null;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
    }
}