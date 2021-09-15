namespace ProEventos.Domain
{
    public class PalestranteEventos
    {
        public int Id{ get; set; }

        public int PalestranteId{ get; set; }

        public int EventoId{ get; set; }

        public Evento Evento{ get; set; }
    }
}