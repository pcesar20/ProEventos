using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {

        public IEnumerable<Evento> _evento = new Evento[]{
        new Evento() {
               EventoId = 1,
               Tema = "teste",
               Local = "Goiania",
               Lote = "1 Lote",
               QtdPessoas = 250,
               DataEvento = DateTime.Now.AddDays(2).ToString(),
               ImagemURL = "teste.png"
                      },
                       new Evento() {
               EventoId = 2,
               Tema = "teste 2",
               Local = "Aparecida",
               Lote = "1 Lote",
               QtdPessoas = 250,
               DataEvento = DateTime.Now.AddDays(2).ToString(),
               ImagemURL = "teste.png"
                       }
    };
     
        public EventoController()
        {
            
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
           return _evento;
                
        }

        [HttpGet("{id}")]
        public IEnumerable<Evento> Get(int id)
        {
           return _evento.Where(evento => evento.EventoId == id);
                
        }


    
    }
}
