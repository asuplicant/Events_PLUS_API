using Projeto_Event_Plus.Context;
using Projeto_Event_Plus.Domains;
using Projeto_Event_Plus.Interfaces;

namespace Projeto_Event_Plus.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly EventPlus_Context _context;

        public TipoUsuarioRepository(EventPlus_Context context)
        {
            _context = context;
        }

        //---------------------------------------------
        // Atualizar Tipo Usuário.
        public void Atualizar(Guid id, TipoUsuario tipoUsuario)
        {
            try
            {
                TipoUsuario tipoBuscado = _context.TiposUsuario.Find(id)!;

                if (tipoBuscado != null)
                {
                    tipoBuscado.TituloTipoUsuario = tipoUsuario.TituloTipoUsuario;
                }

                _context.TiposUsuario.Update(tipoBuscado!);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //---------------------------------------------
        // Buscar Por ID
        public TipoUsuario BuscarPorID(Guid id)
        {
            try
            {
                return _context.TiposUsuario.Find(id)!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //---------------------------------------------
        // Cadastrar Tipo Usuário
        public void Cadastrar(TipoUsuario novoTipoUsuario)
        {
            try
            {
                novoTipoUsuario.IdTipoUsuario = Guid.NewGuid();

                _context.TiposUsuario.Add(novoTipoUsuario);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //---------------------------------------------
        // Deletar Tipo Usuário
        public void Deletar(Guid id)
        {
            try
            {
                TipoUsuario tipoBuscado = _context.TiposUsuario.Find(id)!;

                if (tipoBuscado != null)
                {
                    _context.TiposUsuario.Remove(tipoBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //---------------------------------------------
        // Listar Tipo Usuário
        public List<TipoUsuario> Listar()
        {
            try
            {
                return _context.TiposUsuario.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
