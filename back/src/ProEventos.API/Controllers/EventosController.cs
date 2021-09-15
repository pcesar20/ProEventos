using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.Persistence;
using ProEventos.Domain;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {

        public IEnumerable<Evento> _evento = new Evento[]{
        new Evento() {
               Id = 1,
               Tema = "teste",
               Local = "Goiania",
               Lote = "1 Lote",
               QtdPessoas = 250,
               DataEvento = DateTime.Now.AddDays(2),
               ImagemURL = "teste.png"
                      },
                       new Evento() {
               Id = 2,
               Tema = "teste 2",
               Local = "Aparecida",
               Lote = "1 Lote",
               QtdPessoas = 250,
               DataEvento = DateTime.Now.AddDays(2),
               ImagemURL = "teste.png"
                       }
    };
        private readonly ProEventosContext _context;
     
        public EventosController(ProEventosContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
           return _context.Eventos;
                
        }

        [HttpGet("{id}")]
        public IEnumerable<Evento> Get(int id)
        {
           return _context.Eventos.Where(evento => evento.Id == id);
                
        }


    
    }
}
