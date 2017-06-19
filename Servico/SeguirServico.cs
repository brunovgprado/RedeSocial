using Negocio.Repositorio;
using Negocio.Dominio;
using System.Collections.Generic;

namespace Servico
{
    public class SeguirServico
    {
        private ISeguirRepository repositorio { get; set; }

        public SeguirServico(ISeguirRepository repositorio)
        {
            this.repositorio = repositorio;
        }
        
        public void SeguirPerfil(Seguir seguir)
        {
            repositorio.SeguirPerfil(seguir);
        }

        public void DeixarDeSeguir(string UserId, int IdSeguido)
        {
            repositorio.DeixarDeSeguir(UserId, IdSeguido);
        }

        public List<Seguir> ObterSeguidos(string userId)
        {
            return repositorio.ObterSeguidos(userId);
        }

        public bool checarSeguido(string UserId, int SeguidoId)
        {
            return repositorio.ChecaSeguido(UserId, SeguidoId);
        }

        //Metodo que apaga registro de seguidos de um usuario
        public void ExecutaExclusao(string UserId, int PerfilId)
        {
            repositorio.executaExclusao(UserId, PerfilId);
        }

        public void dispose()
        {
            repositorio.dispose();
        }
    }
}
