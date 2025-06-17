using Projeto_Event_Plus.Context;
using Projeto_Event_Plus.Interfaces;
using Projeto_Event_Plus.Domains;

namespace Projeto_Event_Plus.Repositories
{
    public class TipoEventoRepository : ITipoEventoRepository
    {           
        private readonly EventPlus_Context _context;

        public TipoEventoRepository(EventPlus_Context context)
        {
            _context = context;
        }

        //---------------------------------------------
        // Atualizar Tipo Evento
        public void Atualizar(Guid id, TipoEvento tipoEventos)
        {
            try
            {
                TipoEvento tipoBuscado = _context.TiposEvento.Find(id)!;

                if (tipoBuscado != null)
                {
                    tipoBuscado.TituloTipoEvento = tipoEventos.TituloTipoEvento;
                }

                _context.TiposEvento.Update(tipoBuscado!);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //---------------------------------------------
        // Buscar por Id.
        public TipoEvento BuscarPorId(Guid id)
        {
            try
            {
                return _context.TiposEvento.Find(id)!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //---------------------------------------------
        // Cadastrar Tipo Evento
        public void Cadastrar(TipoEvento tipoEventos)
        {
            try
            {
                tipoEventos.IdTipoEvento = Guid.NewGuid();

                _context.TiposEvento.Add(tipoEventos);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //---------------------------------------------
        // Deletar Tipo Evento
        public void Deletar(Guid id)
        {
            try
            {
                TipoEvento tipoBuscado = _context.TiposEvento.Find(id)!;

                if (tipoBuscado != null)
                {
                    _context.TiposEvento.Remove(tipoBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //---------------------------------------------
        // Listar Tipo Evento
        public List<TipoEvento> Listar()
        {
            try
            {
                return _context.TiposEvento
                    .OrderBy(tp => tp.TituloTipoEvento)
                    .ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
